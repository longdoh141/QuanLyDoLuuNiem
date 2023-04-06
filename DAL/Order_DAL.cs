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
    public class Order_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnection"].ToString();
        public List<Order> Gets()
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from [Order]";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    orders.Add(new Order
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2],
                        dateCreated = (DateTime)dr[3],
                        dateUpdated = (DateTime)dr[4],
                    });
                }
                return orders;
            }
        }
        public List<Order> getByID(int id)
        {
            List<Order> orders = new List<Order>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from [Order] where id = " + id;
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    orders.Add(new Order
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2],
                        dateCreated = (DateTime)dr[3],
                        dateUpdated = (DateTime)dr[4],
                    });
                }
                return orders;
            }
        }

        public int GetID(Order order)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select id from [Order] where Name = '" + order.name + "'";
                connection.Open();
                Int32 NewOrderId = (Int32)cmd.ExecuteScalar();
                return NewOrderId;
            }
        }

        public void Insert(Order ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Insert into [Order](name,description,dateCreated, dateUpdated) values('" + ob.name + "', '" + ob.detail + "','" + DateTime.Now + "','"+ DateTime.Now + "' )";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void Update(Order ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Update [Order] set name = '" + ob.name + "',detail = '" + ob.detail + "', dateUpdated = " + DateTime.Now +" where id = " + ob.id;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void CheckOut(Order ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Update [Order] set status = 1, dateUpdated = " + DateTime.Now + " where id = " + ob.id;
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
                string sql = "Delete from [Order] where id = '" + id + "'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}