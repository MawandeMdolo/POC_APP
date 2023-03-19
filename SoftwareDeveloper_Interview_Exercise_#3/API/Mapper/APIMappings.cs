using AutoMapper;
using Entities;
using Entities.DTOs;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace POC_API.Mapper
{
    public class APIMappings : Profile
    {
        public APIMappings()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();

        }

    }
}
