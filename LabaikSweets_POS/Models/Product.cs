using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaikSweets_POS.Models
{
    class Product
    {
        public string CategoryId { get; set; }

        public string ProductId { get; set; }

        public string CompanyId { get; set; }

        public string UomId { get; set; }

        public string Barcode { get; set; }

        public string ProductName { get; set; }

        public string Quantity { get; set; }

        public string PurchasePrice { get; set; }

        public string SalePrice { get; set; }

        public string ReorderLevel { get; set; }

        public string ReplenishLevel { get; set; }

        public DateTime ExpireDate { get; set; }

        public bool IsActive { get; set; }
    }
}
