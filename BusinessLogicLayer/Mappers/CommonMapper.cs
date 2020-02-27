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
                cfg.CreateMap<AirlineEntity, Airline>().ReverseMap();
                cfg.CreateMap<AirplaneEntity, Airplane>().ReverseMap();
                cfg.CreateMap<AirplaneSchemaEntity, AirplaneSchema>().ReverseMap();
                cfg.CreateMap<AirplaneSubTypeEntity, AirplaneSubType>().ReverseMap();
                cfg.CreateMap<AirplaneTypeEntity, AirplaneType>().ReverseMap();
                cfg.CreateMap<AirportEntity, Airport>().ReverseMap();
                cfg.CreateMap<ClassTypeEntity, ClassType>().ReverseMap();
                cfg.CreateMap<CountryEntity, Country>().ReverseMap();
                cfg.CreateMap<DocumentEntity, Document>().ReverseMap();
                cfg.CreateMap<DocumentTypeEntity, DocumentType>().ReverseMap();
                cfg.CreateMap<FlightEntity, Flight>().ReverseMap();
                cfg.CreateMap<OrderStatusEntity, OrderStatus>().ReverseMap();
                cfg.CreateMap<PassengerSeatEntity, PassengerSeat>().ReverseMap();
                cfg.CreateMap<TicketEntity, Ticket>().ReverseMap();
                cfg.CreateMap<UserRoleEntity, UserRole>().ReverseMap();
                cfg.CreateMap<UserEntity, User>()
                    .ForMember(
                        dest => dest.Password,
                        opt => opt.Ignore())
                    .ReverseMap();
            });
            Mapper = new Mapper(config);
        }

        public static Airline ToModel(this AirlineEntity model) => Mapper.Map<Airline>(model);
        public static AirlineEntity ToEntity(this Airline model) => Mapper.Map<AirlineEntity>(model);

        public static Airplane ToModel(this AirplaneEntity model) => Mapper.Map<Airplane>(model);
        public static AirplaneEntity ToEntity(this Airplane model) => Mapper.Map<AirplaneEntity>(model);

        public static AirplaneSchema ToModel(this AirplaneSchemaEntity model) => Mapper.Map<AirplaneSchema>(model);
        public static AirplaneSchemaEntity ToEntity(this AirplaneSchema model) => Mapper.Map<AirplaneSchemaEntity>(model);

        public static AirplaneSubType ToModel(this AirplaneSubTypeEntity model) => Mapper.Map<AirplaneSubType>(model);
        public static AirplaneSubTypeEntity ToEntity(this AirplaneSubType model) => Mapper.Map<AirplaneSubTypeEntity>(model);

        public static AirplaneType ToModel(this AirplaneTypeEntity model) => Mapper.Map<AirplaneType>(model);
        public static AirplaneTypeEntity ToEntity(this AirplaneType model) => Mapper.Map<AirplaneTypeEntity>(model);

        public static Airport ToModel(this AirportEntity model) => Mapper.Map<Airport>(model);
        public static AirportEntity ToEntity(this Airport model) => Mapper.Map<AirportEntity>(model);

        public static ClassType ToModel(this ClassTypeEntity model) => Mapper.Map<ClassType>(model);
        public static ClassTypeEntity ToEntity(this ClassType model) => Mapper.Map<ClassTypeEntity>(model);

        public static Country ToModel(this CountryEntity model) => Mapper.Map<Country>(model);
        public static CountryEntity ToEntity(this Country model) => Mapper.Map<CountryEntity>(model);

        public static Document ToModel(this DocumentEntity model) => Mapper.Map<Document>(model);
        public static DocumentEntity ToEntity(this Document model) => Mapper.Map<DocumentEntity>(model);

        public static DocumentType ToModel(this DocumentTypeEntity model) => Mapper.Map<DocumentType>(model);
        public static DocumentTypeEntity ToEntity(this DocumentType model) => Mapper.Map<DocumentTypeEntity>(model);

        public static OrderStatus ToModel(this OrderStatusEntity model) => Mapper.Map<OrderStatus>(model);
        public static OrderStatusEntity ToEntity(this OrderStatus model) => Mapper.Map<OrderStatusEntity>(model);

        public static UserRole ToModel(this UserRoleEntity model) => Mapper.Map<UserRole>(model);
        public static UserRoleEntity ToEntity(this UserRole model) => Mapper.Map<UserRoleEntity>(model);

        public static Flight ToModel(this FlightEntity model) => Mapper.Map<Flight>(model);
        public static FlightEntity ToEntity(this Flight model) => Mapper.Map<FlightEntity>(model);

        public static PassengerSeat ToModel(this PassengerSeatEntity model) => Mapper.Map<PassengerSeat>(model);
        public static PassengerSeatEntity ToEntity(this PassengerSeat model) => Mapper.Map<PassengerSeatEntity>(model);

        public static Ticket ToModel(this TicketEntity model) => Mapper.Map<Ticket>(model);
        public static TicketEntity ToEntity(this Ticket model) => Mapper.Map<TicketEntity>(model);

        public static User ToModel(this UserEntity model) => Mapper.Map<User>(model);
        public static UserEntity ToEntity(this User model) => Mapper.Map<UserEntity>(model);
    }
}
