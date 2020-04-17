using DomainValidation.Validation;
using System.Collections.Generic;

namespace PGD.Infra.Data.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        List<ValidationError> Commit();
        void AtivarLogs(bool logAtivo);
    }
}
