﻿using AutoMapper;
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
                cfg.CreateMap<Airline, AirlineBm>().ReverseMap();
                cfg.CreateMap<AirplaneSchema, AirplaneSchemaBm>().ReverseMap();
                cfg.CreateMap<AirplaneSubType, AirplaneSubTypeBm>().ReverseMap();
                cfg.CreateMap<AirplaneType, AirplaneTypeBm>().ReverseMap();
                cfg.CreateMap<ClassType, ClassTypeBm>().ReverseMap();
                cfg.CreateMap<Country, CountryBm>().ReverseMap();
                cfg.CreateMap<DocumentType, DocumentTypeBm>().ReverseMap();
                cfg.CreateMap<OrderStatus, OrderStatusBm>().ReverseMap();
                cfg.CreateMap<UserRole, UserRoleBm>().ReverseMap();
            });
            Mapper = new Mapper(config);
        }
        public static AirlineBm ToBm(this Airline model) => Mapper.Map<AirlineBm>(model);
        public static Airline ToDal(this AirlineBm model) => Mapper.Map<Airline>(model);

        public static AirplaneSchemaBm ToBm(this AirplaneSchema model) => Mapper.Map<AirplaneSchemaBm>(model);
        public static AirplaneSchema ToDal(this AirplaneSchemaBm model) => Mapper.Map<AirplaneSchema>(model);
        
        public static AirplaneSubTypeBm ToBm(this AirplaneSubType model) => Mapper.Map<AirplaneSubTypeBm>(model);
        public static AirplaneSubType ToDal(this AirplaneSubTypeBm model) => Mapper.Map<AirplaneSubType>(model);
        
        public static AirplaneTypeBm ToBm(this AirplaneType model) => Mapper.Map<AirplaneTypeBm>(model);
        public static AirplaneType ToDal(this AirplaneTypeBm model) => Mapper.Map<AirplaneType>(model);
        
        public static ClassTypeBm ToBm(this ClassType model) => Mapper.Map<ClassTypeBm>(model);
        public static ClassType ToDal(this ClassTypeBm model) => Mapper.Map<ClassType>(model);
        
        public static CountryBm ToBm(this Country model) => Mapper.Map<CountryBm>(model);
        public static Country ToDal(this CountryBm model) => Mapper.Map<Country>(model);

        public static DocumentTypeBm ToBm(this DocumentType model) => Mapper.Map<DocumentTypeBm>(model);
        public static DocumentType ToDal(this DocumentTypeBm model) => Mapper.Map<DocumentType>(model);

        public static OrderStatusBm ToBm(this OrderStatus model) => Mapper.Map<OrderStatusBm>(model);
        public static OrderStatus ToDal(this OrderStatusBm model) => Mapper.Map<OrderStatus>(model);

        public static UserRoleBm ToBm(this UserRole model) => Mapper.Map<UserRoleBm>(model);
        public static UserRole ToDal(this UserRoleBm model) => Mapper.Map<UserRole>(model);
    }
}