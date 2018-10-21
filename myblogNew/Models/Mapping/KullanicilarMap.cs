using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace myblogNew.Models.Mapping
{
    public class KullanicilarMap : EntityTypeConfiguration<Kullanicilar>
    {
        public KullanicilarMap()
        {
            // Primary Key
            this.HasKey(t => t.KullaniciID);

            // Properties
            this.Property(t => t.KullaniciAdi)
                .HasMaxLength(50);

            this.Property(t => t.Sifre)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Kullanicilar");
            this.Property(t => t.KullaniciID).HasColumnName("KullaniciID");
            this.Property(t => t.KullaniciAdi).HasColumnName("KullaniciAdi");
            this.Property(t => t.Sifre).HasColumnName("Sifre");
            this.Property(t => t.Mail).HasColumnName("Mail");
        }
    }
}
