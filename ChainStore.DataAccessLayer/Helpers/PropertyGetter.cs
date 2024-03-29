﻿using System;
using ChainStore.Shared.Util;
using Microsoft.Data.SqlClient;

namespace ChainStore.DataAccessLayer.Helpers;

public sealed class PropertyGetter
{
    public PropertyGetter(string connectionString)
    {
        CustomValidator.ValidateString(connectionString, 0, 400);
        ConnectionString = connectionString;
    }

    public string ConnectionString { get; }

    public T GetProperty<T>(string entityName, string propertyName, string idColumnName, Guid id)
    {
        CustomValidator.ValidateId(id);
        CustomValidator.ValidateString(entityName, 0, 100);
        CustomValidator.ValidateString(propertyName, 0, 100);
        CustomValidator.ValidateString(idColumnName, 0, 100);
        var tableName = GetTableName(entityName);
        var con = new SqlConnection(ConnectionString);
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

    private string GetTableName(string entityName)
    {
        return $"dbo.{entityName}s";
    }
}