using System;
using Entelect.Encentivize.Sdk.Achievements;
using Entelect.Encentivize.Sdk.Achievements.AchievementCategories;
using Entelect.Encentivize.Sdk.GenericServices;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupMembers;
using Entelect.Encentivize.Sdk.MemberGrouping.Groups;
using Entelect.Encentivize.Sdk.MemberGrouping.GroupTypes;
using Entelect.Encentivize.Sdk.Members.Achievements;
using Entelect.Encentivize.Sdk.Otp.Configuration;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class EntitySettingsTests
    {

        [TestCase(typeof(AchievementCategory), "Achievement Category", "Achievement Categories", "AchievementCategories")]
        [TestCase(typeof(MemberAchievement), "Member Achievement", "Member Achievements", "MemberAchievements")]
        [TestCase(typeof(OneTimePinConfiguration), "One Time Pin Configuration", "One Time Pin Configurations", "OneTimePinConfigurations")]
        [TestCase(typeof(GroupType), "Group Type", "Group Types", "GroupTypes")]
        [TestCase(typeof(Group), "Group", "Groups", "Groups")]
        [TestCase(typeof(GroupMember), "Group Member", "Group Members", "GroupMembers")]
        [TestCase(typeof(Achievement), "Achievement", "Achievements", "Achievements")]
        public void TestDefaultConstructor(Type type, string expectedNameSingular, string expectedNamePlural, string expectedBaseRoute)
        {
            var entitySettings = new EntitySettings(type);
            Assert.AreEqual(expectedNameSingular, entitySettings.EntityNameSingular);
            Assert.AreEqual(expectedNamePlural, entitySettings.EntityNamePlural);
            Assert.AreEqual(expectedBaseRoute, entitySettings.BaseRoute);
        }
    }
}