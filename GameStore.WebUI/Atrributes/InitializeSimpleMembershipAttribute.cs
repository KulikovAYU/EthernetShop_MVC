using System;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using GameStore.Domain.EMDB;
using GameStore.Domain.EMDB.Repositories.DBContext;
using WebMatrix.WebData;


namespace MvcInternetApplication.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeSimpleMembershipAttribute : ActionFilterAttribute
    {
        private static SimpleMembershipInitializer _initializer;
        private static object _initializerLock = new object();
        private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Инициализация ASP.NET Simple Membership происходит один раз при старте приложения
            LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
               

                //Database.SetInitializer<IUnitOfWork>(null);

                try
                {
                    using (var uio = new UnitOfWork(new EFDbContext()))
                    {
                        if (uio == null)
                        {
                            ((IObjectContextAdapter)uio).ObjectContext.CreateDatabase();
                        }
                    }



                    ////IUnitOfWork uio = null;
                    //using (var context = new UsersContext())
                    //{
                    //    if (!context.Database.Exists())
                    //    {
                    //        // Создание базы данных SimpleMembership без применения миграции Entity Framework
                    //        ((IObjectContextAdapter)uio).ObjectContext.CreateDatabase();
                    //    }
                    //}
                    // Настройка  ASP.NET Simple Membership
                    // 1 параметр - имя строки подключения к базе данных.
                    // 2 параметр - таблица, которая содержит информацию о пользователях
                    // 3 параметр - имя колонки в таблице, которая отвечает за хранение логина
                    // 4 параметр - autoCreateTables автоматическое создание таблиц если они не существуют в базе
                    //string connectionString =
                    //    ConfigurationManager.ConnectionStrings["EFDbContext"].ConnectionString;
                    WebSecurity.InitializeDatabaseConnection("EFDbContext", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                }
            }
        }
    }
}

