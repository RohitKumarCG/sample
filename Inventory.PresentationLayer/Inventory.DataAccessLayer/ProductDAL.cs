using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exception;
using Newtonsoft.Json;

namespace Inventory.DataAccessLayer
{
    //Abstract Class of Data Access Layer of Product
    public abstract class ProductDalAbstract
    {
        public abstract bool AddProductDAL(Product newProduct);
        public abstract bool DeleteProductDAL(string deleteProductID);
        public abstract bool UpdateProductDAL(Product updateProduct);
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product SearchProductByIDDAL(string searchProductID);
        public abstract Product SearchProductByNameDAL(string searchProductName);
        public abstract Product SearchProductByCodeDAL(string searchProductCode);
        public abstract void ProductSerializeDAL();
        public abstract List<Product> ProductDeserializeDAL();
    }

    //Class of Data Access Layer of Product
    public class ProductDAL : ProductDalAbstract
    {
        public static List<Product> productList = new List<Product>();
        public List<Product> productListToSerialize = new List<Product>();
        public List<Product> productListToDeserialize = new List<Product>();
        private string filePath = "Product.dat";

        //To add Product
        public override bool AddProductDAL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                productList.Add(newProduct);
                productAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productAdded;
        }

        //To delete Product
        public override bool DeleteProductDAL(string deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                Product deleteProduct = null;
                foreach (Product item in productList)
                {
                    if (item.ProductID == deleteProductID)
                    {
                        deleteProduct = item;
                    }
                }

                if (deleteProduct != null)
                {
                    productList.Remove(deleteProduct);
                    productDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productDeleted;

        }

        //To update Product
        public override bool UpdateProductDAL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductID == updateProduct.ProductID)
                    {
                        item.ProductName = updateProduct.ProductName;
                        //item.ProductCode = updateProduct.ProductCode;
                        productUpdated = true;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return productUpdated;

        }

        //To list all the Products
        public override List<Product> GetAllProductsDAL()
        {
            return productList;
        }

        //To search for Product by ID
        public override Product SearchProductByIDDAL(string searchProductID)
        {
            Product searchProduct = null;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductID == searchProductID)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProduct;
        }

        //To search for Product by Name
        public override Product SearchProductByNameDAL(string searchProductName)
        {
            Product searchProduct = null;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductName == searchProductName)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProduct;
        }

        //To search for Product by Code
        public override Product SearchProductByCodeDAL(string searchProductCode)
        {
            Product searchProduct = null;
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductCode == searchProductCode)
                    {
                        searchProduct = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProduct;
        }

        // Searializing Data of list in File
        public override void ProductSerializeDAL()
        {
            productListToSerialize = productList;
            StreamWriter sw = new StreamWriter(filePath);
            string content = JsonConvert.SerializeObject(productListToSerialize);
            sw.Write(content);
            sw.Close();
        }

        // Deserialzing Data of Field in File
        public override List<Product> ProductDeserializeDAL()
        {
            StreamReader sr = new StreamReader(filePath);
            productListToDeserialize = JsonConvert.DeserializeObject<List<Product>>(sr.ReadToEnd());
            return productListToDeserialize;
        }
    }
}
