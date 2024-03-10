using AutoMapper;
using API_SWP.Dto;
using API_SWP.Model;

namespace API_SWP.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Admin, AdminDto>();
            CreateMap<ConstructionPriceQuotation, ConstructionPriceQuotationDto>();
            CreateMap<ConstructionReceived, ConstructionReceivedDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Request, RequestDto>();
            CreateMap<Staff, StaffDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AdminDto, Admin>();
            CreateMap<ConstructionPriceQuotationDto, ConstructionPriceQuotation>();
            CreateMap<ConstructionReceivedDto, ConstructionReceived>();
            CreateMap<PostDto, Post>();
            CreateMap<RequestDto, Request>();
            CreateMap<StaffDto, Staff>();
        }
    }
}
