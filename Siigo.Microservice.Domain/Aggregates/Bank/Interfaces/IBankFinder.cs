using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siigo.Microservice.Domain.Aggregates.Bank.Interfaces {

    public interface IBankFinder<T>
    {
        Task<IEnumerable<T>> FindBankByIdAsync(string id);
        
        Task<IEnumerable<T>> FindBanksAsync();
    }
}
