using AutoMapper;

namespace IShop.Service.Products
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Domain.Model.Product, Persistence.Model.Product>();
            CreateMap<Persistence.Model.Product, Domain.Model.Product>();

            CreateMap<Domain.Model.Category, Persistence.Model.Category>();
            CreateMap<Persistence.Model.Category, Domain.Model.Category>();

            CreateMap<Domain.Model.Dimensions, Persistence.Model.Dimensions>();
            CreateMap<Persistence.Model.Dimensions, Domain.Model.Dimensions>();

            CreateMap<Domain.Model.Pricing, Persistence.Model.Pricing>();
            CreateMap<Persistence.Model.Pricing, Domain.Model.Pricing>();

            CreateMap<Domain.Model.Shipping, Persistence.Model.Shipping>();
            CreateMap<Persistence.Model.Shipping, Domain.Model.Shipping>();
        }
    }
}
