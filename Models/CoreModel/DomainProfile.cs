using AutoMapper;
using MediatrRailwayExample.Models.Data;

namespace MediatrRailwayExample.Models.CoreModel
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Loanee, GetLoanee.Response>();
        }
    }
}
