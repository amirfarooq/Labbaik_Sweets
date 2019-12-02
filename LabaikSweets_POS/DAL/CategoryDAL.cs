using LabaikSweets_POS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabaikSweets_POS.DAL
{
    public class CategoryDAL : DBHelper
    {
        public int ManageCategory(string categoryName)
        {
            int result = 0;
            var parameters = new List<IDbDataParameter>();
            parameters.Add(CreateParameter("@categoryName", categoryName));
            object category = GetScalarValue("dbo.InsertCategory", CommandType.StoredProcedure, parameters.ToArray());
            int.TryParse(Convert.ToString(category), out result);
            return result;
        }

        public List<CategoryModel> GetAllCategories(string filter = "")
        {
            List<CategoryModel> list = new List<CategoryModel>();
            var datatable = GetDataTable("dbo.SP_GetAllCategories", CommandType.StoredProcedure);
            return ConvertDataTableToList<CategoryModel>(datatable);
        }

       /* private void TestMethod()
        {
            var user = new Product
            {
                FirstName = "First",
                LastName = "Last",
                Dob = DateTime.Now.AddDays(-3000),
                IsActive = true
            };

            var parameters = new List<IDbDataParameter>();
            parameters.Add(CreateParameter("@FirstName", 50, user.FirstName, DbType.String));
            parameters.Add(CreateParameter("@LastName", user.LastName, DbType.String));
            parameters.Add(CreateParameter("@Dob", user.Dob, DbType.DateTime));
            parameters.Add(CreateParameter("@IsActive", 50, user.IsActive, DbType.Boolean));

            //use CommandType.StoredProcedure for StoredProcedure
            //use CommandType.Text for Query

            //INSERT OR GET SINGLE COLUMN VALUE
            object lastId = GetScalarValue("Stored Procedure Name", CommandType.StoredProcedure, parameters.ToArray());

            //UPDATE/DELETE
            ExecuteQuery("Stored Procedure Name", CommandType.StoredProcedure, parameters.ToArray());

            //DATATABLE
            var dataTable = GetDataTable("Stored Procedure NAME", CommandType.StoredProcedure);

            //DATAREADER
            IDbConnection connection = null;
            var dataReader = GetDataReader("Stored Procedure Name", CommandType.StoredProcedure, null, out connection);
            try
            {
                user = new Product();
                while (dataReader.Read())
                {
                    user.FirstName = dataReader["FirstName"].ToString();
                    user.LastName = dataReader["LastName"].ToString();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                dataReader.Close();
                CloseConnection(connection);
            }
        }*/

    }
}
