using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.Exception;
using Inventory.DataAccessLayer;
using System.Text.RegularExpressions;

namespace Inventory.BusinessLayer
{
    //Abstract Class of Business Layer of Product
    public abstract class ProductBLAbstract
    {
        public abstract bool ValidateProduct(Product product);
        public abstract bool AddProductBL(Product newProduct);
        public abstract bool DeleteProductBL(string deleteProductID);
        public abstract bool UpdateProductBL(Product updateProduct);
        public abstract List<Product> GetAllProductsBL();
        public abstract Product SearchProductByIDBL(string searchProductID);
        public abstract Product SearchProductByNameBL(string searchProductName);
        public abstract Product SearchProductByCodeBL(string searchProductCode);
        public abstract bool ProductSerializeBL();
        public abstract List<Product> ProductDeserializeBL();
    }

    //Class of Business Layer of Product
    public class ProductBL : ProductBLAbstract
    {
        //Validate product details before adding and updating
        public override bool ValidateProduct(Product product)
        {
            StringBuilder sb = new StringBuilder();
            bool validProduct = true;

            /*foreach (Product item in ProductDAL.productList)
            {
                if (item.ProductID == product.ProductID)
                {
                    validProduct = false;
                    sb.Append("\nProduct ID already exists");
                }
            }*/
            if (product.ProductID == String.Empty || product.ProductID.Length > 5)
            {
                validProduct = false;
                sb.Append("\nInvalid Product ID");
            }

            Regex regex1 = new Regex("^[a-zA-Z]+$");
            if (!regex1.IsMatch(product.ProductName) || product.ProductName == String.Empty || product.ProductName.Length > 30)
            {
                validProduct = false;
                sb.Append("\nInvalid Product Name");
            }

            /*foreach (Product item in ProductDAL.productList)
            {
                if (item.ProductCode == product.ProductCode)
                {
                    validProduct = false;
                    sb.Append("\nProduct Code already exists");
                }
            }*/
            Regex regex2 = new Regex("^[a-zA-Z]+$");
            if (!regex2.IsMatch(product.ProductCode) || product.ProductCode == String.Empty || product.ProductCode.Length > 4)
            {
                validProduct = false;
                sb.Append("\nInvalid Product Code");
            }
            DateTime mfd = Convert.ToDateTime(product.ProductMFD);
            DateTime now = DateTime.Now;
            int res1 = DateTime.Compare(mfd, now);
            if (res1 > 0)
            {
                validProduct = false;
                sb.Append("\nInvalid Manufacture Date");
            }

            DateTime exp = Convert.ToDateTime(product.ProductEXP);
            int res2 = DateTime.Compare(now, exp);
            if (res2 > 0)
            {
                validProduct = false;
                sb.Append("\nInvalid Expiry Date");
            }

            /*if ((product.ProductType != "juice") || (product.ProductType != "energy drink") || (product.ProductType != "tonic water") || (product.ProductType != "mocktail") || (product.ProductType != "softdrink"))
            {
                validProduct = false;
                sb.Append("\nInvalid Product Type");
            }*/

            if (validProduct == false)
            {
                throw new InventoryException(sb.ToString());
            }
            return validProduct;
        }

        //validate product details before calling add
        public override bool AddProductBL(Product newProduct)
        {
            bool productAdded = false;
            try
            {
                if (ValidateProduct(newProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productAdded = productDAL.AddProductDAL(newProduct);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return productAdded;
        }

        //validate and call delete
        public override bool DeleteProductBL(string deleteProductID)
        {
            bool productDeleted = false;
            try
            {
                if (deleteProductID.Length > 0 && deleteProductID.Length < 5)
                {
                    ProductDAL productDAL = new ProductDAL();
                    productDeleted = productDAL.DeleteProductDAL(deleteProductID);
                }
                else
                {
                    throw new InventoryException("Invalid Product ID");
                }

            }
            catch (InventoryException)
            {
                throw;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return productDeleted;
        }

        //validate raw material details before calling update
        public override bool UpdateProductBL(Product updateProduct)
        {
            bool productUpdated = false;
            try
            {
                if (ValidateProduct(updateProduct))
                {
                    ProductDAL productDAL = new ProductDAL();
                    productUpdated = productDAL.UpdateProductDAL(updateProduct);
                }
            }
            catch (InventoryException)
            {
                throw;
            }
            catch (SystemException ex)
            {
                throw ex;
            }

            return productUpdated;
        }

        //calling getAll method
        public override List<Product> GetAllProductsBL()
        {
            List<Product> productList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productList = productDAL.GetAllProductsDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return productList;
        }

        //calling search method
        public override Product SearchProductByIDBL(string searchProductID)
        {
            Product searchProduct = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                searchProduct = productDAL.SearchProductByIDDAL(searchProductID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchProduct;
        }

        //calling search method
        public override Product SearchProductByNameBL(string searchProductName)
        {
            Product searchProduct = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                searchProduct = productDAL.SearchProductByNameDAL(searchProductName);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchProduct;
        }

        //calling search method
        public override Product SearchProductByCodeBL(string searchProductCode)
        {
            Product searchProduct = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                searchProduct = productDAL.SearchProductByCodeDAL(searchProductCode);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchProduct;
        }

        //Serilize Data
        public override bool ProductSerializeBL()
        {
            bool isSerializationComplete = false;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productDAL.ProductSerializeDAL();
                isSerializationComplete = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return isSerializationComplete;
        }

        //Deserialize Data
        public override List<Product> ProductDeserializeBL()
        {
            List<Product> productDeserializeList = null;
            try
            {
                ProductDAL productDAL = new ProductDAL();
                productDeserializeList = productDAL.ProductDeserializeDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return productDeserializeList;
        }
    }
}