﻿using System;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;

namespace Entelect.Encentivize.Sdk.GenericServices
{
    public interface IEntityRetrievalService<TOutput> 
        where TOutput : class, new()
    {
        TOutput GetById(int id);
        TOutput GetById(long id);
        TOutput GetById(Guid id);
        TOutput GetById(string id);
        PagedResult<TOutput> FindBySearchCriteria(BaseSearchCriteria searchCriteria);
    }
}