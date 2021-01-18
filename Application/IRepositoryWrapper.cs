using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public interface IRepositoryWrapper
    {
        IProductRepository Product { get; }
        void Save();
    }
}
