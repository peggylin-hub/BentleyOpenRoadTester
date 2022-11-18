/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2018 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class FeatureForm
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
            this.FeatureDefinition = new System.Windows.Forms.Label();
            this.FeatureDef = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.FeatureName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FeatureDefinition
            // 
            this.FeatureDefinition.AutoSize = true;
            this.FeatureDefinition.Location = new System.Drawing.Point(27, 18);
            this.FeatureDefinition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.FeatureDefinition.Name = "FeatureDefinition";
            this.FeatureDefinition.Size = new System.Drawing.Size(90, 13);
            this.FeatureDefinition.TabIndex = 9;
            this.FeatureDefinition.Text = "Feature Definition";
            // 
            // FeatureDef
            // 
            this.FeatureDef.FormattingEnabled = true;
            this.FeatureDef.Location = new System.Drawing.Point(126, 15);
            this.FeatureDef.Margin = new System.Windows.Forms.Padding(7, 6, 7, 3);
            this.FeatureDef.Name = "FeatureDef";
            this.FeatureDef.Size = new System.Drawing.Size(93, 21);
            this.FeatureDef.TabIndex = 1;
            this.FeatureDef.SelectedIndexChanged += new System.EventHandler(this.FeatureDef_SelectedIndexChanged);
            this.FeatureDef.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(126, 74);
            this.btnOK.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FeatureName
            // 
            this.FeatureName.Location = new System.Drawing.Point(126, 42);
            this.FeatureName.Margin = new System.Windows.Forms.Padding(7, 3, 7, 6);
            this.FeatureName.Name = "FeatureName";
            this.FeatureName.Size = new System.Drawing.Size(93, 20);
            this.FeatureName.TabIndex = 2;
            this.FeatureName.TextChanged += new System.EventHandler(this.FeatureName_TextChanged);
            this.FeatureName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.quickBoxs_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Feature Name";
            // 
            // FeatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 112);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FeatureName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.FeatureDef);
            this.Controls.Add(this.FeatureDefinition);
            this.Name = "FeatureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Feature Form";
            this.Load += new System.EventHandler(this.HAForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label FeatureDefinition;
        private System.Windows.Forms.ComboBox FeatureDef;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox FeatureName;
        private System.Windows.Forms.Label label1;
        }
    }