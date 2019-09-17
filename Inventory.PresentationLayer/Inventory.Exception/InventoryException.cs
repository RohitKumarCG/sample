using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Exception
{
    //Class for InventoryException 
    public sealed class InventoryException : ApplicationException
    {
        public InventoryException() : base()
        {
        }

        public InventoryException(string message) : base(message)
        {
        }
    }
}