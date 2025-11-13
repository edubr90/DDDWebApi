using System.Collections.Generic;

namespace DDDWebApi.Application.Validators
{
 public interface IEntityValidator<T>
 {
 IEnumerable<string> Validate(T entity);
 }
}