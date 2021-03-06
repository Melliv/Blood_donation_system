using System;
using System.Collections.Generic;
using Contracts.Domain.Base;

namespace Contracts.DAL.Base.Repositories
{
    public interface IBaseRepositoryCommon<TEntity, TKey>
        where TEntity : class, IDomainEntityId<TKey> // any more rules? maybe ID?
        where TKey : IEquatable<TKey>
    {
        // common
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entity);
        TEntity Remove(TEntity entity, TKey? userId = default);
        
    }

}