using AutoMapper;
using Tweetinvi.Models;

namespace TermProgress.Library.Clients.MappingProfiles
{
    /// <summary>
    /// Represents the social network status mapping profile.
    /// </summary>
    public class SocialNetworkStatusProfile : Profile
    {
        /// <summary>
        /// Class construcor.
        /// </summary>
        public SocialNetworkStatusProfile()
        {
            CreateMap<ITweet, SocialNetworkStatus>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.FullText));
        }
    }
}