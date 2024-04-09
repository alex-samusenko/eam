using Xafari.BC;

namespace Project.Win
{
    partial class ProjectWinModule
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
            // WinModule
            // 
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.SystemModule.SystemModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.Win.SystemModule.SystemWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.TreeListEditors.Win.TreeListEditorsWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.PivotChart.Win.PivotChartWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.PivotGrid.Win.PivotGridWindowsFormsModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.XafariModule));
            this.RequiredModuleTypes.Add(typeof(XafariBCModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.Win.XafariWinModule));
            this.RequiredModuleTypes.Add(typeof(Xafari.FW.ExpressApp.ReportsV2.Win.ReportsWindowsFormsModuleV2));
        }

        #endregion
    }
}
