

using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object entity)
    {
        var context = new ValidationContext<object>(entity);
       var result = validator.Validate(context);
        if (!result.IsValid)
        {
            throw new ValidationException(result.Errors);
        }
    }
}

//log:Yapılan operasyonların bir yerde kaydını tutmak.Method başında ve bitiminde çalıştırabiliriz. Dependency Injection yapılarak kullanılır.
//Cache
//Transaction
//Auth 
//performans yönetimi en yaygın cross cutting concernlerdir. 