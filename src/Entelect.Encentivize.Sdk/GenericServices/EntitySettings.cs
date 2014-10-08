using System;
using Entelect.Extensions;

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
        /// The base route to get the entity on the rest api
        /// </summary>
        public string BaseRoute { get; set; }// change to BaseEntityUrl

        public EntitySettings()
        {
        }

        public void PopulateBasedOnType<TEntity>()
            where TEntity : IEntity
        {
            PopulateBasedOnType(typeof (TEntity));
        }

        public void PopulateBasedOnType(Type entityType)
        {
            var entityName = entityType.Name;
            EntityNameSingular = entityName.PascalToSpacedString();
            EntityNamePlural = Plurarlise(EntityNameSingular);
            BaseRoute = Plurarlise(entityName);
        }

        internal EntitySettings(Type entityType)
        {
            var entityName = entityType.Name;
            EntityNameSingular = entityName.PascalToSpacedString();
            EntityNamePlural = Plurarlise(EntityNameSingular);
            BaseRoute = Plurarlise(entityName);
        }

        public EntitySettings(string entityNameSingular, string entityNamePlural, string baseRoute)
        {
            EntityNameSingular = entityNameSingular;
            EntityNamePlural = entityNamePlural;
            BaseRoute = baseRoute;
        }

        protected string Plurarlise(string entityNameSingular)
        {
            /* todo rk, replace this with our pluralisation service asap */
            if (entityNameSingular.EndsWith("y"))
            {
                var pluralisedName = entityNameSingular.Substring(0, entityNameSingular.Length - 1);
                return string.Format("{0}ies", pluralisedName);
            }
            return string.Format("{0}s", entityNameSingular);
        }
    }
}