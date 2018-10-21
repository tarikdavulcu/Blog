using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace myblogNew.Models.Mapping
{
    public class MesajlarMap : EntityTypeConfiguration<Mesajlar>
    {
        public MesajlarMap()
        {
            // Primary Key
            this.HasKey(t => t.MesajID);

            // Properties
            this.Property(t => t.Ad)
                .HasMaxLength(50);

            this.Property(t => t.Mail)
                .HasMaxLength(100);

            this.Property(t => t.Telefon)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Mesajlar");
            this.Property(t => t.MesajID).HasColumnName("MesajID");
            this.Property(t => t.Ad).HasColumnName("Ad");
            this.Property(t => t.Mail).HasColumnName("Mail");
            this.Property(t => t.Telefon).HasColumnName("Telefon");
            this.Property(t => t.Mesaj).HasColumnName("Mesaj");
        }
    }
}
