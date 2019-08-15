using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace IShop.Common.Dispatching
{
    public class RequestDelegator : IRequestDelegator
    {
        private readonly IServiceProvider serviceProvider;

        public RequestDelegator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> DelegateAsync<TRequest, TResult>(TRequest request)
            => await serviceProvider
                .GetService<IQueryHandler<TRequest, TResult>>()
                .HandleAsync(request);
    }
}
