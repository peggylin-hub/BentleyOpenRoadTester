/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class PointForm
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
            this.comboBoxFeatureDefinition = new System.Windows.Forms.ComboBox();
            this.labelAngle = new System.Windows.Forms.Label();
            this.labelDistance = new System.Windows.Forms.Label();
            this.textBoxAngle = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelFeatureDefinition = new System.Windows.Forms.Label();
            this.labelFeatureName = new System.Windows.Forms.Label();
            this.textBoxFeatureName = new System.Windows.Forms.TextBox();
            this.textBoxDistance = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // comboBoxFeatureDefinition
            // 
            this.comboBoxFeatureDefinition.FormattingEnabled = true;
            this.comboBoxFeatureDefinition.Location = new System.Drawing.Point(129, 72);
            this.comboBoxFeatureDefinition.Name = "comboBoxFeatureDefinition";
            this.comboBoxFeatureDefinition.Size = new System.Drawing.Size(250, 21);
            this.comboBoxFeatureDefinition.TabIndex = 3;
            this.comboBoxFeatureDefinition.SelectedIndexChanged += new System.EventHandler(this.FeatureDef_SelectedIndexChanged);
            // 
            // labelAngle
            // 
            this.labelAngle.AutoSize = true;
            this.labelAngle.Location = new System.Drawing.Point(16, 15);
            this.labelAngle.Name = "labelAngle";
            this.labelAngle.Size = new System.Drawing.Size(37, 13);
            this.labelAngle.TabIndex = 0;
            this.labelAngle.Text = "Angle:";
            // 
            // labelDistance
            // 
            this.labelDistance.AutoSize = true;
            this.labelDistance.Location = new System.Drawing.Point(16, 40);
            this.labelDistance.Name = "labelDistance";
            this.labelDistance.Size = new System.Drawing.Size(52, 13);
            this.labelDistance.TabIndex = 98;
            this.labelDistance.Text = "Distance:";
            // 
            // textBoxAngle
            // 
            this.textBoxAngle.Location = new System.Drawing.Point(129, 12);
            this.textBoxAngle.Name = "textBoxAngle";
            this.textBoxAngle.Size = new System.Drawing.Size(135, 20);
            this.textBoxAngle.TabIndex = 1;
            this.textBoxAngle.Leave += new System.EventHandler(this.GetAngle);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(16, 125);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(129, 122);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(250, 20);
            this.textBoxDescription.TabIndex = 5;
            // 
            // buttonApply
            // 
            this.buttonApply.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonApply.Location = new System.Drawing.Point(90, 160);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(75, 25);
            this.buttonApply.TabIndex = 6;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.ButtonApply_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(235, 160);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelFeatureDefinition
            // 
            this.labelFeatureDefinition.AutoSize = true;
            this.labelFeatureDefinition.Location = new System.Drawing.Point(16, 75);
            this.labelFeatureDefinition.Name = "labelFeatureDefinition";
            this.labelFeatureDefinition.Size = new System.Drawing.Size(93, 13);
            this.labelFeatureDefinition.TabIndex = 15;
            this.labelFeatureDefinition.Text = "Feature Definition:";
            // 
            // labelFeatureName
            // 
            this.labelFeatureName.AutoSize = true;
            this.labelFeatureName.Location = new System.Drawing.Point(16, 100);
            this.labelFeatureName.Name = "labelFeatureName";
            this.labelFeatureName.Size = new System.Drawing.Size(77, 13);
            this.labelFeatureName.TabIndex = 17;
            this.labelFeatureName.Text = "Feature Name:";
            // 
            // textBoxFeatureName
            // 
            this.textBoxFeatureName.Location = new System.Drawing.Point(129, 97);
            this.textBoxFeatureName.Name = "textBoxFeatureName";
            this.textBoxFeatureName.Size = new System.Drawing.Size(250, 20);
            this.textBoxFeatureName.TabIndex = 4;
            // 
            // textBoxDistance
            // 
            this.textBoxDistance.Location = new System.Drawing.Point(129, 37);
            this.textBoxDistance.Name = "textBoxDistance";
            this.textBoxDistance.Size = new System.Drawing.Size(135, 20);
            this.textBoxDistance.TabIndex = 2;
            this.textBoxDistance.Leave += new System.EventHandler(this.FormatDistance);
            // 
            // PointForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 191);
            this.Controls.Add(this.textBoxFeatureName);
            this.Controls.Add(this.labelFeatureName);
            this.Controls.Add(this.labelFeatureDefinition);
            this.Controls.Add(this.textBoxDistance);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxFeatureDefinition);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxAngle);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDistance);
            this.Controls.Add(this.labelAngle);
            this.Name = "PointForm";
            this.Text = "ForesightPointForm";
            this.Load += new System.EventHandler(this.HAForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label labelAngle;
        private System.Windows.Forms.Label labelDistance;
        private System.Windows.Forms.TextBox textBoxAngle;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxFeatureDefinition;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelFeatureDefinition;
        private System.Windows.Forms.Label labelFeatureName;
        private System.Windows.Forms.TextBox textBoxFeatureName;
        private System.Windows.Forms.TextBox textBoxDistance;
        }
    }