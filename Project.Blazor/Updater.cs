using System;

using Xafari.FW.ExpressApp;
using Xafari.FW.ExpressApp.Updating;

namespace Project.Blazor.DatabaseUpdate
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
