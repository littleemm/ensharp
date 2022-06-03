package controller;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.Statement;
import java.sql.ResultSet;
import java.sql.SQLException;
import model.MemberDTO;
import utility.Constant;

public class DatabaseConnection {
	private Connection connection;
	private Statement statement;
	private ResultSet result;
	private MemberDTO memberDTO;
	
	public DatabaseConnection(MemberDTO memberDTO) {
		this.memberDTO = memberDTO;
		
		try {
			String url = "jdbc:mysql://localhost/younglim_signup?serverTimezone=Asia/Seoul";
			String id = "root";
			String password = "0000";
			Class.forName("com.mysql.cj.jdbc.Driver");
			connection = DriverManager.getConnection(url,id,password);
			statement = connection.createStatement();
		}catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public void succeedSignUp(MemberDTO memberDTO) {
		String query = String.format(Constant.INSERT_QUERY, memberDTO.getName(), memberDTO.getId(), 
				memberDTO.getPassword(), memberDTO.getBirth(), memberDTO.getEmail(), memberDTO.getPhoneNumber(), 
				memberDTO.getZipCode(), memberDTO.getAddress(), memberDTO.getDetailAddress());
		System.out.println(query);
		
		try {
			statement.executeUpdate(query);
		} catch (SQLException e) {
			e.printStackTrace();
		}
	
	}
	
	public int login(String userID, String userPassword) {
		String SQL = "SELECT userPassword FROM USER WHERE userID = ?";
		try {
			statement = connection.prepareStatement(SQL);
			//statement.setString(1, userID);
			//result = statement.executeQuery();
			if(result.next()) {
				if(result.getString(1).contentEquals(userPassword)) {
					return 1;
				}
				else
					return 0;
			}
			return -1;
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		return -2;
	}
	
	
}
