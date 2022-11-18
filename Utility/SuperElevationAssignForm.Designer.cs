/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class SuperElevationAssignForm
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
            this.labelSuperPoint = new System.Windows.Forms.Label();
            this.comboBoxSuperPoint = new System.Windows.Forms.ComboBox();
            this.labelPivotPoint = new System.Windows.Forms.Label();
            this.comboBoxPivotPoint = new System.Windows.Forms.ComboBox();
            this.labelStartDistance = new System.Windows.Forms.Label();
            this.labelEndDistance = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.textBoxStartDistance = new System.Windows.Forms.TextBox();
            this.textBoxEndDistance = new System.Windows.Forms.TextBox();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelSuperPoint
            // 
            this.labelSuperPoint.AutoSize = true;
            this.labelSuperPoint.Location = new System.Drawing.Point(13, 17);
            this.labelSuperPoint.Name = "labelSuperPoint";
            this.labelSuperPoint.Size = new System.Drawing.Size(65, 13);
            this.labelSuperPoint.TabIndex = 0;
            this.labelSuperPoint.Text = "Super Point:";
            // 
            // comboBoxSuperPoint
            // 
            this.comboBoxSuperPoint.FormattingEnabled = true;
            this.comboBoxSuperPoint.Location = new System.Drawing.Point(93, 13);
            this.comboBoxSuperPoint.Name = "comboBoxSuperPoint";
            this.comboBoxSuperPoint.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSuperPoint.TabIndex = 1;
            // 
            // labelPivotPoint
            // 
            this.labelPivotPoint.AutoSize = true;
            this.labelPivotPoint.Location = new System.Drawing.Point(234, 17);
            this.labelPivotPoint.Name = "labelPivotPoint";
            this.labelPivotPoint.Size = new System.Drawing.Size(61, 13);
            this.labelPivotPoint.TabIndex = 2;
            this.labelPivotPoint.Text = "Pivot Point:";
            // 
            // comboBoxPivotPoint
            // 
            this.comboBoxPivotPoint.FormattingEnabled = true;
            this.comboBoxPivotPoint.Location = new System.Drawing.Point(316, 13);
            this.comboBoxPivotPoint.Name = "comboBoxPivotPoint";
            this.comboBoxPivotPoint.Size = new System.Drawing.Size(100, 21);
            this.comboBoxPivotPoint.TabIndex = 3;
            // 
            // labelStartDistance
            // 
            this.labelStartDistance.AutoSize = true;
            this.labelStartDistance.Location = new System.Drawing.Point(13, 51);
            this.labelStartDistance.Name = "labelStartDistance";
            this.labelStartDistance.Size = new System.Drawing.Size(77, 13);
            this.labelStartDistance.TabIndex = 4;
            this.labelStartDistance.Text = "Start Distance:";
            // 
            // labelEndDistance
            // 
            this.labelEndDistance.AutoSize = true;
            this.labelEndDistance.Location = new System.Drawing.Point(234, 51);
            this.labelEndDistance.Name = "labelEndDistance";
            this.labelEndDistance.Size = new System.Drawing.Size(74, 13);
            this.labelEndDistance.TabIndex = 5;
            this.labelEndDistance.Text = "End Distance:";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(16, 89);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(41, 13);
            this.labelPriority.TabIndex = 6;
            this.labelPriority.Text = "Priority:";
            // 
            // textBoxStartDistance
            // 
            this.textBoxStartDistance.Location = new System.Drawing.Point(93, 47);
            this.textBoxStartDistance.Name = "textBoxStartDistance";
            this.textBoxStartDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartDistance.TabIndex = 7;
            // 
            // textBoxEndDistance
            // 
            this.textBoxEndDistance.Location = new System.Drawing.Point(314, 47);
            this.textBoxEndDistance.Name = "textBoxEndDistance";
            this.textBoxEndDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndDistance.TabIndex = 8;
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(93, 87);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(100, 20);
            this.textBoxPriority.TabIndex = 8;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(220, 123);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(339, 123);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // SuperElevationAssignForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 158);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxPriority);
            this.Controls.Add(this.textBoxEndDistance);
            this.Controls.Add(this.textBoxStartDistance);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.labelEndDistance);
            this.Controls.Add(this.labelStartDistance);
            this.Controls.Add(this.comboBoxPivotPoint);
            this.Controls.Add(this.labelPivotPoint);
            this.Controls.Add(this.comboBoxSuperPoint);
            this.Controls.Add(this.labelSuperPoint);
            this.Name = "SuperElevationAssignForm";
            this.Text = "SuperElevationAssignForm";
            this.Load += new System.EventHandler(this.SuperElevationAssignForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label labelSuperPoint;
        private System.Windows.Forms.ComboBox comboBoxSuperPoint;
        private System.Windows.Forms.Label labelPivotPoint;
        private System.Windows.Forms.ComboBox comboBoxPivotPoint;
        private System.Windows.Forms.Label labelStartDistance;
        private System.Windows.Forms.Label labelEndDistance;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.TextBox textBoxStartDistance;
        private System.Windows.Forms.TextBox textBoxEndDistance;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        }
    }