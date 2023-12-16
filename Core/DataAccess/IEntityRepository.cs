using System.Linq.Expressions;
using Core.Entities;

namespace Core.DataAccess;
//Generic Constrait Generic Kısıt
//class referans tip olabilir demek
//IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
//  Claslarda IEntity imkanlarından yararlanmak istiyorum ama classlarda Ientityi kullanmak istemiyorum çünkü soyut bir nesne o yüzden yanına  new() ekledik
//new() : newlenebilir olmalı demektir.
public interface IEntityRepository<T> where T :class,IEntity,new()
{
  T Get(Expression<Func<T,bool>>filter);
    
    List<T> GetAll(Expression<Func<T,bool>>filter=null);
    void Add(T entity);

    void Update(T entity);

    void Delete(T entity);
}
// Generic nesnelerde ilk 5i ve Idye göre getirme olur.