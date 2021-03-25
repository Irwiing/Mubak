using Model;
using System.Collections.Generic;
using System.Data.Entity;

namespace Context
{
    class UserInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            var users = new List<User>
            {
                new User {Login = "admin", Password = "admin", Permission = "Administrator", Name = "Irwing", Situation = "ativo"},
                new User {Login = "user", Password = "user", Permission = "Customer", Name = "Hugo", Situation = "ativo"}
            };

            users.ForEach(user => context.Users.Add(user));
            context.SaveChanges();
        }

    }
}
