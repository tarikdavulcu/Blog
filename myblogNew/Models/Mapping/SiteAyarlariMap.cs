using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace myblogNew.Models.Mapping
{
    public class SiteAyarlariMap : EntityTypeConfiguration<SiteAyarlari>
    {
        public SiteAyarlariMap()
        {
            // Primary Key
            this.HasKey(t => t.SiteAyarID);

            // Properties
            this.Property(t => t.SiteLinki)
                .HasMaxLength(50);

            this.Property(t => t.SiteAdi)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("SiteAyarlari");
            this.Property(t => t.SiteAyarID).HasColumnName("SiteAyarID");
            this.Property(t => t.SiteLogo).HasColumnName("SiteLogo");
            this.Property(t => t.SiteFavicon).HasColumnName("SiteFavicon");
            this.Property(t => t.SiteTitle).HasColumnName("SiteTitle");
            this.Property(t => t.SiteTwitter).HasColumnName("SiteTwitter");
            this.Property(t => t.SiteFacebook).HasColumnName("SiteFacebook");
            this.Property(t => t.SiteInstagram).HasColumnName("SiteInstagram");
            this.Property(t => t.SiteGithub).HasColumnName("SiteGithub");
            this.Property(t => t.SiteLinkedin).HasColumnName("SiteLinkedin");
            this.Property(t => t.SiteCopyright).HasColumnName("SiteCopyright");
            this.Property(t => t.SiteAnasayfaResim).HasColumnName("SiteAnasayfaResim");
            this.Property(t => t.SiteAnasayfa).HasColumnName("SiteAnasayfa");
            this.Property(t => t.SiteAnasayfaAltBaslik).HasColumnName("SiteAnasayfaAltBaslik");
            this.Property(t => t.SiteHakkimdaResim).HasColumnName("SiteHakkimdaResim");
            this.Property(t => t.SiteHakkimda).HasColumnName("SiteHakkimda");
            this.Property(t => t.SiteHakkimdaAltBaslik).HasColumnName("SiteHakkimdaAltBaslik");
            this.Property(t => t.SiteHakkimdaAciklama).HasColumnName("SiteHakkimdaAciklama");
            this.Property(t => t.SiteIletisimResim).HasColumnName("SiteIletisimResim");
            this.Property(t => t.SiteIletisim).HasColumnName("SiteIletisim");
            this.Property(t => t.SiteIletisimAltBaslik).HasColumnName("SiteIletisimAltBaslik");
            this.Property(t => t.SiteIletisimAciklama).HasColumnName("SiteIletisimAciklama");
            this.Property(t => t.SiteLinki).HasColumnName("SiteLinki");
            this.Property(t => t.SiteAdi).HasColumnName("SiteAdi");
            this.Property(t => t.SiteAnasayfaEtiket).HasColumnName("SiteAnasayfaEtiket");
            this.Property(t => t.SiteKisiProfil).HasColumnName("SiteKisiProfil");
            this.Property(t => t.SiteKisiEPosta).HasColumnName("SiteKisiEPosta");
            this.Property(t => t.SiteKisiTel).HasColumnName("SiteKisiTel");
            this.Property(t => t.SiteKisiAdres).HasColumnName("SiteKisiAdres");
        }
    }
}
