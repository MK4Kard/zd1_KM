using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1_2_KM
{
    class Shop
    {
        private Dictionary<Product, int> products; // словарь товаров и их количества
        private decimal profit; // прибыль магазина

        public Shop() // конструктор магазина
        {
            products = new Dictionary<Product, int>(); // инициализация словаря
            profit = 0; // начальная прибыль = 0
        }

        public void AddProduct(Product product, int count) // добавление товара
        {
            // поиск существующего товара с таким же названием
            var existingProduct = products.Keys.FirstOrDefault(p => p.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase));

            // если товар с таким названием уже есть
            if (existingProduct != null)
            {
                if (existingProduct.Price != product.Price) // проверки сущетсвующей цены с добавляемой
                {
                    // вывод исключения
                    throw new ArgumentException($"Товар с названием '{product.Name}' уже существует с другой ценой ({existingProduct.Price} руб.)");
                }

                products[existingProduct] += count; // увеличиваем количество существующего товара
            }
            else
            {
                products.Add(product, count); // добавление нового товара
            }
        }

        public List<string> WriteAllProducts(ref string title) // получение списка всех товаров в текстовом формате
        {
            List<string> prod = new List<string>(); // создание списка для хранения строк с информацией о товарах
            
            title = "Список продуктов: "; // установление заголовка
            foreach (var product in products) // перебор всех товаров
            {
                prod.Add(product.Key.GetInfo() + "; Количество: " + product.Value); // добавление товара в список
            }

            return prod; // возвращение товаров
        }

        public void CreateProduct(string name, decimal price, int count) // создание нового товара
        {
            // поиск существующего товара с таким же названием
            var existingProduct = products.Keys.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            // если товар с таким названием уже есть
            if (existingProduct != null)
            {
                if (existingProduct.Price != price) // проверки сущетсвующей цены с добавляемой
                {
                    // вывод исключения
                    throw new ArgumentException($"Товар с названием '{name}' уже существует с другой ценой ({existingProduct.Price} руб.)");
                }

                products[existingProduct] += count; // увеличиваем количество существующего товара
            }
            else
            {
                products.Add(new Product(name, price), count); // добавление нового товара
            }
        }

        public void Sell(Product product, ref string text) // продажа одной единицы товара
        {
            if (products.ContainsKey(product)) // проверка наличия товара в магазине
            {
                if (products[product] == 0) // проверка наличия
                {
                    text = "Нет в наличии!";
                }
                else
                {
                    products[product]--; // усеньшение количества на 1
                }
            }
            else
            {
                text = "Товар не найден!";
            }
        }
        public void Sell(Product product, int quantity, ref string message) // продажа нескольких товаров
        {
            if (!products.ContainsKey(product)) // проверка наличия товара в магазине
            {
                message = $"Товар '{product.Name}' не найден.";
                return;
            }

            if (products[product] < quantity) // проверка, что запрашиваемое количество есть в наличие
            {
                message = $"Недостаточно товара '{product.Name}'. В наличии: {products[product]} шт.";
                return;
            }

            products[product] -= quantity; // уменьшение количества
            profit += product.Price * quantity; // увеличивание прибыли
            message = "";
        }

        public Product FindByName(string name) // поиск товара по названию
        {
            foreach (var product in products.Keys) // перебор всех товаров в списке
            {
                if (product.Name == name) // если товар найден, то возвращаем его
                {
                    return product;
                }
            }
            return null;
        }

        public int GetProductCount(Product product) // получение количества товара
        {
            return products.ContainsKey(product) ? products[product] : 0;
        }

        public decimal CalculateProfit() // свойство для получения прибыли
        {
            return profit;
        }

        public decimal CalculateProfit(string productName) // получение прибыли конкретного товара
        {
            Product product = FindByName(productName); // поиск товара по названию
            if (product == null) return 0;

            return product.Price * (products.ContainsKey(product) ? products[product] : 0); // цену умножаем на количество единиц
        }

        public List<Product> CheckLowStock(int threshold) // проверка товаров с низким запасом
        {
            return products.Where(item => item.Value < threshold) // фильтруем товары, где количество меньше заданного порога
                          .Select(item => item.Key) // выбираем только объекты товаров
                          .ToList(); // преобразуем в список и возвращаем
        }
    }
}
