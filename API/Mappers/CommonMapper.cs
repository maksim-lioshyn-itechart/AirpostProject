using API.Models;
using AutoMapper;
using BusinessLogic.Models;

namespace API.Mappers
{
    public static class CommonMapper
    {
        private static readonly Mapper Mapper;
        static CommonMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Airline, AirlineViewModel>().ReverseMap();
                cfg.CreateMap<Airplane, AirplaneViewModel>().ReverseMap();
                cfg.CreateMap<AirplaneSchema, AirplaneSchemaViewModel>().ReverseMap();
                cfg.CreateMap<AirplaneSubType, AirplaneSubTypeViewModel>().ReverseMap();
                cfg.CreateMap<AirplaneType, AirplaneTypeViewModel>().ReverseMap();
                cfg.CreateMap<Airport, AirportViewModel>().ReverseMap();
                cfg.CreateMap<ClassType, ClassTypeViewModel>().ReverseMap();
                cfg.CreateMap<Country, CountryViewModel>().ReverseMap();
                cfg.CreateMap<Document, DocumentViewModel>().ReverseMap();
                cfg.CreateMap<DocumentType, DocumentTypeViewModel>().ReverseMap();
                cfg.CreateMap<Flight, FlightViewModel>().ReverseMap();
                cfg.CreateMap<OrderStatus, OrderStatusViewModel>().ReverseMap();
                cfg.CreateMap<PassengerSeat, PassengerSeatViewModel>().ReverseMap();
                cfg.CreateMap<Ticket, TicketViewModel>().ReverseMap();
                cfg.CreateMap<UserRole, UserRoleViewModel>().ReverseMap();
                cfg.CreateMap<User, UserViewModel>()
                    .ForMember(
                        dest => dest.Password,
                        opt => opt.Ignore())
                    .ReverseMap();
            });
            Mapper = new Mapper(config);
        }
        public static AirlineViewModel ToViewModel(this Airline model) => Mapper.Map<AirlineViewModel>(model);
        public static Airline ToModel(this AirlineViewModel model) => Mapper.Map<Airline>(model);

        public static AirplaneViewModel ToViewModel(this Airplane model) => Mapper.Map<AirplaneViewModel>(model);
        public static Airplane ToModel(this AirplaneViewModel model) => Mapper.Map<Airplane>(model);

        public static AirplaneSchemaViewModel ToViewModel(this AirplaneSchema model) => Mapper.Map<AirplaneSchemaViewModel>(model);
        public static AirplaneSchema ToModel(this AirplaneSchemaViewModel model) => Mapper.Map<AirplaneSchema>(model);

        public static AirplaneSubTypeViewModel ToViewModel(this AirplaneSubType model) => Mapper.Map<AirplaneSubTypeViewModel>(model);
        public static AirplaneSubType ToModel(this AirplaneSubTypeViewModel model) => Mapper.Map<AirplaneSubType>(model);

        public static AirplaneTypeViewModel ToViewModel(this AirplaneType model) => Mapper.Map<AirplaneTypeViewModel>(model);
        public static AirplaneType ToModel(this AirplaneTypeViewModel model) => Mapper.Map<AirplaneType>(model);

        public static AirportViewModel ToViewModel(this Airport model) => Mapper.Map<AirportViewModel>(model);
        public static Airport ToModel(this AirportViewModel model) => Mapper.Map<Airport>(model);

        public static ClassTypeViewModel ToViewModel(this ClassType model) => Mapper.Map<ClassTypeViewModel>(model);
        public static ClassType ToModel(this ClassTypeViewModel model) => Mapper.Map<ClassType>(model);

        public static CountryViewModel ToViewModel(this Country model) => Mapper.Map<CountryViewModel>(model);
        public static Country ToModel(this CountryViewModel model) => Mapper.Map<Country>(model);

        public static DocumentViewModel ToViewModel(this Document model) => Mapper.Map<DocumentViewModel>(model);
        public static Document ToModel(this DocumentViewModel model) => Mapper.Map<Document>(model);

        public static DocumentTypeViewModel ToViewModel(this DocumentType model) => Mapper.Map<DocumentTypeViewModel>(model);
        public static DocumentType ToModel(this DocumentTypeViewModel model) => Mapper.Map<DocumentType>(model);

        public static OrderStatusViewModel ToViewModel(this OrderStatus model) => Mapper.Map<OrderStatusViewModel>(model);
        public static OrderStatus ToModel(this OrderStatusViewModel model) => Mapper.Map<OrderStatus>(model);

        public static UserRoleViewModel ToViewModel(this UserRole model) => Mapper.Map<UserRoleViewModel>(model);
        public static UserRole ToModel(this UserRoleViewModel model) => Mapper.Map<UserRole>(model);

        public static FlightViewModel ToViewModel(this Flight model) => Mapper.Map<FlightViewModel>(model);
        public static Flight ToModel(this FlightViewModel model) => Mapper.Map<Flight>(model);

        public static PassengerSeatViewModel ToViewModel(this PassengerSeat model) => Mapper.Map<PassengerSeatViewModel>(model);
        public static PassengerSeat ToModel(this PassengerSeatViewModel model) => Mapper.Map<PassengerSeat>(model);

        public static TicketViewModel ToViewModel(this Ticket model) => Mapper.Map<TicketViewModel>(model);
        public static Ticket ToModel(this TicketViewModel model) => Mapper.Map<Ticket>(model);

        public static UserViewModel ToViewModel(this User model) => Mapper.Map<UserViewModel>(model);
        public static User ToModel(this UserViewModel model) => Mapper.Map<User>(model);
    }
}
