using AutoMapper;
using BusinessLogicLayer.Models;
using PresentationAPILayer.Models;

namespace PresentationAPILayer.Mappers
{
    public static class CommonMapper
    {
        private static readonly Mapper Mapper;
        static CommonMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AirlineBm, AirlineVm>().ReverseMap();
                cfg.CreateMap<AirplaneBm, AirplaneVm>().ReverseMap();
                cfg.CreateMap<AirplaneSchemaBm, AirplaneSchemaVm>().ReverseMap();
                cfg.CreateMap<AirplaneSubTypeBm, AirplaneSubTypeVm>().ReverseMap();
                cfg.CreateMap<AirplaneTypeBm, AirplaneTypeVm>().ReverseMap();
                cfg.CreateMap<AirportBm, AirportVm>().ReverseMap();
                cfg.CreateMap<ClassTypeBm, ClassTypeVm>().ReverseMap();
                cfg.CreateMap<CountryBm, CountryVm>().ReverseMap();
                cfg.CreateMap<DocumentBm, DocumentVm>().ReverseMap();
                cfg.CreateMap<DocumentTypeBm, DocumentTypeVm>().ReverseMap();
                cfg.CreateMap<FlightBm, FlightVm>().ReverseMap();
                cfg.CreateMap<OrderStatusBm, OrderStatusVm>().ReverseMap();
                cfg.CreateMap<PassengerSeatBm, PassengerSeatVm>().ReverseMap();
                cfg.CreateMap<TicketBm, TicketVm>().ReverseMap();
                cfg.CreateMap<UserRoleBm, UserRoleVm>().ReverseMap();
            });
            Mapper = new Mapper(config);
        }
        public static AirlineVm ToBm(this AirlineBm model) => Mapper.Map<AirlineVm>(model);
        public static AirlineBm ToDal(this AirlineVm model) => Mapper.Map<AirlineBm>(model);

        public static AirplaneVm ToBm(this AirplaneBm model) => Mapper.Map<AirplaneVm>(model);
        public static AirplaneBm ToDal(this AirplaneVm model) => Mapper.Map<AirplaneBm>(model);

        public static AirplaneSchemaVm ToBm(this AirplaneSchemaBm model) => Mapper.Map<AirplaneSchemaVm>(model);
        public static AirplaneSchemaBm ToDal(this AirplaneSchemaVm model) => Mapper.Map<AirplaneSchemaBm>(model);

        public static AirplaneSubTypeVm ToBm(this AirplaneSubTypeBm model) => Mapper.Map<AirplaneSubTypeVm>(model);
        public static AirplaneSubTypeBm ToDal(this AirplaneSubTypeVm model) => Mapper.Map<AirplaneSubTypeBm>(model);

        public static AirplaneTypeVm ToBm(this AirplaneTypeBm model) => Mapper.Map<AirplaneTypeVm>(model);
        public static AirplaneTypeBm ToDal(this AirplaneTypeVm model) => Mapper.Map<AirplaneTypeBm>(model);

        public static AirportVm ToBm(this AirportBm model) => Mapper.Map<AirportVm>(model);
        public static AirportBm ToDal(this AirportVm model) => Mapper.Map<AirportBm>(model);

        public static ClassTypeVm ToBm(this ClassTypeBm model) => Mapper.Map<ClassTypeVm>(model);
        public static ClassTypeBm ToDal(this ClassTypeVm model) => Mapper.Map<ClassTypeBm>(model);

        public static CountryVm ToBm(this CountryBm model) => Mapper.Map<CountryVm>(model);
        public static CountryBm ToDal(this CountryVm model) => Mapper.Map<CountryBm>(model);

        public static DocumentVm ToBm(this DocumentBm model) => Mapper.Map<DocumentVm>(model);
        public static DocumentBm ToDal(this DocumentVm model) => Mapper.Map<DocumentBm>(model);

        public static DocumentTypeVm ToBm(this DocumentTypeBm model) => Mapper.Map<DocumentTypeVm>(model);
        public static DocumentTypeBm ToDal(this DocumentTypeVm model) => Mapper.Map<DocumentTypeBm>(model);

        public static OrderStatusVm ToBm(this OrderStatusBm model) => Mapper.Map<OrderStatusVm>(model);
        public static OrderStatusBm ToDal(this OrderStatusVm model) => Mapper.Map<OrderStatusBm>(model);

        public static UserRoleVm ToBm(this UserRoleBm model) => Mapper.Map<UserRoleVm>(model);
        public static UserRoleBm ToDal(this UserRoleVm model) => Mapper.Map<UserRoleBm>(model);

        public static FlightVm ToBm(this FlightBm model) => Mapper.Map<FlightVm>(model);
        public static FlightBm ToDal(this FlightVm model) => Mapper.Map<FlightBm>(model);

        public static PassengerSeatVm ToBm(this PassengerSeatBm model) => Mapper.Map<PassengerSeatVm>(model);
        public static PassengerSeatBm ToDal(this PassengerSeatVm model) => Mapper.Map<PassengerSeatBm>(model);

        public static TicketVm ToBm(this TicketBm model) => Mapper.Map<TicketVm>(model);
        public static TicketBm ToDal(this TicketVm model) => Mapper.Map<TicketBm>(model);
    }
}
