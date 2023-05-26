using AutoMapper;
using System;
using Cars.Application.Common.Mappings;
using Cars.Domain;

namespace Cars.Application.Cars.Queries.GetCarList
{
    public class CarLookupDto : IMapWith<Car>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Car, CarLookupDto>()
                .ForMember(carDto => carDto.Id,
                    opt => opt.MapFrom(car => car.Id))
                .ForMember(carDto => carDto.Title,
                    opt => opt.MapFrom(car => car.Title));
        }
    }
}
