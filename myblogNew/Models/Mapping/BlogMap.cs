using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace myblogNew.Models.Mapping
{
    public class BlogMap : EntityTypeConfiguration<Blog>
    {
        public BlogMap()
        {
            // Primary Key
            this.HasKey(t => t.BlogID);

            // Properties
            this.Property(t => t.SeoLink)
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Blog");
            this.Property(t => t.BlogID).HasColumnName("BlogID");
            this.Property(t => t.Resim).HasColumnName("Resim");
            this.Property(t => t.Baslik).HasColumnName("Baslik");
            this.Property(t => t.AltBaslik).HasColumnName("AltBaslik");
            this.Property(t => t.Icerik).HasColumnName("Icerik");
            this.Property(t => t.PostTarihi).HasColumnName("PostTarihi");
            this.Property(t => t.KullaniciID).HasColumnName("KullaniciID");
            this.Property(t => t.SeoLink).HasColumnName("SeoLink");

            // Relationships
            this.HasOptional(t => t.Kullanicilar)
                .WithMany(t => t.Blogs)
                .HasForeignKey(d => d.KullaniciID);

        }
    }
}
