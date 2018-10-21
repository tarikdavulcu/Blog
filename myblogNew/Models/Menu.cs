using System;
using System.Collections.Generic;

namespace myblogNew.Models
{
    public partial class Menu
    {
        public int MenuID { get; set; }
        public string Adi { get; set; }
        public string Link { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> SiraNo { get; set; }
    }
}
