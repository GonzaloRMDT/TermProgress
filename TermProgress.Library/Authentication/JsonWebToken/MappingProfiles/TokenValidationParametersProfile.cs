using System;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using TermProgress.Library.Configurations;

namespace TermProgress.Library.Authentication.JsonWebToken.MappingProfiles
{
    /// <summary>
    /// Represents a <c>TokenValidationParameters</c> mapping profile.
    /// </summary>
    public class TokenValidationParametersProfile : Profile
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        public TokenValidationParametersProfile()
        {
            CreateMap<JsonWebTokenConfiguration, TokenValidationParameters>()
                .ForMember(dest => dest.IssuerSigningKey, opt => opt.MapFrom(src => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(src.SecretKey))))
                .ForMember(dest => dest.ValidAudience, opt => opt.MapFrom(src => src.Audience))
                .ForMember(dest => dest.ValidIssuer, opt => opt.MapFrom(src => src.Issuer));
        }
    }
}
