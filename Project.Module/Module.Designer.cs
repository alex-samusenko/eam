using Xafari.BC;
using Xafari.FW.ExpressApp;

namespace Project.Module
{
    partial class ProjectModule
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
            // ProjectModule
            // 
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.SystemModule.SystemModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.Objects.BusinessClassLibraryCustomizationModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.ConditionalAppearance.ConditionalAppearanceModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.CloneObject.CloneObjectModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.ViewVariantsModule.ViewVariantsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.XafariModule));
            this.RequiredModuleTypes.Add(typeof(XafariBCModule));
        }

        #endregion
    }
}
