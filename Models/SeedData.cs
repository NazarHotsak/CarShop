using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace CheapCars.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (context.Cars.Any() == false)
            {
                context.AddRange
                (
                    new Car
                    {
                        Name = "Honda fit",
                        Status = StatusCar.InStock,
                        Brand = "Honda",
                        Year = 2006,
                        Price = 536000,
                        EngineCapacity = 42,
                        Mileage = 0,
                        DriveType = DriveType.rearWheel,
                        Gearbox = "Вариатор",
                        Cut = false,
                        FullDuty = true,
                        Color = "Red",
                        Description = "Honda Fit/Jazz — японский легковой автомобиль, принадлежащий к сегменту B по европейской классификации. " +
                        "Под именем Fit автомобиль известен в Японии, Китае, Северной и Южной Америке. Под названием Jazz — в Европе, некоторых странах Азии," +
                        " в Австралии, Океании, на Среднем Востоке и в Африке. У себя на родине, в Японии, дважды выбирался «Автомобилем года»: 2001—2002 гг.[1], " +
                        "2007—2008 гг.[2] Выпускались автомобили с гибридной силовой установкой Fit/Jazz Hybrid и электромобили Fit EV." +
                        "Ранее в Европу уже поставлялся компактный хэтчбек Honda City первого поколения(1981—1986 гг.) под названием Honda " +
                        "Jazz.В начале 1990 - х годов топовые комплектации второго поколения Honda City GA2 на внутреннем японском рынке имели название Honda City Fit.",
                        Location = "Японія"
                    },
                    new Car
                    {
                        Name = "Nissan Micra",
                        Status = StatusCar.OnOrder,
                        Brand = "Nissan",
                        Year = 2004,
                        Price = 785000,
                        EngineCapacity = 39,
                        Mileage = 75843,
                        DriveType = DriveType.rearWheel,
                        Gearbox = "Вариатор",
                        Cut = false,
                        FullDuty = true,
                        Color = "White",
                        Description = "В 1976 году известный итальянский дизайнер Джорджетто Джуджаро представил руководству компании Nissan свои предложения по компактному автомобилю для европейского рынка. В это время " +
                        "на фирме уже работали над подобным проектом, но показанные Джуджаро эскизы имели оригинальный и стильный дизайн и были по достоинству оценены[3]. На их основе и с использованием " +
                        " собственных наработок под началом Наганори Ито (англ. Naganori Ito) был создан прототип будущего автомобиля, показанный на Токийском автосалоне 1981 года под кодом NX-018[4]. Для выбора " +
                        " настоящего имени новой модели был объявлен конкурс[5], на который пришло почти 6 миллионов предложений. После просмотра всех вариантов было решено дать автомобилю название March " +
                        "и в октябре 1982 года Nissan March поступил в продажу в Японии",
                        Location = "Японія"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
