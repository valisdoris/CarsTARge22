﻿using CarsTARge22.Core.Domain;
using CarsTARge22.Core.Dto;

namespace CarsTARge22.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
    }
}