using System.Collections.Generic;

namespace DDDWebApi.Domain.Specifications
{
    public interface ISpecification<T>
    {
        /// <summary>
        /// Validate the candidate and return zero or more error messages. Empty means valid.
        /// </summary>
        IEnumerable<string> Validate(T candidate);
    }
}