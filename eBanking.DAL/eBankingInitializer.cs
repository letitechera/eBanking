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
                    Name = "Pesos"
                },
                new AccountType()
                {
                    Name = "Dolares"
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
            var accounts = new List<Account>{
                new Account()
                {
                    Balance = 500,
                    UserId = newUser.Id,
                    AccountTypeId = 1,
                },
                new Account()
                {
                    Balance = 600,
                    UserId = newUser.Id,
                    AccountTypeId = 2,
                }
            };
            context.SaveChanges();
        }
    }
}

