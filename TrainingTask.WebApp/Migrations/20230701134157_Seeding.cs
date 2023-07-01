using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrainingTask.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "7666 Smitham Landing, Suite 918, 50682-8733, Reingerberg, Washington, United States", "Abby", "+1 202-918-2132" },
                    { 2, "049 Steuber Pines, Suite 946, 22779, Gislasonton, Rhode Island, United States", "Abeni", "+1 505-646-7697" }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, "Samsung", "Samsung specializes in the production of a wide variety of consumer and industry electronics, including appliances, digital media devices, semiconductors memory chips, and integrated systems. It has become one of the most-recognizable names in technology and produces about a fifth of South Koreas total exports." },
                    { 2, "Nvidia", "Nvidia Corporation is a technology company known for designing and manufacturing graphics processing units (GPUs). The company was founded in 1993 by Jen-Hsun Jensen Huang, Curtis Priem and Chris Malachowsky and is headquartered in Santa Clara, Calif." }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, "Pitch", "unit of typeface equal to number of characters per inch" },
                    { 2, "Vara", "unit of linear measure of between 33 and 43 inches" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "CompanyId", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, 1, "smart phone", "" },
                    { 2, 2, "Graphics Card", "" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BuyingPrice", "Name", "Notes", "SellingPrice", "TypeId" },
                values: new object[,]
                {
                    { 1, 150m, "A51", "Samsung Galaxy A51 is an Android smartphone manufactured by Samsung Electronics as part of its Galaxy A series. It was announced and released in December 2019. The phone has a Super AMOLED FHD+ 6.5 in display, a 48 MP wide, 12 MP ultrawide, 5 MP depth, and 5 MP macro camera, a 4000 mAh battery, and an optical in-screen fingerprint sensor.", 300m, 1 },
                    { 2, 350m, "RTX 40 Series", "NVIDIA® GeForce RTX™ 40 Series GPUs are beyond fast for gamers and creators. They're powered by the ultra-efficient NVIDIA Ada Lovelace architecture which delivers a quantum leap in both performance and AI-powered graphics. Experience lifelike virtual worlds with ray tracing and ultra-high FPS gaming with the lowest latency. Discover revolutionary new ways to create and unprecedented workflow acceleration.", 600m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "Date", "Discount", "ItemId", "Number", "PaidUp", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3m, 1, "1111111111", 100m, 300m, 3 },
                    { 2, 2, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, 2, "2222222222", 200m, 600m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
