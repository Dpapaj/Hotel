﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Repositories.Interface
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T:class;
        void save();
    }
}
