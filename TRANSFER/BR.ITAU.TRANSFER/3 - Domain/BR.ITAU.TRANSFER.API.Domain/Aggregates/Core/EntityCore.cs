using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;
using ValidationException = System.ComponentModel.DataAnnotations.ValidationException;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace BR.ITAU.TRANSFER.API.Domain.Aggregates.Core
{
    public abstract class EntityCore<T> : AbstractValidator<T> where T : EntityCore<T>
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected EntityCore()
        {
            ValidationResult = new ValidationResult();
        }

        public bool IsValid(T instance) 
        {
            ValidationResult = Validate(instance);
            if (!ValidationResult.IsValid)
            {
                return ValidationResult.IsValid;
            }

            var resultadoValidacao = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
            var contexto = new ValidationContext(instance, null, null);
            Validator.TryValidateObject(instance, contexto, resultadoValidacao, true);
            if (resultadoValidacao.Count > 0)
            {
                StringBuilder msgs = new StringBuilder();
                foreach (var validacao in resultadoValidacao)
                {
                    msgs.Append(validacao.ToString() + "<br/>");
                }

                throw new ValidationException(msgs.ToString());
            }

            return true;
        }

        public void AddValidationResult(ValidationResult validationResult)
        {
            if (validationResult != null)
                foreach (var error in validationResult.Errors)
                    ValidationResult.Errors.Add(error);
        }
    }
}
