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
    public class Detail_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnection"].ToString();
        public List<Detail> Gets()
        {
            List<Detail> details = new List<Detail>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Detail";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    details.Add(new Detail
                    {
                        id = Convert.ToInt16(dr[0]),
                        order_id = Convert.ToInt16(dr[0]),
                        product_id = Convert.ToInt16(dr[1]),
                        quantity = Convert.ToInt16(dr[2]),
                    });
                }
                return details;
            }
        }
        public List<Detail> getsByID(int order_id)
        {
            List<Detail> details = new List<Detail>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from detail where order_id = " + order_id;
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    details.Add(new Detail
                    {
                        order_id = Convert.ToInt16(dr[0]),
                        product_id = Convert.ToInt16(dr[1]),
                        quantity = Convert.ToInt16(dr[2]),
                    });
                }
                return details;
            }
        }

        public List<Detail> getByID(int order_id, int product_id)
        {
            List<Detail> details = new List<Detail>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from detail where order_id = " + order_id + " AND product_id = "+ product_id;
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    details.Add(new Detail
                    {
                        order_id = Convert.ToInt16(dr[0]),
                        product_id = Convert.ToInt16(dr[1]),
                        quantity = Convert.ToInt16(dr[2]),
                    });
                }
                return details;
            }
        }

        public void Insert(Detail ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Insert into detail(order_id, product_id, [quantity], price) values(" + ob.order_id + ", " + ob.product_id + "," + ob.quantity + ", "  + ob.price +" )";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(Detail ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Update order set quantity = " + ob.quantity + " where order_id = " + ob.order_id + " AND product_id = " + ob.product_id;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
        public void delete(Detail ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Delete from detail where order_id = " + ob.order_id + " AND product_id = " + ob.product_id;
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}