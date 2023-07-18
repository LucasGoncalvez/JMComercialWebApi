namespace JMComercialWebApi.Data
{
    public interface IDatabase
    {
        public dynamic _personaActions { get; set; }
        public dynamic _ubicacionAction { get; set; }
        public string GetConectionString();
    }
}
