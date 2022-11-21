using CupApplication.Data;
using CupApplication.Data.Models;
using CupApplication.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CupApplication.Data.Models;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace CupApplication.Data
{

    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.DB_BenefitType.Any())
            {
                content.AddRange(
                    new BenefitType {Group = "Администрация", Koefficient = 0 },
                    new BenefitType {Group = "Охрана", Koefficient = (float)0.8 },
                    new BenefitType {Group = "Сотрудник", Koefficient = (float)0.8 }
                    );
                Log.Debug("Инициализация таблицы DB_BenefitType произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_BenefitType не требуется");
            content.SaveChanges();

            if (!content.DB_Beneficiaries.Any())
            {
                content.AddRange(
                    new Beneficiaries { Name = "Иванов Иван Иваныч", GroupObj = content.DB_BenefitType.FirstOrDefault(p => p.Group == "Администрация") },
                    new Beneficiaries { Name = "Охранов Охран Охраныч", GroupObj = content.DB_BenefitType.FirstOrDefault(p => p.Group == "Охрана") },
                    new Beneficiaries { Name = "Русланов Руслан Русланыч", GroupObj = content.DB_BenefitType.FirstOrDefault(p => p.Group == "Администрация") },
                    new Beneficiaries { Name = "Ленанов Ленон Ленаныч",GroupObj = content.DB_BenefitType.FirstOrDefault(p => p.Group == "Сотрудник") }
                    );
                Log.Debug("Инициализация таблицы DB_Beneficiaries произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_Beneficiaries не требуется");


            if (!content.DB_Drinks.Any())
            {
                content.AddRange(
                    new Drinks { Name = "Американо 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Зерно Арабика" },
                    new Drinks { Name = "Американо 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Зерно Арабика" },
                    new Drinks { Name = "Американо 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Зерно Арабика" },
                    new Drinks { Name = "Американо Стекло", Price = 120, Cup = "Стекло", Source1 = "Зерно Арабика" },
                    new Drinks { Name = "Горячий шоколад 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Шоколад", Source2 = "Молоко" },
                    new Drinks { Name = "Горячий шоколад 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Шоколад", Source2 = "Молоко" },
                    new Drinks { Name = "Горячий шоколад 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Шоколад", Source2 = "Молоко" },
                    new Drinks { Name = "Горячий шоколад Стекло", Price = 120, Cup = "Стекло", Source1 = "Шоколад", Source2 = "Молоко" },
                    new Drinks { Name = "Какао 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Какао порошек", Source2 = "Молоко" },
                    new Drinks { Name = "Какао 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Какао порошек", Source2 = "Молоко" },
                    new Drinks { Name = "Какао 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Какао порошек", Source2 = "Молоко" },
                    new Drinks { Name = "Какао Стекло", Price = 120, Cup = "Стекло", Source1 = "Какао порошек", Source2 = "Молоко" },
                    new Drinks { Name = "Капучино 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Капучино 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Капучино 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Капучино Стекло", Price = 120, Cup = "Стекло", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Латте 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Латте 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Латте 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Латте Стекло", Price = 120, Cup = "Стекло", Source1 = "Зерно Арабика", Source2 = "Молоко" },
                    new Drinks { Name = "Мокко 250", Price = 80, Cup = "Стаканчик 250", Source1 = "Зерно Арабика", Source2 = "Шоколад", Source3 = "Молоко" },
                    new Drinks { Name = "Мокко 350", Price = 100, Cup = "Стаканчик 350", Source1 = "Зерно Арабика", Source2 = "Шоколад", Source3 = "Молоко" },
                    new Drinks { Name = "Мокко 450", Price = 120, Cup = "Стаканчик 450", Source1 = "Зерно Арабика", Source2 = "Шоколад", Source3 = "Молоко" },
                    new Drinks { Name = "Мокко Стекло", Price = 120, Cup = "Стекло", Source1 = "Зерно Арабика", Source2 = "Шоколад", Source3 = "Молоко" }
                    );
                Log.Debug("Инициализация таблицы DB_Drinks произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_Drinks не требуется");

            if (!content.DB_Drinks_leftovers.Any())
            {
                content.AddRange(
                    new Drinks_leftovers { Name = "Зерно Арабика", Amount = (float)1.92, Price = 1000 },
                    new Drinks_leftovers { Name = "Зерно Арабика + Робуста", Amount = (float)0, Price = 800 },
                    new Drinks_leftovers { Name = "Стаканчик 250", Amount = 10, Price = 10 },
                    new Drinks_leftovers { Name = "Стаканчик 350", Amount = 10, Price = 10 },
                    new Drinks_leftovers { Name = "Стаканчик 450", Amount = 10, Price = 20 }
                    );
                Log.Debug("Инициализация таблицы DB_Drinks_leftovers произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_Drinks_leftovers не требуется");

            if (!content.DB_Products.Any())
            {
                content.AddRange(
                    new Products { Name = "Клубничный сироп", VolumeInStock = (float)0.8, Price = 800, PortionVolume = (float)0.01, PortionPrice = 25 },
                    new Products { Name = "Ванильный сироп", VolumeInStock = (float)0.8, Price = 800, PortionVolume = (float)0.01, PortionPrice = 25 },
                    new Products { Name = "Мятный сироп", VolumeInStock = (float)0.8, Price = 800, PortionVolume = (float)0.01, PortionPrice = 25 },
                    new Products { Name = "Карамельный сироп", VolumeInStock = (float)0.8, Price = 800, PortionVolume = (float)0.01, PortionPrice = 25 },
                    new Products { Name = "Доктор Эггман", VolumeInStock = 1, Price = 500, PortionVolume = 1, PortionPrice = 500 },
                    new Products { Name = "Чоко Пай", VolumeInStock = 10, Price = 50, PortionVolume = 1, PortionPrice = 50 },
                    new Products { Name = "Печенье", VolumeInStock = 10, Price = 100, PortionVolume = 1, PortionPrice = 100 }
                    );
                Log.Debug("Инициализация таблицы DB_Products произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_Products не требуется");

            if (!content.DB_WorkingSession.Any())
            {
                content.AddRange(
                    new WorkingSession { OpenDate = "01.01.0001", OpenTime = "00:00:00", CloseDate = "11.01.0001", CloseTime = "00:00:00", Name = "Русланов Руслан Русланы", WorkerID = 1 }
                    );
                Log.Debug("Инициализация таблицы DB_WorkingSession произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_WorkingSession не требуется");

            if (!content.DB_Sales.Any())
            {
                content.AddRange(
                    new Sales { Date = "01.01.0001", Time = "00:00:10", WorkingTimeId = 1, WorkerId = 1, Cup1_ID = 1, Cup1_Amount = 1, Paid = 100 }
                    );
                Log.Debug("Инициализация таблицы DB_Sales произведена");
            }
            else
                Log.Debug("Инициализация таблицы DB_Sales не требуется");

            content.SaveChanges();
            Log.Debug("Изменения БД сохранены");
        }

    }

}
