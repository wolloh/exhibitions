using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exhibitions.Context.Setup
{
    public static class DbSeeder
    {
        private static IServiceScope ServiceScope(IServiceProvider serviceProvider) => serviceProvider.GetService<IServiceScopeFactory>()!.CreateScope();
        private static MainDbContext DbContext(IServiceProvider serviceProvider) => ServiceScope(serviceProvider).ServiceProvider.GetRequiredService<IDbContextFactory<MainDbContext>>().CreateDbContext();

        //private static readonly string masterUserName = "Admin";
        //private static readonly string masterUserEmail = "admin@dsrnetscool.com";
        //private static readonly string masterUserPassword = "Pass123#";

        //private static void ConfigureAdministrator(IServiceScope scope)
        //{
        //    //    var defaults = scope.ServiceProvider.GetService<IDefaultsSettings>();

        //    //    if (defaults != null)
        //    //    {
        //    //        var userService = scope.ServiceProvider.GetService<IUserService>();
        //    //        if (addAdmin && (!userService?.Any() ?? false))
        //    //        {
        //    //            var user = userService.Create(new CreateUserModel
        //    //            {
        //    //                Type = UserType.ForPortal,
        //    //                Status = UserStatus.Active,
        //    //                Name = defaults.AdministratorName,
        //    //                Password = defaults.AdministratorPassword,
        //    //                Email = defaults.AdministratorEmail,
        //    //                IsEmailConfirmed = !defaults.AdministratorEmail.IsNullOrEmpty(),
        //    //                Phone = null,
        //    //                IsPhoneConfirmed = false,
        //    //                IsChangePasswordNeeded = true
        //    //            })
        //    //                .GetAwaiter()
        //    //                .GetResult();

        //    //            userService.SetUserRoles(user.Id, Infrastructure.User.UserRole.Administrator).GetAwaiter().GetResult();
        //    //        }
        //    //    }
        //}

        public static void Execute(IServiceProvider serviceProvider, bool addDemoData, bool addAdmin = true)
        {
            using var scope = ServiceScope(serviceProvider);
            ArgumentNullException.ThrowIfNull(scope);

            //if (addAdmin)
            //{
            //    ConfigureAdministrator(scope);
            //}

            if (addDemoData)
            {
                Task.Run(async () =>
                {
                    await ConfigureDemoData(serviceProvider);
                });
            }
        }

        private static async Task ConfigureDemoData(IServiceProvider serviceProvider)
        {
            await AddExhibitions(serviceProvider);
        }

        private static async Task AddExhibitions(IServiceProvider serviceProvider)
        {
            await using var context = DbContext(serviceProvider);


            if (context.Exhibitions.Any() || context.Comments.Any() || context.Categories.Any() || context.Photos.Any())
                return;

            var c1 = new Entities.Category()
            {
                Name = "General"
            };
            context.Categories.Add(c1);
            var e1 = new Entities.Exhibition()
            {
                Name = "Монопородная выставка \" АМЕРИКАНСКАЯ АКИТА\"",
                Place= "Тульская область, город Чехов, наб. Балканская, 01",
                Categories=new List<Entities.Category>() {c1 },
                Date= DateTime.Now,
            };
            context.Exhibitions.Add(e1);

            var guid = Guid.NewGuid();
            var bytes = guid.ToByteArray();
            var rawValue = BitConverter.ToInt64(bytes, 0);
            var inRangeValue = Math.Abs(rawValue) % DateTime.MaxValue.Ticks;

            var e2 = new Entities.Exhibition()
            {
                Name = "МОНОПОРОДНАЯ ВЫСТАВКА \" СРЕДНЕАЗИАТСКАЯ ОВЧАРКА\" РАНГ КЧК",
                Place = "Курганская область, город Серпухов, шоссе Косиора, 43",
                Categories = new List<Entities.Category>() { c1 },
                Date= new DateTime(inRangeValue),
        };
            context.Exhibitions.Add(e2);



            //var cm1 = new Entities.Comment()
            //{
            //   Message="Nice exhibitions",
            //   Time_Published= DateTime.Now,
            //   Exhibition=e1,
            //   Author=null,
            //};
            //context.Comments.Add(cm1);        

            context.SaveChanges();
        }
    }
}
