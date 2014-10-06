namespace Entelect.Encentivize.Sdk.GenericServices
{
    public class EntitySettings
    {
        /// <summary>
        /// The singular for of the entity name to display
        /// </summary>
        public string EntityNameSingular { get; set; }
        /// <summary>
        /// The plural for of the entity name to display
        /// </summary>
        public string EntityNamePlural { get; set; }
        /// <summary>
        /// The base route to the entity on the rest api
        /// </summary>
        public string EntityRoute { get; set; }

        public EntitySettings(string entityNameSingular, string entityNamePlural, string entityRoute)
        {
            EntityNameSingular = entityNameSingular;
            EntityNamePlural = entityNamePlural;
            EntityRoute = entityRoute;
        }

        public EntitySettings(string sameForAll)
        {
            EntityNameSingular = sameForAll;
            EntityNamePlural = sameForAll;
            EntityRoute = sameForAll;
        }
    }
}