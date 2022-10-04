using AutoMapper;
using Domain.Entities;

namespace Application.Features.WebinarFeature.Query.Result;

public class WebinarMapper : Profile
{
    public WebinarMapper()
    {
        CreateMap<Webinar, WebinarResult>()
            .ForMember(des => des.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(des => des.Name,
                opt => opt.MapFrom(src => src.Name))
            .ForMember(des => des.ScheduledOn,
                opt => opt.MapFrom(src => src.ScheduledOn));
    }
}