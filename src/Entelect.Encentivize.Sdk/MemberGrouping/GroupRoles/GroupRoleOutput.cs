using System.Collections.Generic;
using Entelect.Encentivize.Sdk.MemberGrouping.Abilities;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRoleOutput
    {
        public long GroupRoleId { get; set; }
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<AbilityOutput> Abilities { get; set; }
    }
}