using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КПЗ_Лаб_4
{
    public partial class Form1 : Form
    {
        private ConcreteOrderBuilder _builder = new ConcreteOrderBuilder();
        private OrderDirector _director;
        private Order _lastOrder;

        public Form1()
        {
            InitializeComponent();
            _director = new OrderDirector(_builder);
        }

        // Додати покупця
        private void button1_Click(object sender, EventArgs e)
        {
            _builder.SetCustomer("Андрій Торопцев");
            listBox1.Items.Add("Покупець: Андрій Торопцев");
        }

        // Додати товар
        private void button2_Click(object sender, EventArgs e)
        {
            _builder.AddItem("Механічна клавіатура");
            listBox1.Items.Add("Товар: Механічна клавіатура");
        }

        // Вказати адресу
        private void button3_Click(object sender, EventArgs e)
        {
            _builder.SetDeliveryAddress("м. Київ, пр-т Перемоги, 37");
            listBox1.Items.Add("Адреса: м. Київ, пр-т Перемоги, 37");
        }

        // Спосіб доставки
        private void button4_Click(object sender, EventArgs e)
        {
            _builder.SetDeliveryMethod("Нова Пошта");
            listBox1.Items.Add("Спосіб доставки: Нова Пошта");
        }

        // Спосіб оплати
        private void button5_Click(object sender, EventArgs e)
        {
            _builder.SetPaymentMethod("Онлайн карткою");
            listBox1.Items.Add("Спосіб оплати: Онлайн карткою");
        }

        // Промокод
        private void button6_Click(object sender, EventArgs e)
        {
            _builder.SetPromoCode("SALE2026");
            listBox1.Items.Add("Промокод: SALE2026");
        }

        // Коментар
        private void button7_Click(object sender, EventArgs e)
        {
            _builder.SetComment("Зателефонувати перед відправкою");
            listBox1.Items.Add("Коментар: Зателефонувати перед відправкою");
        }

        // Завершити ручне замовлення
        private void button8_Click(object sender, EventArgs e)
        {
            _lastOrder = _builder.GetResult();
            listBox1.Items.Add("Замовлення сформовано:");
            foreach (var line in _lastOrder.GetDetails().Split('\n'))
            {
                listBox1.Items.Add(line);
            }
            listBox1.Items.Add("");
        }

        // Зібрати Експрес
        private void button9_Click(object sender, EventArgs e)
        {
            _director.BuildExpressOrder("Петро Іванов", "м. Київ, вул. Хрещатик, 10");
            _lastOrder = _builder.GetResult();

            listBox1.Items.Add("Експрес-замовлення:");
            foreach (var line in _lastOrder.GetDetails().Split('\n'))
            {
                listBox1.Items.Add(line);
            }
            listBox1.Items.Add("");
        }

        // Зібрати Самовивіз
        private void button10_Click(object sender, EventArgs e)
        {
            _director.BuildPickupOrder("Олена Коваль");
            _lastOrder = _builder.GetResult();

            listBox1.Items.Add("Самовивіз:");
            foreach (var line in _lastOrder.GetDetails().Split('\n'))
            {
                listBox1.Items.Add(line);
            }
            listBox1.Items.Add("");
        }

        // Очистити
        private void button11_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            _builder.Reset();
        }

        // Клонувати замовлення
        private void button12_Click(object sender, EventArgs e)
        {
            if (_lastOrder == null)
            {
                listBox1.Items.Add("Спочатку сформуйте замовлення!");
                return;
            }

            Order copy = _lastOrder.clone();
            listBox1.Items.Add("Клон замовлення:");
            foreach (var line in copy.GetDetails().Split('\n'))
            {
                listBox1.Items.Add(line);
            }
            listBox1.Items.Add("");
        }

        // Змінити клон
        private void button13_Click(object sender, EventArgs e)
        {
            if (_lastOrder == null)
            {
                listBox1.Items.Add("Спочатку сформуйте замовлення!");
                return;
            }

            Order copy = _lastOrder.clone();
            copy.Customer = "Василь Бондар";
            copy.DeliveryAddress = "м. Львів, вул. Городоцька, 15";

            listBox1.Items.Add("Модифікований клон:");
            foreach (var line in copy.GetDetails().Split('\n'))
            {
                listBox1.Items.Add(line);
            }
            listBox1.Items.Add("");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}