using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;

namespace DataAccess.Abstract;

//katmanlarla çalışırken nesneleri public olarak veririz ki diğer katmanlarda o nesneye ulaşabilsin.
public interface ICategoryDal:IEntityRepository<Category>
{
       
}