using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Project1.Controllers;
using Project1.Models;
using ReactApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1
{
    public class Program
    {
        public static void Main(string[] args)
        { // добавление данных
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта 
                Phone phone1 = new Phone { Id = "1" , Name = "Привет", Price = 123 };
                Phone phone2 = new Phone { Id = "2" , Name = "Как дела?",  Price = 456 };

                // добавляем их в бд
                db.Phones.AddRange(phone1, phone2);
              // db.SaveChanges();
            }
            // получение данных
            /*using (ApplicationContext db = new ApplicationContext())
            {
                // получаем объекты из бд и выводим на консоль
                var users = db.Phones.ToList();
                Console.WriteLine("Phones list:");
                foreach (Phone u in users)
                {
                    Console.WriteLine($"{u.Id}.{u.Name} - {u.Price}");
                }
            }*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
