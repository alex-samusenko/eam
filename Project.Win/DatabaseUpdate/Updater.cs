using System;
using System.Collections.Generic;
using System.Diagnostics;
using XafariFW.ExpressApp;
using XafariFW.ExpressApp.Updating;

namespace Project.Win.DatabaseUpdate
{
    /// <summary>
    /// Class Updater.
    /// </summary>
    public class Updater : ModuleUpdater
    {
        /// <summary>
        /// Initializes a new instance of the ModuleUpdater.
        /// </summary>
        public Updater(IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion)
        {
        }

        /// <summary>
        /// Performs a database update before the database schema is updated.
        /// </summary>
        public override void UpdateDatabaseBeforeUpdateSchema()
        {
            base.UpdateDatabaseBeforeUpdateSchema();
        }
        
        /// <summary>
        /// Performs a database update after the database schema is updated.
        /// </summary>
        public override void UpdateDatabaseAfterUpdateSchema()
        {
            base.UpdateDatabaseAfterUpdateSchema();
        }
    }
}
