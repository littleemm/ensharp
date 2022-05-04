using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryProgram
{
    class LogVO
    {
        private string id;
        private string date;
        private string time;
        private string user;
        private string history;

        public LogVO(string id, string user, string history)
        {
            this.id = id;
            this.user = user;
            this.history = history;
        }

        public LogVO(string date, string time, string user, string history)
        {
            this.date = date;
            this.time = time;
            this.user = user;
            this.history = history;
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string History
        {
            get { return history; }
            set { history = value; }
        }
    }
}
