using Xafari.BC;

namespace Project.Blazor.Module
{
    partial class ProjectBlazorModule
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // 
            // SmetaBlazorModule
            // 
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.SystemModule.SystemModule));
            this.RequiredModuleTypes.Add(typeof(PromAktiv.Core.Module.CoreModule));
            this.RequiredModuleTypes.Add(typeof(PromAktiv.Core.Module.Blazor.PromAktivCoreBlazorModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.XafariModule));
            this.RequiredModuleTypes.Add(typeof(XafariBCModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Editors.Blazor.XafariEditorsBlazorModule));
            this.RequiredModuleTypes.Add(typeof(Project.Module.ProjectModule));
        }

        #endregion
    }
}
