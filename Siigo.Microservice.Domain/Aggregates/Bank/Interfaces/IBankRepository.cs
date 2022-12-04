using System.Threading.Tasks;

namespace Siigo.Microservice.Domain.Aggregates.Bank.Interfaces
{
    
    public interface IBankRepository<in T>
    {
        public Task CreateAsync(T bank);

        public Task UpdateAsync(T bank);

    }
}