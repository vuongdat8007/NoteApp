using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DAL
{
    public class DataConnection
    {
        private string conStr = "";

        public DataConnection()
        {
            conStr = @"Data Source=.\SQLEXPRESS02;Initial Catalog=Schedule_app;Integrated Security=True";
        }

        public SqlConnection GetConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
