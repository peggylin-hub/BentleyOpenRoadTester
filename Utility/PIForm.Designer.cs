/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class PIForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.CurveRadius = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.FeatureDef = new System.Windows.Forms.ComboBox();
            this.FeatureDefinition = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CurveRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(126, 71);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // CurveRadius
            // 
            this.CurveRadius.DecimalPlaces = 2;
            this.CurveRadius.Location = new System.Drawing.Point(126, 12);
            this.CurveRadius.Margin = new System.Windows.Forms.Padding(7, 3, 7, 3);
            this.CurveRadius.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.CurveRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CurveRadius.Name = "CurveRadius";
            this.CurveRadius.Size = new System.Drawing.Size(93, 20);
            this.CurveRadius.TabIndex = 2;
            this.CurveRadius.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.CurveRadius.ValueChanged += new System.EventHandler(this.CurveRadius_ValueChanged);
            this.CurveRadius.Enter += new System.EventHandler(this.quickBoxs_Enter);
            this.CurveRadius.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Curve Radius";
            // 
            // FeatureDef
            // 
            this.FeatureDef.FormattingEnabled = true;
            this.FeatureDef.Location = new System.Drawing.Point(126, 38);
            this.FeatureDef.Margin = new System.Windows.Forms.Padding(7, 3, 7, 6);
            this.FeatureDef.Name = "FeatureDef";
            this.FeatureDef.Size = new System.Drawing.Size(93, 21);
            this.FeatureDef.TabIndex = 4;
            this.FeatureDef.SelectedIndexChanged += new System.EventHandler(this.FeatureDef_SelectedIndexChanged);
            // 
            // FeatureDefinition
            // 
            this.FeatureDefinition.AutoSize = true;
            this.FeatureDefinition.Location = new System.Drawing.Point(27, 41);
            this.FeatureDefinition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FeatureDefinition.Name = "FeatureDefinition";
            this.FeatureDefinition.Size = new System.Drawing.Size(90, 13);
            this.FeatureDefinition.TabIndex = 8;
            this.FeatureDefinition.Text = "Feature Definition";
            // 
            // PIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 109);
            this.Controls.Add(this.FeatureDefinition);
            this.Controls.Add(this.FeatureDef);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CurveRadius);
            this.Controls.Add(this.btnOK);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PI Settings";
            this.Load += new System.EventHandler(this.PIForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CurveRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.NumericUpDown CurveRadius;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FeatureDef;
        private System.Windows.Forms.Label FeatureDefinition;
        }
    }