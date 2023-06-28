using Microsoft.EntityFrameworkCore;
using TrainingTask.WebApp.Entities;

namespace TrainingTask.WebApp.Seeding
{
    public static class ModelSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var firstCompany = new Company
            {
                Id = 1,
                Name = "Samsung",
                Notes = "Samsung specializes in the production of a wide variety of consumer " +
                "and industry electronics, including appliances, digital media devices, semiconductors, " +
                "memory chips, and integrated systems. It has become one of the most-recognizable names in " +
                "technology and produces about a fifth of South Koreas total exports."
            };

            var secondCompany = new Company
            {
                Id = 2,
                Name = "Nvidia",
                Notes = "Nvidia Corporation is a technology company known for designing and manufacturing" +
                " graphics processing units (GPUs). The company was founded in 1993 by Jen-Hsun Jensen Huang," +
                " Curtis Priem and Chris Malachowsky and is headquartered in Santa Clara, Calif."
            };

            builder.Entity<Company>().HasData(firstCompany,secondCompany);

            var firstType = new Entities.Type
            {
                Id = 1,
                Name = "smart phone",
                Notes = "",
                CompanyId = firstCompany.Id
            };

            var secondType = new Entities.Type
            {
                Id = 2,
                Name = "Graphics Card",
                Notes = "",
                CompanyId = secondCompany.Id,
            };

            builder.Entity<Entities.Type>().HasData(firstType, secondType);

            var firstItem = new Item
            {
                Id = 1,
                Name = "A51",
                SellingPrice = 300,
                BuyingPrice = 150,
                Notes = "Samsung Galaxy A51 is an Android smartphone manufactured by Samsung Electronics as part " +
                "of its Galaxy A series. It was announced and released in December 2019. The phone has a Super AMOLED" +
                " FHD+ 6.5 in display, a 48 MP wide, 12 MP ultrawide, 5 MP depth, and 5 MP macro camera, a 4000 mAh battery," +
                " and an optical in-screen fingerprint sensor.",
                TypeId = firstType.Id
            };

            var secondItem = new Item
            {
                Id = 2,
                Name = "RTX 40 Series",
                SellingPrice = 600,
                BuyingPrice = 350,
                Notes = "NVIDIA® GeForce RTX™ 40 Series GPUs are beyond fast for gamers and creators." +
                " They're powered by the ultra-efficient NVIDIA Ada Lovelace architecture which delivers " +
                "a quantum leap in both performance and AI-powered graphics. Experience lifelike virtual worlds " +
                "with ray tracing and ultra-high FPS gaming with the lowest latency. Discover revolutionary new " +
                "ways to create and unprecedented workflow acceleration.",
                TypeId = secondType.Id
            };

            builder.Entity<Entities.Item>().HasData(firstItem, secondItem);

            var firstClient = new Client
            {
                Id = 1,
                Name = "Abby",
                Phone = "+1 202-918-2132",
                Address = "7666 Smitham Landing, Suite 918, 50682-8733, Reingerberg, Washington, United States"
            };

            var secondClient = new Client
            {
                Id = 2,
                Name = "Abeni",
                Phone = "+1 505-646-7697",
                Address = "049 Steuber Pines, Suite 946, 22779, Gislasonton, Rhode Island, United States"
            };

            builder.Entity<Entities.Client>().HasData(firstClient, secondClient);

            var firstInvoice = new Invoice
            {
                Id = 1,
                Date = DateTime.Now.AddYears(-3),
                Quantity = 3,
                Price = firstItem.SellingPrice,
                PaidUp = 100,
                Discount = 3,
                Number = new Random().NextInt64(1000000000, 9999999999).ToString(),
                ItemId = firstItem.Id,
                ClientId = firstClient.Id
            };

            var secondInvoice = new Invoice
            {
                Id = 2,
                Date = DateTime.Now.AddYears(-1),
                Quantity = 1,
                Price = secondItem.SellingPrice,
                PaidUp = 200,
                Discount = 8,
                Number = new Random().NextInt64(1000000000, 9999999999).ToString(),
                ItemId = secondItem.Id,
                ClientId = secondClient.Id
            };

            var thirdInvoice = new Invoice
            {
                Id = 3,
                Date = DateTime.Now.AddYears(2),
                Quantity = 2,
                Price = secondItem.SellingPrice,
                PaidUp = 50,
                Discount = 13,
                Number = new Random().NextInt64(1000000000, 9999999999).ToString(),
                ItemId = secondItem.Id,
                ClientId = firstClient.Id
            };

            builder.Entity<Entities.Invoice>().HasData(firstInvoice, secondInvoice, thirdInvoice);

            var firstUnit = new Unit
            {
                Id = 1,
                Name = "Pitch",
                Notes = "unit of typeface equal to number of characters per inch"
            };

            var secondUnit = new Unit
            {
                Id = 2,
                Name = "Vara",
                Notes = "unit of linear measure of between 33 and 43 inches"
            };

            builder.Entity<Entities.Unit>().HasData(firstUnit, secondUnit);
        }
    }
}
