using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_2_KM
{
    class Product
    {
        public decimal Price { get; set; } // цена товара
        public string Name { get; set; } // название товара

        public Product(string Name, decimal Price) // конструктор товара
        {
            this.Name = Name; // установка названия
            this.Price = Price; // установка цены
        }

        public string GetInfo() // получение информации о товаре
        {
            return $"Наименование: {Name}; Цена: {Price} руб.";
        }
    }
}
