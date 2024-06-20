using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmCode = table.Column<int>(type: "int", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Article_Image_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Image",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    VisitorId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleVisitor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleVisitor_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleVisitor_Visitor_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitor",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1871e622-dd80-440b-baa7-9b08f2862a47", "Admin", "ADMIN" },
                    { 2, "733a7431-72ca-4760-8333-7c6e0bd20c1a", "Author", "AUTHOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "ConfirmCode", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Path", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, "Sistemin en yetkili admini.", 0, "c0bd1235-9418-45f4-9189-49be154301c0", null, "admin@gmail.com", true, "Cevdet", "Herodot", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHwaJY5uxjraHfyXkQHC9List6TTh+cq6EjxjCxlfSYXJDVMB3h3HeXJwxab6aBd7w==", "user-images/usericon.jpg", "+905376112122", true, "bd9119bc-03ec-4497-a6c0-1e30aba6b145", false, "admin@gmail.com" },
                    { 2, "Sitenin kıdemli yazar kadrosuna dahil.", 0, "7535b457-7f46-4a36-9e5f-39ccdfed1b1f", null, "mahmut@gmail.com", true, "Mahmut", "Taylan", false, null, "MAHMUT@GMAIL.COM", "MAHMUT@GMAIL.COM", "AQAAAAEAACcQAAAAEPCJHNGvCfMmxmUBGwyjlrdUgxlO89Yl11I9PlJtFCt8jOYJTP2Xw9gD2u+/ZyNPIg==", "user-images/Mahmut.jpg", "+905556667788", true, "c5bd5d6c-4d91-4803-96a4-3ac2de029fa0", false, "mahmut@gmail.com" },
                    { 3, "Sitenin kıdemli yazar kadrosuna dahil.", 0, "ac5998b8-e662-4fd3-b297-418cb10458f9", null, "dursun@gmail.com", true, "Dursun", "Durmasin", false, null, "DURSUN@GMAIL.COM", "DURSUN@GMAIL.COM", "AQAAAAEAACcQAAAAEJaF/c7780jaV89vCJCDQR4/tg/3pzheHJKmIYoWB16xHoh0Qyd6t9Tgat0IMKfEsQ==", "user-images/usericon.jpg", "+905537611222", true, "018c9e3b-66d2-4b0e-b6fe-5a271501901b", false, "dursun@gmail.com" },
                    { 4, "Sitenin kıdemli yazar kadrosuna dahil.", 0, "fff10466-e7c0-455d-8b33-ad656c2c9ac7", null, "kamil@gmail.com", true, "Kamil", "Kamil", false, null, "KAMIL@GMAIL.COM", "KAMIL@GMAIL.COM", "AQAAAAEAACcQAAAAECF9Ht3JDGrVoS98qcmXX8R8iRqix+EbLcRVcgOdAsCJS2UQgj9PKOd/go/TEGjm0w==", "user-images/usericon.jpg", "+905556667788", true, "d55faf92-5077-4e82-bd43-997c69d7ae78", false, "Kamil@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7646), null, null, false, "Teknoloji", null, null },
                    { 2, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7648), null, null, false, "Ekonomi", null, null },
                    { 3, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7649), null, null, false, "Psikoloji", null, null },
                    { 4, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7650), null, null, false, "Felsefe", null, null },
                    { 5, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7651), null, null, false, "Tarih", null, null },
                    { 6, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7652), null, null, false, "Otomobil", null, null },
                    { 7, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7653), null, null, false, "Tarim", null, null },
                    { 8, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7654), null, null, false, "Cinsel Hayat", null, null },
                    { 9, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(7655), null, null, false, "Cografya", null, null }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8049), null, null, "article-images/teknoloji.png", "png", false, null, null },
                    { 2, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8050), null, null, "article-images/ekonomi.png", "png", false, null, null },
                    { 3, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8052), null, null, "article-images/psikoloji.png", "png", false, null, null },
                    { 4, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8053), null, null, "article-images/felsefe.jpg", "jpg", false, null, null },
                    { 5, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8054), null, null, "article-images/tarih.jpg", "jpg", false, null, null },
                    { 6, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8055), null, null, "article-images/otomobil.jpg", "jpg", false, null, null },
                    { 7, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8056), null, null, "article-images/tarim.jpg", "jpg", false, null, null },
                    { 8, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8057), null, null, "article-images/cinsel hayat.jpg", "jpg", false, null, null },
                    { 9, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(8058), null, null, "article-images/cografya.jpg", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Article",
                columns: new[] { "Id", "AppUserId", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, null, 3, "Duygusal zeka, bireylerin duygularını anlama, yönetme ve başkalarının duygularını anlama yeteneğini ifade eder. Bu kavram, geleneksel zeka kavramının yanı sıra kişinin sosyal ve duygusal becerilerini de içerir. Duygusal zekaya sahip olmak, ilişkileri güçlendirmek, stresle başa çıkmak ve genel refahı artırmak için kritik bir öneme sahiptir.\n\nDuygusal zeka, beş ana bileşenden oluşur: öz farkındalık, duygu yönetimi, sosyal farkındalık, ilişki yönetimi ve öz motivasyon. Öz farkındalık, kişinin duygularını tanıma ve anlama yeteneğini ifade eder. Duygu yönetimi, duyguları etkili bir şekilde yönetme ve uygun tepkiler verme becerisini içerir. Sosyal farkındalık, başkalarının duygularını tanıma ve empati kurma yeteneğini ifade eder. İlişki yönetimi, sağlıklı ilişkiler kurma, çatışmaları çözme ve işbirliği yapma becerisini içerir. Son olarak, öz motivasyon, uzun vadeli hedeflere odaklanma, yenilgiyi aşma ve içsel motivasyonu koruma yeteneğini ifade eder.\n\nDuygusal zekanın önemi, kişisel ve profesyonel başarı üzerinde derin bir etkiye sahiptir. Araştırmalar, duygusal zekası yüksek bireylerin daha sağlıklı ilişkilere, daha iyi iş performansına ve daha iyi psikolojik refaha sahip olduğunu göstermektedir. Ayrıca, duygusal zeka, stresle başa çıkma, problem çözme ve yaşamın zorluklarıyla baş etme becerilerini geliştirmeye yardımcı olabilir.\n\nDuygusal zeka, doğuştan gelen bir yetenek olmakla birlikte, herkes bu beceriyi geliştirebilir. Kendi duygularınızı tanıma, empati kurma ve etkili iletişim becerileri geliştirme gibi stratejilerle duygusal zekanızı artırabilirsiniz. Ayrıca, stres yönetimi, zihinsel sağlık ve kişisel gelişim alanlarında destek alarak duygusal zekanızı güçlendirebilirsiniz.\n\nSonuç olarak, duygusal zeka, hayatı daha anlamlı kılan ve kişisel gelişimi destekleyen önemli bir beceridir. Duygusal zekaya sahip olmak, daha sağlıklı ilişkiler kurma, iş performansını artırma ve genel refahı iyileştirme fırsatı sunar. Bu nedenle, duygusal zeka üzerinde çalışmak ve bu beceriyi geliştirmek, herkes için önemli bir hedeftir.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4891), null, null, 1, false, "Hayatı Daha Anlamlı Kılan Beceri", null, null, 3, 19 },
                    { 2, null, 2, "Ekonomi, sadece para ve piyasalarla ilgili değildir; aynı zamanda insanların karar alma süreçlerini de içerir. Tüketici davranışları, ekonomideki bu insan odaklı perspektifi temsil eder ve tüketicilerin alışveriş, harcama ve kaynak tahsisi gibi kararlarını anlamaya odaklanır. Tüketici davranışları, piyasalardaki talebi belirler ve şirketlerin ürünlerini pazarlama stratejilerini oluşturmasına yardımcı olur.\n\nTüketici davranışları, bir dizi faktörden etkilenir. Bunlar arasında kişisel tercihler, gelir seviyesi, fiyatlar, reklamlar, sosyal normlar ve kültürel faktörler bulunur. Örneğin, bir tüketici bir ürün satın alırken, hem ürünün fiyatını hem de kalitesini dikkate alabilir. Ayrıca, ürünün markası, sosyal statüye olan etkisi veya arkadaşların önerileri gibi faktörler de satın alma kararını etkileyebilir.\n\nEkonomide tüketici davranışlarının anlaşılması, hem bireyler hem de işletmeler için önemlidir. Bireyler, kişisel finansal kararlarında daha bilinçli olmak için tüketici davranışlarını anlamalıdır. Aynı zamanda, işletmeler, tüketicilerin taleplerini ve tercihlerini anlamak için tüketici davranışlarını analiz eder ve buna göre pazarlama stratejilerini belirler.\n\nTüketici davranışlarını anlamak, ekonomideki etkileşimleri ve sonuçları değerlendirmek için kritik bir öneme sahiptir. Bu anlayış, ekonomik politikaların oluşturulmasında ve tüketici refahının artırılmasında da önemli bir rol oynar. Örneğin, tüketici davranışları analizi, vergi politikalarının tasarımında veya rekabet politikalarının belirlenmesinde kullanılabilir.\n\nSonuç olarak, tüketici davranışları ekonomide merkezi bir rol oynar ve tüketicilerin alışveriş ve harcama kararlarını anlamak, hem bireylerin hem de işletmelerin ekonomik başarısı için kritik öneme sahiptir.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4893), null, null, 2, false, "Ekonomik Karar Alma Sürecindeki Anahtar Rol", null, null, 2, 67 },
                    { 3, null, 1, "Teknoloji, günümüzün vazgeçilmez bir parçası haline gelmiştir ve günlük yaşamımızı birçok şekilde etkilemektedir. İnternetten akıllı telefonlara, yapay zekadan bulut bilişime kadar, teknolojinin sunduğu imkanlar, iletişimi kolaylaştırmaktan, iş yapma şeklimizi değiştirmeye kadar geniş bir yelpazede etkiye sahiptir.\n\nTeknoloji, iletişim alanında devrim yaratmıştır. İnternet ve sosyal medya platformları, dünya çapında insanların birbirleriyle bağlantı kurmasını sağlar. Arkadaşlarla iletişim kurmak, haber almak, bilgi paylaşmak ve hatta işbirliği yapmak için artık sınırların ötesine geçmek gerekmiyor. Bu, küresel topluluğun daha bağlantılı hale gelmesine ve bilgi paylaşımının artmasına olanak tanır.\n\nTeknolojinin iş dünyasındaki rolü de büyük bir dönüşüm geçirmiştir. Dijitalleşme ve otomasyon, iş süreçlerini daha verimli hale getirirken, uzaktan çalışma imkanı iş modellerini değiştirmiştir. Artık birçok iş, fiziksel ofis ortamına bağımlı olmadan da yürütülebilir hale gelmiştir. Ayrıca, yapay zeka ve veri analitiği gibi teknolojik yenilikler, işletmelerin veri tabanlı kararlar almasına ve müşteri deneyimini geliştirmesine olanak tanır.\n\nSağlık sektöründe de teknolojinin rolü giderek artmaktadır. Tele-tıp uygulamaları, hasta bakımını daha erişilebilir hale getirirken, sağlık verilerinin dijitalleştirilmesi, tedavi planlamasını ve hastalık izleme süreçlerini iyileştirir. Böylece, teknoloji sağlık hizmetlerinin daha etkin ve verimli bir şekilde sunulmasına katkıda bulunur.\n\nSonuç olarak, teknoloji günlük yaşamımızı derinlemesine etkilemektedir ve sürekli olarak dönüşüm geçirmektedir. İletişimden iş dünyasına, sağlık hizmetlerinden eğitime kadar her alanda teknolojinin rolü büyük önem taşır. Bu nedenle, teknolojik gelişmeleri takip etmek ve bu yenilikleri günlük hayatımıza entegre etmek, bireysel ve toplumsal olarak rekabet avantajı sağlar.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4895), null, null, 3, false, "Teknolojinin Günlük Hayattaki Rolü: Dönüşüm ve Etkileşim", null, null, 1, 20 },
                    { 4, null, 4, "Felsefe, insanlığın varoluşundan bu yana bilgelik arayışının merkezinde yer alan bir disiplindir. Felsefe, temel soruları sorgulamak, bilgiyi keşfetmek ve insanın kendisi ve evren hakkındaki anlayışını derinleştirmek için bir çerçeve sağlar. Felsefenin amacı, düşünceyi yönlendirmek, değerleri sorgulamak ve yaşamın anlamını aramaktır.\r\n\r\nFelsefenin tarihi, birçok büyük düşünürün felsefi sorulara cevap aramasıyla işlenir. Antik Yunan filozofları, bilgi, gerçeklik, adalet ve erdem gibi kavramları tartıştılar. Sokrates'in sorgulama yöntemi, Platon'un idealar kuramı ve Aristoteles'in lojik ve metafizik çalışmaları, felsefi düşüncenin temelini oluşturur.\r\n\r\nFelsefenin önemi, sadece akademik bir konu olarak değil, aynı zamanda günlük yaşamımızda da kendini gösterir. Felsefi düşünce, insanların dünya görüşlerini şekillendirir, değerleri sorgular ve etik kararlar almalarına rehberlik eder. Ayrıca, felsefe, eleştirel düşünme becerilerini geliştirir, problem çözme yeteneğini artırır ve insanların yaşamlarını anlamlı kılar.\r\n\r\nFelsefe, insanın kendisi ve evren hakkındaki bilgisini derinleştirmenin yanı sıra, bireysel ve toplumsal düzeyde refahı artırmak için de kullanılabilir. Etik ve siyaset felsefesi, adaletin ve eşitliğin nasıl sağlanabileceğini tartışırken, metafizik ve ontoloji evrenin temel yapısını anlamaya çalışır. Bu, insanların kendi düşünce ve davranışlarını daha bilinçli bir şekilde şekillendirmelerine yardımcı olur.\r\n\r\nSonuç olarak, felsefe, insanlık yolculuğunun ayrılmaz bir parçasıdır ve insanın bilgelik arayışını şekillendiren temel bir disiplindir. Felsefi düşünce, insanların dünya görüşlerini genişletir, değerleri sorgular ve yaşamlarını anlamlı kılar. Bu nedenle, felsefe, bireysel ve toplumsal düzeyde daha iyi bir anlayış ve refah için kritik bir öneme sahiptir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4896), null, null, 3, false, "Felsefenin Önemi: Bilgelik Arayışı ve İnsanlık Yolculuğu", null, null, 1, 19 },
                    { 5, null, 5, "Tarih, insanlığın geçmiş deneyimlerini inceleyen ve anlamaya çalışan disiplindir. Tarih, olayları, insanların davranışlarını, toplumların yapılarını ve kültürel değişimleri inceler. Bu nedenle, tarih, insanlığın kolektif hafızasıdır ve geçmişten geleceğe uzanan bir yolculuktur.\r\n\r\nTarihin önemi, insanların geçmiş hakkında bilgi edinmesine ve geleceği şekillendirmesine yardımcı olmasıdır. Geçmişteki olayları anlamak, bugünkü dünyayı ve toplumları daha iyi anlamamıza ve değerlendirmemize yardımcı olur. Tarih, insanlığın ne kadar ilerlediğini gösterirken, aynı zamanda insan doğasının temel özelliklerini de ortaya koyar.\r\n\r\nTarih, kültürler arası etkileşimi ve değişimi anlamamıza da yardımcı olur. İnsanların farklı toplumlar arasındaki ilişkilerini, ticaret yollarını ve kültürel alışverişi inceleyerek, tarih bize insanlığın karmaşık ve çeşitli doğasını gösterir. Ayrıca, tarih, ideolojilerin ve inanç sistemlerinin nasıl geliştiğini anlamamıza ve bugünkü dünyadaki sosyal ve politik yapıları daha iyi kavramamıza yardımcı olur.\r\n\r\nTarihin öğretilmesi ve öğrenilmesi, genç nesillerin tarih bilincini geliştirmesine ve geçmişten ders çıkarmasına olanak tanır. Tarih, insanların geçmişteki hatalardan ders almasını ve geleceği daha iyi bir şekilde şekillendirmesini sağlar. Ayrıca, tarih, milli kimlik ve toplumsal bellek oluşturmanın bir yolu olarak da önemlidir.\r\n\r\nSonuç olarak, tarih insanlığın geçmişini inceleyen ve anlamaya çalışan kritik bir disiplindir. Geçmiş olayları ve deneyimleri inceleyerek, insanlar bugünkü dünyayı ve geleceği daha iyi anlamaya ve değerlendirmeye yardımcı olabilirler. Tarih, insanların ortak hafızasıdır ve insanlık hikayesinin bir parçasıdır.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4898), null, null, 5, false, "Tarihin Önemi: Geçmişten Geleceğe İnsanlık Hikayesi", null, null, 2, 67 },
                    { 6, null, 6, "\r\nElbette, işte otomobillerle ilgili kısa bir makale:\r\n\r\nOtomobil Devrimi: Mobilite ve Modern Yaşamın Köprüsü\r\n\r\nOtomobil, modern dünyanın vazgeçilmez bir parçası haline gelmiştir. Mobiliteyi artıran ve iletişimi kolaylaştıran otomobiller, insanların günlük yaşamlarını kökten değiştirmiştir. Otomobil devrimi, ulaşımın dönüşümünde bir kilometre taşı olmuş ve toplumların yapısını etkilemiştir.\r\n\r\nOtomobiller, insanların yerinden bağımsız olarak seyahat etmesini sağlar. Bu, işe gitmek, alışveriş yapmak, aile ziyaretleri ve tatil gibi günlük aktiviteleri daha kolay ve hızlı hale getirir. Otomobiller aynı zamanda toplumların ve ekonomilerin büyümesine katkıda bulunur, çünkü insanlar işlerine daha kolay ve verimli bir şekilde ulaşabilirler.\r\n\r\nOtomobiller, endüstriyel devrimin bir sonucu olarak ortaya çıkmıştır ve sürekli olarak gelişmiştir. İlk otomobiller, insanların ulaşımında devrim yaratmış ve dünya çapında bir fenomen haline gelmiştir. Daha sonra, otomobil teknolojisindeki ilerlemeler, daha güvenli, daha çevre dostu ve daha konforlu araçlar üretilmesine olanak tanımıştır.\r\n\r\nAncak, otomobillerin yaygın kullanımı çevresel ve sosyal sorunları da beraberinde getirmiştir. Fosil yakıtlı araçlar, hava kirliliği ve iklim değişikliği gibi çevresel sorunlara katkıda bulunurken, trafik sıkışıklığı ve kazalar da toplumsal sorunlar olarak ortaya çıkmıştır. Bu nedenle, otomobil endüstrisi sürekli olarak daha sürdürülebilir ve çevre dostu çözümler aramaktadır.\r\n\r\nSonuç olarak, otomobil devrimi, mobiliteyi artıran ve modern yaşamın temel bir parçası haline gelen önemli bir dönüşümü temsil eder. Otomobiller, insanların günlük yaşamlarını kolaylaştırırken, aynı zamanda çevresel ve sosyal sorunlara da neden olabilirler. Bu nedenle, otomobil endüstrisi sürdürülebilirlik ve yenilikçilik üzerine odaklanarak gelecekte daha iyi bir mobilite sağlamayı hedeflemektedir.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4899), null, null, 6, false, "Otomobil Devrimi: Mobilite ve Modern Yaşamın Köprüsü", null, null, 3, 20 },
                    { 7, null, 7, "Tarım, insanlık tarihindeki en eski ve en temel geçim kaynaklarından biridir. Tarım, yiyecek üretimi için toprak kullanımını ve bitki yetiştiriciliğini ifade eder. İnsanlar, tarımı binlerce yıl boyunca hayatta kalmak ve toplumlarını beslemek için kullanmışlardır.\r\n\r\nTarım, insanlığın yerleşik yaşama geçişinde kritik bir rol oynamıştır. Tarım sayesinde insanlar, avcılık ve toplayıcılıktan çiftçilik ve hayvancılığa geçiş yapmışlardır. Bu, insanların daha kalabalık topluluklar halinde yaşamalarına ve şehirlerin kurulmasına olanak tanımıştır. Ayrıca, tarımın ortaya çıkması, medeniyetin gelişmesiyle birlikte ekonomik, sosyal ve kültürel yapıların oluşmasını da sağlamıştır.\r\n\r\nTarım, günümüzde de insanlık için hayati bir öneme sahiptir. Dünya nüfusu sürekli olarak artarken, gıda güvenliği ve beslenme ihtiyacı da artmaktadır. Tarım, bu ihtiyaçları karşılamak için gerekli olan yiyecek ve lif üretimini sağlar. Ayrıca, tarım sektörü, birçok ülkenin ekonomisinde önemli bir yer tutar ve istihdam yaratır.\r\n\r\nAncak, modern tarımın bazı sorunları da vardır. Endüstriyel tarım uygulamaları, toprak erozyonu, su kirliliği ve biyoçeşitlilik kaybı gibi çevresel sorunlara neden olabilir. Ayrıca, tarım kimyasalları ve genetiği değiştirilmiş organizmalar gibi teknolojilerin kullanımı, gıda güvenliği ve insan sağlığı konularında endişelere neden olabilir.\r\n\r\nBu nedenle, sürdürülebilir tarım uygulamalarının teşvik edilmesi ve çiftçilere destek sağlanması önemlidir. Organik tarım, çevre dostu tarım uygulamaları ve yerel gıda üretimi gibi yaklaşımlar, tarımın çevresel ve sosyal etkilerini azaltabilir. Ayrıca, teknolojik yeniliklerin kullanımı, verimliliği artırabilir ve tarımın daha sürdürülebilir hale gelmesine yardımcı olabilir.\r\n\r\nSonuç olarak, tarım insanlığın temel geçim kaynaklarından biridir ve yaşamın devamı için hayati bir öneme sahiptir. Ancak, modern tarım uygulamalarının çevresel ve sosyal etkileri göz önünde bulundurularak sürdürülebilir tarım yöntemleri teşvik edilmelidir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4900), null, null, 7, false, "Tarımın Önemi: Geçmişten Günümüze İnsanlıkın Temel Geçim Kaynağı", null, null, 1, 19 },
                    { 8, null, 8, "Cinsel hayat, insanın fiziksel, duygusal ve sosyal refahını derinden etkileyen önemli bir yaşam alanıdır. Cinsellik, sağlıklı bir yaşamın ayrılmaz bir parçası olarak kabul edilmelidir ve cinsel sağlık, bireylerin ve toplumların genel refahını etkileyen birçok faktöre bağlıdır.\r\n\r\nCinsel sağlık, cinsel ilişkilerin fiziksel ve duygusal olarak sağlıklı ve tatmin edici olmasını içerir. Bu, cinsel yolla bulaşan enfeksiyonlardan korunma, doğum kontrolü yöntemlerinin bilinçli kullanımı ve cinsel ilişkilerde rahatlık ve güven duygusunun olması gibi çeşitli unsurları içerir. Ayrıca, cinsel sağlık, cinsel eğitim ve bilgiye erişim gibi faktörlerle de yakından ilişkilidir.\r\n\r\nCinsel hayatın sağlıklı ve tatmin edici olması, genel yaşam kalitesini artırır. Düzenli cinsel aktivite, stresi azaltabilir, bağışıklık sistemini güçlendirebilir ve duygusal bağları güçlendirebilir. Ayrıca, cinsel ilişkilerin duygusal ve zihinsel sağlık üzerinde olumlu etkileri olduğu bilinmektedir.\r\n\r\nAncak, cinsel hayat bazen sorunlarla da karşılaşabilir. Cinsel işlev bozuklukları, cinsel isteksizlik, orgazm sorunları ve cinsel travmalar gibi sorunlar, bireylerin cinsel sağlığını olumsuz yönde etkileyebilir. Bu gibi durumlarda, uzman yardımı almak ve uygun tedavileri aramak önemlidir.\r\n\r\nCinsel sağlık ve iyilik, beden ve zihin arasındaki dengeyi korumak için kritik bir faktördür. Cinsel sağlık, bireylerin kendilerini iyi hissetmelerine, ilişkilerinde daha tatmin edici deneyimler yaşamalarına ve genel refahlarını artırmalarına yardımcı olur. Bu nedenle, cinsel sağlık konusunda bilinçli olmak, düzenli sağlık kontrolleri yapmak ve gerektiğinde profesyonel yardım almak önemlidir.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4902), null, null, 8, false, "Cinsel Sağlık ve İyilik: Beden ve Zihin Arasındaki Dengenin Önemi", null, null, 2, 67 },
                    { 9, null, 9, "Coğrafya, dünya üzerindeki yerleri, doğal ve beşeri süreçleri inceleyen bir bilim dalıdır. Toprak, su, iklim, bitki örtüsü, yerleşim birimleri, ekonomik aktiviteler ve insan etkileşimleri gibi konular coğrafyanın kapsamına girer. Coğrafya, dünyayı anlamamızı sağlayan bir çerçeve sunar ve insanlığın doğal ve beşeri çevresiyle olan ilişkisini keşfetmemize yardımcı olur.\r\n\r\nCoğrafyanın önemi, insanların yaşadığı yerleri, doğal kaynakları ve çevresel koşulları anlamamıza yardımcı olmasıdır. İnsanlar, coğrafi koşullara uyum sağlayarak yerleşim yerleri seçerler, tarımı, endüstriyi ve ticareti planlarlar. Ayrıca, coğrafi özellikler, iklim değişiklikleri ve doğal afetler gibi faktörler, insanların günlük yaşamlarını ve ekonomik faaliyetlerini etkiler.\r\n\r\nCoğrafya, kültürel etkileşimleri ve küresel ilişkileri anlamamıza da yardımcı olur. Ticaret yolları, göç hareketleri, kültürel değişimler ve çatışma bölgeleri gibi konular, coğrafi faktörlerden etkilenir. Coğrafi bilgi, uluslararası ilişkilerde ve küresel politikada önemli bir rol oynar ve insanların dünya çapında birbirleriyle bağlantılı olduğunu gösterir.\r\n\r\nCoğrafya, sürdürülebilirlik ve çevre koruma gibi konuları da ele alır. Doğal kaynakların yönetimi, çevre kirliliği, iklim değişikliği ve doğal yaşamın korunması gibi konular, coğrafi perspektiften incelenir. Bu, insanların doğal kaynakları sürdürülebilir bir şekilde kullanmasını ve doğal çevreyi korumasını sağlar.\r\n\r\nSonuç olarak, coğrafya, dünya ve insanlığın anlaşılması için temel bir araçtır. Coğrafi bilgi, insanların yaşadıkları yerleri, doğal çevreyi ve kültürel etkileşimleri anlamalarına yardımcı olur. Coğrafyanın önemi, hem bireysel hem de toplumsal düzeyde insanların yaşamlarını ve dünyayı daha iyi bir şekilde anlamalarına katkıda bulunur.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 9, 73, DateTimeKind.Local).AddTicks(4903), null, null, 9, false, "Coğrafyanın Önemi: Dünya ve İnsanlığın Anlaşılması İçin Temel Araç", null, null, 3, 20 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AppUserId",
                table: "Article",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CategoryId",
                table: "Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Article_ImageId",
                table: "Article",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitor_ArticleId",
                table: "ArticleVisitor",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitor_VisitorId",
                table: "ArticleVisitor",
                column: "VisitorId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitor");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
