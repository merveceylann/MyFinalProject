using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new() //generic constraint
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //bu yapi sayesinde ayri metodlara ihtiyac kalmaz
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

        //List<T> GetAllByCategory(int categoryId);
        //buna ihtiyac kalmadi cunku yukarıda ister filtreli ister filtresiz get metodu yazabiliriz
    }
}
