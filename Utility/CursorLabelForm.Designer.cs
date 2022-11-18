/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class CursorLabelForm
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
            this.HostPanel = new System.Windows.Forms.TableLayoutPanel();
            this.LabelName = new System.Windows.Forms.Label();
            this.LabelValue = new System.Windows.Forms.Label();
            this.HostPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HostPanel
            // 
            this.HostPanel.AutoSize = true;
            this.HostPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.HostPanel.ColumnCount = 2;
            this.HostPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HostPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.HostPanel.Controls.Add(this.LabelValue, 0, 0);
            this.HostPanel.Controls.Add(this.LabelName, 0, 0);
            this.HostPanel.Location = new System.Drawing.Point(0, 0);
            this.HostPanel.Margin = new System.Windows.Forms.Padding(0);
            this.HostPanel.Name = "HostPanel";
            this.HostPanel.RowCount = 1;
            this.HostPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HostPanel.Size = new System.Drawing.Size(200, 100);
            this.HostPanel.TabIndex = 0;
            // 
            // LabelName
            // 
            this.LabelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(1, 43);
            this.LabelName.Margin = new System.Windows.Forms.Padding(0);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(61, 13);
            this.LabelName.TabIndex = 1;
            this.LabelName.Text = "";
            this.LabelName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // LabelValue
            // 
            this.LabelValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LabelValue.AutoSize = true;
            this.LabelValue.Location = new System.Drawing.Point(63, 43);
            this.LabelValue.Margin = new System.Windows.Forms.Padding(0);
            this.LabelValue.Name = "LabelValue";
            this.LabelValue.Size = new System.Drawing.Size(60, 13);
            this.LabelValue.TabIndex = 2;
            this.LabelValue.Text = "";
            this.LabelValue.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // CursorLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 218);
            this.Controls.Add(this.HostPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CursorLabelForm";
            this.Text = "";
            this.Opacity = 0.7D;
            this.ShowInTaskbar = false;
            this.HostPanel.ResumeLayout(false);
            this.HostPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.TableLayoutPanel HostPanel;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.Label LabelValue;
        }
    }