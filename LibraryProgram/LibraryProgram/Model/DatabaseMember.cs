using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Common;
using MySql.Data.MySqlClient;

namespace LibraryProgram
{
    class DatabaseMember
    {
        private MySqlConnection connection;
        
        public DatabaseMember()
        {
            connection = new MySqlConnection(Constant.STRING_CONNECTION);
        }
       
        public bool SelectMember(string query, string id, string password) // 불러오기
        {
            connection.Open();
            
            List<string>[] element = new List<string>[2];

            for (int index = 0; index < element.Length; index++)
            {
                element[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element[0].Add(dataReader["id"].ToString());
                element[1].Add(dataReader["password"].ToString());
            }
            
            for (int i = 0; i < element[0].Count; i++)
            {
                if (element[0][i].Equals(id))
                {
                    if (element[0][i].Equals(id) && element[1][i].Equals(password))
                {
                        dataReader.Close();
                        connection.Close();
                        return true;
                    }
                }
            }

            dataReader.Close();
            connection.Close();

            return false;
        }

        public void InsertMember(MemberDTO memberDTO) // 등록
        {
            memberDTO.Address = ReplaceAddressBeforeInsert(memberDTO.Address);
            string query = string.Format(Constant.INSERT_QUERY_MEMBER, memberDTO.Id, memberDTO.Password, memberDTO.Name, memberDTO.Age, memberDTO.PhoneNumber, memberDTO.Address);

            connection.Open();
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void UpdateMember(string address, string phoneNumber, string id) // 주소, 번호만 변경
        {
            string query = "";

            if (phoneNumber.Length > 0 && address.Length > 0)
            {
                query = string.Format(Constant.UPDATE_QUERY_MEMBER_NUMBER_ADDRESS, phoneNumber, address, id);
            }
            if (phoneNumber.Length > 0 && address.Length == 0)
            {
                query = string.Format(Constant.UPDATE_QUERY_MEMBER_NUMBER, phoneNumber, id);
            }
            if (phoneNumber.Length == 0 && address.Length > 0)
            {
                query = string.Format(Constant.UPDATE_QUERY_MEMBER_ADDRESS, address, id);
            }

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void DeleteMember(string id) // 회원 삭제
        {
            string query = string.Format(Constant.DELETE_QUERY_MEMBER, id);

            connection.Open();

            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            dataReader.Close();
            connection.Close();
        }

        public void SelectMemberOfList(string id) // 회원 검색을 위한 데이터 추출
        {
            connection.Open();

            List<string>[] memberSelection = new List<string>[6];

            for (int index = 0; index < memberSelection.Length; index++)
            {
                memberSelection[index] = new List<string>();
            }

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                memberSelection[0].Add(dataReader["id"].ToString());
                memberSelection[1].Add(dataReader["name"].ToString());
                memberSelection[2].Add(dataReader["age"].ToString());
                memberSelection[3].Add(dataReader["address"].ToString());
                memberSelection[4].Add(dataReader["phoneNumber"].ToString());
                memberSelection[5].Add(dataReader["bookCount"].ToString());
            }

            for (int i = 0; i < memberSelection[0].Count; i++)
            {
                if (memberSelection[0][i].Contains(id))
                {
                    ShowData(memberSelection, i);
                }
            }
            
            dataReader.Close();
            connection.Close();
        }

        public void SelectMemberList()
        {
            connection.Open();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Console.WriteLine("      ID      :  " + dataReader["id"].ToString());
                Console.WriteLine("     NAME     :  " + dataReader["name"].ToString());
                Console.WriteLine("      AGE     :  " + dataReader["age"].ToString() + "세");
                Console.WriteLine("   ADDRESS    :  " + dataReader["address"].ToString());
                Console.WriteLine(" PHONE NUMBER :  " + dataReader["phoneNumber"].ToString());
                Console.WriteLine("  BOOK COUNT  :  " + dataReader["bookCount"].ToString() + "권");
                Console.WriteLine("==============================================================================");
            }

            dataReader.Close();
            connection.Close();
        }

        public bool IsMemberId(string memberId) // 회원 아이디 존재 확인
        {
            connection.Open();

            int dataCount = 0;
            
            string query = string.Format(Constant.SELECT_QUERY_MEMBER_WHERE_ID, memberId);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                ++dataCount;
            }

            if (dataCount > 0)
            {
                dataReader.Close();
                connection.Close();
                return true;
            }

            dataReader.Close();
            connection.Close();
            return false;
        }

        public bool IsSearchedMemberId(string memberId) // 회원 아이디 존재 여부 (contain)
        {
            connection.Open();

            List<string> element = new List<string>();

            MySqlCommand command = new MySqlCommand(Constant.SELECT_QUERY_MEMBER, connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                element.Add(dataReader["id"].ToString());
            }

            for (int i = 0; i < element.Count; i++)
            {
                if (element[i].Contains(memberId))
                {
                    dataReader.Close();
                    connection.Close();
                    return true;
                }
            }

            dataReader.Close();
            connection.Close();
            return false;
        }

        private void ShowData (List<string>[] element, int index)
        {
            Console.WriteLine("      ID      :  " + element[0][index]);
            Console.WriteLine("     NAME     :  " + element[1][index]);
            Console.WriteLine("      AGE     :  " + element[2][index] + "세");
            Console.WriteLine("   ADDRESS    :  " + element[3][index]);
            Console.WriteLine(" PHONE NUMBER :  " + element[4][index]);
            Console.WriteLine("  BOOK COUNT  :  " + element[5][index] + "권");
            Console.WriteLine("==============================================================================");
        }

        private string ReplaceAddressBeforeInsert(string address)
        {
            if (address.Substring(0, 2).Equals("서울"))
            {
                address.Replace("서울시", "서울특별시");
            }
            else if (address.Substring(0,2).Equals("세종"))
            {
                address.Replace("세종시", "세종특별자치시");
            }
            else if (address.Substring(0, 2).Equals("제주"))
            {
                address.Replace("제주도", "제주특별자치도");
            }
            else if (CheckMetropolitanName(address))
            {
                for (int i = 0; i < Constant.NAME.Length; i++)
                {
                    address.Replace(Constant.NAME[i] + "시", Constant.NAME[i] + "광역시");
                }
            }

            return address;
        }

        private bool CheckMetropolitanName(string address)
        {
            for (int i=0;i<Constant.NAME.Length;i++)
            {
                if (address.Substring(0,2).Equals(Constant.NAME[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
