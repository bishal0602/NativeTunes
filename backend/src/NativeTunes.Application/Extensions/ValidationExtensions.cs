using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeTunes.Application.Extensions
{
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates using provided fluent validator, parses and returns a ValidationError object if validation fails
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <param name="validator"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<Result<bool, ValidationError>> ValidateAsync<T>(this T instance, AbstractValidator<T> validator, CancellationToken cancellationToken = default)
        {
            ValidationResult validationResult = await validator.ValidateAsync(instance, cancellationToken);
            if (!validationResult.IsValid)
            {
                var validationError = new ValidationError();
                validationResult.Errors.ForEach(e => validationError.ValidationErrorDictionary.Add(e.PropertyName, e.ErrorMessage));
                return validationError;
            }
            return true;
        }
    }
}
