﻿using AutoMapper;
using WhoIsMyGranddaddy.Data.Entities;
using WhoIsMyGranddaddy.Domain.Models;

namespace WhoIsMyGranddaddy.Domain.Mappings;

/// <summary>
/// Mapping profile for family members retrieved from stored procedures
/// </summary>
public class FamilyMemberProfile : Profile
{
    public FamilyMemberProfile()
    {
        CreateMap<PersonWithPartner, FamilyMemberModel>()
            .ForMember(dest => dest.Fid, opt => opt.MapFrom(src => src.FatherId))
            .ForMember(dest => dest.Mid, opt => opt.MapFrom(src => src.MotherId))
            .ForMember(dest => dest.Pids,
                opt => opt.MapFrom(src => src.PartnerId.HasValue ? new [] { src.PartnerId.Value } : null));

        CreateMap<Person, FamilyMemberModel>()
            .ForMember(dest => dest.Fid, opt => opt.MapFrom(src => src.FatherId))
            .ForMember(dest => dest.Mid, opt => opt.MapFrom(src => src.MotherId));

    }
}