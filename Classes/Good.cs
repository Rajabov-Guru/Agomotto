using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agamotto.Classes
{
    class Good
    {

        public string type = "Нет";
        public double price = 0;
        public string nameBrend = "Нет";
        public string name = "Неизвестный товар";
        public string href = "Нет";
        public string properties = "Нет";
        public string image;
        public string ToFormat()
        {
            return $"{type}][{name}][{price}][{nameBrend}][{href}][{properties}";
        }

    }
}
