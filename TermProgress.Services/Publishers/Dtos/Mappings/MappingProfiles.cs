using AutoMapper;
using RestSharp;
using TermProgress.Application.Publishers.Dtos.Enums;
using TermProgress.Application.Publishers.Dtos.Responses;
using TermProgress.Infrastructure.Apis.Commons.Entities;

namespace TermProgress.Application.Publishers.Dtos.Mappings
{
    /// <summary>
    /// Represents the mapping profiles.
    /// </summary>
    public class MappingProfiles : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfiles"/> class.
        /// </summary>
        public MappingProfiles()
        {
            CreateMap<RestResponse<Status>, CreateStatusResponseDto>()
                .ForMember(
                    dest => dest.Result,
                    opt => opt.MapFrom(src => src.IsSuccessful ? RequestResult.Success : RequestResult.Error));

            CreateMap<Status, StatusDto>();
        }
    }
}
