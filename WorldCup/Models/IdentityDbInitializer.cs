using System.Data.Entity;
using WorldCup.Models;

namespace WorldCup.Data
{
    internal class IdentityDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var role = new ApplicationRole
            {
                Name = "Admin"
            };

            context.Roles.Add(role);

            context.Roles.Add(new ApplicationRole
            {
                Name = "Visitor"
            });

        }
    }
}
