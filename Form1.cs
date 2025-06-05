using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace zd1_2_KM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // инициализация компонентов формы
            InitializeDataGridView(); // инициализация DataGridView при запуске
        }

        Shop pyaterochka = new Shop(); // экземпляр магазина
        List<string> prod_text = new List<string>(); // список для хранения текстового представления товаров

        private void ViewProducts(object sender, EventArgs e) // обработчик кнопки просмотра товаров
        {
            CompletionDGV(); // заполнение DataGridView
        }

        private void InitializeDataGridView() // настройка DataGridView
        {
            dataGridView1.ColumnCount = 3; // установка количества колонок
            dataGridView1.Columns[0].Name = "Наименование"; // название первой колонки
            dataGridView1.Columns[1].Name = "Цена"; // название второй колонки
            dataGridView1.Columns[2].Name = "Количество"; // название третьей колонки
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // установление авторазмера для таблицы
        }

        public void CompletionDGV() // заполнение DataGridView данными
        {
            dataGridView1.Rows.Clear(); // очистка таблицы

            string title = "";
            prod_text = pyaterochka.WriteAllProducts(ref title); // получение списка товаров

            foreach (var product in prod_text) // обработка каждого товара
            {
                string[] parts = product.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries); // разделение товара на части

                string name = parts[0].Substring(parts[0].IndexOf(":") + 1).Trim(); // извлечение названия товара
                string price = parts[1].Substring(parts[1].IndexOf(":") + 1).Trim(); // извлечение цены товара
                string count = parts[2].Substring(parts[2].IndexOf(":") + 1).Trim(); // извлечение количества товара

                dataGridView1.Rows.Add(name, price, count); // добавление данных в строку
            }

            if (string.IsNullOrEmpty(label1.Text)) // проверка на то, что label пустой
                label1.Text = title; // установка заголовка
        }

        private void Sale(object sender, EventArgs e) // продажа товаров из корзины
        {
            StringBuilder errorMessages = new StringBuilder(); // создание строки для накопления ошибок
            bool hasErrors = false; // флаг наличия ошибок

            for (int i = 0; i < Basket.Items.Count; i++) // обработка каждого товара
            {
                string item = Basket.Items[i].ToString(); // записывание товара в переменную
                string productName = SeparationWord(item); // извлечение названия товара

                Product foundProduct = pyaterochka.FindByName(productName); // поиск товара в магазине
                if (foundProduct == null) // проверка на не нахождение товара
                {
                    errorMessages.AppendLine($"Товар '{productName}' не найден в магазине."); // добавление ошибки в строку
                    hasErrors = true; // включение флага
                    continue; // продолжение
                }

                string[] parts = item.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); // разделение переменной с товаром
                if (parts.Length >= 3) // проверка длины
                {
                    string countPart = parts[2].Trim();
                    if (countPart.StartsWith("Количество: ")) // проверка начала строки
                    {
                        string countStr = countPart.Substring("Количество: ".Length).Trim(); // Создание строки Количество
                        if (int.TryParse(countStr, out int countToSell)) // парсинг количества
                        {
                            string message = "";
                            pyaterochka.Sell(foundProduct, countToSell, ref message); // продажа товара

                            if (!string.IsNullOrEmpty(message))
                            {
                                errorMessages.AppendLine(message); // добавление ошибки в строку
                                hasErrors = true; // включение флага
                            }
                        }
                    }
                }
            }

            if (hasErrors)
            {
                // Вывод успешного результата
                MessageBox.Show(errorMessages.ToString(), "Ошибки при продаже", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Вывод ошибки
                MessageBox.Show("Продажа успешно завершена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            label7.Text = $"Прибыль: " + pyaterochka.CalculateProfit(); // обновление информации о прибыли
            CompletionDGV(); // обновление таблицы товаров
            Basket.Items.Clear(); // очистка корзины
        }

        public string SeparationWord(string product) // извлечение названия товара из строки
        {
            string[] parts = product.Split(new[] { "; " }, StringSplitOptions.RemoveEmptyEntries); // разделение товара на части
            if (parts.Length > 0) // проверка длины части
            {
                int colonIndex = parts[0].IndexOf(":"); // нахождение знака ":" в части с названием
                if (colonIndex >= 0) // проверка индекса
                {
                    return parts[0].Substring(colonIndex + 1).Trim(); // возвращение названия товара
                }
            }
            return string.Empty; // возвращение пустой строки
        }

        private void LoadShop(object sender, EventArgs e) // загрузка данных при запуске
        {
            pyaterochka.CreateProduct("Кола", 85, 1); // добавление товара 1
            pyaterochka.CreateProduct("Сок \"Добрый\"", 100, 50); // добавление товара 2
        }

        private void CellContent(object sender, DataGridViewCellEventArgs e) // обработчик клика по таблице
        {
            if (e.RowIndex >= 0) // проверка индекса
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex]; // занесение индекса строки в переменную

                string value = row.Cells[0].Value.ToString(); // занесение данного строки в переменную

                if (!string.IsNullOrEmpty(value)) // проверка на пустую строку
                {
                    textBox1.Text = value; // заполнение поля названия товара
                }
            }
        }

        private void To_Backet(object sender, EventArgs e) // добавление товара в корзину
        {
            string productName = textBox1.Text.Trim(); // получение названия товара
            if (string.IsNullOrEmpty(productName)) // проверка на пустую строку
            {
                MessageBox.Show("Введите название товара."); // вывод предупреждения
                return; // возвращение к заполнению
            }

            Product foundProduct = pyaterochka.FindByName(productName); // поиск товара

            if (foundProduct != null) // проверка на нахождение товара
            {
                int count;
                if (!int.TryParse(textBox2.Text, out count) || count <= 0) // проверка на ввод строки количества
                {
                    MessageBox.Show("Введите корректное количество продуктов."); // вывод предупреждения
                    return; // возвращение к заполнению
                }

                bool productExists = false;
                for (int i = 0; i < Basket.Items.Count; i++) // поиск товара в корзине
                {
                    string item = Basket.Items[i].ToString(); // записывание товара в переменную

                    if (item.StartsWith($"Наименование: {foundProduct.Name};")) // проверка на начало строки
                    {
                        string[] parts = item.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries); // разделение строки
                        if (parts.Length >= 3) // проверка на длину
                        {
                            string countPart = parts[2].Trim();
                            if (countPart.StartsWith("Количество: ")) // проверка на начало строки
                            {
                                string countStr = countPart.Substring("Количество: ".Length).Trim(); // записывание строки с количеством
                                if (int.TryParse(countStr, out int existingCount)) // парсинг количества
                                {
                                    int newCount = existingCount + count; // добавление нового количества
                                    decimal newPrice = foundProduct.Price * newCount; // вычисление новой цены

                                    Basket.Items[i] = $"Наименование: {foundProduct.Name}; " + // составление строки
                                                     $"Цена: {newPrice} руб.; " +
                                                     $"Количество: {newCount}";
                                    productExists = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (!productExists) // если товара нет в корзине
                {
                    Basket.Items.Add($"Наименование: {foundProduct.Name}; " + // составление строки
                                   $"Цена: {foundProduct.Price * count} руб.; " +
                                   $"Количество: {count}");
                }
            }
            else
            {
                MessageBox.Show("Товар не найден."); // вывод о не нахождении товара в магазине
            }
        }

        private void Add_Product(object sender, EventArgs e) // добавление нового товара в магазин
        {
            string name = textBox3.Text.Trim(); // получение названия
            if (string.IsNullOrEmpty(name)) // проверка на пустую ошибку
            {
                // вывод предупреждения
                MessageBox.Show("Введите название товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // возвращение к заполнению
            }

            if (!decimal.TryParse(textBox4.Text, out decimal price) || price <= 0) // проверка цены
            {
                // вывод предупреждения
                MessageBox.Show("Введите корректную цену.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // возвращение к заполнению
            }

            if (!int.TryParse(textBox5.Text, out int count) || count <= 0) // проверка количества
            {
                // вывод предупреждения
                MessageBox.Show("Введите корректное количество продуктов.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // возвращение к заполнению
            }

            try
            {
                pyaterochka.CreateProduct(name, price, count); // создание товара
                CompletionDGV(); // обновление таблицы

                // очистка полей ввода
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();

                // вывод о успешном добавлении товара
                MessageBox.Show("Товар успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // вывод об ошибке при заполнении
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowLowStockProducts() // вывод продуктов с малым количеством
        {
            int threshold = (int)numericUpDown1.Value; // получение минимального порога

            List<Product> lowStockProducts = pyaterochka.CheckLowStock(threshold); // составление списка товаров с количеством меньше миниммума

            listBoxLowStock.Items.Clear(); // очищение listbox

            foreach (Product product in lowStockProducts) // поиск товаров в списке
            {
                int currentQuantity = pyaterochka.GetProductCount(product); // получение количества
                listBoxLowStock.Items.Add($"{product.Name} (Осталось: {currentQuantity}, Минимум: {threshold})"); // добавление товара в список
            }

            HighlightLowStockProducts(threshold); // выделение товара в таблице
        }

        private void HighlightLowStockProducts(int threshold) // выделение товара в таблице
        {
            foreach (DataGridViewRow row in dataGridView1.Rows) // поиск в таблице
            {
                if (row.Cells[2].Value != null && // если количество меньше минимума
                    int.TryParse(row.Cells[2].Value.ToString(), out int quantity) &&
                    quantity < threshold)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon; // то перекрасить
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void Establish(object sender, EventArgs e) // установление порога и заполнение списка минимума
        {
            ShowLowStockProducts(); // вывод продуктов с малым количеством
        }

        private void ProfitProduct(object sender, EventArgs e)
        {
            string name = textBox6.Text;
            if (string.IsNullOrEmpty(name)) // проверка на пустую строку
            {
                MessageBox.Show("Введите название товара."); // вывод предупреждения
                return; // возвращение к заполнению
            }

            Product foundProduct = pyaterochka.FindByName(name); // поиск товара

            if (foundProduct == null) // проверка на не нахождение товара
            {
                MessageBox.Show($"Товар '{name}' не найден в магазине."); // добавление ошибки в строку
            }
            else
            {
                label10.Text = $"Прибыль {name}: " + pyaterochka.CalculateProfit(name); // обновление информации о прибыли
            }
        }
    }
}
