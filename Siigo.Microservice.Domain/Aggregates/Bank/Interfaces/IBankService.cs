using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siigo.Microservice.Domain.Aggregates.Bank.Interfaces
{
    public interface IBankService<T> : IBankFinder<T>, IBankRepository<T>
    {
        
    }
}
