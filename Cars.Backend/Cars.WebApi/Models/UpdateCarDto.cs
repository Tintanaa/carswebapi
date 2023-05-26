using AutoMapper;
using System;
using Cars.Application.Common.Mappings;
using Cars.Application.Cars.Commands.UpdateCar;

namespace Cars.WebApi.Models
{
    public class UpdateCarDto : IMapWith<UpdateCarCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public int UsageBenzin { get; set; }
        public int SerialNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCarDto, UpdateCarCommand>()
                .ForMember(noteCommand => noteCommand.Id,
                    opt => opt.MapFrom(noteDto => noteDto.Id))
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Details,
                    opt => opt.MapFrom(noteDto => noteDto.Details))
                .ForMember(carCommand => carCommand.Country,
                    opt => opt.MapFrom(carDto => carDto.Country))
                .ForMember(carCommand => carCommand.UsageBenzin,
                    opt => opt.MapFrom(carDto => carDto.UsageBenzin))
                .ForMember(carCommand => carCommand.SerialNumber,
                    opt => opt.MapFrom(carDto => carDto.SerialNumber));
        }
    }
}
