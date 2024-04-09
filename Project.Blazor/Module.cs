using System.ComponentModel;
using Xafari.FW.ExpressApp.Security.Strategy;
using Xafari.BC;

namespace Project.Blazor
{
    /// <summary>
    /// Class SmetaBlazorModule. This class cannot be inherited.
    /// </summary>
    [ToolboxItemFilter("Xaf.Platform.Blazor")]
    public sealed partial class ProjectBlazorModule : XafariBCModuleBase
    {
        /// <summary>
        /// ctor
        /// </summary>
        public ProjectBlazorModule()
        {
            InitializeComponent();
        }
    }
}
