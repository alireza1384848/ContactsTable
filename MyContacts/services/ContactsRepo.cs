using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.services
{
    internal class ContactsRepo : IMyContacts
    {

        private string Address = "Data Source=.; Initial Catalog=ContatsDB; Integrated Security = true";

        public bool delete(int contactid)
        {
           string quary = "Delete From contantsTable where ContantsID =@ID";
           SqlConnection conn =new SqlConnection(Address);
            try
            {
                SqlCommand cmd = new SqlCommand(quary,conn);
                cmd.Parameters.AddWithValue("@ID", contactid);
                conn.Open();
                cmd.ExecuteNonQuery();
            return true;
            }
            catch
            { 
            return false;
            }
            finally { conn.Close(); }
            
        }

        public bool Insert(string name, string family, string mobile, string address, int age, string email)
        {
                SqlConnection conn = new SqlConnection(Address);
            try
            {
                string quary = "Insert Into contantsTable (Name,Family,Mobile,Age,Address,Email) values (@Name,@Family,@Mobile,@Age,@Address,@Email)";
                SqlCommand cmd = new SqlCommand(quary, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                cmd.ExecuteNonQuery();  
                return true;
            }
            catch
            {
                return false;
            }
            finally 
            {
                conn.Close();

            }
        }

        public DataTable SelectAll()
        {
            string quary = "Select * From contantsTable";

            SqlConnection connection = new SqlConnection(Address);
            SqlDataAdapter sqlData = new SqlDataAdapter(quary, connection);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;
        }

        public DataTable SelectRow(int contactid)
        {
            string quary = "Select * From contantsTable where ContantsID="+contactid;
            SqlConnection connection = new SqlConnection(Address);
            SqlDataAdapter sqlData = new SqlDataAdapter(quary, connection);
            DataTable dt = new DataTable();
            sqlData.Fill(dt);
            return dt;

        }

        public bool update(int contactid, string name, string family, string mobile, string address, int age, string email)
        {
            SqlConnection conn = new SqlConnection(Address);
            try
            {
                string quary = "update contantsTable set Name=@Name,Family=@Family,Mobile=@Mobile,Age=@Age,Address=@Address,Email=@Email where ContantsID=@ID";
                SqlCommand cmd = new SqlCommand(quary, conn);
                cmd.Parameters.AddWithValue("@ID", contactid);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Family", family);
                cmd.Parameters.AddWithValue("@Mobile", mobile);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conn.Close();

            }
        }
    }
}
