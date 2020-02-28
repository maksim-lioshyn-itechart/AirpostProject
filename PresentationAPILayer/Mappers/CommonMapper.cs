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
                cfg.CreateMap<Airline, AirlineVm>().ReverseMap();
                cfg.CreateMap<Airplane, AirplaneVm>().ReverseMap();
                cfg.CreateMap<AirplaneSchema, AirplaneSchemaVm>().ReverseMap();
                cfg.CreateMap<AirplaneSubType, AirplaneSubTypeVm>().ReverseMap();
                cfg.CreateMap<AirplaneType, AirplaneTypeVm>().ReverseMap();
                cfg.CreateMap<Airport, AirportVm>().ReverseMap();
                cfg.CreateMap<ClassType, ClassTypeVm>().ReverseMap();
                cfg.CreateMap<Country, CountryVm>().ReverseMap();
                cfg.CreateMap<Document, DocumentVm>().ReverseMap();
                cfg.CreateMap<DocumentType, DocumentTypeVm>().ReverseMap();
                cfg.CreateMap<Flight, FlightVm>().ReverseMap();
                cfg.CreateMap<OrderStatus, OrderStatusVm>().ReverseMap();
                cfg.CreateMap<PassengerSeat, PassengerSeatVm>().ReverseMap();
                cfg.CreateMap<Ticket, TicketVm>().ReverseMap();
                cfg.CreateMap<UserRole, UserRoleVm>().ReverseMap();
            });
            Mapper = new Mapper(config);
        }
        public static AirlineVm To(this Airline model) => Mapper.Map<AirlineVm>(model);
        public static Airline ToDal(this AirlineVm model) => Mapper.Map<Airline>(model);

        public static AirplaneVm To(this Airplane model) => Mapper.Map<AirplaneVm>(model);
        public static Airplane ToDal(this AirplaneVm model) => Mapper.Map<Airplane>(model);

        public static AirplaneSchemaVm To(this AirplaneSchema model) => Mapper.Map<AirplaneSchemaVm>(model);
        public static AirplaneSchema ToDal(this AirplaneSchemaVm model) => Mapper.Map<AirplaneSchema>(model);

        public static AirplaneSubTypeVm To(this AirplaneSubType model) => Mapper.Map<AirplaneSubTypeVm>(model);
        public static AirplaneSubType ToDal(this AirplaneSubTypeVm model) => Mapper.Map<AirplaneSubType>(model);

        public static AirplaneTypeVm To(this AirplaneType model) => Mapper.Map<AirplaneTypeVm>(model);
        public static AirplaneType ToDal(this AirplaneTypeVm model) => Mapper.Map<AirplaneType>(model);

        public static AirportVm To(this Airport model) => Mapper.Map<AirportVm>(model);
        public static Airport ToDal(this AirportVm model) => Mapper.Map<Airport>(model);

        public static ClassTypeVm To(this ClassType model) => Mapper.Map<ClassTypeVm>(model);
        public static ClassType ToDal(this ClassTypeVm model) => Mapper.Map<ClassType>(model);

        public static CountryVm To(this Country model) => Mapper.Map<CountryVm>(model);
        public static Country ToDal(this CountryVm model) => Mapper.Map<Country>(model);

        public static DocumentVm To(this Document model) => Mapper.Map<DocumentVm>(model);
        public static Document ToDal(this DocumentVm model) => Mapper.Map<Document>(model);

        public static DocumentTypeVm To(this DocumentType model) => Mapper.Map<DocumentTypeVm>(model);
        public static DocumentType ToDal(this DocumentTypeVm model) => Mapper.Map<DocumentType>(model);

        public static OrderStatusVm To(this OrderStatus model) => Mapper.Map<OrderStatusVm>(model);
        public static OrderStatus ToDal(this OrderStatusVm model) => Mapper.Map<OrderStatus>(model);

        public static UserRoleVm To(this UserRole model) => Mapper.Map<UserRoleVm>(model);
        public static UserRole ToDal(this UserRoleVm model) => Mapper.Map<UserRole>(model);

        public static FlightVm To(this Flight model) => Mapper.Map<FlightVm>(model);
        public static Flight ToDal(this FlightVm model) => Mapper.Map<Flight>(model);

        public static PassengerSeatVm To(this PassengerSeat model) => Mapper.Map<PassengerSeatVm>(model);
        public static PassengerSeat ToDal(this PassengerSeatVm model) => Mapper.Map<PassengerSeat>(model);

        public static TicketVm To(this Ticket model) => Mapper.Map<TicketVm>(model);
        public static Ticket ToDal(this TicketVm model) => Mapper.Map<Ticket>(model);
    }
}
