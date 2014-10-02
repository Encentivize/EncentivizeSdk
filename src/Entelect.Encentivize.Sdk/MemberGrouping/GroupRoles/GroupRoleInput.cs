using System.Collections.Generic;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRoleInput : BaseInput
    {
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> Abilities { get; set; }
    }
}