﻿namespace CRUD.Core.Domain.Validations
{
    internal class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        {
            
        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainValidationException(error);
        }
    }
}