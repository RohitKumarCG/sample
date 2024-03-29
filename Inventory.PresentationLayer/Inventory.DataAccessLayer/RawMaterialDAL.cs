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
    //Abstract Class of Data Access Layer of RawMaterial
    public abstract class RawMaterialDalAbstract
    {
        public abstract bool AddRawMaterialDAL(RawMaterial newRawMaterial);
        public abstract bool DeleteRawMaterialDAL(string deleteRawMaterialID);
        public abstract bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial, List<RawMaterial> updatedRawMaterialList);
        public abstract List<RawMaterial> GetAllRawMaterialsDAL();
        public abstract RawMaterial SearchRawMaterialByIDDAL(string searchRawMaterialID);
        public abstract List<RawMaterial> SearchRawMaterialByNameDAL(string searchRawMaterialName);
        public abstract List<RawMaterial> SearchRawMaterialByCodeDAL(string searchRawMaterialCode);
        public abstract void RawMaterialSerializeDAL();
        public abstract List<RawMaterial> RawMaterialDeserializeDAL();

    }

    //Class of Data Access Layer of RawMaterial
    [Serializable]//Making class serializable
    public class RawMaterialDAL : RawMaterialDalAbstract
    {
        public static List<RawMaterial> rawMaterialList = new List<RawMaterial>();
        public List<RawMaterial> rawMaterialListToSerialize = new List<RawMaterial>();
        public List<RawMaterial> rawMaterialListToDeserialize = new List<RawMaterial>();
        private string filePath = "RawMaterial.dat";

        //To add Raw Material
        public override bool AddRawMaterialDAL(RawMaterial newRawMaterial)
        {
            bool rawMaterialAdded = false;
            try
            {
                rawMaterialList.Add(newRawMaterial);
                rawMaterialAdded = true;
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialAdded;
        }

        //To delete Raw Material
        public override bool DeleteRawMaterialDAL(string deleteRawMaterialID)
        {
            bool rawMaterialDeleted = false;
            try
            {
                RawMaterial deleteRawMaterial = null;
                foreach (RawMaterial item in rawMaterialList)
                {
                    if (item.RawMaterialID == deleteRawMaterialID)
                    {
                        deleteRawMaterial = item;
                    }
                }

                if (deleteRawMaterial != null)
                {
                    rawMaterialList.Remove(deleteRawMaterial);
                    rawMaterialDeleted = true;
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialDeleted;

        }

        //To update Raw Material's Name and Code
        public override bool UpdateRawMaterialDAL(RawMaterial updateRawMaterial, List<RawMaterial> updatedRawMaterialList)
        {
            bool rawMaterialUpdated = false;
            try
            {
                foreach (RawMaterial item1 in updatedRawMaterialList)
                {
                    foreach (RawMaterial item2 in rawMaterialList)
                    {
                        if(item1.RawMaterialID == item2.RawMaterialID)
                        {
                            item2.RawMaterialName = updateRawMaterial.RawMaterialName;
                            item2.RawMaterialCode = updateRawMaterial.RawMaterialCode;
                            rawMaterialUpdated = true;
                        }
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return rawMaterialUpdated;
        }

        //To list all the raw materials
        public override List<RawMaterial> GetAllRawMaterialsDAL()
        {
            return rawMaterialList;
        }

        //To search for Raw Material by ID
        public override RawMaterial SearchRawMaterialByIDDAL(string searchRawMaterialID)
        {
            RawMaterial searchRawMaterial = null;
            try
            {
                foreach (RawMaterial item in rawMaterialList)
                {
                    if (item.RawMaterialID == searchRawMaterialID)
                    {
                        searchRawMaterial = item;
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterial;
        }

        //To search for all Raw Material by Name
        public override List<RawMaterial> SearchRawMaterialByNameDAL(string searchRawMaterialName)
        {
            List<RawMaterial> searchRawMaterialList = new List<RawMaterial>();
            try
            {
                foreach (RawMaterial item in rawMaterialList)
                {
                    if (item.RawMaterialName == searchRawMaterialName)
                    {
                        searchRawMaterialList.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterialList;
        }

        //To search for all Raw Material by Code
        public override List<RawMaterial> SearchRawMaterialByCodeDAL(string searchRawMaterialCode)
        {
            List<RawMaterial> searchRawMaterialList = new List<RawMaterial>();
            try
            {
                foreach (RawMaterial item in rawMaterialList)
                {
                    if (item.RawMaterialCode == searchRawMaterialCode)
                    {
                        searchRawMaterialList.Add(item);
                    }
                }
            }
            catch (SystemException ex)
            {
                throw new InventoryException(ex.Message);
            }
            return searchRawMaterialList;
        }

        // Searializing Data of list in File
        public override void RawMaterialSerializeDAL()
        {
            rawMaterialListToSerialize = rawMaterialList;
            StreamWriter sw = new StreamWriter(filePath);
            string content = JsonConvert.SerializeObject(rawMaterialListToSerialize);
            sw.Write(content);
            sw.Close();
        }

        // Deserialzing Data of Field in File
        public override List<RawMaterial> RawMaterialDeserializeDAL()
        {
            StreamReader sr = new StreamReader(filePath);
            rawMaterialListToDeserialize = JsonConvert.DeserializeObject<List<RawMaterial>>(sr.ReadToEnd());
            return rawMaterialListToDeserialize;
        }
    }
}
