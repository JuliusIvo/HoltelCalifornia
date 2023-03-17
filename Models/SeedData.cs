using HotelProject.Data;
using HotelProject.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                if (context.Orders.Any())
                {
                    return;
                }
                if(context.Rooms.Any())
                {
                    return;
                }
             
                context.Rooms.AddRange(
                    new Room
                    {
                        AmountOfBeds = 1,
                        PictureUrl = "https://www.thespruce.com/thmb/2_Q52GK3rayV1wnqm6vyBvgI3Ew=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/put-together-a-perfect-guest-room-1976987-hero-223e3e8f697e4b13b62ad4fe898d492d.jpg",
                        PricePerNight = 20,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now,
                        Name = "404",
                        RoomType = RoomType.Standard_suite

                    },
                    new Room
                    {
                        AmountOfBeds = 2,
                        PictureUrl = "https://www.thespruce.com/thmb/2_Q52GK3rayV1wnqm6vyBvgI3Ew=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/put-together-a-perfect-guest-room-1976987-hero-223e3e8f697e4b13b62ad4fe898d492d.jpg",
                        PricePerNight= 30,
                        DateFrom = DateTime.Now,
                        DateTo = DateTime.Now,
                        Name = "505",
                        RoomType= RoomType.Standard_suite
                    }
                    );
                context.Users.AddRange(
                    new User
                    {
                        Name = "Julius",
                        Email = "something@something.com",
                        Password = "admin",
                        PhoneNumber = "1234567890"
                    },
                    new User
                    {
                        Name = "NotJulius",
                        Email = "something@else.com",
                        Password = "notadmin",
                        PhoneNumber = "1234567890"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
