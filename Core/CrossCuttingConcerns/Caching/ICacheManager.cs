using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key); //generic olmayan versiyonu(typecasting yapmak gerekir)
        void Add(string key, object value, int duration);
        bool IsAdd(string key); //cachete olup olmadigini kontrol etmek icin
        void Remove(string key);
        void RemoveByPattern(string key); //icinde category olanlari sil gibi bi pattern verebilmek icin
    }
}
