﻿using JMComercialWebApi.Data.Interfaces;
using JMComercialWebApi.Models.Tables;

namespace JMComercialWebApi.Data.Abstracts
{
    public abstract class ArticuloBase : IArticuloAction
    {
        public string _connectionString;
        public ArticuloBase(string connectionString)
        {
            _connectionString = connectionString;
        }
        public abstract Task Add(Articulo entity);

        public abstract Task Delete(int id);

        public abstract Task<Articulo?> Get(int id);

        public abstract Task<List<Articulo>?> GetAll();

        public abstract Task Update(Articulo entity);
    }
}
