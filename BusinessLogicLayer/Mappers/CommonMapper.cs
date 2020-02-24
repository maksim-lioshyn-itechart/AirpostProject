using AutoMapper;
using BusinessLogicLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Mappers
{
    public static class CommonMapper
    {
        private static readonly Mapper Mapper;
        static CommonMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Airline, AirlineBM>().ReverseMap();
                cfg.CreateMap<AirplaneSchema, AirplaneSchemaBM>().ReverseMap();
            });
            Mapper = new Mapper(config);
        }
        public static AirlineBM ToBm(this Airline model) => Mapper.Map<AirlineBM>(model);
        public static Airline ToDal(this AirlineBM model) => Mapper.Map<Airline>(model);

        public static AirplaneSchemaBM ToBm(this AirplaneSchema model) => Mapper.Map<AirplaneSchemaBM>(model);
        public static AirplaneSchema ToDal(this AirplaneSchemaBM model) => Mapper.Map<AirplaneSchema>(model);
    }
}
