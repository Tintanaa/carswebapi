using System;
using AutoMapper;
using Cars.Application.Common.Mappings;
using Cars.Domain;

namespace Cars.Application.Cars.Queries.GetCarDetails
{
    public class CarDetailsVm : IMapWith<Car>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Country { get; set; }
        public int UsageBenzin { get; set; }
        public int SerialNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Car, CarDetailsVm>()
                .ForMember(carVm => carVm.Title,
                    opt => opt.MapFrom(car => car.Title))
                .ForMember(carVm => carVm.Details,
                    opt => opt.MapFrom(car => car.Details))
                .ForMember(carVm => carVm.Id,
                    opt => opt.MapFrom(car => car.Id))
                .ForMember(carVm => carVm.Country,
                    opt => opt.MapFrom(car => car.Country))
                .ForMember(carVm => carVm.UsageBenzin,
                    opt => opt.MapFrom(car => car.UsageBenzin))
                .ForMember(carVm => carVm.SerialNumber,
                    opt => opt.MapFrom(car => car.SerialNumber))
                .ForMember(carVm => carVm.CreationDate,
                    opt => opt.MapFrom(car => car.CreationDate))
                .ForMember(carVm => carVm.EditDate,
                    opt => opt.MapFrom(car => car.EditDate));
        }
    }
}
