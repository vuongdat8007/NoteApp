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
    public class NotesDAL
    {
        private DataConnection dc;
        private SqlDataAdapter da;
        private SqlCommand cmd;

        public NotesDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllNotes()
        {
            //B1: tạo câu lệnh sql để lấy toàn bộ tài khoản
            string sql = "select * from Notes";
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

        internal bool DeleteNote(NoteDTO note)
        {
            string sql = "delete Notes where Id=@Id";
            SqlConnection con = dc.GetConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = note.ID;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        //ham them note vào SQL Database
        // WIP...
        public bool AddNote(NoteDTO newNote)
        {
            string sql = "insert into Notes values(@Title,@Content,@Reminder,@Username)";
            SqlConnection con = dc.GetConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = newNote.Title;
                cmd.Parameters.Add("@Content", SqlDbType.NVarChar).Value = newNote.Content;
                cmd.Parameters.Add("@Reminder", SqlDbType.NChar).Value = newNote.Reminder;
                cmd.Parameters.Add("@Username", SqlDbType.NVarChar).Value = newNote.Username;
                //cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = newNote.Password;

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }


        // Search note: WIP...
        public DataTable SearchNote(string searchString)
        {
            string sql = "select * from Notes where Title LIKE %N'" + searchString + "'% OR Content LIKE %N'" + searchString + "'%";

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
