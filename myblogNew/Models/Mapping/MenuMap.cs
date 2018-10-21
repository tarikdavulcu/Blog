using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace myblogNew.Models.Mapping
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            // Primary Key
            this.HasKey(t => t.MenuID);

            // Properties
            this.Property(t => t.Adi)
                .HasMaxLength(50);

            this.Property(t => t.Link)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Menu");
            this.Property(t => t.MenuID).HasColumnName("MenuID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Link).HasColumnName("Link");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.SiraNo).HasColumnName("SiraNo");
        }
    }
}
