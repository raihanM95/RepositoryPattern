using Application;
using Application.Interfaces;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Service
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IProductRepository _product;
        
        public IProductRepository Product
        {
            get
            {
                if (_product == null)
                {
                    _product = new ProductRepository(_repoContext);
                }
                return _product;
            }
        }
        
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
