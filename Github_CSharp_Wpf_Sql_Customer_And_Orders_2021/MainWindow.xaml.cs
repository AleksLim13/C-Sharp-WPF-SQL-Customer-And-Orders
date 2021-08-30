using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSsmsPizza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }//End C:*

        public static void ReadLastOrderRun()
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                IList<CustomerOrder> codmList = codc.GetLastOrder();

                if (codmList.Any())
                {
                    Console.WriteLine("CustomerOrderId, CustomerId, Product, Quantity, Price FROM CustomerOrder");

                    foreach (CustomerOrder locCodm in codmList)
                    {
                        Console.WriteLine(
                                          locCodm.CustomerOrderId + " " +
                                          locCodm.CustomerId + " " +
                                          locCodm.Product + " " +
                                          locCodm.Quantity + " " +
                                          locCodm.Price
                                          );
                    }//End FE:*

                }//End I:*

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

      

        public void DeleteCustomerRun(int targetId)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.DeleteUser(targetId);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void DeleteOrderRun(int targetId)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.DeleteOrder(targetId);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*


        public void InsertCustomerRun(string name, string userName, string email, string password)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.InsertIntoCustomer(name, userName, email, password);

               

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void InsertOrderRun(int customerId, string product, int quantity, string size, double price)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.InsertIntoCustomerOrder(customerId, product, quantity, size, price);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateCustomerNameRun(int customerId, string newName)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateName(customerId, newName);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateCustomerUserNameRun(int customerId, string newName)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateUserName(customerId, newName);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateCustomerEmailRun(int customerId, string email)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateEmail(customerId, email);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateCustomerPasswordRun(int customerId, string password)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdatePassword(customerId, password);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*


        public void RegisterBtn_Click(Object sender, RoutedEventArgs e)
        {
            try {

                if (NameBox.Text != "" && UserNameBox.Text != "" && EmailBox.Text != "" && PasswordBox.Text != "")
                {

                  

                    InsertCustomerRun(NameBox.Text, UserNameBox.Text, EmailBox.Text, PasswordBox.Text);
                    
                 
                    NameBox.Text = "";
                    UserNameBox.Text = "";
                    EmailBox.Text = "";
                    PasswordBox.Text = "";

                    OutputRegister.Text = "Success, the new customer was inserted to the backend.";

                }//End I:*

            }//End TRY:*



            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*



        public void DeleteCustomerBtn_Click(Object sender, RoutedEventArgs e)
        {
            try {
                if (DeleteIdBox.Text != "") {
                    int targetId = Convert.ToInt32(DeleteIdBox.Text);
                    DeleteCustomerRun(targetId);
                    DeleteIdBox.Text = "";  
                    OutputRegister.Text = "Awesome, that customer has been scrapped.";
                }//End 
            }//End TRY:*
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateCustomerNameBtn_Click(Object sender, RoutedEventArgs e) {
            try
            {
                if (UpdateNameIdBox.Text != "" && UpdateNameBox.Text != "")
                {
                    int nameId = Convert.ToInt32(UpdateNameIdBox.Text);
                    UpdateCustomerNameRun(nameId, UpdateNameBox.Text);
                    UpdateCustomerOutput.Text = "Update of customer name was successful";
                    UpdateNameIdBox.Text = "";
                    UpdateNameBox.Text = "";
                }//End I:* 
            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateCustomerUserNameBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateUserNameIdBox.Text != "" && UpdateUserNameBox.Text != "")
                {
                    int nameId = Convert.ToInt32(UpdateUserNameIdBox.Text);
                    UpdateCustomerUserNameRun(nameId, UpdateUserNameBox.Text);
                    UpdateCustomerOutput.Text = "Update of customer user name was successful";
                    UpdateUserNameIdBox.Text = "";
                    UpdateUserNameBox.Text = "";
                }//End I:* 
            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateCustomerEmailBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateEmailIdBox.Text != "" && UpdateEmailBox.Text != "")
                {
                    int nameId = Convert.ToInt32(UpdateEmailIdBox.Text);
                    UpdateCustomerEmailRun(nameId, UpdateEmailBox.Text);
                    UpdateCustomerOutput.Text = "Update of customer email was successful";
                    UpdateEmailIdBox.Text = "";
                    UpdateEmailBox.Text = "";
                        }//End I:*
            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateCustomerPasswordBtn_Click(Object sender, RoutedEventArgs e)
        {
            try {
                if (UpdateNameIdBox.Text != "" && UpdateNameBox.Text != "") {
                    int nameId = Convert.ToInt32(UpdateNameIdBox.Text);
                    UpdateCustomerPasswordRun(nameId, UpdateNameBox.Text);
                    UpdateCustomerOutput.Text = "Update of customer password was successful";
                    UpdateNameIdBox.Text = "";
                    UpdateNameBox.Text = "";
                }//End I:*
                
            }//End TRY:*
            catch (Exception ex) {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateOrderCustomerIdRun(int orderId, int customerId)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateOrderCustomerId(orderId, customerId);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateOrderProductRun(int orderId, string product)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateProduct(orderId, product);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*


        public void UpdateOrderQuantityRun(int orderId, int quantity)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateQuantity(orderId, quantity);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateOrderSizeRun(int orderId, string size)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdateSize(orderId, size);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateOrderPriceRun(int orderId, double price)
        {
            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=Spring2021Exam;Integrated Security=True");

                codc.UpdatePrice(orderId, price);

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateOrderCustomerIdBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateCustomerOrderIdBox.Text != "" && UpdateCustomerIdBox.Text != "")
                {
                    int coid = Convert.ToInt32(UpdateCustomerOrderIdBox.Text);
                    int cid = Convert.ToInt32(UpdateCustomerIdBox.Text);
                    UpdateOrderCustomerIdRun(coid, cid);
                    UpdateOrderOutput.Text = "Update of order customer id was successful";
                    UpdateCustomerOrderIdBox.Text = "";
                    UpdateCustomerIdBox.Text = "";
                }//End I:*

            }//End TRY:*

            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*

        }//End M:*

        public void UpdateOrderProductBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateProductIdBox.Text != "" && UpdateProductBox.Text != "")
                {
                    int poid = Convert.ToInt32(UpdateProductIdBox.Text);
                    UpdateOrderProductRun(poid, UpdateProductBox.Text);
                    UpdateOrderOutput.Text = "Update of order product was successful";
                    UpdateProductIdBox.Text = "";
                    UpdateProductBox.Text = "";
                }//End I:*


            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateOrderQuantityBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateQuantityIdBox.Text != "" && UpdateQuantityBox.Text != "")
                {
                    int quid = Convert.ToInt32(UpdateQuantityIdBox.Text);
                    int qamount = Convert.ToInt32(UpdateQuantityBox.Text);
                    UpdateOrderQuantityRun(quid, qamount);
                    UpdateOrderOutput.Text = "Update of order quantity was successful";
                    UpdateQuantityIdBox.Text = "";
                    UpdateQuantityBox.Text = "";
                }//End I:*

            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateOrderSizeBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdateSizeIdBox.Text != "" && UpdateSizeBox.Text != "")
                {
                    int quid = Convert.ToInt32(UpdateSizeIdBox.Text);
                    UpdateOrderSizeRun(quid, UpdateSizeBox.Text);
                    UpdateOrderOutput.Text = "Update of order product size was successful";
                    UpdateSizeIdBox.Text = "";
                    UpdateSizeBox.Text = "";
                }//End I:*

            }//End TRY:*
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void UpdateOrderPriceBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (UpdatePriceIdBox.Text != "" && UpdatePriceBox.Text != "")
                {
                    int prid = Convert.ToInt32(UpdatePriceIdBox.Text);
                    int price = Convert.ToInt32(UpdatePriceBox.Text);
                    UpdateOrderPriceRun(prid, price);
                    UpdateOrderOutput.Text = "Update of order price was successful";
                    UpdatePriceIdBox.Text = ""; 
                    UpdatePriceBox.Text = "";
                }//End I:*
            }//End TRY:*

            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }//End CAT:*
        }//End M:*

        public void ReadOrderBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {

                if (ReadCustomerID.Text != "")
                {
                    int targetId = Convert.ToInt32(ReadCustomerID.Text);

                    CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=CustomerOrderViewer;Integrated Security=True");


                    IList<CustomerOrder> codmList = codc.GetOrderById(targetId);

                    if (codmList.Any())
                    {

                        foreach (CustomerOrder locCodm in codmList)
                        {
                            OutputOrders.Text +=

                            locCodm.CustomerOrderId + ",\n" +
                            locCodm.CustomerId + ",\n" +
                            locCodm.Product + ",\n" +
                            locCodm.Quantity + ",\n" +
                            locCodm.Size + ",\n" + 
                            locCodm.Price;


                        }//End FE:*

                    }//End I:*
                }//End I:*

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*

        public void ReadCustomerBtn_Click(Object sender, RoutedEventArgs e) {
            try
            {

                if (ReadCustomerID.Text != "") {
                    int targetId = Convert.ToInt32(ReadCustomerID.Text);
                    CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=CustomerOrderViewer;Integrated Security=True");


                    IList<Customer> codmList = codc.GetUserById(targetId);

                    if (codmList.Any())
                    {

                        foreach (Customer locCodm in codmList)
                        {
                            OutputRegister.Text +=
                            locCodm.Id + ",\n" +
                            locCodm.Name + ",\n" +
                            locCodm.UserName + ",\n" +
                            locCodm.Password + ",\n" +
                            locCodm.Email;


                        }//End FE:*

                    }//End I:*
                }//End I:*

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*

        public void DeleteOrderBtn_Click(Object sender, RoutedEventArgs e)
        {
            try
            {
                if (DeleteOrderIdBox.Text != "")
                {
                    int targetId = Convert.ToInt32(DeleteIdBox.Text);
                    DeleteOrderRun(targetId);
                    DeleteOrderIdBox.Text = "";
                    OutputOrders.Text = "All good here. Order deleted successfully.";
                }//End 
            }//End TRY:*
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*

        public void OrderBtn_Click(Object sender, RoutedEventArgs e)
        {
            try {
                if (CustomerIdBox.Text != "" && ProductBox.Text != "" && QuantityBox.Text != "" && SizeBox.Text != "" && PriceBox.Text != "") {
                  
                    int iCustomerId = Convert.ToInt32(CustomerIdBox.Text);
                    int quantity = Convert.ToInt32(QuantityBox.Text);
                    double price = Convert.ToDouble(PriceBox.Text);

                    InsertOrderRun(iCustomerId, ProductBox.Text, quantity, SizeBox.Text, price);

                    CustomerIdBox.Text = "";
                    ProductBox.Text = "";
                    QuantityBox.Text = "";
                    SizeBox.Text = "";
                    PriceBox.Text = "";

                    OutputOrders.Text = "That went well. The order was saved to that relational table.";


                }//End I:*
            }//End TRY:*
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*

        public void ReadCustomerByIdProgRun(int id) {

            try
            {

                CustomerOrderSql codc = new CustomerOrderSql(@"Data Source=.\;Initial Catalog=CustomerOrderViewer;Integrated Security=True");

                IList<CustomerOrder> codmList = codc.GetOrderById(id);

                if (codmList.Any())
                {

                    foreach (CustomerOrder locCodm in codmList)
                    {
                        Console.WriteLine(
                                          locCodm.CustomerOrderId + " " +
                                          locCodm.CustomerId + " " +
                                          locCodm.Product + " " +
                                          locCodm.Quantity + " " +
                                          locCodm.Size + " " +
                                          locCodm.Price
                                          );
                    }//End FE:*

                }//End I:*

            }//End TRY:*

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }//End CAT:*
        }//End M:*

        public void ReadOrderByIdProgRun(int id)
        {

           
        }//End M:*


    }//End CL:*

}//End NS:*
