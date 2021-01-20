using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1.Models.Crud
{
    public class CrudCustomer
    {

        DBConnection db;
        public CrudCustomer()
        {
            db = new DBConnection();
        }

        // viet cac phuong thuc

        public List<Customer> getCustomers(string Id)
        {
            string sql;
            if (string.IsNullOrEmpty(Id))
            {
                sql = "SELECT * FROM customer";
            }
            else
            {
                sql = "SELECT * from customer where Id = " + Id;
            }
            List<Customer> strList = new List<Customer>();
            SqlConnection con = db.getConnection();
            SqlDataAdapter cmd = new SqlDataAdapter(sql, con);

            DataTable dt = new DataTable();

            // mo ket noi:
            con.Open();
            cmd.Fill(dt);

            // dong ket noi:
            cmd.Dispose();
            con.Close();

            Customer customer;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                customer = new Customer();
                customer.Id = Convert.ToInt32(dt.Rows[i]["Id"].ToString());
                customer.Name = dt.Rows[i]["Name"].ToString();
                customer.Age = Convert.ToInt32(dt.Rows[i]["Age"].ToString());
                customer.Address = dt.Rows[i]["Address"].ToString();
                customer.Email = dt.Rows[i]["Email"].ToString();

                strList.Add(customer);
            }
            return strList;
        }

        public void Create(Customer customer)
        {
            string sql = "INSERT INTO customer(Name, Age, Address, Email) VALUES(N'"+customer.Name+"',N'"+customer.Age+"','"+customer.Address+"','"+customer.Email+"')";
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            //mo ket noi va thuc thi
            con.Open();
            cmd.ExecuteNonQuery();
            //ngat ket noi
            cmd.Dispose();
            con.Close();  
        }

        public void Edit(Customer customer)
        {
            string sql = "UPDATE customer SET Name = '"+customer.Name+"', Age = '"+customer.Age+"',Address = '"+customer.Address+"',Email ='"+customer.Email+"' WHERE Id = "+customer.Id;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            con.Close();
        }
        public void Delete(string Id)
        {
            string sql = "DELETE FROM customer WHERE Id ="+ Id;
            SqlConnection con = db.getConnection();
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
        }





        // *******************
        //public static List<Customer> customers = new List<Customer>();

        //static CrudCustomer()
        //{
        //    customers.Add(new Customer(1, "1", 1, "1", "1"));
        //    customers.Add(new Customer(2, "2", 2, "2", "2"));
        //    customers.Add(new Customer(3, "3", 3, "3", "3"));
        //    customers.Add(new Customer(4, "4", 4, "4", "4"));
        //}
        //public List<Customer> FindAll()
        //{
        //    return customers;
        //}
        //public void Create(Customer c)
        //{
        //    customers.Add(c);
        //}
        //public Customer FindById(int id)
        //{
        //    foreach(Customer c in customers)
        //    {
        //        if (c.Id == id)
        //        {
        //            return c;
        //        }
        //    }
        //    return null;
        //}
        //public bool Delete(int id)
        //{
        //    int customerLength = customers.Count;
        //    if (customerLength == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < customerLength; i++)
        //        {
        //            if (customers[i].Id == id)
        //            {
        //                customers.Remove(customers[i]);
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //public bool Update(Customer c)
        //{
        //    int customerLength = customers.Count;
        //    if (customerLength == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < customerLength; i++)
        //        {
        //            if (customers[i].Id == c.Id)
        //            {
        //                customers.Remove(customers[i]);
        //                customers.Insert(i, c);
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}
    }
}