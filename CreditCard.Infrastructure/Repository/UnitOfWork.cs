using CreditCard.Core.Interfaces;
using CreditCard.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DapperContext _context;
        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private readonly IAccountStatementRepository _accountStatementRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICreditCardRepository _creditCardRepository;

        

        public UnitOfWork(DapperContext context)
        {
            _context = context;
        }


        public IAccountStatementRepository AccountStatementRepository => _accountStatementRepository ?? new AccountStatementRepository(_context);
        public ITransactionRepository TransactionRepository => _transactionRepository ?? new TransactionRepository(_context);
        public ICreditCardRepository CreditCardRepository => _creditCardRepository ?? new CreditCardRepository(_context);

        public void BeginTransaction()
        {
            _connection = _context.CreateConnection();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }
    }
}
