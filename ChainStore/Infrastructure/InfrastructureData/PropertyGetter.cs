using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ChainStore.Infrastructure.InfrastructureData
{
    public sealed class PropertyGetter
    {
        private readonly IConfiguration _configuration;

        public PropertyGetter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public T GetProperty<T>(string tableName, string propertyName, string idColumnName, Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            if (propertyName == null) throw new ArgumentNullException(nameof(propertyName));
            if (tableName == null) throw new ArgumentNullException(nameof(tableName));
            if (idColumnName == null) throw new ArgumentNullException(nameof(idColumnName));
            var con = new SqlConnection(_configuration.GetConnectionString("ChainStoreDBConnection"));
            var cm = new SqlCommand($"SELECT * FROM {tableName} WHERE {idColumnName} = @Id", con);
            con.Open();
            var param = new SqlParameter("@Id", id);
            cm.Parameters.Add(param);
            T data;
            try
            {
                var dr = cm.ExecuteReader();
                try
                {
                    data = dr.Read() ? (T) dr[propertyName] : default;
                }
                catch (IndexOutOfRangeException)
                {
                    data = default;
                }
                catch (InvalidCastException)
                {
                    data = default;
                }
                finally
                {
                    dr.Close();
                }
            }
            catch (SqlException)
            {
                data = default;
            }

            con.Close();
            return data;
        }
    }
}