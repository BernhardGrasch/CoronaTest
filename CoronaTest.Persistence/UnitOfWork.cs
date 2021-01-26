using CoronaTest.Core.Contracts;
using CoronaTest.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoronaTest.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly ApplicationDbContext _dbContext;
        public VerificationTokenRepository VerificationTokenRepository { get; private set; }
        public IVerificationTokenRepository VerficationRepository { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public UnitOfWork() : this(new ApplicationDbContext())
        {
        }

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            VerificationTokenRepository = new VerificationTokenRepository(_dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                await ValidateEntity(entity);
            }
            return await _dbContext.SaveChangesAsync();
        }

        private Task ValidateEntity(object entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task MigrateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
