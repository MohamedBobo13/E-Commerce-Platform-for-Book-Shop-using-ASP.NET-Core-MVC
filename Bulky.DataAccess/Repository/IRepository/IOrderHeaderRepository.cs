using Bulky.Models;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IOrderHeaderRepository : IRepository<OrderHeader>
    {
        // Updates the entire OrderHeader object in the database
        void Update(OrderHeader obj);

        // Updates the order status and optionally the payment status for a specific order
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);

        // Updates the Stripe payment information (session ID and payment intent ID) for a specific order
        void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId);
    }
}
