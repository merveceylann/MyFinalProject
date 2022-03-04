using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages //surekli bunu newlemek icin ve sabit oldugu icin static yaptik
    {
        public static string ProductAdded = "Urun eklendi";
        public static string ProductNameInvalid = "Urun ismi gecersiz";
        public static string ProductListed = "Urunler listelendi";
        public static string MaintenanceTime = "Sistem bakimda";
        public static string ProductCountOfCategoryError = "Urun sayisi 10 dan kucuk olmali!";
        public static string ProductNameAlreadyExists = "Boyle bir urun var";
        internal static string CategoryLimitExceded = "Category limiti asildi";
    }
}

