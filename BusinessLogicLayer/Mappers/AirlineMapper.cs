using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    public static class AirlineMapper
    {
        private static readonly Mapper Mapper;
        static AirlineMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Airline, AirlineBM>().ReverseMap());
            Mapper = new Mapper(config);
        }
        public static AirlineBM AutoAirlineMapper(this Airline model) => Mapper.Map<AirlineBM>(model);

        public static Airline ToAirline(this AirlineBM model) => Mapper.Map<Airline>(model);
    }
}
