using Microsoft.Data.SqlClient;

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
    }
}
