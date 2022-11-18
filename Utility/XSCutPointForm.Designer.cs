/*--------------------------------------------------------------------------------------+
|
|  $Source: PowerProduct/OpenRoadsDesignerSDK/ORDExamples/ManagedSDKExample/Utility/XSCutPointForm.Designer.cs $
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/

namespace OpenRoadAddin.Utility
    {
    partial class XSCutPointForm
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
            this.LeftWidth = new System.Windows.Forms.Label();
            this.RightWidth = new System.Windows.Forms.Label();
            this.LeftWidthNumber = new System.Windows.Forms.NumericUpDown();
            this.RightWidthNumber = new System.Windows.Forms.NumericUpDown();
            this.Increment = new System.Windows.Forms.Label();
            this.IncrementNumber = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.StartStationNumber = new System.Windows.Forms.NumericUpDown();
            this.EndStationNumber = new System.Windows.Forms.NumericUpDown();
            this.StartStation = new System.Windows.Forms.Label();
            this.EndStation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LeftWidthNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightWidthNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartStationNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndStationNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // LeftWidth
            // 
            this.LeftWidth.AutoSize = true;
            this.LeftWidth.Location = new System.Drawing.Point(37, 15);
            this.LeftWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LeftWidth.Name = "LeftWidth";
            this.LeftWidth.Size = new System.Drawing.Size(76, 17);
            this.LeftWidth.TabIndex = 1;
            this.LeftWidth.Text = "Left Width:";
            // 
            // RightWidth
            // 
            this.RightWidth.AutoSize = true;
            this.RightWidth.Location = new System.Drawing.Point(28, 45);
            this.RightWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RightWidth.Name = "RightWidth";
            this.RightWidth.Size = new System.Drawing.Size(85, 17);
            this.RightWidth.TabIndex = 2;
            this.RightWidth.Text = "Right Width:";
            // 
            // LeftWidthNumber
            // 
            this.LeftWidthNumber.DecimalPlaces = 2;
            this.LeftWidthNumber.Location = new System.Drawing.Point(122, 13);
            this.LeftWidthNumber.Margin = new System.Windows.Forms.Padding(4);
            this.LeftWidthNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.LeftWidthNumber.Name = "LeftWidthNumber";
            this.LeftWidthNumber.Size = new System.Drawing.Size(160, 22);
            this.LeftWidthNumber.TabIndex = 1;
            this.LeftWidthNumber.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.LeftWidthNumber.ValueChanged += new System.EventHandler(this.LeftWidthNumber_ValueChanged);
            this.LeftWidthNumber.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.LeftWidthNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // RightWidthNumber
            // 
            this.RightWidthNumber.DecimalPlaces = 2;
            this.RightWidthNumber.Location = new System.Drawing.Point(122, 43);
            this.RightWidthNumber.Margin = new System.Windows.Forms.Padding(4);
            this.RightWidthNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.RightWidthNumber.Name = "RightWidthNumber";
            this.RightWidthNumber.Size = new System.Drawing.Size(160, 22);
            this.RightWidthNumber.TabIndex = 2;
            this.RightWidthNumber.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.RightWidthNumber.ValueChanged += new System.EventHandler(this.RightWidthNumber_ValueChanged);
            this.RightWidthNumber.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.RightWidthNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // Increment
            // 
            this.Increment.AutoSize = true;
            this.Increment.Location = new System.Drawing.Point(55, 75);
            this.Increment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Increment.Name = "Increment";
            this.Increment.Size = new System.Drawing.Size(58, 17);
            this.Increment.TabIndex = 5;
            this.Increment.Text = "Interval:";
            // 
            // IncrementNumber
            // 
            this.IncrementNumber.DecimalPlaces = 2;
            this.IncrementNumber.Location = new System.Drawing.Point(122, 73);
            this.IncrementNumber.Margin = new System.Windows.Forms.Padding(4);
            this.IncrementNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.IncrementNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.IncrementNumber.Name = "IncrementNumber";
            this.IncrementNumber.Size = new System.Drawing.Size(160, 22);
            this.IncrementNumber.TabIndex = 3;
            this.IncrementNumber.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.IncrementNumber.ValueChanged += new System.EventHandler(this.IncrementNumber_ValueChanged);
            this.IncrementNumber.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.IncrementNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(182, 170);
            this.btnOK.Margin = new System.Windows.Forms.Padding(4);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(13, 170);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // StartStationNumber
            // 
            this.StartStationNumber.DecimalPlaces = 2;
            this.StartStationNumber.Location = new System.Drawing.Point(122, 102);
            this.StartStationNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StartStationNumber.Name = "StartStationNumber";
            this.StartStationNumber.Size = new System.Drawing.Size(160, 22);
            this.StartStationNumber.TabIndex = 4;
            this.StartStationNumber.ValueChanged += new System.EventHandler(this.StartStationNumber_ValueChanged);
            this.StartStationNumber.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.StartStationNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // EndStationNumber
            // 
            this.EndStationNumber.DecimalPlaces = 2;
            this.EndStationNumber.Location = new System.Drawing.Point(122, 130);
            this.EndStationNumber.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EndStationNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EndStationNumber.Name = "EndStationNumber";
            this.EndStationNumber.Size = new System.Drawing.Size(160, 22);
            this.EndStationNumber.TabIndex = 5;
            this.EndStationNumber.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EndStationNumber.ValueChanged += new System.EventHandler(this.EndStationNumber_ValueChanged);
            this.EndStationNumber.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.EndStationNumber.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // StartStation
            // 
            this.StartStation.AutoSize = true;
            this.StartStation.Location = new System.Drawing.Point(23, 104);
            this.StartStation.Name = "StartStation";
            this.StartStation.Size = new System.Drawing.Size(90, 17);
            this.StartStation.TabIndex = 12;
            this.StartStation.Text = "Start Station:";
            // 
            // EndStation
            // 
            this.EndStation.AutoSize = true;
            this.EndStation.Location = new System.Drawing.Point(28, 132);
            this.EndStation.Name = "EndStation";
            this.EndStation.Size = new System.Drawing.Size(85, 17);
            this.EndStation.TabIndex = 13;
            this.EndStation.Text = "End Station:";
            // 
            // XSCutPointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 211);
            this.Controls.Add(this.EndStation);
            this.Controls.Add(this.StartStation);
            this.Controls.Add(this.EndStationNumber);
            this.Controls.Add(this.StartStationNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.IncrementNumber);
            this.Controls.Add(this.Increment);
            this.Controls.Add(this.RightWidthNumber);
            this.Controls.Add(this.LeftWidthNumber);
            this.Controls.Add(this.RightWidth);
            this.Controls.Add(this.LeftWidth);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "XSCutPointForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cut Point Settings";
            this.Load += new System.EventHandler(this.XSCutPointForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LeftWidthNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RightWidthNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IncrementNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartStationNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EndStationNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label LeftWidth;
        private System.Windows.Forms.Label RightWidth;
        private System.Windows.Forms.NumericUpDown LeftWidthNumber;
        private System.Windows.Forms.NumericUpDown RightWidthNumber;
        private System.Windows.Forms.Label Increment;
        private System.Windows.Forms.NumericUpDown IncrementNumber;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown StartStationNumber;
        private System.Windows.Forms.NumericUpDown EndStationNumber;
        private System.Windows.Forms.Label StartStation;
        private System.Windows.Forms.Label EndStation;
        }
    }