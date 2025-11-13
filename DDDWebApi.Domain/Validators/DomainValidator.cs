using System.Collections.Generic;
using System.Linq;
using DDDWebApi.Domain.Specifications;

namespace DDDWebApi.Domain.Validators
{
 public static class DomainValidator
 {
 public static IEnumerable<string> Validate<T>(T entity, IEnumerable<ISpecification<T>> specifications)
 {
 return specifications.SelectMany(s => s.Validate(entity)).Where(m => !string.IsNullOrWhiteSpace(m));
 }
 }
}