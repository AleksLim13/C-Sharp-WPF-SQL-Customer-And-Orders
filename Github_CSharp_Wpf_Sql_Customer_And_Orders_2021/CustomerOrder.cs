using System;
using System.Collections.Generic;
using System.Text;

namespace WpfSsmsPizza
{
    class CustomerOrder
    {
        public CustomerOrder() { }//End C:*

        public int CustomerOrderId { get; set; }

        public int CustomerId { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }

        public double Price { get; set; }

    }//End CL:*

}//End NS:*
