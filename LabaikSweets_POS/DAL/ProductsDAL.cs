using LabaikSweets_POS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaikSweets_POS.DAL
{
   public class ProductsDAL:DBHelper
    {
      /*  public int ManageProduct(string categoryName)
        {
            int result = 0;
            var parameters = new List<IDbDataParameter>();
            parameters.Add(CreateParameter("@categoryName", categoryName));
            object category = GetScalarValue("dbo.InsertCategory", CommandType.StoredProcedure, parameters.ToArray());
            int.TryParse(Convert.ToString(category), out result);
            return result;
        }*/

        public List<CategoryModel> GetAllCategories(string filter = "")
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var datatable = GetDataTable("dbo.SP_GetAllCategories", CommandType.StoredProcedure);
            return ConvertDataTableToList<CategoryModel>(datatable);
        }

        private void ManageProduct()
        {
            var product = new Product
            {
                CategoryId = "CategoryId",
                CompanyId = "CompanyId",
                UomId = "UomId",
                Barcode = "Barcode",
                ProductName = "ProductName",
                Quantity = "Quantity",
                PurchasePrice = "PurchasePrice",
                SalePrice = "SalePrice",
                ReorderLevel = "ReorderLevel",
                ReplenishLevel = "ReplenishLevel",
                ExpireDate = DateTime.Now.AddDays(-3000),
                IsActive = true
            };

            var parameters = new List<IDbDataParameter>();
            parameters.Add(CreateParameter("@CategoryId", 50, product.CategoryId, DbType.String));          
            parameters.Add(CreateParameter("@CompanyId", 50, product.CompanyId, DbType.String));
            parameters.Add(CreateParameter("@UomId", 50, product.UomId, DbType.String));
            parameters.Add(CreateParameter("@Barcode", 50, product.Barcode, DbType.String));
            parameters.Add(CreateParameter("@ProductName", 50, product.ProductName, DbType.String));
            parameters.Add(CreateParameter("@Quantity", 50, product.Quantity, DbType.String));
            parameters.Add(CreateParameter("@PurchasePrice", 50, product.PurchasePrice, DbType.String));
            parameters.Add(CreateParameter("@SalePrice", 50, product.SalePrice, DbType.String));
            parameters.Add(CreateParameter("@ReorderLevel", 50, product.ReorderLevel, DbType.String));
            parameters.Add(CreateParameter("@ReplenishLevel", product.ReplenishLevel, DbType.String));
            parameters.Add(CreateParameter("@ExpireDate", product.ExpireDate, DbType.DateTime));
            parameters.Add(CreateParameter("@IsActive", 50, product.IsActive, DbType.Boolean));

            //use CommandType.StoredProcedure for StoredProcedure
            //use CommandType.Text for Query

            //INSERT OR GET SINGLE COLUMN VALUE
            object lastId = GetScalarValue("InsertProductDetails", CommandType.StoredProcedure, parameters.ToArray());

            //UPDATE/DELETE
          //  ExecuteQuery("Stored Procedure Name", CommandType.StoredProcedure, parameters.ToArray());

            //DATATABLE
          //  var dataTable = GetDataTable("Stored Procedure NAME", CommandType.StoredProcedure);

            //DATAREADER
           /* IDbConnection connection = null;
            var dataReader = GetDataReader("Stored Procedure Name", CommandType.StoredProcedure, null, out connection);
            try
            {
                product = new Product();
                while (dataReader.Read())
                {
                   // product.FirstName = dataReader["FirstName"].ToString();
                   // product.LastName = dataReader["LastName"].ToString();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                dataReader.Close();
                CloseConnection(connection);
            }*/
        }

    }
}
