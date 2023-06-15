﻿namespace JMComercialWebApi.Data.Interfaces
{
    //Los metodos basicos que cada entidad debe tener
    public interface IGenericActions<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> Get(int id);
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(int id);
    }
}