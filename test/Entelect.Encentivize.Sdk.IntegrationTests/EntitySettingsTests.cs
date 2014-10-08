﻿using System;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.GenericServices;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class EntitySettingsTests
    {

        [TestCase(typeof(AchievementCategory), "Achievement Category", "Achievement Categories", "AchievementCategories")]
        public void TestDefaultConstructor(Type type, string expectedNameSingular, string expectedNamePlural, string expectedBaseRoute)
        {
            var entitySettings = new EntitySettings<TestEntity>(type);
            Assert.AreEqual(expectedNameSingular, entitySettings.EntityNameSingular);
            Assert.AreEqual(expectedNamePlural, entitySettings.EntityNamePlural);
            Assert.AreEqual(expectedBaseRoute, entitySettings.BaseRoute);
        }
    }

    public class TestEntity : IEntity
    {
    }
}