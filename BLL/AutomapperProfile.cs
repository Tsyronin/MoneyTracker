using AutoMapper;
using BLL.Dto;
using DAL.Entities;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BankAccountDto, UserBankAccount>();
        }
    }
}