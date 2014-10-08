using System.Collections.Generic;
using Entelect.Encentivize.Sdk.MemberGrouping.Abilities;

namespace Entelect.Encentivize.Sdk.MemberGrouping.GroupRoles
{
    public class GroupRole: IEditableEntity<GroupRoleInput>
    {
        public long GroupRoleId { get; set; }
        public long GroupTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ability> Abilities { get; set; }
        public GroupRoleInput ToInput()
        {
            throw new System.NotImplementedException();
        }

        public string GetModificationUrl()
        {
            throw new System.NotImplementedException();
        }
    }
}