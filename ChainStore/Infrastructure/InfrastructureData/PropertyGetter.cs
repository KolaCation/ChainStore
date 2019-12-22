using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace ChainStore.Infrastructure.InfrastructureData
{
    public sealed class PropertyGetter<T>
    {
        public T GetProperty(Guid clientId, string propertyName)
        {
            if(clientId.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(clientId));
            if(propertyName==null) throw new ArgumentNullException(nameof(propertyName));
            var con = new SqlConnection("server=(localdb)\\MSSQLLocalDB;database=ChainStoreDB;Trusted_Connection=true");
            var cm = new SqlCommand("SELECT * FROM dbo.Clients WHERE ClientId = @ClientId", con);
            con.Open();
            var param = new SqlParameter("@ClientId", clientId);
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
            con.Close();
            return data;
        }
    }
}
