using BlogProject.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.DAL.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn(1, 1);

            builder.Property(x => x.FileName)
                .IsRequired();

            builder.Property(x => x.FileType)
                .IsRequired();

            builder.HasData(
                new Image { Id = 1, FileName = "article-images/teknoloji.png", FileType = "png", CreatedBy = "Cevdet Heredot", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 2, FileName = "article-images/ekonomi.png", FileType = "png", CreatedBy = "Mahmut Taylan", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 3, FileName = "article-images/psikoloji.png", FileType = "png", CreatedBy = "Dursun Durmasin", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 4, FileName = "article-images/felsefe.jpg", FileType = "jpg", CreatedBy = "Cevdet Heredot", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 5, FileName = "article-images/tarih.jpg", FileType = "jpg", CreatedBy = "Mahmut Taylan", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 6, FileName = "article-images/otomobil.jpg", FileType = "jpg", CreatedBy = "Dursun Durmasin", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 7, FileName = "article-images/tarim.jpg", FileType = "jpg", CreatedBy = "Cevdet Heredot", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 8, FileName = "article-images/cinsel hayat.jpg", FileType = "jpg", CreatedBy = "Mahmut Taylan", CreatedDate = DateTime.Now, IsDeleted = false },
                new Image { Id = 9, FileName = "article-images/cografya.jpg", FileType = "jpg", CreatedBy = "Dursun Durmasin", CreatedDate = DateTime.Now, IsDeleted = false }
                );


        }
    }
}
