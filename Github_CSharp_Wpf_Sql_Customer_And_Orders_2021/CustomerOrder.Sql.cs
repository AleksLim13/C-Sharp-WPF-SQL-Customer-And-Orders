using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WpfSsmsPizza
{
    class CustomerOrderSql
    {
        private string cString;

        public CustomerOrderSql(string cString)
        {
            this.cString = cString;
        }//End C:*

        public IList<CustomerOrder> GetList()
        {

            List<CustomerOrder> codmList = new List<CustomerOrder>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand("", conn))
                {
                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                CustomerOrder codm2 = new CustomerOrder()
                                {

                                };


                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*

        public IList<CustomerOrder> GetOrderList()
        {

            List<CustomerOrder> codmList = new List<CustomerOrder>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();
                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail
                using (SqlCommand commannd = new SqlCommand(@"SELECT * from dbo.CustomerOrder", conn))
                {
                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                CustomerOrder codm2 = new CustomerOrder()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    Product = reader["Product"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Size = reader["Size"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"])


                                };


                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*


        public IList<Customer> GetUserList()
        {

            List<Customer> codmList = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"SELECT * from dbo.Customer", conn))
                {
                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                Customer codm2 = new Customer()
                                {
                                    Id = Convert.ToInt32(reader["CustomerId"]),
                                    Name = reader["CustomerName"].ToString(),
                                    UserName = reader["CustomerUserName"].ToString(),
                                    Email = reader["CustomerEmail"].ToString(),
                                    Password = reader["CustomerPassword"].ToString(),


                                };


                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*

        public IList<CustomerOrder> GetOrderById(int orderId)
        {

            List<CustomerOrder> codmList = new List<CustomerOrder>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"SELECT * from dbo.CustomerOrder where CustomerOrderId = @orderId", conn))
                {
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                CustomerOrder codm2 = new CustomerOrder()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    Product = reader["Product"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Size = reader["Size"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"]),

                                };


                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*

        public void UpdatePrice(int orderId, double price)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();
                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail

                using (SqlCommand commannd = new SqlCommand(@"update dbo.CustomerOrderDetail set Price = @price where CustomerOrderId = @orderId", conn))
                {

                    commannd.Parameters.Add("@price", SqlDbType.VarChar).Value = price;
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void UpdateOrderCustomerId(int orderId, int customerId)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"update dbo.CustomerOrder set CustomerId = @customerId where OrderId = @orderId", conn))
                {

                    commannd.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*
        public void UpdateProduct(int orderId, string product)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();


                using (SqlCommand commannd = new SqlCommand(@"update dbo.CustomerOrder set Product = @product where CustomerOrderId = @orderId", conn))
                {

                    commannd.Parameters.Add("@product", SqlDbType.VarChar).Value = product;
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void UpdateQuantity(int orderId, int quantity)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail

                using (SqlCommand commannd = new SqlCommand(@"update dbo.CustomerOrder set Quantity = @quantity where CustomerOrderId = @orderId", conn))
                {

                    commannd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = quantity;
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void UpdateSize(int orderId, string size)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"update dbo.CustomerOrder set Size = @size where CustomerOrderId = @orderId", conn))
                {

                    commannd.Parameters.Add("@size", SqlDbType.VarChar).Value = size;
                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void DeleteOrder(int orderId)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"delete from dbo.CustomerOrder where CustomerOrderId = @orderId", conn))
                {


                    commannd.Parameters.Add("@orderId", SqlDbType.VarChar).Value = orderId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*
        }//End M:*


        public IList<Customer> GetUserById(int customerId)
        {

            List<Customer> codmList = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail
                using (SqlCommand commannd = new SqlCommand(@"SELECT * from dbo.Customer where CustomerId = @customerId", conn))
                {
                    commannd.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;

                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                Customer codm2 = new Customer()
                                {
                                    Id = Convert.ToInt32(reader["CustomerId"]),
                                    Name = reader["CustomerName"].ToString(),
                                    UserName = reader["CustomerUserName"].ToString(),
                                    Email = reader["CustomerEmail"].ToString(),
                                    Password = reader["CustomerPassword"].ToString(),

                                };

                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*

        public void UpdateName(int targetId, string newName)
        {


            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();
                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail

                using (SqlCommand commannd = new SqlCommand(@"update dbo.Customer set CustomerName = @newName where CustomerId = @targetId", conn))
                {

                    commannd.Parameters.Add("@newName", SqlDbType.VarChar).Value = newName;
                    commannd.Parameters.Add("@targetId", SqlDbType.VarChar).Value = targetId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void UpdateEmail(int targetId, string newEmail)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"update dbo.Customer set CustomerEmail = @newEmail where CustomerId = @targetId", conn))
                {

                    commannd.Parameters.Add("@newEmail", SqlDbType.VarChar).Value = newEmail;

                    commannd.Parameters.Add("@targetId", SqlDbType.VarChar).Value = targetId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*
        }//End M:*
        public void UpdatePassword(int targetId, string newPassword)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"update dbo.Customer set Password = @newPassword where CustomerId = @targetId", conn))
                {

                    commannd.Parameters.Add("@newPassword", SqlDbType.VarChar).Value = newPassword;

                    commannd.Parameters.Add("@targetId", SqlDbType.VarChar).Value = targetId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public void UpdateUserName(int targetId, string newUN)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();
                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail

                using (SqlCommand commannd = new SqlCommand(@"update dbo.Customer set CustomerUserName = @newUN where CustomerOrderId = @targetId", conn))
                {

                    commannd.Parameters.Add("@newUN", SqlDbType.VarChar).Value = newUN;
                    commannd.Parameters.Add("@targetId", SqlDbType.VarChar).Value = targetId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*
        public void DeleteUser(int customerId)
        {

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"delete from dbo.Customer where CustomerId = @customerId", conn))
                {

                    commannd.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*

        }//End M:*

        public static string ReadOrderById(int targetId)
        {
            string result = "";

            CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

            IList<CustomerOrder> codmList = codc.GetOrderById(targetId);

            if (codmList.Any())
            {

                foreach (CustomerOrder locCodm in codmList)
                {
                    result +=
                                      locCodm.CustomerOrderId.ToString() + " " +
                                      locCodm.CustomerId.ToString() + " " +
                                      locCodm.Product.ToString() + " " +
                                      locCodm.Quantity.ToString() + " " +
                                      locCodm.Price.ToString() + ",\n\n";

                }//End FE:*

                return result;

            }//End I:*
            return null;
        }//End M:*

        public static string ReadCustomerById(int targetId)
        {


            string result = "";

            CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

            IList<Customer> codmList = codc.GetUserById(targetId);

            if (codmList.Any())
            {
                Console.WriteLine("CustomerId, CustomerName, CustomerUserName, CustomerEmail, CustomerPassword FROM Customer");

                foreach (Customer locCodm in codmList)
                {
                    result +=
                                      locCodm.Id.ToString() + " " +
                                      locCodm.Name.ToString() + " " +
                                      locCodm.UserName.ToString() + " " +
                                      locCodm.Email.ToString() + " " +
                                      locCodm.Password.ToString() + ",\n\n";

                }//End FE:*
                return result;

            }//End I:*
            return null;

        }//End M:*

        public string PrintAllOrders()
        {
            string result = "";

            CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

            IList<CustomerOrder> codmList = codc.GetOrderList();

            if (codmList.Any())
            {
                Console.WriteLine("CustomerOrderId, CustomerId, Product, Quantity, [Size], Price FROM CustomerOrder");

                foreach (CustomerOrder locCodm in codmList)
                {
                    result +=
                                      locCodm.CustomerOrderId.ToString() + " " +
                                      locCodm.CustomerId.ToString() + " " +
                                      locCodm.Product.ToString() + " " +
                                      locCodm.Quantity.ToString() + " " +
                                      locCodm.Size.ToString() + " " +
                                      locCodm.Price.ToString() + ",\n\n";

                }//End FE:*
                return result;
            }//End I:*
            return null;
        }//End M:*

        public string PrintAllUsers()
        {
            string result = "";

            CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

            IList<Customer> codmList = codc.GetUserList();

            if (codmList.Any())
            {
                Console.WriteLine("CustomerOrderId, CustomerId, Product, Quantity, [Size], Price FROM CustomerOrder");

                foreach (Customer locCodm in codmList)
                {
                    result +=
                                      locCodm.Id.ToString() + " " +
                                      locCodm.Name.ToString() + " " +
                                      locCodm.UserName.ToString() + " " +
                                      locCodm.Email.ToString() + " " +
                                      locCodm.Password.ToString() + ",\n\n";

                }//End FE:*
                return result;
            }//End I:*


            return null;
        }//End M:*

        public void InsertIntoCustomerOrder(int customerId, string product, int quantity, string size, double price)
        {
            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"insert into dbo.CustomerOrder (CustomerId, Product, Quantity, Size, Price) values (@customerId, @product, @quantity, @size, @price)", conn))
                {

                 
                    commannd.Parameters.Add("@customerId", SqlDbType.VarChar).Value = customerId;
                    commannd.Parameters.Add("@product", SqlDbType.VarChar).Value = product;
                    commannd.Parameters.Add("@quantity", SqlDbType.VarChar).Value = quantity;
                    commannd.Parameters.Add("@size", SqlDbType.VarChar).Value = size;
                    commannd.Parameters.Add("@price", SqlDbType.VarChar).Value = price;

                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*
        }//End M:*

        public void InsertIntoCustomer(string name, string userName, string email, string password)
        {
            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"insert into dbo.Customer (CustomerName, CustomerUserName, CustomerEmail, CustomerPassword) values (@name, @userName, @email, @password)", conn))
                {

                   
                    commannd.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                    commannd.Parameters.Add("@userName", SqlDbType.VarChar).Value = userName;
                    commannd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
                    commannd.Parameters.Add("@password", SqlDbType.VarChar).Value = password;


                    SqlDataReader reader = commannd.ExecuteReader();

                }//End U:*

            }//End U:*
        }//End M:*

        public IList<Customer> GetLastCustomer()
        {

            List<Customer> codmList = new List<Customer>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                //SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail
                using (SqlCommand commannd = new SqlCommand(@"SELECT TOP 1 * FROM dbo.Customer ORDER BY CustomerId DESC", conn))
                {


                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                Customer codm2 = new Customer()
                                {
                                    Id = Convert.ToInt32(reader["CustomerId"]),
                                    Name = reader["CustomerName"].ToString(),
                                    UserName = reader["CustomerUserName"].ToString(),
                                    Email = reader["CustomerEmail"].ToString(),
                                    Password = reader["CustomerPassword"].ToString(),

                                };

                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*

            return codmList;

        }//End M:*

        public IList<CustomerOrder> GetLastOrder()
        {
            List<CustomerOrder> codmList = new List<CustomerOrder>();

            using (SqlConnection conn = new SqlConnection(cString))
            {

                conn.Open();

                using (SqlCommand commannd = new SqlCommand(@"SELECT TOP 1 * FROM dbo.CustomerOrder ORDER BY CustomerOrderId DESC", conn))
                {


                    using (SqlDataReader reader = commannd.ExecuteReader())
                    {

                        if (reader.HasRows)
                        {

                            while (reader.Read())
                            {

                                CustomerOrder codm2 = new CustomerOrder()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    Product = reader["Product"].ToString(),
                                    Quantity = Convert.ToInt32(reader["Quantity"]),
                                    Size = reader["Size"].ToString(),
                                    Price = Convert.ToDouble(reader["Price"]),

                                };


                                codmList.Add(codm2);

                            }//End W:*

                        }//End I:*

                    }//End U:*

                }//End U:*

            }//End U:*
            return codmList;
        }//End M:*
    }//End CL:*
}//End NS:*
