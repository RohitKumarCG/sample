using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Entities;
using Inventory.DataAccessLayer;
using System.Text.RegularExpressions;
using Inventory.Exception;

namespace Inventory.BusinessLayer
{

    //Abstract Class of Business Layer of RawMaterial
    public abstract class RawMaterialBLAbstract
    {
        public abstract bool ValidateRawMaterial(RawMaterial rawMaterial);
        public abstract bool AddRawMaterialBL(RawMaterial newRawMaterial);
        public abstract bool DeleteRawMaterialBL(string deleteRawMaterialID);
        public abstract bool UpdateRawMaterialBL(RawMaterial updateRawMaterial);
        public abstract List<RawMaterial> GetAllRawMaterialsBL();
        public abstract RawMaterial SearchRawMaterialByIDBL(string searchRawMaterialID);
        public abstract RawMaterial SearchRawMaterialByNameBL(string searchRawMaterialName);
        public abstract RawMaterial SearchRawMaterialByCodeBL(string searchRawMaterialCode);
        public abstract bool RawMaterialSerializeBL();
        public abstract List<RawMaterial> RawMaterialDeserializeBL();
    }

    //Class of Business Layer of RawMaterial
    public class RawMaterialBL : RawMaterialBLAbstract
    {
        //Validate raw material details before adding and updating
        public override bool ValidateRawMaterial(RawMaterial rawMaterial)
        {
            StringBuilder sb = new StringBuilder();
            bool validRawMaterial = true;

            //Rule: Can contain alphabets only,spaces allowed, length less than 30
            Regex regex1 = new Regex("^[a-zA-Z ]+$");
            if (!regex1.IsMatch(rawMaterial.RawMaterialName) || rawMaterial.RawMaterialName == String.Empty || rawMaterial.RawMaterialName.Length > 30)
            {
                validRawMaterial = false;
                sb.Append("\nInvalid Raw Material Name");
            }

            //Rule: Can contain alphabets only,no spaces , length less than 5
            Regex regex2 = new Regex("^[a-zA-Z]+$");
            if (!regex2.IsMatch(rawMaterial.RawMaterialCode) || rawMaterial.RawMaterialCode == String.Empty || rawMaterial.RawMaterialCode.Length > 5)
            {
                validRawMaterial = false;
                sb.Append("\nInvalid Raw Material Code");
            }

            if (validRawMaterial == false)
            {
                throw new InventoryException(sb.ToString());
            }
            return validRawMaterial;
        }

        //validate raw material details before calling add
        public override bool AddRawMaterialBL(RawMaterial newRawMaterial)
        {
            bool rawMaterialAdded = false;
            try
            {
                if (ValidateRawMaterial(newRawMaterial))
                {
                    RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                    rawMaterialAdded = rawMaterialDAL.AddRawMaterialDAL(newRawMaterial);
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

            return rawMaterialAdded;
        }

        //validate and call delete
        public override bool DeleteRawMaterialBL(string deleteRawMaterialID)
        {
            bool rawMaterialDeleted = false;
            try
            {
                if (deleteRawMaterialID.Length > 0 && deleteRawMaterialID.Length < 6)
                {
                    RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                    rawMaterialDeleted = rawMaterialDAL.DeleteRawMaterialDAL(deleteRawMaterialID);
                }
                else
                {
                    throw new InventoryException("Invalid Raw Material ID");
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
            return rawMaterialDeleted;
        }

        //validate raw material details before calling update
        public override bool UpdateRawMaterialBL(RawMaterial updateRawMaterial)
        {
            bool rawMaterialUpdated = false;
            try
            {
                if (ValidateRawMaterial(updateRawMaterial))
                {
                    RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                    rawMaterialUpdated = rawMaterialDAL.UpdateRawMaterialDAL(updateRawMaterial);
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

            return rawMaterialUpdated;
        }

        //calling getAll method
        public override List<RawMaterial> GetAllRawMaterialsBL()
        {
            List<RawMaterial> rawMaterialList = null;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                rawMaterialList = rawMaterialDAL.GetAllRawMaterialsDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return rawMaterialList;
        }

        //calling search method
        public override RawMaterial SearchRawMaterialByIDBL(string searchRawMaterialID)
        {
            RawMaterial searchRawMaterial = null;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                searchRawMaterial = rawMaterialDAL.SearchRawMaterialByIDDAL(searchRawMaterialID);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchRawMaterial;
        }

        //calling search method
        public override RawMaterial SearchRawMaterialByNameBL(string searchRawMaterialName)
        {
            RawMaterial searchRawMaterial = null;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                searchRawMaterial = rawMaterialDAL.SearchRawMaterialByNameDAL(searchRawMaterialName);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchRawMaterial;
        }

        //calling search method
        public override RawMaterial SearchRawMaterialByCodeBL(string searchRawMaterialCode)
        {
            RawMaterial searchRawMaterial = null;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                searchRawMaterial = rawMaterialDAL.SearchRawMaterialByCodeDAL(searchRawMaterialCode);
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return searchRawMaterial;
        }

        //Serilize Data
        public override bool RawMaterialSerializeBL()
        {
            bool isSerializationComplete = false;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                rawMaterialDAL.RawMaterialSerializeDAL();
                isSerializationComplete = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return isSerializationComplete;
        }

        //Deserialize Data
        public override List<RawMaterial> RawMaterialDeserializeBL()
        {
            List<RawMaterial> rawMaterialDeserializeList = null;
            try
            {
                RawMaterialDAL rawMaterialDAL = new RawMaterialDAL();
                rawMaterialDeserializeList = rawMaterialDAL.RawMaterialDeserializeDAL();
            }
            catch (InventoryException ex)
            {
                throw ex;
            }
            catch (SystemException ex)
            {
                throw ex;
            }
            return rawMaterialDeserializeList;
        }
    }
}
