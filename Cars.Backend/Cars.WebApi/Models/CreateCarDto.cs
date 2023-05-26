using AutoMapper;
using Cars.Application.Common.Mappings;
using Cars.Application.Cars.Commands.CreateCar;
using System.ComponentModel.DataAnnotations;

namespace Cars.WebApi.Models
{
    public class CreateCarDto : IMapWith<CreateCarCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public int UsageBenzin { get; set; }
        public int SerialNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCarDto, CreateCarCommand>()
                .ForMember(carCommand => carCommand.Title,
                    opt => opt.MapFrom(carDto => carDto.Title))
                .ForMember(carCommand => carCommand.Details,
                    opt => opt.MapFrom(carDto => carDto.Details))
                .ForMember(carCommand => carCommand.Country,
                    opt => opt.MapFrom(carDto => carDto.Country))
                .ForMember(carCommand => carCommand.UsageBenzin,
                    opt => opt.MapFrom(carDto => carDto.UsageBenzin))
                .ForMember(carCommand => carCommand.SerialNumber,
                    opt => opt.MapFrom(carDto => carDto.SerialNumber));
        }
    }
}
