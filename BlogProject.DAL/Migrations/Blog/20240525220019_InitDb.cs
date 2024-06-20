using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProject.DAL.Migrations.Blog
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
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
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
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
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
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
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Articles_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleVisitors",
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
                    table.PrimaryKey("PK_ArticleVisitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ArticleVisitors_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7130), null, null, false, "Teknoloji", null, null },
                    { 2, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7133), null, null, false, "Ekonomi", null, null },
                    { 3, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7135), null, null, false, "Psikoloji", null, null },
                    { 4, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7137), null, null, false, "Felsefe", null, null },
                    { 5, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7138), null, null, false, "Tarih", null, null },
                    { 6, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7139), null, null, false, "Otomobil", null, null },
                    { 7, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7141), null, null, false, "Tarim", null, null },
                    { 8, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7142), null, null, false, "Cinsel Hayat", null, null },
                    { 9, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7144), null, null, false, "Cografya", null, null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "FileName", "FileType", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7593), null, null, "article-images/teknoloji.png", "png", false, null, null },
                    { 2, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7596), null, null, "article-images/ekonomi.png", "png", false, null, null },
                    { 3, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7597), null, null, "article-images/psikoloji.png", "png", false, null, null },
                    { 4, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7599), null, null, "article-images/felsefe.jpg", "jpg", false, null, null },
                    { 5, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7601), null, null, "article-images/tarih.jpg", "jpg", false, null, null },
                    { 6, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7602), null, null, "article-images/otomobil.jpg", "jpg", false, null, null },
                    { 7, "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7604), null, null, "article-images/tarim.jpg", "jpg", false, null, null },
                    { 8, "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7605), null, null, "article-images/cinsel hayat.jpg", "jpg", false, null, null },
                    { 9, "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(7607), null, null, "article-images/cografya.jpg", "jpg", false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "UserId", "ViewCount" },
                values: new object[,]
                {
                    { 1, 3, "Duygusal zeka, bireylerin duygularını anlama, yönetme ve başkalarının duygularını anlama yeteneğini ifade eder. Bu kavram, geleneksel zeka kavramının yanı sıra kişinin sosyal ve duygusal becerilerini de içerir. Duygusal zekaya sahip olmak, ilişkileri güçlendirmek, stresle başa çıkmak ve genel refahı artırmak için kritik bir öneme sahiptir.\n\nDuygusal zeka, beş ana bileşenden oluşur: öz farkındalık, duygu yönetimi, sosyal farkındalık, ilişki yönetimi ve öz motivasyon. Öz farkındalık, kişinin duygularını tanıma ve anlama yeteneğini ifade eder. Duygu yönetimi, duyguları etkili bir şekilde yönetme ve uygun tepkiler verme becerisini içerir. Sosyal farkındalık, başkalarının duygularını tanıma ve empati kurma yeteneğini ifade eder. İlişki yönetimi, sağlıklı ilişkiler kurma, çatışmaları çözme ve işbirliği yapma becerisini içerir. Son olarak, öz motivasyon, uzun vadeli hedeflere odaklanma, yenilgiyi aşma ve içsel motivasyonu koruma yeteneğini ifade eder.\n\nDuygusal zekanın önemi, kişisel ve profesyonel başarı üzerinde derin bir etkiye sahiptir. Araştırmalar, duygusal zekası yüksek bireylerin daha sağlıklı ilişkilere, daha iyi iş performansına ve daha iyi psikolojik refaha sahip olduğunu göstermektedir. Ayrıca, duygusal zeka, stresle başa çıkma, problem çözme ve yaşamın zorluklarıyla baş etme becerilerini geliştirmeye yardımcı olabilir.\n\nDuygusal zeka, doğuştan gelen bir yetenek olmakla birlikte, herkes bu beceriyi geliştirebilir. Kendi duygularınızı tanıma, empati kurma ve etkili iletişim becerileri geliştirme gibi stratejilerle duygusal zekanızı artırabilirsiniz. Ayrıca, stres yönetimi, zihinsel sağlık ve kişisel gelişim alanlarında destek alarak duygusal zekanızı güçlendirebilirsiniz.\n\nSonuç olarak, duygusal zeka, hayatı daha anlamlı kılan ve kişisel gelişimi destekleyen önemli bir beceridir. Duygusal zekaya sahip olmak, daha sağlıklı ilişkiler kurma, iş performansını artırma ve genel refahı iyileştirme fırsatı sunar. Bu nedenle, duygusal zeka üzerinde çalışmak ve bu beceriyi geliştirmek, herkes için önemli bir hedeftir.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6453), null, null, 1, false, "Hayatı Daha Anlamlı Kılan Beceri", null, null, 3, 19 },
                    { 2, 2, "Ekonomi, sadece para ve piyasalarla ilgili değildir; aynı zamanda insanların karar alma süreçlerini de içerir. Tüketici davranışları, ekonomideki bu insan odaklı perspektifi temsil eder ve tüketicilerin alışveriş, harcama ve kaynak tahsisi gibi kararlarını anlamaya odaklanır. Tüketici davranışları, piyasalardaki talebi belirler ve şirketlerin ürünlerini pazarlama stratejilerini oluşturmasına yardımcı olur.\n\nTüketici davranışları, bir dizi faktörden etkilenir. Bunlar arasında kişisel tercihler, gelir seviyesi, fiyatlar, reklamlar, sosyal normlar ve kültürel faktörler bulunur. Örneğin, bir tüketici bir ürün satın alırken, hem ürünün fiyatını hem de kalitesini dikkate alabilir. Ayrıca, ürünün markası, sosyal statüye olan etkisi veya arkadaşların önerileri gibi faktörler de satın alma kararını etkileyebilir.\n\nEkonomide tüketici davranışlarının anlaşılması, hem bireyler hem de işletmeler için önemlidir. Bireyler, kişisel finansal kararlarında daha bilinçli olmak için tüketici davranışlarını anlamalıdır. Aynı zamanda, işletmeler, tüketicilerin taleplerini ve tercihlerini anlamak için tüketici davranışlarını analiz eder ve buna göre pazarlama stratejilerini belirler.\n\nTüketici davranışlarını anlamak, ekonomideki etkileşimleri ve sonuçları değerlendirmek için kritik bir öneme sahiptir. Bu anlayış, ekonomik politikaların oluşturulmasında ve tüketici refahının artırılmasında da önemli bir rol oynar. Örneğin, tüketici davranışları analizi, vergi politikalarının tasarımında veya rekabet politikalarının belirlenmesinde kullanılabilir.\n\nSonuç olarak, tüketici davranışları ekonomide merkezi bir rol oynar ve tüketicilerin alışveriş ve harcama kararlarını anlamak, hem bireylerin hem de işletmelerin ekonomik başarısı için kritik öneme sahiptir.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6457), null, null, 2, false, "Ekonomik Karar Alma Sürecindeki Anahtar Rol", null, null, 2, 67 },
                    { 3, 1, "Teknoloji, günümüzün vazgeçilmez bir parçası haline gelmiştir ve günlük yaşamımızı birçok şekilde etkilemektedir. İnternetten akıllı telefonlara, yapay zekadan bulut bilişime kadar, teknolojinin sunduğu imkanlar, iletişimi kolaylaştırmaktan, iş yapma şeklimizi değiştirmeye kadar geniş bir yelpazede etkiye sahiptir.\n\nTeknoloji, iletişim alanında devrim yaratmıştır. İnternet ve sosyal medya platformları, dünya çapında insanların birbirleriyle bağlantı kurmasını sağlar. Arkadaşlarla iletişim kurmak, haber almak, bilgi paylaşmak ve hatta işbirliği yapmak için artık sınırların ötesine geçmek gerekmiyor. Bu, küresel topluluğun daha bağlantılı hale gelmesine ve bilgi paylaşımının artmasına olanak tanır.\n\nTeknolojinin iş dünyasındaki rolü de büyük bir dönüşüm geçirmiştir. Dijitalleşme ve otomasyon, iş süreçlerini daha verimli hale getirirken, uzaktan çalışma imkanı iş modellerini değiştirmiştir. Artık birçok iş, fiziksel ofis ortamına bağımlı olmadan da yürütülebilir hale gelmiştir. Ayrıca, yapay zeka ve veri analitiği gibi teknolojik yenilikler, işletmelerin veri tabanlı kararlar almasına ve müşteri deneyimini geliştirmesine olanak tanır.\n\nSağlık sektöründe de teknolojinin rolü giderek artmaktadır. Tele-tıp uygulamaları, hasta bakımını daha erişilebilir hale getirirken, sağlık verilerinin dijitalleştirilmesi, tedavi planlamasını ve hastalık izleme süreçlerini iyileştirir. Böylece, teknoloji sağlık hizmetlerinin daha etkin ve verimli bir şekilde sunulmasına katkıda bulunur.\n\nSonuç olarak, teknoloji günlük yaşamımızı derinlemesine etkilemektedir ve sürekli olarak dönüşüm geçirmektedir. İletişimden iş dünyasına, sağlık hizmetlerinden eğitime kadar her alanda teknolojinin rolü büyük önem taşır. Bu nedenle, teknolojik gelişmeleri takip etmek ve bu yenilikleri günlük hayatımıza entegre etmek, bireysel ve toplumsal olarak rekabet avantajı sağlar.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6459), null, null, 3, false, "Teknolojinin Günlük Hayattaki Rolü: Dönüşüm ve Etkileşim", null, null, 1, 20 },
                    { 4, 4, "Felsefe, insanlığın varoluşundan bu yana bilgelik arayışının merkezinde yer alan bir disiplindir. Felsefe, temel soruları sorgulamak, bilgiyi keşfetmek ve insanın kendisi ve evren hakkındaki anlayışını derinleştirmek için bir çerçeve sağlar. Felsefenin amacı, düşünceyi yönlendirmek, değerleri sorgulamak ve yaşamın anlamını aramaktır.\r\n\r\nFelsefenin tarihi, birçok büyük düşünürün felsefi sorulara cevap aramasıyla işlenir. Antik Yunan filozofları, bilgi, gerçeklik, adalet ve erdem gibi kavramları tartıştılar. Sokrates'in sorgulama yöntemi, Platon'un idealar kuramı ve Aristoteles'in lojik ve metafizik çalışmaları, felsefi düşüncenin temelini oluşturur.\r\n\r\nFelsefenin önemi, sadece akademik bir konu olarak değil, aynı zamanda günlük yaşamımızda da kendini gösterir. Felsefi düşünce, insanların dünya görüşlerini şekillendirir, değerleri sorgular ve etik kararlar almalarına rehberlik eder. Ayrıca, felsefe, eleştirel düşünme becerilerini geliştirir, problem çözme yeteneğini artırır ve insanların yaşamlarını anlamlı kılar.\r\n\r\nFelsefe, insanın kendisi ve evren hakkındaki bilgisini derinleştirmenin yanı sıra, bireysel ve toplumsal düzeyde refahı artırmak için de kullanılabilir. Etik ve siyaset felsefesi, adaletin ve eşitliğin nasıl sağlanabileceğini tartışırken, metafizik ve ontoloji evrenin temel yapısını anlamaya çalışır. Bu, insanların kendi düşünce ve davranışlarını daha bilinçli bir şekilde şekillendirmelerine yardımcı olur.\r\n\r\nSonuç olarak, felsefe, insanlık yolculuğunun ayrılmaz bir parçasıdır ve insanın bilgelik arayışını şekillendiren temel bir disiplindir. Felsefi düşünce, insanların dünya görüşlerini genişletir, değerleri sorgular ve yaşamlarını anlamlı kılar. Bu nedenle, felsefe, bireysel ve toplumsal düzeyde daha iyi bir anlayış ve refah için kritik bir öneme sahiptir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6461), null, null, 3, false, "Felsefenin Önemi: Bilgelik Arayışı ve İnsanlık Yolculuğu", null, null, 1, 19 },
                    { 5, 5, "Tarih, insanlığın geçmiş deneyimlerini inceleyen ve anlamaya çalışan disiplindir. Tarih, olayları, insanların davranışlarını, toplumların yapılarını ve kültürel değişimleri inceler. Bu nedenle, tarih, insanlığın kolektif hafızasıdır ve geçmişten geleceğe uzanan bir yolculuktur.\r\n\r\nTarihin önemi, insanların geçmiş hakkında bilgi edinmesine ve geleceği şekillendirmesine yardımcı olmasıdır. Geçmişteki olayları anlamak, bugünkü dünyayı ve toplumları daha iyi anlamamıza ve değerlendirmemize yardımcı olur. Tarih, insanlığın ne kadar ilerlediğini gösterirken, aynı zamanda insan doğasının temel özelliklerini de ortaya koyar.\r\n\r\nTarih, kültürler arası etkileşimi ve değişimi anlamamıza da yardımcı olur. İnsanların farklı toplumlar arasındaki ilişkilerini, ticaret yollarını ve kültürel alışverişi inceleyerek, tarih bize insanlığın karmaşık ve çeşitli doğasını gösterir. Ayrıca, tarih, ideolojilerin ve inanç sistemlerinin nasıl geliştiğini anlamamıza ve bugünkü dünyadaki sosyal ve politik yapıları daha iyi kavramamıza yardımcı olur.\r\n\r\nTarihin öğretilmesi ve öğrenilmesi, genç nesillerin tarih bilincini geliştirmesine ve geçmişten ders çıkarmasına olanak tanır. Tarih, insanların geçmişteki hatalardan ders almasını ve geleceği daha iyi bir şekilde şekillendirmesini sağlar. Ayrıca, tarih, milli kimlik ve toplumsal bellek oluşturmanın bir yolu olarak da önemlidir.\r\n\r\nSonuç olarak, tarih insanlığın geçmişini inceleyen ve anlamaya çalışan kritik bir disiplindir. Geçmiş olayları ve deneyimleri inceleyerek, insanlar bugünkü dünyayı ve geleceği daha iyi anlamaya ve değerlendirmeye yardımcı olabilirler. Tarih, insanların ortak hafızasıdır ve insanlık hikayesinin bir parçasıdır.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6469), null, null, 5, false, "Tarihin Önemi: Geçmişten Geleceğe İnsanlık Hikayesi", null, null, 2, 67 },
                    { 6, 6, "\r\nElbette, işte otomobillerle ilgili kısa bir makale:\r\n\r\nOtomobil Devrimi: Mobilite ve Modern Yaşamın Köprüsü\r\n\r\nOtomobil, modern dünyanın vazgeçilmez bir parçası haline gelmiştir. Mobiliteyi artıran ve iletişimi kolaylaştıran otomobiller, insanların günlük yaşamlarını kökten değiştirmiştir. Otomobil devrimi, ulaşımın dönüşümünde bir kilometre taşı olmuş ve toplumların yapısını etkilemiştir.\r\n\r\nOtomobiller, insanların yerinden bağımsız olarak seyahat etmesini sağlar. Bu, işe gitmek, alışveriş yapmak, aile ziyaretleri ve tatil gibi günlük aktiviteleri daha kolay ve hızlı hale getirir. Otomobiller aynı zamanda toplumların ve ekonomilerin büyümesine katkıda bulunur, çünkü insanlar işlerine daha kolay ve verimli bir şekilde ulaşabilirler.\r\n\r\nOtomobiller, endüstriyel devrimin bir sonucu olarak ortaya çıkmıştır ve sürekli olarak gelişmiştir. İlk otomobiller, insanların ulaşımında devrim yaratmış ve dünya çapında bir fenomen haline gelmiştir. Daha sonra, otomobil teknolojisindeki ilerlemeler, daha güvenli, daha çevre dostu ve daha konforlu araçlar üretilmesine olanak tanımıştır.\r\n\r\nAncak, otomobillerin yaygın kullanımı çevresel ve sosyal sorunları da beraberinde getirmiştir. Fosil yakıtlı araçlar, hava kirliliği ve iklim değişikliği gibi çevresel sorunlara katkıda bulunurken, trafik sıkışıklığı ve kazalar da toplumsal sorunlar olarak ortaya çıkmıştır. Bu nedenle, otomobil endüstrisi sürekli olarak daha sürdürülebilir ve çevre dostu çözümler aramaktadır.\r\n\r\nSonuç olarak, otomobil devrimi, mobiliteyi artıran ve modern yaşamın temel bir parçası haline gelen önemli bir dönüşümü temsil eder. Otomobiller, insanların günlük yaşamlarını kolaylaştırırken, aynı zamanda çevresel ve sosyal sorunlara da neden olabilirler. Bu nedenle, otomobil endüstrisi sürdürülebilirlik ve yenilikçilik üzerine odaklanarak gelecekte daha iyi bir mobilite sağlamayı hedeflemektedir.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6471), null, null, 6, false, "Otomobil Devrimi: Mobilite ve Modern Yaşamın Köprüsü", null, null, 3, 20 },
                    { 7, 7, "Tarım, insanlık tarihindeki en eski ve en temel geçim kaynaklarından biridir. Tarım, yiyecek üretimi için toprak kullanımını ve bitki yetiştiriciliğini ifade eder. İnsanlar, tarımı binlerce yıl boyunca hayatta kalmak ve toplumlarını beslemek için kullanmışlardır.\r\n\r\nTarım, insanlığın yerleşik yaşama geçişinde kritik bir rol oynamıştır. Tarım sayesinde insanlar, avcılık ve toplayıcılıktan çiftçilik ve hayvancılığa geçiş yapmışlardır. Bu, insanların daha kalabalık topluluklar halinde yaşamalarına ve şehirlerin kurulmasına olanak tanımıştır. Ayrıca, tarımın ortaya çıkması, medeniyetin gelişmesiyle birlikte ekonomik, sosyal ve kültürel yapıların oluşmasını da sağlamıştır.\r\n\r\nTarım, günümüzde de insanlık için hayati bir öneme sahiptir. Dünya nüfusu sürekli olarak artarken, gıda güvenliği ve beslenme ihtiyacı da artmaktadır. Tarım, bu ihtiyaçları karşılamak için gerekli olan yiyecek ve lif üretimini sağlar. Ayrıca, tarım sektörü, birçok ülkenin ekonomisinde önemli bir yer tutar ve istihdam yaratır.\r\n\r\nAncak, modern tarımın bazı sorunları da vardır. Endüstriyel tarım uygulamaları, toprak erozyonu, su kirliliği ve biyoçeşitlilik kaybı gibi çevresel sorunlara neden olabilir. Ayrıca, tarım kimyasalları ve genetiği değiştirilmiş organizmalar gibi teknolojilerin kullanımı, gıda güvenliği ve insan sağlığı konularında endişelere neden olabilir.\r\n\r\nBu nedenle, sürdürülebilir tarım uygulamalarının teşvik edilmesi ve çiftçilere destek sağlanması önemlidir. Organik tarım, çevre dostu tarım uygulamaları ve yerel gıda üretimi gibi yaklaşımlar, tarımın çevresel ve sosyal etkilerini azaltabilir. Ayrıca, teknolojik yeniliklerin kullanımı, verimliliği artırabilir ve tarımın daha sürdürülebilir hale gelmesine yardımcı olabilir.\r\n\r\nSonuç olarak, tarım insanlığın temel geçim kaynaklarından biridir ve yaşamın devamı için hayati bir öneme sahiptir. Ancak, modern tarım uygulamalarının çevresel ve sosyal etkileri göz önünde bulundurularak sürdürülebilir tarım yöntemleri teşvik edilmelidir.", "Cevdet Heredot", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6475), null, null, 7, false, "Tarımın Önemi: Geçmişten Günümüze İnsanlıkın Temel Geçim Kaynağı", null, null, 1, 19 },
                    { 8, 8, "Cinsel hayat, insanın fiziksel, duygusal ve sosyal refahını derinden etkileyen önemli bir yaşam alanıdır. Cinsellik, sağlıklı bir yaşamın ayrılmaz bir parçası olarak kabul edilmelidir ve cinsel sağlık, bireylerin ve toplumların genel refahını etkileyen birçok faktöre bağlıdır.\r\n\r\nCinsel sağlık, cinsel ilişkilerin fiziksel ve duygusal olarak sağlıklı ve tatmin edici olmasını içerir. Bu, cinsel yolla bulaşan enfeksiyonlardan korunma, doğum kontrolü yöntemlerinin bilinçli kullanımı ve cinsel ilişkilerde rahatlık ve güven duygusunun olması gibi çeşitli unsurları içerir. Ayrıca, cinsel sağlık, cinsel eğitim ve bilgiye erişim gibi faktörlerle de yakından ilişkilidir.\r\n\r\nCinsel hayatın sağlıklı ve tatmin edici olması, genel yaşam kalitesini artırır. Düzenli cinsel aktivite, stresi azaltabilir, bağışıklık sistemini güçlendirebilir ve duygusal bağları güçlendirebilir. Ayrıca, cinsel ilişkilerin duygusal ve zihinsel sağlık üzerinde olumlu etkileri olduğu bilinmektedir.\r\n\r\nAncak, cinsel hayat bazen sorunlarla da karşılaşabilir. Cinsel işlev bozuklukları, cinsel isteksizlik, orgazm sorunları ve cinsel travmalar gibi sorunlar, bireylerin cinsel sağlığını olumsuz yönde etkileyebilir. Bu gibi durumlarda, uzman yardımı almak ve uygun tedavileri aramak önemlidir.\r\n\r\nCinsel sağlık ve iyilik, beden ve zihin arasındaki dengeyi korumak için kritik bir faktördür. Cinsel sağlık, bireylerin kendilerini iyi hissetmelerine, ilişkilerinde daha tatmin edici deneyimler yaşamalarına ve genel refahlarını artırmalarına yardımcı olur. Bu nedenle, cinsel sağlık konusunda bilinçli olmak, düzenli sağlık kontrolleri yapmak ve gerektiğinde profesyonel yardım almak önemlidir.", "Mahmut Taylan", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6477), null, null, 8, false, "Cinsel Sağlık ve İyilik: Beden ve Zihin Arasındaki Dengenin Önemi", null, null, 2, 67 },
                    { 9, 9, "Coğrafya, dünya üzerindeki yerleri, doğal ve beşeri süreçleri inceleyen bir bilim dalıdır. Toprak, su, iklim, bitki örtüsü, yerleşim birimleri, ekonomik aktiviteler ve insan etkileşimleri gibi konular coğrafyanın kapsamına girer. Coğrafya, dünyayı anlamamızı sağlayan bir çerçeve sunar ve insanlığın doğal ve beşeri çevresiyle olan ilişkisini keşfetmemize yardımcı olur.\r\n\r\nCoğrafyanın önemi, insanların yaşadığı yerleri, doğal kaynakları ve çevresel koşulları anlamamıza yardımcı olmasıdır. İnsanlar, coğrafi koşullara uyum sağlayarak yerleşim yerleri seçerler, tarımı, endüstriyi ve ticareti planlarlar. Ayrıca, coğrafi özellikler, iklim değişiklikleri ve doğal afetler gibi faktörler, insanların günlük yaşamlarını ve ekonomik faaliyetlerini etkiler.\r\n\r\nCoğrafya, kültürel etkileşimleri ve küresel ilişkileri anlamamıza da yardımcı olur. Ticaret yolları, göç hareketleri, kültürel değişimler ve çatışma bölgeleri gibi konular, coğrafi faktörlerden etkilenir. Coğrafi bilgi, uluslararası ilişkilerde ve küresel politikada önemli bir rol oynar ve insanların dünya çapında birbirleriyle bağlantılı olduğunu gösterir.\r\n\r\nCoğrafya, sürdürülebilirlik ve çevre koruma gibi konuları da ele alır. Doğal kaynakların yönetimi, çevre kirliliği, iklim değişikliği ve doğal yaşamın korunması gibi konular, coğrafi perspektiften incelenir. Bu, insanların doğal kaynakları sürdürülebilir bir şekilde kullanmasını ve doğal çevreyi korumasını sağlar.\r\n\r\nSonuç olarak, coğrafya, dünya ve insanlığın anlaşılması için temel bir araçtır. Coğrafi bilgi, insanların yaşadıkları yerleri, doğal çevreyi ve kültürel etkileşimleri anlamalarına yardımcı olur. Coğrafyanın önemi, hem bireysel hem de toplumsal düzeyde insanların yaşamlarını ve dünyayı daha iyi bir şekilde anlamalarına katkıda bulunur.", "Dursun Durmasin", new DateTime(2024, 5, 26, 1, 0, 19, 184, DateTimeKind.Local).AddTicks(6478), null, null, 9, false, "Coğrafyanın Önemi: Dünya ve İnsanlığın Anlaşılması İçin Temel Araç", null, null, 3, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ImageId",
                table: "Articles",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_ArticleId",
                table: "ArticleVisitors",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVisitors_VisitorId",
                table: "ArticleVisitors",
                column: "VisitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVisitors");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Images");
        }
    }
}
