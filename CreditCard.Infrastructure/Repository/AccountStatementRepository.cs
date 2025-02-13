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
    public class AccountStatementRepository : IAccountStatementRepository
    {
        private readonly DapperContext context;

        public AccountStatementRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AccountStatement>> GetAccountStatementsAsync()
        {
            using (var connection = context.CreateConnection())
            {
                string sql = "SELECT * FROM dbo.vw_AccountStatement";
                return await connection.QueryAsync<AccountStatement>(sql);
            }
        }

        public async Task<AccountStatement> GetAccountStatementByIdAsync(string cardNumber)
        {
            using (var connection = context.CreateConnection())
            {
                // Consulta SQL con filtro por CardNumber
                string sql = "SELECT * FROM dbo.vw_AccountStatement WHERE CardNumber = @CardNumber";

                // Usamos QueryFirstOrDefaultAsync para obtener un solo registro o null si no existe
                return await connection.QueryFirstOrDefaultAsync<AccountStatement>(sql, new { CardNumber = cardNumber });
            }
        }
    }
}
