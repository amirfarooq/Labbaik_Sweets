using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LabaikSweets_POS.DAL
{
   public class DBHelper
    {

        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    var dataset = new DataSet();
                    var dataAdaper = GetDataAdapter(command);
                    dataAdaper.Fill(dataset);

                    return dataset.Tables[0];
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    var dataset = new DataSet();
                    var dataAdaper = GetDataAdapter(command);
                    dataAdaper.Fill(dataset);

                    return dataset;
                }
            }
        }

        public IDataReader GetDataReader(string commandText, CommandType commandType, IDbDataParameter[] parameters, out IDbConnection connection)
        {
            IDataReader reader = null;
            connection = GetConnection();

            var command = GetCommand(commandText, connection, commandType);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }

            reader = command.ExecuteReader();

            return reader;
        }

        public int ExecuteQuery(string commandText, CommandType commandType, IDbDataParameter[] parameters)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteNonQuery();
                }
            }
        }

        public object GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[] parameters = null)
        {
            using (var connection = GetConnection())
            {
                using (var command = GetCommand(commandText, connection, commandType))
                {
                    if (parameters != null)
                    {
                        foreach (var parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    return command.ExecuteScalar();
                }
            }
        }

        public IDbConnection GetConnection()
        {
            try
            {
                var connection = new SqlConnection(CConfig.CONNECTIONSTRING);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                throw new Exception("Error occured while creating connection. Please check connection string and provider name.");
            }
        }

        public void CloseConnection(IDbConnection connection)
        {
            CloseConnection(connection);
        }

        public IDbCommand GetCommand(string commandText, IDbConnection connection, CommandType commandType)
        {
            try
            {
                IDbCommand command = new SqlCommand();
                command.CommandText = commandText;
                command.Connection = connection;
                command.CommandType = commandType;

                return command;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter 'commandText'.");
            }
        }

        public DbDataAdapter GetDataAdapter(IDbCommand command)
        {
            DbDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = (DbCommand)command;
            adapter.InsertCommand = (DbCommand)command;
            adapter.UpdateCommand = (DbCommand)command;
            adapter.DeleteCommand = (DbCommand)command;
            return adapter;
        }

        public IDbDataParameter CreateParameter(string name, object value)
        {
            return GetParameter(name, value);
        }

        public IDbDataParameter CreateParameter(string name, object value, DbType dbType)
        {
            return GetParameter(name, value, dbType, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType)
        {
            return GetParameter(name, value, dbType, size, ParameterDirection.Input);
        }

        public IDbDataParameter CreateParameter(string name, int size, object value, DbType dbType, ParameterDirection direction)
        {
            return GetParameter(name, value, dbType, size, direction);
        }

        public DbParameter GetParameter(string name, object value)
        {
            try
            {
                DbParameter dbParam = new SqlParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = ParameterDirection.Input;
                return dbParam;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter or type.");
            }
        }

        public DbParameter GetParameter(string name, object value, DbType dbType)
        {
            try
            {
                DbParameter dbParam = new SqlParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = ParameterDirection.Input;
                dbParam.DbType = dbType;

                return dbParam;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter or type.");
            }
        }

        public DbParameter GetParameter(string name, object value, DbType dbType, ParameterDirection parameterDirection)
        {
            try
            {
                DbParameter dbParam = new SqlParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Direction = parameterDirection;
                dbParam.DbType = dbType;

                return dbParam;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter or type.");
            }
        }

        public DbParameter GetParameter(string name, object value, DbType dbType, int size, ParameterDirection parameterDirection)
        {
            try
            {
                DbParameter dbParam = new SqlParameter();
                dbParam.ParameterName = name;
                dbParam.Value = value;
                dbParam.Size = size;
                dbParam.Direction = parameterDirection;
                dbParam.DbType = dbType;

                return dbParam;
            }
            catch (Exception)
            {
                throw new Exception("Invalid parameter or type.");
            }
        }

        public static List<T> ConvertDataTableToList<T>(DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();
                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch
            {
                return null;
            }
        }
    }
}
