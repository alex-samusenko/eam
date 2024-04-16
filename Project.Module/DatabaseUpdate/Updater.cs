using System;
using System.Security.Principal;

using Xafari.FW.ExpressApp;
using Xafari.FW.ExpressApp.Updating;
using Xafari.FW.Xpo;
using Xafari.FW.Data.Filtering;

namespace Projet.Module.DatabaseUpdate
{
    /// <summary>
    /// Class Updater.
    /// </summary>
    public class Updater : ModuleUpdater
    {
        /// <summary>
        /// Initializes a new instance of the ModuleUpdater.
        /// </summary>
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        /// <summary>
        /// Performs a database update after the database schema is updated.
        /// </summary>
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
        }
    }
}
