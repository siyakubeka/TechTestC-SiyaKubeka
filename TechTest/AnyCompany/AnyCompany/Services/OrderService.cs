namespace AnyCompany
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public bool PlaceOrder(Order order, int customerId)
        {
            Customer customer = CustomerRepository.Load(customerId);

            if (customer == null)
                return false; // Customer not found, cannot place the order.

            if (order.Amount == 0)
                return false; // Invalid order amount.

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            int orderId = orderRepository.Save(order);

            return orderId > 0;
        }
    }
}
