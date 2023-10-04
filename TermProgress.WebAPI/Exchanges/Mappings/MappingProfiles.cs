using AutoMapper;
using TermProgress.Application.Publishers.Dtos.Requests;
using TermProgress.Application.Publishers.Dtos.Responses;
using TermProgress.WebAPI.Exchanges.Requests;
using TermProgress.WebAPI.Exchanges.Responses;

namespace TermProgress.WebAPI.Exchanges.Mappings
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
            CreateMap<CreateStatusRequest, CreateStatusRequestDto>();
            CreateMap<StatusDto, CreateStatusResponse>();
        }
    }
}
