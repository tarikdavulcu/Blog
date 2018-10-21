using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using myblogNew.Models.Mapping;

namespace myblogNew.Models
{
    public partial class myBlogContext : DbContext
    {
        static myBlogContext()
        {
            Database.SetInitializer<myBlogContext>(null);
        }

        public myBlogContext()
            : base("Name=myBlogContext")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Kullanicilar> Kullanicilars { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<SiteAyarlari> SiteAyarlaris { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BlogMap());
            modelBuilder.Configurations.Add(new KullanicilarMap());
            modelBuilder.Configurations.Add(new MenuMap());
            modelBuilder.Configurations.Add(new MesajlarMap());
            modelBuilder.Configurations.Add(new SiteAyarlariMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
        }
    }
}
