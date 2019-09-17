using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using Inventory.BusinessLayer;
using Inventory.Exception;

namespace Inventory.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            RawMaterial rawMaterial1 = new RawMaterial() { RawMaterialID = "RM101", RawMaterialName = "Mango", RawMaterialCode = "MGO" };
            RawMaterialBL rawMaterialBL = new RawMaterialBL();
            rawMaterialBL.AddRawMaterialBL(rawMaterial1);
            Product product1 = new Product() {ProductID = "P101", ProductName = "MJUICE", ProductCode = "MJ", ProductMFD = "12-09-2019", ProductEXP = "12-09-2020", ProductType = "MOCKTAIL" };
            ProductBL productBL = new ProductBL();
            productBL.AddProductBL(product1);

            int choice;
            do
            {
                PrintMenu();
                Console.WriteLine("Enter your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddRawMaterial();
                        break;
                    case 2:
                        ListAllRawMaterial();
                        break;
                    case 3:
                        SearchRawMaterialByID();
                        break;
                    case 4:
                        SearchRawMaterialByName();
                        break;
                    case 5:
                        SearchRawMaterialByCode();
                        break;
                    case 6:
                        UpdateRawMaterial();
                        break;
                    case 7:
                        DeleteRawMaterial();
                        break;
                    case 8:
                        AddProduct();
                        break;
                    case 9:
                        ListAllProduct();
                        break;
                    case 10:
                        SearchProductByID();
                        break;
                    case 11:
                        SearchProductByName();
                        break;
                    case 12:
                        SearchProductByCode();
                        break;
                    case 13:
                        UpdateProduct();
                        break;
                    case 14:
                        DeleteProduct();
                        break;
                    case 15:
                        SerializeRawMaterial();
                        break;
                    case 16:
                        DeserializeRawMaterial();
                        break;
                    case 17:
                        SerializeProduct();
                        break;
                    case 18:
                        DeserializeProduct();
                        break;
                    case 19:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != -1);
        }

        private static void AddRawMaterial()
        {
            try
            {
                RawMaterial newRawMaterial = new RawMaterial();
                Console.WriteLine("Enter RawMaterialID :");
                newRawMaterial.RawMaterialID = Console.ReadLine();
                Console.WriteLine("Enter Raw Material Name :");
                newRawMaterial.RawMaterialName = Console.ReadLine();
                Console.WriteLine("Enter Raw Material Code :");
                newRawMaterial.RawMaterialCode = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                bool rawMaterialAdded = rawMaterialBL.AddRawMaterialBL(newRawMaterial);
                if (rawMaterialAdded)
                    Console.WriteLine("Raw Material Added");
                else
                    Console.WriteLine("Raw Material not Added");
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllRawMaterial()
        {
            try
            {
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                List<RawMaterial> rawMaterialList = rawMaterialBL.GetAllRawMaterialsBL();
                if (rawMaterialList.Count != 0)
                {
                    Console.WriteLine("******************************  Raw Materials ********************************");
                    Console.WriteLine("ID\t\tName\t\tCode");
                    Console.WriteLine("******************************************************************************");
                    foreach (RawMaterial rawMaterial in rawMaterialList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", rawMaterial.RawMaterialID, rawMaterial.RawMaterialName, rawMaterial.RawMaterialCode);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchRawMaterialByID()
        {
            try
            {
                string searchRawMaterialID;
                Console.WriteLine("Enter Raw Material ID to Search:");
                searchRawMaterialID = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial searchRawMaterial = rawMaterialBL.SearchRawMaterialByIDBL(searchRawMaterialID);
                if (searchRawMaterial != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchRawMaterial.RawMaterialID, searchRawMaterial.RawMaterialName, searchRawMaterial.RawMaterialCode);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchRawMaterialByName()
        {
            try
            {
                string searchRawMaterialName;
                Console.WriteLine("Enter Raw Material Name to Search:");
                searchRawMaterialName = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial searchRawMaterial = rawMaterialBL.SearchRawMaterialByNameBL(searchRawMaterialName);
                if (searchRawMaterial != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchRawMaterial.RawMaterialID, searchRawMaterial.RawMaterialName, searchRawMaterial.RawMaterialCode);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchRawMaterialByCode()
        {
            try
            {
                string searchRawMaterialCode;
                Console.WriteLine("Enter Raw Material ID to Search:");
                searchRawMaterialCode = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial searchRawMaterial = rawMaterialBL.SearchRawMaterialByCodeBL(searchRawMaterialCode);
                if (searchRawMaterial != null)
                {
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}", searchRawMaterial.RawMaterialID, searchRawMaterial.RawMaterialName, searchRawMaterial.RawMaterialCode);
                    Console.WriteLine("******************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateRawMaterial()
        {
            try
            {
                string updateRawMaterialID;
                Console.WriteLine("Enter Raw Material ID to Update Details:");
                updateRawMaterialID = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial updatedRawMaterial = rawMaterialBL.SearchRawMaterialByIDBL(updateRawMaterialID);
                if (updatedRawMaterial != null)
                {
                    Console.WriteLine("Update Raw Material Name :");
                    updatedRawMaterial.RawMaterialName = Console.ReadLine();
                    Console.WriteLine("Update Raw Material Code :");
                    updatedRawMaterial.RawMaterialCode = Console.ReadLine();
                    bool rawMaterialUpdated = rawMaterialBL.UpdateRawMaterialBL(updatedRawMaterial);
                    if (rawMaterialUpdated)
                        Console.WriteLine("Raw Material Details Updated");
                    else
                        Console.WriteLine("Raw Material Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteRawMaterial()
        {
            try
            {
                string deleteRawMaterialID;
                Console.WriteLine("Enter Raw Material ID to Delete:");
                deleteRawMaterialID = Console.ReadLine();
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                RawMaterial deleteRawMaterial = rawMaterialBL.SearchRawMaterialByIDBL(deleteRawMaterialID);
                if (deleteRawMaterial != null)
                {
                    bool rawMaterialdeleted = rawMaterialBL.DeleteRawMaterialBL(deleteRawMaterialID);
                    if (rawMaterialdeleted)
                        Console.WriteLine("Raw Material Deleted");
                    else
                        Console.WriteLine("Raw Material not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SerializeRawMaterial()
        {
            try
            {
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                bool isSerializationComplete = rawMaterialBL.RawMaterialSerializeBL();
                if (isSerializationComplete)
                {
                    Console.WriteLine("Serialization Done");
                }
                else
                {
                    Console.WriteLine("Serialization Not Done");
                }
            }
            catch (SystemException ex)
            {

                Console.WriteLine(ex.Message); 
            }
        }

        private static void DeserializeRawMaterial()
        {
            try
            {
                RawMaterialBL rawMaterialBL = new RawMaterialBL();
                List<RawMaterial> rawMaterialDeserializeList = rawMaterialBL.RawMaterialDeserializeBL();
                if (rawMaterialDeserializeList.Count != 0)
                {
                    Console.WriteLine("******************************  Raw Materials ********************************");
                    Console.WriteLine("ID\t\tName\t\tCode");
                    Console.WriteLine("******************************************************************************");
                    foreach (RawMaterial rawMaterial in rawMaterialDeserializeList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}", rawMaterial.RawMaterialID, rawMaterial.RawMaterialName, rawMaterial.RawMaterialCode);
                    }
                    Console.WriteLine("******************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Raw Material Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void AddProduct()
        {
            try
            {
                Product newProduct = new Product();
                Console.WriteLine("Enter Product ID :");
                newProduct.ProductID = Console.ReadLine();
                Console.WriteLine("Enter Product Name :");
                newProduct.ProductName = Console.ReadLine();
                Console.WriteLine("Enter Product Code :");
                newProduct.ProductCode = Console.ReadLine();
                Console.WriteLine("Enter Product MFD :");
                newProduct.ProductMFD = Console.ReadLine();
                Console.WriteLine("Enter Product EXP :");
                newProduct.ProductEXP = Console.ReadLine();
                Console.WriteLine("Enter Product Type :");
                newProduct.ProductType = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                bool productAdded = productBL.AddProductBL(newProduct);
                if (productAdded)
                    Console.WriteLine("Product Added");
                else
                    Console.WriteLine("Product not Added");
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ListAllProduct()
        {
            try
            {
                ProductBL productBL = new ProductBL();
                List<Product> productList = productBL.GetAllProductsBL();
                if (productList.Count != 0)
                {
                    Console.WriteLine("*********8*************************************** Products *************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode\t\tMFD\t\t\tEXP\t\t\tType");
                    Console.WriteLine("************************************************************************************************************");
                    foreach (Product product in productList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", product.ProductID, product.ProductName, product.ProductCode, product.ProductMFD, product.ProductEXP, product.ProductType);

                    }
                    Console.WriteLine("************************************************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchProductByID()
        {
            try
            {
                string searchProductID;
                Console.WriteLine("Enter Product ID to Search:");
                searchProductID = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                Product searchProduct = productBL.SearchProductByIDBL(searchProductID);
                if (searchProduct != null)
                {
                    Console.WriteLine("************************************************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode\t\tMFD\t\t\tEXP\t\t\tType");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchProduct.ProductID, searchProduct.ProductName, searchProduct.ProductCode, searchProduct.ProductMFD, searchProduct.ProductEXP, searchProduct.ProductType);
                    Console.WriteLine("************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchProductByName()
        {
            try
            {
                string searchProductName;
                Console.WriteLine("Enter Product Name to Search:");
                searchProductName = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                Product searchProduct = productBL.SearchProductByNameBL(searchProductName);
                if (searchProduct != null)
                {
                    Console.WriteLine("************************************************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode\t\tMFD\t\t\tEXP\t\t\tType");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchProduct.ProductID, searchProduct.ProductName, searchProduct.ProductCode, searchProduct.ProductMFD, searchProduct.ProductEXP, searchProduct.ProductType);
                    Console.WriteLine("************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SearchProductByCode()
        {
            try
            {
                string searchProductCode;
                Console.WriteLine("Enter Product Code to Search:");
                searchProductCode = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                Product searchProduct = productBL.SearchProductByCodeBL(searchProductCode);
                if (searchProduct != null)
                {
                    Console.WriteLine("************************************************************************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode\t\tMFD\t\t\tEXP\t\t\tType");
                    Console.WriteLine("******************************************************************************");
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", searchProduct.ProductID, searchProduct.ProductName, searchProduct.ProductCode, searchProduct.ProductMFD, searchProduct.ProductEXP, searchProduct.ProductType);
                    Console.WriteLine("************************************************************************************************************");
                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdateProduct()
        {
            try
            {
                string updateProductID;
                Console.WriteLine("Enter Product ID to Update Details:");
                updateProductID = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                Product updatedProduct = productBL.SearchProductByIDBL(updateProductID);
                if (updatedProduct != null)
                {
                    Console.WriteLine("Update Product Name :");
                    updatedProduct.ProductName = Console.ReadLine();
                    Console.WriteLine("Update Product Code :");
                    updatedProduct.ProductCode = Console.ReadLine();
                    bool productUpdated = productBL.UpdateProductBL(updatedProduct);
                    if (productUpdated)
                        Console.WriteLine("Product Details Updated");
                    else
                        Console.WriteLine("Product Details not Updated ");
                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void DeleteProduct()
        {
            try
            {
                string deleteProductID;
                Console.WriteLine("Enter Product ID to Delete:");
                deleteProductID = Console.ReadLine();
                ProductBL productBL = new ProductBL();
                Product deleteProduct = productBL.SearchProductByIDBL(deleteProductID);
                if (deleteProduct != null)
                {
                    bool productdeleted = productBL.DeleteProductBL(deleteProductID);
                    if (productdeleted)
                        Console.WriteLine("Product Deleted");
                    else
                        Console.WriteLine("Product not Deleted ");
                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SerializeProduct()
        {
            try
            {
                ProductBL productBL = new ProductBL();
                bool isSerializationComplete = productBL.ProductSerializeBL();
                if (isSerializationComplete)
                {
                    Console.WriteLine("Serialization Done");
                }
                else
                {
                    Console.WriteLine("Serialization Not Done");
                }
            }
            catch (SystemException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        private static void DeserializeProduct()
        {
            try
            {
                ProductBL productBL = new ProductBL();
                List<Product> productDeserializeList = productBL.ProductDeserializeBL();
                if (productDeserializeList.Count != 0)
                {
                    Console.WriteLine("*********8*************************************** Products *************************************************");
                    Console.WriteLine("ID\t\tName\t\tCode\t\tMFD\t\t\tEXP\t\t\tType");
                    Console.WriteLine("************************************************************************************************************");
                    foreach (Product product in productDeserializeList)
                    {
                        Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", product.ProductID, product.ProductName, product.ProductCode, product.ProductMFD, product.ProductEXP, product.ProductType);

                    }
                    Console.WriteLine("************************************************************************************************************");

                }
                else
                {
                    Console.WriteLine("No Product Details Available");
                }
            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine("\n***********Inventory Menu***********");
            Console.WriteLine("1. Add Raw Material");
            Console.WriteLine("2. List All Raw Materials");
            Console.WriteLine("3. Search Raw Material by ID");
            Console.WriteLine("4. Search Raw Material by Name");
            Console.WriteLine("5. Search Raw Material by Code");
            Console.WriteLine("6. Update Raw Material");
            Console.WriteLine("7. Delete Raw Material");
            Console.WriteLine("8. Add Product");
            Console.WriteLine("9. List All Product");
            Console.WriteLine("10. Search Product by ID");
            Console.WriteLine("11. Search Product by Name");
            Console.WriteLine("12. Search Product by Code");
            Console.WriteLine("13. Update Product");
            Console.WriteLine("14. Delete Product");
            Console.WriteLine("15. Serialize Raw Material");
            Console.WriteLine("16. Deserialize Raw Material");
            Console.WriteLine("17. Serialize Product");
            Console.WriteLine("18. Deserialize Product");
            Console.WriteLine("19. Exit");
            Console.WriteLine("******************************************\n");
        }
    }
}