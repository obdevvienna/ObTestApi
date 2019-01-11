using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OBTestApi.DbModels
{
    public static class DatabaseInitializer
    {
        public static IWebHost MigrateDatabase(this IWebHost webHost)
        {
            var serviceScopeFactory = (IServiceScopeFactory)webHost.Services.GetService(typeof(IServiceScopeFactory));

            using (var scope = serviceScopeFactory.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<OBDbContext>();
                dbContext.Database.Migrate();
                if (!dbContext.Patient.Any())
                {
                    dbContext.Patient.Add(new Patient()
                    {
                        FirstName = "Otto",
                        LastName = "Bock",
                        ProfileImage = "https://media.ottobock.com/group-site/_general/images/prof_hans_georg_n%C3%A4der_24_9_page.jpg"
                    });

                    dbContext.Patient.Add(new Patient()
                    {
                        FirstName = "Ute",
                        LastName = "Bock",
                        ProfileImage = "http://media.ottobock.com/_web-site/prosthetics/lower-limb/genium/images/genium_opg_2153587_16_9_teaser_twocolumn.jpg"
                    });
                    dbContext.SaveChanges();
                }
            }

            return webHost;
        }
    }
}
