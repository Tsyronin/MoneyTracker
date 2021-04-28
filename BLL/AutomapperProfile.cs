using AutoMapper;
using BLL.Dto;
using DAL.Entities;
using System;

namespace BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<BankAccountDto, UserBankAccount>();

            CreateMap<MonoApiExpense, ExpenseDto>()
                .ForMember(ed => ed.BankExpenseId, x => x.MapFrom(mae => mae.Id))
                .ForMember(ed => ed.Time, x => x.MapFrom(mae => DateTimeOffset.FromUnixTimeSeconds(mae.Time).DateTime))
                .ForMember(ed => ed.Id, x => x.MapFrom(mae => 0));

            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}