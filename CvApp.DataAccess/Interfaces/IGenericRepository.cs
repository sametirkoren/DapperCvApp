using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.DataAccess.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class , ITable , new()
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
