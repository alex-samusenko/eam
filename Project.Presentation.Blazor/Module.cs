using Xafari.FW.ExpressApp;
using Xafari.FW.ExpressApp.Editors;
using Xafari.FW.ExpressApp.FileAttachments.Blazor;
using Xafari.FW.ExpressApp.Model.Core;
using System;
using System.ComponentModel;
using Xafari.BC;

namespace Project.Presentation.Blazor
{
	/// <summary>
	/// Class ProjectPresentationBlazorModule. This class cannot be inherited.
	/// </summary>
	[ToolboxItemFilter("Xaf.Platform.Blazor")]
	public sealed partial class ProjectPresentationBlazorModule : XafariBCModuleBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ProjectPresentationBlazorModule"/> class.
		/// </summary>
		public PromjectPresentationBlazorModule()
		{
			InitializeComponent();
	        }

	}
}
