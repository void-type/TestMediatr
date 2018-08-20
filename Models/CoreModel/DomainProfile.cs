using architectureTest.Models.Data;
using AutoMapper;

namespace architectureTest.Models.CoreModel
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Loanee, GetLoanee.Response>();
        }
    }
}
