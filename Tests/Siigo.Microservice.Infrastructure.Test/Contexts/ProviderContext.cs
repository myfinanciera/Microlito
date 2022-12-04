using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Siigo.Core.Provider.Context;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;

namespace Siigo.Microservice.Infrastructure.Test.Contexts;

    /// <summary>
    /// Provider context used to unit test
    /// </summary>
    public sealed class ProviderContext : DbContextBase
    {
        /// <summary>
        /// Get the Current Transaction Context
        /// </summary>
        public IDbContextTransaction CurrentTransaction => base.GetCurrentTransaction();

        /// <summary>
        /// Initialize a new instance of the <see cref="ProviderContext"/>
        /// </summary>
        /// <param name="options">The options for this context.</param>
        /// <param name="serviceProvider">Service Provider</param>
        public ProviderContext([NotNull] DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        /// <summary>
        /// Config Model
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Bank>().Property(x => x.Name).HasMaxLength(100);
            

            //base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// This method is used to internal test
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous transaction initialization. 
        /// </returns>
        public Task<IDbContextTransaction> BeginTransactionInternalAsync()
        {
            return base.BeginTransactionAsync();
        }

        /// <summary>
        /// This method is used to internal test
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public Task CommitTransactionInternalAsync()
        {
            return base.CommitTransactionAsync();
        }

        /// <summary>
        /// This method is used to internal test
        /// </summary>
        public void RollbackTransactionInternal()
        {
            base.RollbackTransaction();
        }

        /// <summary>
        /// Gets or sets the bank
        /// </summary>
        public DbSet<Bank> Bank { get; set; }

    }
