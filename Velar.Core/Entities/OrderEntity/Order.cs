using Velar.Core.Entities.CartEntity;
using Velar.Core.Entities.UserEntity;

namespace Velar.Core.Entities.OrderEntity
{
    public class Order
    {
        public int OrderId { get; set; }
        public DeliveryService DeliveryService { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string DeliveryAddress { get; set; }
        public string City { get; set; }
        public int Postal { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string UserId { get; set; }
        public int CartId { get; set; }

        public virtual User User { get; set; }
        public virtual Cart Cart { get; set; }
    }

    public enum DeliveryService : int
    {
        Dpd = 0,
        InPost = 1
    }

    public enum DeliveryMethod : int
    {
        Department = 0,
        Courier = 1
    }

    public enum PaymentMethod : int
    {
        Account = 0,
        Card = 1,
        Cash = 2
    }
}