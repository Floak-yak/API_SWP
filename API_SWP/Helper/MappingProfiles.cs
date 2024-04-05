using AutoMapper;
using API_SWP.Dto;
using API_SWP.Model;
using API_SWP.ViewModel;

namespace API_SWP.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<HouseTypeOption, HouseTypeOptionDto>();
            CreateMap<HouseTypeOptionDto, HouseTypeOption>();
            CreateMap<ComboDesign, ComboDesignModelView>();
            CreateMap<ComboDesignModelView, ComboDesign>();
            CreateMap<RequestDto, RequestCreateModel>();
            CreateMap<RequestCreateModel, RequestDto>();
            CreateMap<ConstructionPriceQuotation, ConstructionPriceQuotationCreateModel>();
            CreateMap<ConstructionPriceQuotationCreateModel, ConstructionPriceQuotation>();
            CreateMap<Customer, CustomerUpdateModel>();
            CreateMap<CustomerUpdateModel, Customer>();
            CreateMap<ConstructionPriceQuotation, ConstructionPriceQuotationUpdateModel>();
            CreateMap<ConstructionPriceQuotationUpdateModel, ConstructionPriceQuotation>();
            CreateMap<ConstructionReceived, ConstructionReceivedUpdateModel>();
            CreateMap<ConstructionReceivedUpdateModel, ConstructionReceived>();
            CreateMap<Post, PostUpdateModel>();
            CreateMap<PostUpdateModel, Post>();
            CreateMap<Request, RequestCreateModel>();
            CreateMap<RequestCreateModel, Request>();
            CreateMap<Request, RequestUpdateModel>();
            CreateMap<RequestUpdateModel, Request>();
            CreateMap<StaffUpdateModel, Model.Staff>();
            CreateMap<Model.Staff, StaffUpdateModel>();
            CreateMap<Admin, AdminModel>();
            CreateMap<AdminModel, Admin>();
            CreateMap<Customer, CustomerRegisterDto>();
            CreateMap<CustomerRegisterDto, Customer>();
            CreateMap<Customer, CustomerDto>();
            CreateMap<Admin, AdminDto>();
            CreateMap<ConstructionPriceQuotation, ConstructionPriceQuotationDto>();
            CreateMap<ConstructionReceived, ConstructionReceivedDto>();
            CreateMap<Post, PostDto>();
            CreateMap<Request, RequestDto>();
            CreateMap<Model.Staff, StaffDto>();
            CreateMap<CustomerDto, Customer>();
            CreateMap<AdminDto, Admin>();
            CreateMap<ConstructionPriceQuotationDto, ConstructionPriceQuotation>();
            CreateMap<ConstructionReceivedDto, ConstructionReceived>();
            CreateMap<PostDto, Post>();
            CreateMap<RequestDto, Request>();
            CreateMap<StaffDto, Model.Staff>();
        }
    }
}
