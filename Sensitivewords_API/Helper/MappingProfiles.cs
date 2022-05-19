using AutoMapper;
using Sensitivewords_API.Dto_s;
using Sensitivewords_Business.Entities;
namespace Sensitivewords_API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<WordDto, Word>();
            CreateMap<Word, WordDto>();
        }
    }
}
