using System.Collections.Generic;
using System.Linq;
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
        public GroupRoleInput ToEditInput()
        {
            return new GroupRoleInput
            {
                Abilities = Abilities.Select(ability => ability.AbilityId),
                Description = Description,
                GroupTypeId = GroupTypeId,
                Name = Name
            };
        }

        public string GetModificationUrl()
        {
            return string.Format("GroupRoles/{0}", GroupRoleId);
        }
    }
}