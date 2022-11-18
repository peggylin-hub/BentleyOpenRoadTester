/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class CurveWideningPlaceForm
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
            this.labelStartDistance = new System.Windows.Forms.Label();
            this.labelEndDistance = new System.Windows.Forms.Label();
            this.textBoxStartDistance = new System.Windows.Forms.TextBox();
            this.textBoxEndDistance = new System.Windows.Forms.TextBox();
            this.labelPointName = new System.Windows.Forms.Label();
            this.labelEnabled = new System.Windows.Forms.Label();
            this.labelOverlap = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.textBoxPriority = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelWideningTableFileName = new System.Windows.Forms.Label();
            this.textBoxWideningTableFile = new System.Windows.Forms.TextBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.comboBoxEnabled = new System.Windows.Forms.ComboBox();
            this.comboBoxPointName = new System.Windows.Forms.ComboBox();
            this.comboBoxOverlap = new System.Windows.Forms.ComboBox();
            this.checkBoxUseSpiralLengthForTransition = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStartDistance
            // 
            this.labelStartDistance.AutoSize = true;
            this.labelStartDistance.Location = new System.Drawing.Point(16, 13);
            this.labelStartDistance.Name = "labelStartDistance";
            this.labelStartDistance.Size = new System.Drawing.Size(77, 13);
            this.labelStartDistance.TabIndex = 0;
            this.labelStartDistance.Text = "Start Distance:";
            // 
            // labelEndDistance
            // 
            this.labelEndDistance.AutoSize = true;
            this.labelEndDistance.Location = new System.Drawing.Point(243, 13);
            this.labelEndDistance.Name = "labelEndDistance";
            this.labelEndDistance.Size = new System.Drawing.Size(74, 13);
            this.labelEndDistance.TabIndex = 1;
            this.labelEndDistance.Text = "End Distance:";
            // 
            // textBoxStartDistance
            // 
            this.textBoxStartDistance.Location = new System.Drawing.Point(98, 9);
            this.textBoxStartDistance.Name = "textBoxStartDistance";
            this.textBoxStartDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartDistance.TabIndex = 2;
            // 
            // textBoxEndDistance
            // 
            this.textBoxEndDistance.Location = new System.Drawing.Point(338, 9);
            this.textBoxEndDistance.Name = "textBoxEndDistance";
            this.textBoxEndDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndDistance.TabIndex = 2;
            // 
            // labelPointName
            // 
            this.labelPointName.AutoSize = true;
            this.labelPointName.Location = new System.Drawing.Point(16, 45);
            this.labelPointName.Name = "labelPointName";
            this.labelPointName.Size = new System.Drawing.Size(65, 13);
            this.labelPointName.TabIndex = 0;
            this.labelPointName.Text = "Point Name:";
            // 
            // labelEnabled
            // 
            this.labelEnabled.AutoSize = true;
            this.labelEnabled.Location = new System.Drawing.Point(243, 45);
            this.labelEnabled.Name = "labelEnabled";
            this.labelEnabled.Size = new System.Drawing.Size(49, 13);
            this.labelEnabled.TabIndex = 1;
            this.labelEnabled.Text = "Enabled:";
            // 
            // labelOverlap
            // 
            this.labelOverlap.AutoSize = true;
            this.labelOverlap.Location = new System.Drawing.Point(16, 77);
            this.labelOverlap.Name = "labelOverlap";
            this.labelOverlap.Size = new System.Drawing.Size(47, 13);
            this.labelOverlap.TabIndex = 0;
            this.labelOverlap.Text = "Overlap:";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Location = new System.Drawing.Point(243, 77);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(41, 13);
            this.labelPriority.TabIndex = 1;
            this.labelPriority.Text = "Priority:";
            // 
            // textBoxPriority
            // 
            this.textBoxPriority.Location = new System.Drawing.Point(338, 73);
            this.textBoxPriority.Name = "textBoxPriority";
            this.textBoxPriority.Size = new System.Drawing.Size(100, 20);
            this.textBoxPriority.TabIndex = 2;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(16, 145);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(63, 13);
            this.labelDescription.TabIndex = 1;
            this.labelDescription.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(129, 141);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(287, 20);
            this.textBoxDescription.TabIndex = 2;
            // 
            // labelWideningTableFileName
            // 
            this.labelWideningTableFileName.AutoSize = true;
            this.labelWideningTableFileName.Location = new System.Drawing.Point(16, 177);
            this.labelWideningTableFileName.Name = "labelWideningTableFileName";
            this.labelWideningTableFileName.Size = new System.Drawing.Size(104, 13);
            this.labelWideningTableFileName.TabIndex = 3;
            this.labelWideningTableFileName.Text = "Widening Table File:";
            // 
            // textBoxWideningTableFile
            // 
            this.textBoxWideningTableFile.Location = new System.Drawing.Point(129, 173);
            this.textBoxWideningTableFile.Name = "textBoxWideningTableFile";
            this.textBoxWideningTableFile.ReadOnly = true;
            this.textBoxWideningTableFile.Size = new System.Drawing.Size(287, 20);
            this.textBoxWideningTableFile.TabIndex = 4;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(423, 172);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(27, 23);
            this.buttonSelect.TabIndex = 5;
            this.buttonSelect.Text = "...";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.buttonSelect_Click);
            // 
            // comboBoxEnabled
            // 
            this.comboBoxEnabled.FormattingEnabled = true;
            this.comboBoxEnabled.Location = new System.Drawing.Point(338, 41);
            this.comboBoxEnabled.Name = "comboBoxEnabled";
            this.comboBoxEnabled.Size = new System.Drawing.Size(100, 21);
            this.comboBoxEnabled.TabIndex = 7;
            // 
            // comboBoxPointName
            // 
            this.comboBoxPointName.FormattingEnabled = true;
            this.comboBoxPointName.Location = new System.Drawing.Point(97, 41);
            this.comboBoxPointName.Name = "comboBoxPointName";
            this.comboBoxPointName.Size = new System.Drawing.Size(102, 21);
            this.comboBoxPointName.TabIndex = 6;
            // 
            // comboBoxOverlap
            // 
            this.comboBoxOverlap.FormattingEnabled = true;
            this.comboBoxOverlap.Location = new System.Drawing.Point(96, 73);
            this.comboBoxOverlap.Name = "comboBoxOverlap";
            this.comboBoxOverlap.Size = new System.Drawing.Size(102, 21);
            this.comboBoxOverlap.TabIndex = 6;
            // 
            // checkBoxUseSpiralLengthForTransition
            // 
            this.checkBoxUseSpiralLengthForTransition.AutoSize = true;
            this.checkBoxUseSpiralLengthForTransition.Location = new System.Drawing.Point(16, 109);
            this.checkBoxUseSpiralLengthForTransition.Name = "checkBoxUseSpiralLengthForTransition";
            this.checkBoxUseSpiralLengthForTransition.Size = new System.Drawing.Size(174, 17);
            this.checkBoxUseSpiralLengthForTransition.TabIndex = 8;
            this.checkBoxUseSpiralLengthForTransition.Text = "Use SpiralLength For Transition";
            this.checkBoxUseSpiralLengthForTransition.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(226, 206);
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
            this.buttonCancel.Location = new System.Drawing.Point(351, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // CurveWideningPlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 238);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkBoxUseSpiralLengthForTransition);
            this.Controls.Add(this.comboBoxEnabled);
            this.Controls.Add(this.comboBoxOverlap);
            this.Controls.Add(this.comboBoxPointName);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.textBoxWideningTableFile);
            this.Controls.Add(this.labelWideningTableFileName);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxPriority);
            this.Controls.Add(this.textBoxEndDistance);
            this.Controls.Add(this.textBoxStartDistance);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.labelEnabled);
            this.Controls.Add(this.labelEndDistance);
            this.Controls.Add(this.labelOverlap);
            this.Controls.Add(this.labelPointName);
            this.Controls.Add(this.labelStartDistance);
            this.Name = "CurveWideningPlaceForm";
            this.Text = "CurveWideningPlaceForm";
            this.Load += new System.EventHandler(this.CurveWideningPlaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label labelStartDistance;
        private System.Windows.Forms.Label labelEndDistance;
        private System.Windows.Forms.TextBox textBoxStartDistance;
        private System.Windows.Forms.TextBox textBoxEndDistance;
        private System.Windows.Forms.Label labelPointName;
        private System.Windows.Forms.Label labelEnabled;
        private System.Windows.Forms.Label labelOverlap;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.TextBox textBoxPriority;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelWideningTableFileName;
        private System.Windows.Forms.TextBox textBoxWideningTableFile;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.ComboBox comboBoxEnabled;
        private System.Windows.Forms.ComboBox comboBoxPointName;
        private System.Windows.Forms.ComboBox comboBoxOverlap;
        private System.Windows.Forms.CheckBox checkBoxUseSpiralLengthForTransition;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        }
    }