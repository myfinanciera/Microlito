using System.Collections.Generic;
using System.Threading.Tasks;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;

namespace Siigo.Microservice.Domain.Services
{
    public sealed class BankService: IBankService<Bank>
    {
        private readonly IBankFinder<Bank> _bankFinder;
        private readonly IBankRepository<Bank> _bankRepository;

        public BankService(IBankFinder<Bank> bankFinder,
            IBankRepository<Bank> bankRepository)
        {
            _bankFinder = bankFinder;
            _bankRepository = bankRepository;
        }

        public Task<IEnumerable<Bank>> FindBankByIdAsync(string id)
        {
            return _bankFinder.FindBankByIdAsync(id);
        }

        public Task<IEnumerable<Bank>> FindBanksAsync()
        {
            return _bankFinder.FindBanksAsync();
        }

        public  Task CreateAsync(Bank bank)
        {
             return _bankRepository.CreateAsync(bank);
        }

        public  Task UpdateAsync(Bank bank)
        {
            // update aggregate 
           return _bankRepository.UpdateAsync(bank);
        }

       
    }
}