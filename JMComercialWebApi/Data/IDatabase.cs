namespace JMComercialWebApi.Data
{
    public interface IDatabase
    {
        public dynamic _personaActions { get; set; }
        public string GetConectionString();
    }
}
