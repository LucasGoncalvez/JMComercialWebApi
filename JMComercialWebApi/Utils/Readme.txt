Aquí ira un archivo donde trendrá todos los métodos genéricos que se usan en varias clases. Como para recibir de forma
segura los datos desde la base de datos (Ej: reader.GetString() se rompre si recibe un null)

private int? SafeGetInt(SqlDataReader reader, int index)
{
    return reader.IsDBNull(index) ? null : (int?)reader.GetInt32(index);
}