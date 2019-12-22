using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ChainStore.Infrastructure.InfrastructureData
{
    public sealed class PropertyGetter
    {
        public T GetProperty<T>(string tableName, string propertyName, string idColumnName, Guid id)
        {
            if(id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            if(propertyName==null) throw new ArgumentNullException(nameof(propertyName));
            if(tableName==null) throw new ArgumentNullException(nameof(tableName));
            if(idColumnName==null) throw new ArgumentNullException(nameof(idColumnName));
            var con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;database=ChainStoreDB;Trusted_Connection=true");
            var cm = new SqlCommand($"SELECT * FROM {tableName} WHERE {idColumnName} = @Id", con);
            con.Open();
            var param = new SqlParameter("@Id", id);
            cm.Parameters.Add(param);
            var dr = cm.ExecuteReader();
            T data;
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
            con.Close();
            return data;
        }
    }
}
