
namespace zd1_2_KM
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBox2 = new System.Windows.Forms.TextBox();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            Basket = new System.Windows.Forms.ListBox();
            title_basket = new System.Windows.Forms.Label();
            button3 = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            textBox3 = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            textBox4 = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            textBox5 = new System.Windows.Forms.TextBox();
            button4 = new System.Windows.Forms.Button();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            listBoxLowStock = new System.Windows.Forms.ListBox();
            button5 = new System.Windows.Forms.Button();
            label9 = new System.Windows.Forms.Label();
            textBox6 = new System.Windows.Forms.TextBox();
            label10 = new System.Windows.Forms.Label();
            button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(347, 23);
            button1.TabIndex = 0;
            button1.Text = "Посмотреть товары";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ViewProducts;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(0, 15);
            label1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(12, 327);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(347, 23);
            button2.TabIndex = 3;
            button2.Text = "Продать";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Sale;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(365, 12);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(121, 15);
            label2.TabIndex = 4;
            label2.Text = "Какой товар продать";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(365, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(121, 23);
            textBox1.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(365, 57);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(101, 15);
            label3.TabIndex = 6;
            label3.Text = "Сколько продать";
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(365, 76);
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(121, 23);
            textBox2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(12, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(347, 150);
            dataGridView1.TabIndex = 8;
            dataGridView1.CellClick += CellContent;
            // 
            // Basket
            // 
            Basket.FormattingEnabled = true;
            Basket.ItemHeight = 15;
            Basket.Location = new System.Drawing.Point(12, 227);
            Basket.Name = "Basket";
            Basket.Size = new System.Drawing.Size(347, 94);
            Basket.TabIndex = 9;
            // 
            // title_basket
            // 
            title_basket.AutoSize = true;
            title_basket.Location = new System.Drawing.Point(12, 209);
            title_basket.Name = "title_basket";
            title_basket.Size = new System.Drawing.Size(53, 15);
            title_basket.TabIndex = 10;
            title_basket.Text = "Корзина";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(366, 105);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(117, 41);
            button3.TabIndex = 11;
            button3.Text = "Перейти к корзине";
            button3.UseVisualStyleBackColor = true;
            button3.Click += To_Backet;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(366, 191);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(93, 15);
            label4.TabIndex = 12;
            label4.Text = "Добавить товар";
            // 
            // textBox3
            // 
            textBox3.Location = new System.Drawing.Point(366, 209);
            textBox3.Name = "textBox3";
            textBox3.Size = new System.Drawing.Size(121, 23);
            textBox3.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(366, 235);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(35, 15);
            label5.TabIndex = 14;
            label5.Text = "Цена";
            // 
            // textBox4
            // 
            textBox4.Location = new System.Drawing.Point(366, 253);
            textBox4.Name = "textBox4";
            textBox4.Size = new System.Drawing.Size(121, 23);
            textBox4.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(366, 279);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(72, 15);
            label6.TabIndex = 16;
            label6.Text = "Количество";
            // 
            // textBox5
            // 
            textBox5.Location = new System.Drawing.Point(367, 297);
            textBox5.Name = "textBox5";
            textBox5.Size = new System.Drawing.Size(120, 23);
            textBox5.TabIndex = 17;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(367, 326);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(120, 23);
            button4.TabIndex = 18;
            button4.Text = "Добавить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Add_Product;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(12, 194);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(65, 15);
            label7.TabIndex = 19;
            label7.Text = "Прибыль: ";
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(492, 10);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(228, 17);
            label8.TabIndex = 20;
            label8.Text = "Сколько минимум товаров может быть";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new System.Drawing.Point(492, 31);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new System.Drawing.Size(228, 23);
            numericUpDown1.TabIndex = 21;
            // 
            // listBoxLowStock
            // 
            listBoxLowStock.FormattingEnabled = true;
            listBoxLowStock.ItemHeight = 15;
            listBoxLowStock.Location = new System.Drawing.Point(492, 86);
            listBoxLowStock.Name = "listBoxLowStock";
            listBoxLowStock.Size = new System.Drawing.Size(228, 94);
            listBoxLowStock.TabIndex = 22;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(492, 57);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(228, 23);
            button5.TabIndex = 23;
            button5.Text = "Установить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Establish;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(492, 191);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(172, 15);
            label9.TabIndex = 24;
            label9.Text = "Прибыль конкретного товара";
            // 
            // textBox6
            // 
            textBox6.Location = new System.Drawing.Point(492, 209);
            textBox6.Name = "textBox6";
            textBox6.Size = new System.Drawing.Size(172, 23);
            textBox6.TabIndex = 25;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(492, 261);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(62, 15);
            label10.TabIndex = 26;
            label10.Text = "Прибыль:";
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(492, 235);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(171, 23);
            button6.TabIndex = 27;
            button6.Text = "Рассчитать";
            button6.UseVisualStyleBackColor = true;
            button6.Click += ProfitProduct;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(732, 360);
            Controls.Add(button6);
            Controls.Add(label10);
            Controls.Add(textBox6);
            Controls.Add(label9);
            Controls.Add(button5);
            Controls.Add(listBoxLowStock);
            Controls.Add(numericUpDown1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(button4);
            Controls.Add(textBox5);
            Controls.Add(label6);
            Controls.Add(textBox4);
            Controls.Add(label5);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(title_basket);
            Controls.Add(Basket);
            Controls.Add(dataGridView1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += LoadShop;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox Basket;
        private System.Windows.Forms.Label title_basket;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.ListBox listBoxLowStock;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
    }
}

