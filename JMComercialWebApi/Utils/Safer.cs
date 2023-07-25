using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace JMComercialWebApi.Utils
{
    public static class Safer
    {
        private static T? SafeGetValue<T>(SqlDataReader reader, int index)
        {
            if (!reader.IsDBNull(index))
            {
                return (T)reader[index];
            }
            return default;
        }

        public static int? SafeGetInt(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? null : (int?)reader.GetInt32(index);
        }

        public static string? SafeGetString(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? null : (string?)reader.GetString(index);
        }

        public static bool? SafeGetBoolean(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? null : (bool?)reader.GetBoolean(index);
        }

        public static DateTime? SafeGetDateTime(SqlDataReader reader, int index)
        {
            return reader.IsDBNull(index) ? null : (DateTime?)reader.GetDateTime(index);
        }




        public static int? SafeGetInt(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(column) ? null : (int?)reader.GetInt32(column);
        }

        public static string? SafeGetString(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(column) ? null : (string?)reader.GetString(column);
        }

        public static bool? SafeGetBoolean(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(column) ? null : (bool?)reader.GetBoolean(column);
        }

        public static string? SafeGetDateTime(SqlDataReader reader, string column)
        {
            return reader.IsDBNull(column) ? null : (string?)reader.GetDateTime(column).ToString();
        }
    }
}
