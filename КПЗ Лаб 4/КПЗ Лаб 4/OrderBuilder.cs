using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КПЗ_Лаб_4
{
    public class Order
    {
        public string Customer { get; set; } = "";
        public List<string> Items { get; set; } = new List<string>();
        public string DeliveryAddress { get; set; } = "";
        public string DeliveryMethod { get; set; } = "";
        public string PaymentMethod { get; set; } = "";
        public string PromoCode { get; set; } = "";
        public string Comment { get; set; } = "";

        public Order()
        {

        }
        public Order(Order other)
        {
            this.Customer = other.Customer;
            this.Items = new List<string>(other.Items); 
            this.DeliveryAddress = other.DeliveryAddress;
            this.DeliveryMethod = other.DeliveryMethod;
            this.PaymentMethod = other.PaymentMethod;
            this.PromoCode = other.PromoCode;
            this.Comment = other.Comment;
        }

        public Order clone()
        {
            return new Order(this);
        }

        public string GetDetails()
        {
            string itemsList = Items.Count > 0 ? string.Join(", ", Items) : "немає";
            return $"Покупець: {(string.IsNullOrEmpty(Customer) ? "—" : Customer)}\n" +
                   $"Товари: {itemsList}\n" +
                   $"Адреса: {(string.IsNullOrEmpty(DeliveryAddress) ? "—" : DeliveryAddress)}\n" +
                   $"Доставка: {(string.IsNullOrEmpty(DeliveryMethod) ? "—" : DeliveryMethod)}\n" +
                   $"Оплата: {(string.IsNullOrEmpty(PaymentMethod) ? "—" : PaymentMethod)}\n" +
                   $"Промокод: {(string.IsNullOrEmpty(PromoCode) ? "немає" : PromoCode)}\n" +
                   $"Коментар: {(string.IsNullOrEmpty(Comment) ? "немає" : Comment)}";
        }
    }

    public interface IOrderBuilder
    {
        void Reset();
        void SetCustomer(string customer);
        void AddItem(string item);
        void SetDeliveryAddress(string address);
        void SetDeliveryMethod(string method);
        void SetPaymentMethod(string method);
        void SetPromoCode(string promo);
        void SetComment(string comment);
        Order GetResult();
    }

    public class ConcreteOrderBuilder : IOrderBuilder
    {
        private Order _order = new Order();

        public void Reset()
        {
            _order = new Order();
        }

        public void SetCustomer(string customer) => _order.Customer = customer;
        public void AddItem(string item) => _order.Items.Add(item);
        public void SetDeliveryAddress(string address) => _order.DeliveryAddress = address;
        public void SetDeliveryMethod(string method) => _order.DeliveryMethod = method;
        public void SetPaymentMethod(string method) => _order.PaymentMethod = method;
        public void SetPromoCode(string promo) => _order.PromoCode = promo;
        public void SetComment(string comment) => _order.Comment = comment;

        public Order GetResult()
        {
            Order finished = _order;
            Reset();
            return finished;
        }
    }

    public class OrderDirector
    {
        private IOrderBuilder _builder;

        public OrderDirector(IOrderBuilder builder)
        {
            _builder = builder;
        }

        public void BuildExpressOrder(string customer, string address)
        {
            _builder.Reset();
            _builder.SetCustomer(customer);
            _builder.AddItem("Смартфон Galaxy S24");
            _builder.AddItem("Захисне скло");
            _builder.AddItem("Чохол бампер");
            _builder.SetDeliveryAddress(address);
            _builder.SetDeliveryMethod("Експрес-кур'єр");
            _builder.SetPaymentMethod("Онлайн карткою");
            _builder.SetPromoCode("Жовтень");
            _builder.SetComment("Зателефонувати за 20 хвилин");
        }

        public void BuildPickupOrder(string customer)
        {
            _builder.Reset();
            _builder.SetCustomer(customer);
            _builder.AddItem("Навушники Sony");
            _builder.SetDeliveryAddress("Магазин №4 (вул. Хрещатик, 2)");
            _builder.SetDeliveryMethod("Самовивіз з точки видачі");
            _builder.SetPaymentMethod("Готівка при отриманні");
            _builder.SetPromoCode("");
            _builder.SetComment("Огляд при отриманні");
        }
    }
}