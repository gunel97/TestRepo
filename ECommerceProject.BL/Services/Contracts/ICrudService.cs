﻿using ECommerceProject.DA.DataContext.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceProject.BL.Services.Contracts
{
    public interface ICrudService<TEntity, TViewModel, TCreateViewModel, TUpdateViewModel> where TEntity:Entity
    {
        Task<IEnumerable<TViewModel>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool AsNoTracking = false);

        Task<TViewModel?> GetAsync(Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool AsNoTracking = false);

        Task<TViewModel?> GetByIdAsync(int id);

        Task CreateAsync(TCreateViewModel model);

        Task<bool> UpdateAsync(int id, TUpdateViewModel model);

        Task<bool> DeleteAsync(int id);
    }
}
