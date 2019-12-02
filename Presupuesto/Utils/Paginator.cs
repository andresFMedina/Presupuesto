using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presupuesto.Utils
{
    public class Paginator<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int RegisterPerPages { get; set; }
        public int TotalRegister { get; set; }
        public int TotalPages { get; set; }
        public string CurrentFilter { get; set; }
        public IEnumerable <T> Result { get; set; }
    }
}
