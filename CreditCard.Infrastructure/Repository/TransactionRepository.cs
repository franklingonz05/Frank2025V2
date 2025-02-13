using AutoMapper;
using CreditCard.Core.Domain.Entity;
using CreditCard.Core.Interfaces;
using CreditCard.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly DapperContext context;

        public TransactionRepository(DapperContext context)
        {
            this.context = context;
        }


        public async Task<int> RegisterTransactionAsync(Transactions transaction)
        {
            using (var connection = context.CreateConnection())
            {

                string sql = "EXEC dbo.sp_RegisterTransaction @CreditCardID, @Type, @Amount, @TransactionDate, @Description";

                return await connection.ExecuteScalarAsync<int>(sql, transaction);
            }
        }

        public async Task<IEnumerable<TransactionView>> GetTransactionsByCardForCurrentMonthAsync(string cardNumber)
        {
            using (var connection = context.CreateConnection())
            {
                string sql = @"
            SELECT 
                TransactionID, 
                TransactionDate,
                Amount,
                Description,
                CodeType,
                Type,
                CreditCardID
            FROM vw_TransactionList
            WHERE 
                MONTH(TransactionDate) = MONTH(GETDATE()) 
                AND YEAR(TransactionDate) = YEAR(GETDATE()) 
                AND CardNumber = @CardNumber
            ORDER BY TransactionDate ASC";

                return await connection.QueryAsync<TransactionView>(sql, new { CardNumber = cardNumber });
            }
        }
    }
}
