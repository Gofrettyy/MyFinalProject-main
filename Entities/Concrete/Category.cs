using Core.Entities;


namespace Entities.Concrete;
// Çıplak Class kalmasın. Eğer ki sen bir classı bir interface yada inheritance ile implemente etmediysen bil ki ilerde sorun yaşayacaksın.
public class Category:IEntity
{
    public int CategoryId { get; set; }
    public string? CategoryName { get; set; }
}