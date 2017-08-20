using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Data
{
    public class DbInitializer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreated();

            if (context.Organizations.Any())
            {
                return;   // DB has been seeded
            }

            addOrganizations(context);

        }

        private static void addOrganizations(ApiContext context)
        {
            var organizations = new Organization[]
            {
                new Organization{ Code = "ggc", DisplayName = "Georgia Gwinnett College" },
                new Organization{ Code = "uga", DisplayName = "University of Georgia" },
                new Organization{ Code = "ksu", DisplayName = "Kentucky State University" },
                new Organization{ Code = "gsu", DisplayName = "Georgia State University" }
            };
            foreach (Organization c in organizations)
            {
                context.Organizations.Add(c);
            }
            context.SaveChanges();
        }
    }
}
