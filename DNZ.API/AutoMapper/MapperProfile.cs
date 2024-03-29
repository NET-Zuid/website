﻿using AutoMapper;

using DNZ.Common.Models;
using DNZ.Common.TableEntities;

namespace DNZ.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ContentEntity, ContentModel>();
            CreateMap<MeetingEntity, MeetingModel>()
                .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.PartitionKey));
        }
    }
}
