using System;
using System.Collections.Generic;

namespace myblogNew.Models
{
    public partial class Blog
    {
        public int BlogID { get; set; }
        public string Resim { get; set; }
        public string Baslik { get; set; }
        public string AltBaslik { get; set; }
        public string Icerik { get; set; }
        public Nullable<System.DateTime> PostTarihi { get; set; }
        public Nullable<int> KullaniciID { get; set; }
        public string SeoLink { get; set; }
        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
