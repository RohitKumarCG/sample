using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    //Interface for Product
    public interface IProduct
    {
        string ProductID { get; set; }
        string ProductName { get; set; }
        string ProductCode { get; set; }
        string ProductMFD { get; set; }
        string ProductEXP { get; set; }
        string ProductType { get; set; }
    }

    //Class for Product
    public class Product : IProduct
    {
        //auto-implemented properties
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public string ProductMFD { get; set; }
        public string ProductEXP { get; set; }
        public string ProductType { get; set; }


        //Constructor to initialize with default values
        public Product()
        {
            ProductID = string.Empty;
            ProductName = string.Empty;
            ProductCode = string.Empty;
            ProductMFD = string.Empty;
            ProductEXP = string.Empty;
            ProductType = string.Empty;
        }
    }
}