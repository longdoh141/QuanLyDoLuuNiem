using QuanLyDoLuuNiem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.DAL
{
    public class Category_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnection"].ToString();
        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from category";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    categories.Add(new Category
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2],
                    });
                }
                return categories;
            }
        }
        public List<Category> getCategoryByID(int id)
        {
            List<Category> categories = new List<Category>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from category where id = " + id;
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    categories.Add(new Category
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2]
                    });
                }
                return categories;
            }
        }

        public void Insert(Category ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Insert into category(name,description) values('" + ob.name + "', '" + ob.detail + "' )";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Category ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Update category set name = '" + ob.name + "',description = '" + ob.detail + "'  where id = " + ob.id;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Delete from category where id = '" + id + "'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}