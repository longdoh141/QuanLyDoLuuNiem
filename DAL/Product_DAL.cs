using QuanLyDoLuuNiem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace QuanLyDoLuuNiem.DAL
{
    public class Product_DAL
    {
        string conString = ConfigurationManager.ConnectionStrings["adoConnection"].ToString();
        public List<product> getProducts()
        {
            List<product> products = new List<product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from product";
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    products.Add(new product
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2],
                        image = (string)dr[3],
                        price = Convert.ToDouble(dr[4]),
                        category_id = Convert.ToInt16(dr[5]),
                    }); 
                }
                return products;
            }
        }
        public List<product> getProductByID(int id)
        {
            List<product> products = new List<product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from product where id = " + id;
                connection.Open();
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                connection.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    products.Add(new product
                    {
                        id = Convert.ToInt16(dr[0]),
                        name = (string)dr[1],
                        detail = (string)dr[2],
                        image = (string)dr[3],
                        price = Convert.ToDouble(dr[4]),
                        category_id = Convert.ToInt16(dr[5]),
                    });
                }
                return products;
            }
        }

        public void Insert(product ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Insert into product(name,detail,image,price,category_id) values('" + ob.name + "', '" + ob.detail + "','" + ob.image + "'," + ob.price + "," + ob.category_id + " )";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void Update(product ob)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {
                string sql = "Update product set name = '" + ob.name + "',detail = '" + ob.detail + "', image = '" + ob.image + "', price = " + ob.price + ", category_id = " + ob.category_id + " where id = " + ob.id;
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
                string sql = "Delete from product where id = '" + id + "'";
                connection.Open();
                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

    }
}