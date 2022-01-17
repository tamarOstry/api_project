using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace veichle
{
    class DataAccsess
    {



        string connectionString = @"Data Source=SRV2\PUPILS;Initial Catalog=vaichle;Integrated Security=True";

        public void addProduct(string name, int price, string desc, int category_id, string image)
        {
            string query = "insert into product values(@name,@price,@desc,@category_id,@image)";
            using (SqlConnection sqlconection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlconection);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                cmd.Parameters.Add("@price", SqlDbType.Int, 50).Value = price;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = desc;
                cmd.Parameters.Add("@category_id", SqlDbType.VarChar, 50).Value = category_id;
                cmd.Parameters.Add("@image", SqlDbType.VarChar, 50).Value = image;
                sqlconection.Open();
                int num = cmd.ExecuteNonQuery();
                if (num == 1)
                    Console.WriteLine("the product insert in succsessfuly!!");
                else
                    Console.WriteLine("one or mor from the details worng!");
            }
        }


        public void selectProduct(string name)
        {
            string query = "select *from product where prod_name=@name";
            using (SqlConnection sqlconection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, sqlconection);
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = name;
                sqlconection.Open();
                SqlDataReader sqlDataReader = cmd.ExecuteReader();
                Console.WriteLine("this is the details of this product");
                    while (sqlDataReader.Read())
                    {
                        Console.WriteLine("id= "+sqlDataReader.GetInt32(0));
                        Console.WriteLine("name= " + sqlDataReader.GetString(1));
                        Console.WriteLine("price= " + sqlDataReader.GetInt32(2));
                        Console.WriteLine("description= " + sqlDataReader.GetString(3));
                        Console.WriteLine("category_id= " + sqlDataReader.GetInt32(4));
                        Console.WriteLine("image= " + sqlDataReader.GetString(5));
                }
                }
            }

        }

    }

