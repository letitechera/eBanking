using eBanking.Model.DBModel;
using System.Collections.Generic;
using System.Data.Entity;

namespace eBanking.DAL
{
    public class eBankingInitializer : DropCreateDatabaseIfModelChanges<eBankingContext>
    {
        protected override void Seed(eBankingContext context)
        {
            var types = new List<AccountType>{
                new AccountType()
                {
                    Name = "Caja de ahorro"
                },
                new AccountType()
                {
                    Name = "Cuenta corriente"
                }
            };
            context.AccountTypes.AddRange(types);

            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@gmail.com",
                IdNumber = "44815237",
            };

            var newUser = context.Users.Add(user);
            context.SaveChanges();

            var accounts = new List<Account>{
                new Account()
                {
                    Id = 0,
                    Balance = 500,
                    UserId = 1,
                    AccountTypeId = 1,
                },
                new Account()
                {
                    Id = 0,
                    Balance = 600,
                    UserId = 1,
                    AccountTypeId = 2,
                }
            };
            context.Accounts.AddRange(accounts);
            context.SaveChanges();
        }
    }
}

