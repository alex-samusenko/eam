using Xafari;
using Xafari.FW.ExpressApp;
using Xafari.FW.ExpressApp.DC;
using Xafari.FW.ExpressApp.Updating;
using Xafari.FW.ExpressApp.Xpo;
using Xafari.FW.Data.Filtering;
using Xafari.FW.Xpo;
using System.Collections.Generic;
using Project.Module.ObjectsExtensions;

namespace Project.Module
{
    /// <summary>
    /// Class ProjectModule. This class cannot be inherited.
    /// </summary>
    public sealed partial class ProjectModule : ModuleBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectModule"/> class.
        /// </summary>
        public ProjectModule()
        {
            InitializeComponent();

        }
        /// <summary>
        /// Register class extensions.
        /// </summary>
        public override void CustomizeTypesInfo(ITypesInfo typesInfo)
        {
            base.CustomizeTypesInfo(typesInfo);
            //CalculatedPersistentAliasHelper(typesInfo);
            EmployeeExtension.CustomizeTypesInfo(typesInfo);
        }
    }
}
