﻿namespace DataAccessLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IAirlineRepository AirlineRepository { get; }
    }
}
