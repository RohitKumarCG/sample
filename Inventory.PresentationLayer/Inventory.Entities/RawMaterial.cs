using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Entities
{
    //Interface for RawMaterial
    public interface IRawMaterial
    {
        string RawMaterialID { get; set; }
        string RawMaterialName { get; set; }
        string RawMaterialCode { get; set; }
    }

    //Class for RawMaterial

    public class RawMaterial : IRawMaterial
    {
        //auto-implemented properties
        public string RawMaterialID { get; set; }
        public string RawMaterialName { get; set; }
        public string RawMaterialCode { get; set; }


        //Constructor to initialize with default values
        public RawMaterial()
        {
            RawMaterialID = string.Empty;
            RawMaterialName = string.Empty;
            RawMaterialCode = string.Empty;
        }
    }
}
