using AutoMapper;
using BRICS_API_NEO.DTOs;
using BRICS_API_NEO.Models;

namespace BRICS_API_NEO.HelperMethods
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Map GenericCorporateAlertRequest to AlertNotificationDTOs
            CreateMap<GenericCorporateAlertRequest, AlertNotificationDTOs>();

            // Map AlertNotificationDTOs to Icicialertnotification
            //CreateMap<AlertNotificationDTOs, Icicialertnotification>()
            //    .ForMember(des => des.AlertSequenceNumber, opt => opt.MapFrom(src => src.AlertSequenceNo))
            //    .ForMember(des => des.ChequeNumber, opt => opt.MapFrom(src => src.ChequeNo))
            //    .ForMember(des => des.RemitterIfscCode, opt => opt.MapFrom(src => src.RemitterIfsc));
        }

    }
}
