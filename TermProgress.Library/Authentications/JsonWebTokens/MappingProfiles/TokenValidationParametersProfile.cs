using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TermProgress.Library.Options;

namespace TermProgress.Library.Authentications.JsonWebTokens.MappingProfiles
{
    /// <summary>
    /// Represents a token validation parameters mapping profile.
    /// </summary>
    public class TokenValidationParametersProfile : Profile
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public TokenValidationParametersProfile()
        {
            CreateMap<TokenOptions, TokenValidationParameters>()
                .ForMember(dest => dest.IssuerSigningKey, opt => opt.MapFrom(src => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(src.SecretKey))))
                .ForMember(dest => dest.ValidAudience, opt => opt.MapFrom(src => src.Audience))
                .ForMember(dest => dest.ValidIssuer, opt => opt.MapFrom(src => src.Issuer));
        }
    }
}
