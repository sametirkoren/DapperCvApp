using CvApp.Business.Interfaces;
using CvApp.DataAccess.Interfaces;
using CvApp.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CvApp.Business.Concrete
{
    public class GenericManager<TEntity> : IGenericService<TEntity> where TEntity : class, ITable, new()
    {
        private readonly IGenericRepository<TEntity> _genericRepository;

        public GenericManager(IGenericRepository<TEntity> genericRepository)
        {
            _genericRepository = genericRepository;
            
        }

        public void Delete(TEntity entity)
        {
            _genericRepository.Delete(entity);
        }

        public List<TEntity> GetAll()
        {
            return _genericRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public void Insert(TEntity entity)
        {
            _genericRepository.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            _genericRepository.Update(entity);
        }
    }
}
