using NoteApp.Services.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services.DAL
{
    public class AccountsDAL
    {
        private DataConnection dc;
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public AccountsDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllAccounts()
        {
            //B1: tạo câu lệnh sql để lấy toàn bộ tài khoản
            string sql = "select * from Accounts";
            //b2: tạo một kết nối đên sql
            SqlConnection con = dc.GetConnect();
            //b3: khởi tạo đối tượng của lớp sqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //b4: mở kết nối
            con.Open();
            //b5: đỗ dữ liệu từ sqlDataAdapter vào datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //b6: đóng kết nối
            con.Close();
            return dt;
        }

        //ham them tài khoản
        public bool AddAccount(AccountDTO acc)
        {
            string sql = "insert into Accounts values(@Username,@Password)";
            SqlConnection con = dc.GetConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = acc.Username;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = acc.Password;
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        

        public DataTable SearchAccount(string acc, string password)
        {
            string sql = "select * from Accounts where Username = N'" + acc + "' AND Password = N'" + password + "'";

            SqlConnection con = dc.GetConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
    }
}
