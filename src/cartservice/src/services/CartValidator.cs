using System.Threading.Tasks;
using Hipstershop;

namespace cartservice.cartstore
{
    public interface ICartValidator
    {
        Task<bool> ValidateCartInput(AddItemRequest request);
    }

    public class CartValidator : ICartValidator
    {
        public Task<bool> ValidateCartInput(AddItemRequest request)
        {
            if (string.IsNullOrEmpty(request.UserId))
            {
                return Task.FromResult(false);
            }

            if (string.IsNullOrEmpty(request.Item.ProductId))
            {
                return Task.FromResult(false);
            }

            if (request.Item.Quantity <= 0)
            {
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}