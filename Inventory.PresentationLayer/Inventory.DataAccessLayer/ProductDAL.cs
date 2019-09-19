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
        public abstract bool UpdateProductDAL(Product updateProduct, List<Product> updatedProductList);
        public abstract List<Product> GetAllProductsDAL();
        public abstract Product SearchProductByIDDAL(string searchProductID);
        public abstract List<Product> SearchProductByTypeDAL(string searchProductType);
        public abstract List<Product> SearchProductByCodeDAL(string searchProductCode);
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
        public override bool UpdateProductDAL(Product updateProduct, List<Product> updatedProductList)
        {
            bool productUpdated = false;
            try
            {
                foreach (Product item1 in updatedProductList)
                {
                    foreach (Product item2 in productList)
                    {
                        if (item1.ProductID == item2.ProductID)
                        {
                            item2.ProductType = updateProduct.ProductType;
                            item2.ProductCode = updateProduct.ProductCode;
                            productUpdated = true;
                        }
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
        public override List<Product> SearchProductByTypeDAL(string searchProductType)
        {
            List<Product> searchProductList = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductType == searchProductType)
                    {
                        searchProductList.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProductList;
        }

        //To search for Product by Code
        public override List<Product> SearchProductByCodeDAL(string searchProductCode)
        {
            List<Product> searchProductList = new List<Product>();
            try
            {
                foreach (Product item in productList)
                {
                    if (item.ProductCode == searchProductCode)
                    {
                        searchProductList.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchProductList;
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
