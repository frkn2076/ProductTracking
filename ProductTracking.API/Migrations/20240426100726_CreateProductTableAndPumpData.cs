using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductTracking.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateProductTableAndPumpData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Color = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    Barcode = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Barcode", "Brand", "Color", "Name", "Size" },
                values: new object[,]
                {
                    { 1, "f73c5a92-6459-4288-b253-79a42045f9b5", "Company-ABC0", 2, "Name-3", 46 },
                    { 2, "6a086e8b-1b64-460b-aba3-8553e8b2ebf4", "Company-ABC9", 3, "Name-8", 18 },
                    { 3, "7ff295ae-2672-4d00-a56a-207aaf461853", "Company-ABC1", 3, "Name-8", 66 },
                    { 4, "c967f617-a8bf-44a0-99c1-4e81fdab990c", "Company-ABC8", 4, "Name-9", 63 },
                    { 5, "3ab22062-d885-40d4-8fd4-469ec83fecf3", "Company-ABC2", 9, "Name-8", 67 },
                    { 6, "a2a3ba67-0ba5-4c63-a222-69e39965565b", "Company-ABC7", 8, "Name-6", 72 },
                    { 7, "f71a83b8-45c6-42ab-bb98-e7be6ead1533", "Company-ABC6", 9, "Name-1", 94 },
                    { 8, "082c80e4-7e76-4fbe-bb97-c0936de44921", "Company-ABC7", 1, "Name-7", 70 },
                    { 9, "43ad2da8-8038-4652-b02b-420294d17cee", "Company-ABC7", 1, "Name-7", 70 },
                    { 10, "0c4e9550-e92d-4f47-860e-447f03bf9245", "Company-ABC2", 8, "Name-1", 30 },
                    { 11, "ea4a1294-518a-4487-9fdc-dd1f41f4f07e", "Company-ABC3", 4, "Name-6", 20 },
                    { 12, "718503ca-bdb8-4885-85fd-9c8fc349a5fc", "Company-ABC4", 8, "Name-6", 28 },
                    { 13, "9ad283b3-15be-4e78-b972-8873287ee243", "Company-ABC1", 5, "Name-1", 79 },
                    { 14, "634f2514-1f5c-46cd-af22-a813043dae91", "Company-ABC4", 1, "Name-9", 92 },
                    { 15, "f10ad16a-b60c-4dd9-99d6-239220b1cfcf", "Company-ABC9", 9, "Name-2", 29 },
                    { 16, "e5faef0f-3c07-43a6-8427-c0889b808a8f", "Company-ABC5", 8, "Name-2", 46 },
                    { 17, "b395d97f-2c98-4acc-a52f-9e14e3fee5b2", "Company-ABC4", 10, "Name-5", 71 },
                    { 18, "868c9638-5969-483e-869d-32982923f8ec", "Company-ABC2", 3, "Name-5", 13 },
                    { 19, "a1d9be7e-5273-4196-bd18-270c118c7a04", "Company-ABC6", 5, "Name-0", 59 },
                    { 20, "ec701963-1238-4bf1-91af-fbca77428786", "Company-ABC1", 6, "Name-1", 47 },
                    { 21, "4aa20a11-47f3-4578-abab-2b57e3cbe7ef", "Company-ABC5", 6, "Name-5", 12 },
                    { 22, "abb259c7-310e-45f0-ae91-f4496f31ca96", "Company-ABC1", 2, "Name-5", 36 },
                    { 23, "a4f432bc-13bb-4b1a-9638-4c03bf998e15", "Company-ABC8", 8, "Name-1", 36 },
                    { 24, "12d3099b-bfac-4d82-9e77-3d5c7161a115", "Company-ABC9", 7, "Name-8", 35 },
                    { 25, "729d0226-fb73-40f9-ac85-8badcb695b6c", "Company-ABC0", 2, "Name-4", 45 },
                    { 26, "2d6a66d8-9564-4f6f-a452-5f7bf113175a", "Company-ABC4", 8, "Name-3", 28 },
                    { 27, "f0fe4a48-bea8-4281-ab39-27aaabb34550", "Company-ABC7", 8, "Name-4", 20 },
                    { 28, "494c32cb-b89c-482f-a07c-6f561b3c369a", "Company-ABC4", 3, "Name-1", 88 },
                    { 29, "29cf94b5-f0e9-46ed-af1c-495c011f35de", "Company-ABC0", 1, "Name-6", 47 },
                    { 30, "275c585b-37bc-4668-828c-300d46fe33ed", "Company-ABC4", 3, "Name-4", 61 },
                    { 31, "6da04f05-e79a-4834-a90c-3b97054b9ec1", "Company-ABC6", 1, "Name-5", 19 },
                    { 32, "b53581a5-4637-4d23-af4d-955ea224adb6", "Company-ABC7", 3, "Name-1", 20 },
                    { 33, "d3f11e5f-cca6-46d7-955c-4ecf3bef8add", "Company-ABC3", 10, "Name-9", 20 },
                    { 34, "dc29bec9-fb79-4907-affd-f6f18b4b4255", "Company-ABC5", 10, "Name-3", 68 },
                    { 35, "2099bc72-5a4a-4806-a79f-8284840998e5", "Company-ABC6", 4, "Name-6", 63 },
                    { 36, "1d80fe69-c0c1-4044-94d4-e7d0da926aa8", "Company-ABC6", 6, "Name-8", 64 },
                    { 37, "6e31a4a5-2b9f-49ee-9b58-6a738aedecf8", "Company-ABC8", 2, "Name-7", 65 },
                    { 38, "8c23fe9c-819f-4e4f-97f3-4539d7dde98b", "Company-ABC1", 10, "Name-5", 68 },
                    { 39, "8f3dcfca-d530-4d5d-95f5-aefddac5ca88", "Company-ABC5", 3, "Name-4", 21 },
                    { 40, "fb3c4ebd-c5f0-488e-a566-d82a310a5a2a", "Company-ABC1", 5, "Name-7", 10 },
                    { 41, "1adfb1c3-0b83-4135-9ad9-730acc31a24b", "Company-ABC7", 10, "Name-4", 36 },
                    { 42, "578ff1bb-177f-4e6d-9c78-f78bc2afc9b0", "Company-ABC7", 3, "Name-3", 32 },
                    { 43, "1741a70f-d355-4298-b5b8-2848f2f3f1f8", "Company-ABC7", 10, "Name-8", 32 },
                    { 44, "a75d2459-fdd6-4b96-81e1-94769e7f203f", "Company-ABC7", 9, "Name-7", 30 },
                    { 45, "90dc377c-0d51-494c-aa9e-1bf002794830", "Company-ABC3", 6, "Name-8", 84 },
                    { 46, "3f220da8-2caa-478c-9318-c0559b4e5c05", "Company-ABC0", 8, "Name-6", 53 },
                    { 47, "6049522d-e016-471d-9a9d-0403dbf935c6", "Company-ABC7", 4, "Name-0", 26 },
                    { 48, "e1367fb8-224c-4304-a0f6-00bd5434da69", "Company-ABC2", 1, "Name-1", 47 },
                    { 49, "09262dd7-0664-494c-b5a7-b1efa1c0c7ed", "Company-ABC7", 8, "Name-5", 21 },
                    { 50, "4c6020b8-ae48-41b7-b25f-e7e18aa17b66", "Company-ABC4", 10, "Name-4", 97 },
                    { 51, "58074334-8771-4698-a387-bf6aac94e2a9", "Company-ABC9", 4, "Name-8", 23 },
                    { 52, "86447a35-028c-4acb-bf68-4b0b69c8291a", "Company-ABC2", 2, "Name-1", 94 },
                    { 53, "c9efd372-e166-4b9d-8f43-0620315a9e0e", "Company-ABC2", 1, "Name-1", 39 },
                    { 54, "e5bf6e12-2db4-4d58-be89-6899152062a9", "Company-ABC5", 3, "Name-8", 76 },
                    { 55, "315c672b-b112-4a88-b9d8-f6c823794ffd", "Company-ABC9", 4, "Name-3", 66 },
                    { 56, "bb050d10-85fc-4374-ba25-69dd67b0101d", "Company-ABC1", 8, "Name-4", 81 },
                    { 57, "2f884739-c6ea-4150-aa00-99bd049c4186", "Company-ABC0", 6, "Name-9", 56 },
                    { 58, "ec8e93f1-24fa-4025-827b-c9e68c631037", "Company-ABC9", 3, "Name-9", 69 },
                    { 59, "d8c5c509-e4fd-4e10-9021-c2f569530b00", "Company-ABC0", 5, "Name-2", 37 },
                    { 60, "28471429-a5f2-4d27-8a45-be8662beee03", "Company-ABC4", 7, "Name-2", 80 },
                    { 61, "678578a9-675d-4ad5-89fd-dda6c0fbafe0", "Company-ABC9", 6, "Name-2", 17 },
                    { 62, "0271d20f-4fc7-41ca-b8fc-d1440e695e9b", "Company-ABC3", 10, "Name-7", 79 },
                    { 63, "0aa7630c-b719-4a79-b4be-9671b6b9369d", "Company-ABC9", 8, "Name-3", 99 },
                    { 64, "d5fbc2bb-01cd-4ed9-8ef7-427e92c5db4c", "Company-ABC6", 1, "Name-1", 97 },
                    { 65, "726da87d-fdd4-4aa7-8c60-873acfeb861a", "Company-ABC0", 7, "Name-0", 83 },
                    { 66, "16dc2621-779b-46b4-a0e4-18f83874590c", "Company-ABC9", 10, "Name-9", 23 },
                    { 67, "9234a492-0682-4df8-9af8-e157e67d62d7", "Company-ABC0", 5, "Name-0", 45 },
                    { 68, "d21f8eeb-bf6c-4bd9-976b-f0ab943381c2", "Company-ABC9", 7, "Name-4", 84 },
                    { 69, "a5496673-d941-4f82-9226-d3a947f3e01d", "Company-ABC3", 3, "Name-1", 88 },
                    { 70, "1808fe64-bcdd-44af-933a-d041dab25bd8", "Company-ABC5", 8, "Name-5", 83 },
                    { 71, "061b9fc4-1508-4281-bff9-6f09512c5275", "Company-ABC4", 5, "Name-0", 15 },
                    { 72, "df76bf4a-fb3c-4054-856b-11fc00feeb48", "Company-ABC5", 5, "Name-0", 24 },
                    { 73, "a1f63a4a-15cd-4c24-a9f9-9ed1d731287a", "Company-ABC4", 7, "Name-3", 17 },
                    { 74, "b9090a17-b517-45bd-86ca-c9081d9afbd6", "Company-ABC1", 1, "Name-8", 51 },
                    { 75, "7a239713-3d53-4802-b317-75627b17212e", "Company-ABC9", 8, "Name-7", 53 },
                    { 76, "0e1b1780-d12e-4144-97b2-a4e34f588993", "Company-ABC9", 7, "Name-9", 30 },
                    { 77, "ae818371-f9ea-4961-83c8-f13dc1a92df1", "Company-ABC9", 8, "Name-5", 56 },
                    { 78, "ebb56799-005c-4aeb-95a9-29434b4d5f64", "Company-ABC8", 10, "Name-7", 76 },
                    { 79, "09e8ce1a-28c8-4ae1-a67b-e49bb54a3e81", "Company-ABC0", 8, "Name-9", 79 },
                    { 80, "c1c159f6-5c5c-41fc-af4a-5652ec30374e", "Company-ABC5", 10, "Name-2", 42 },
                    { 81, "9854938e-635f-4d0e-a9f4-12807a3490c7", "Company-ABC5", 7, "Name-7", 36 },
                    { 82, "8aad33c0-d016-49bb-8fac-f06bac84ed09", "Company-ABC7", 8, "Name-0", 70 },
                    { 83, "bf31caa0-1a10-4645-8c7e-15d31bac48f0", "Company-ABC6", 2, "Name-2", 99 },
                    { 84, "abfb31d6-e21c-4231-adc6-7c60f4133bd6", "Company-ABC2", 7, "Name-4", 58 },
                    { 85, "8542f3ad-33d2-462a-a524-53797292ddc1", "Company-ABC1", 3, "Name-8", 66 },
                    { 86, "e3a7be42-ca78-422f-acf9-3405c6915491", "Company-ABC5", 8, "Name-0", 13 },
                    { 87, "4187d3bb-6c30-46a6-a953-096c00338348", "Company-ABC9", 3, "Name-3", 89 },
                    { 88, "2f85a518-db53-4386-9b7a-6166e8c488db", "Company-ABC0", 6, "Name-0", 90 },
                    { 89, "581217b0-e4e0-4439-a399-6730134cd3c5", "Company-ABC3", 9, "Name-6", 63 },
                    { 90, "de4c1857-e770-4e26-bcb1-766665b69447", "Company-ABC6", 3, "Name-4", 62 },
                    { 91, "fe41a6ce-801f-4827-8cb6-93dd0a2f2a54", "Company-ABC9", 5, "Name-2", 68 },
                    { 92, "cff6864b-624c-4efa-ad4d-6e3d61101566", "Company-ABC6", 3, "Name-1", 79 },
                    { 93, "1991d7a5-4295-488e-9f24-bf493d2bb27a", "Company-ABC0", 5, "Name-2", 31 },
                    { 94, "da7c3ba5-6595-49fb-855b-adfa8eea9b22", "Company-ABC8", 1, "Name-2", 92 },
                    { 95, "34628679-9ce3-41fd-bc55-b7200199096a", "Company-ABC4", 4, "Name-1", 17 },
                    { 96, "8e4417bb-2a05-45d8-83a0-82e21a26e1c6", "Company-ABC6", 2, "Name-5", 83 },
                    { 97, "0c73ff10-555e-4948-8586-db71a5ce6a7f", "Company-ABC5", 8, "Name-0", 30 },
                    { 98, "aac895fd-ab85-4528-aebb-4a3aac3456f9", "Company-ABC2", 9, "Name-7", 18 },
                    { 99, "ddf1e2df-e4c8-407c-9d99-aef34c31506d", "Company-ABC0", 1, "Name-8", 75 },
                    { 100, "a58f4ac3-742f-4aba-8f3c-b79929d23a20", "Company-ABC7", 6, "Name-8", 19 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
