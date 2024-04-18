using System;
using Model;
using DataAccess.DAOs;

namespace DataAccess.CRUD
{
        public abstract class CrudFactory
        {

            protected SqlDao _dao;
            public abstract void Create(BaseModel baseModel);
            public abstract T RetrieveById<T>(int id);
            public abstract List<T> RetrieveAll<T>();
            public abstract void Update(BaseModel baseModel, int id);
            public abstract void Delete(int id);
        }
}

