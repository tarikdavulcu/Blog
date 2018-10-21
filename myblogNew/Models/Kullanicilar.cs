using System;
using System.Collections.Generic;

namespace myblogNew.Models
{
    public partial class Kullanicilar
    {
        public Kullanicilar()
        {
            this.Blogs = new List<Blog>();
        }

        public int KullaniciID { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string Mail { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
    }
}
