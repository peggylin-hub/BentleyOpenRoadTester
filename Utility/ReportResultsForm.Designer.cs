/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/ReportResultsForm.Designer.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

namespace OpenRoadAddin
{
    partial class ReportResultsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelReportName = new System.Windows.Forms.Label();
            this.reportViewer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // labelReportName
            // 
            this.labelReportName.AutoSize = true;
            this.labelReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReportName.Location = new System.Drawing.Point(8, 0);
            this.labelReportName.Name = "labelReportName";
            this.labelReportName.Padding = new System.Windows.Forms.Padding(10);
            this.labelReportName.Size = new System.Drawing.Size(153, 44);
            this.labelReportName.TabIndex = 0;
            this.labelReportName.Text = "Report Name";
            // 
            // reportViewer
            // 
            this.reportViewer.AllowNavigation = false;
            this.reportViewer.AllowWebBrowserDrop = false;
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.Location = new System.Drawing.Point(12, 47);
            this.reportViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(760, 502);
            this.reportViewer.TabIndex = 1;
            this.reportViewer.WebBrowserShortcutsEnabled = false;
            // 
            // ReportResultsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.labelReportName);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "ReportResultsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Results";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelReportName;
        private System.Windows.Forms.WebBrowser reportViewer;
    }
}