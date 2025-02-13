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
    public class CreditCardRepository : ICreditCardRepository
    {
        private readonly DapperContext context;

        public CreditCardRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<CreditCardView>> GetCreditCardAsync()
        {
            using (var connection = context.CreateConnection())
            {
                string sql = @"
                            SELECT [FirstName]
                                  ,[LastName]
                                  ,[ClientID]
                                  ,[CardNumber]
                                  ,[Email]
                                  ,[CreditCardID]
                              FROM [vw_CreditCard2]";

                return await connection.QueryAsync<CreditCardView>(sql);
            }
        }
    }
}
