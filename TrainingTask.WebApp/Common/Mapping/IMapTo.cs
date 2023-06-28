﻿using AutoMapper;

namespace TrainingTask.WebApp.Common.Mapping
{
    public interface IMapTo<T>
    {
        public void Mapping(Profile profile) => profile.CreateMap(GetType(), typeof(T));
    }
}
