/*--------------------------------------------------------------------------------------+
|
|  $Copyright: (c) 2019 Bentley Systems, Incorporated. All rights reserved. $
|
+--------------------------------------------------------------------------------------*/
namespace OpenRoadAddin.Utility
    {
    partial class SuperElevationPlaceForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FeatureDef = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxSide = new System.Windows.Forms.ComboBox();
            this.comboBoxSuperElevationType = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBoxT1SuperPointType = new System.Windows.Forms.ComboBox();
            this.comboBoxT1TransitionType = new System.Windows.Forms.ComboBox();
            this.comboBoxT1PivotEdgeType = new System.Windows.Forms.ComboBox();
            this.textBoxT1NonLinearCurveLength = new System.Windows.Forms.TextBox();
            this.textBoxT1Slope = new System.Windows.Forms.TextBox();
            this.labelT1NonLinearCurveLength = new System.Windows.Forms.Label();
            this.labelT1TransitionType = new System.Windows.Forms.Label();
            this.labelT1SuperPointType = new System.Windows.Forms.Label();
            this.labelT1Slope = new System.Windows.Forms.Label();
            this.labelT1PivotEdgeType = new System.Windows.Forms.Label();
            this.textBoxT1Distance = new System.Windows.Forms.TextBox();
            this.labelT1Distance = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.comboBoxT2SuperPointType = new System.Windows.Forms.ComboBox();
            this.comboBoxT2TransitionType = new System.Windows.Forms.ComboBox();
            this.comboBoxT2PivotEdgeType = new System.Windows.Forms.ComboBox();
            this.textBoxT2NonLinearCurveLength = new System.Windows.Forms.TextBox();
            this.textBoxT2Slope = new System.Windows.Forms.TextBox();
            this.labelT2NonLinearCurveLength = new System.Windows.Forms.Label();
            this.labelT2TransitionType = new System.Windows.Forms.Label();
            this.labelT2SuperPointType = new System.Windows.Forms.Label();
            this.labelT2Slope = new System.Windows.Forms.Label();
            this.labelT2PivotEdgeType = new System.Windows.Forms.Label();
            this.textBoxT2Distance = new System.Windows.Forms.TextBox();
            this.labelT2Distance = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.comboBoxT3SuperPointType = new System.Windows.Forms.ComboBox();
            this.comboBoxT3TransitionType = new System.Windows.Forms.ComboBox();
            this.comboBoxT3PivotEdgeType = new System.Windows.Forms.ComboBox();
            this.textBoxT3NonLinearCurveLength = new System.Windows.Forms.TextBox();
            this.textBoxT3Slope = new System.Windows.Forms.TextBox();
            this.labelT3NonLinearCurveLength = new System.Windows.Forms.Label();
            this.labelT3TransitionType = new System.Windows.Forms.Label();
            this.labelT3SuperPointType = new System.Windows.Forms.Label();
            this.labelT3Slope = new System.Windows.Forms.Label();
            this.labelT3PivotEdgeType = new System.Windows.Forms.Label();
            this.textBoxT3Distance = new System.Windows.Forms.TextBox();
            this.labelT3Distance = new System.Windows.Forms.Label();
            this.textBoxInsideEdgeOffset = new System.Windows.Forms.TextBox();
            this.textBoxLaneName = new System.Windows.Forms.TextBox();
            this.textBoxLaneEndDistance = new System.Windows.Forms.TextBox();
            this.textBoxSlope = new System.Windows.Forms.TextBox();
            this.textBoxLaneStartDistance = new System.Windows.Forms.TextBox();
            this.textBoxWidth = new System.Windows.Forms.TextBox();
            this.labelLaneEndDistance = new System.Windows.Forms.Label();
            this.labelLaneStartDistance = new System.Windows.Forms.Label();
            this.labelSlope = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.labelInsideEdgeOffset = new System.Windows.Forms.Label();
            this.labelSide = new System.Windows.Forms.Label();
            this.labelLaneName = new System.Windows.Forms.Label();
            this.labelSuperElevationType = new System.Windows.Forms.Label();
            this.textBoxEndDistance = new System.Windows.Forms.TextBox();
            this.textBoxStartDistance = new System.Windows.Forms.TextBox();
            this.textBoxSectionName = new System.Windows.Forms.TextBox();
            this.labelEndDistance = new System.Windows.Forms.Label();
            this.labelStartDistance = new System.Windows.Forms.Label();
            this.labelFeatureName = new System.Windows.Forms.Label();
            this.labelSectionName = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FeatureDef);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBoxEndDistance);
            this.groupBox1.Controls.Add(this.textBoxStartDistance);
            this.groupBox1.Controls.Add(this.textBoxSectionName);
            this.groupBox1.Controls.Add(this.labelEndDistance);
            this.groupBox1.Controls.Add(this.labelStartDistance);
            this.groupBox1.Controls.Add(this.labelFeatureName);
            this.groupBox1.Controls.Add(this.labelSectionName);
            this.groupBox1.Location = new System.Drawing.Point(12, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 397);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SuperElevation Section:";
            // 
            // FeatureDef
            // 
            this.FeatureDef.FormattingEnabled = true;
            this.FeatureDef.Location = new System.Drawing.Point(382, 20);
            this.FeatureDef.Margin = new System.Windows.Forms.Padding(7, 3, 7, 6);
            this.FeatureDef.Name = "FeatureDef";
            this.FeatureDef.Size = new System.Drawing.Size(100, 21);
            this.FeatureDef.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBoxSide);
            this.groupBox2.Controls.Add(this.comboBoxSuperElevationType);
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Controls.Add(this.textBoxInsideEdgeOffset);
            this.groupBox2.Controls.Add(this.textBoxLaneName);
            this.groupBox2.Controls.Add(this.textBoxLaneEndDistance);
            this.groupBox2.Controls.Add(this.textBoxSlope);
            this.groupBox2.Controls.Add(this.textBoxLaneStartDistance);
            this.groupBox2.Controls.Add(this.textBoxWidth);
            this.groupBox2.Controls.Add(this.labelLaneEndDistance);
            this.groupBox2.Controls.Add(this.labelLaneStartDistance);
            this.groupBox2.Controls.Add(this.labelSlope);
            this.groupBox2.Controls.Add(this.labelWidth);
            this.groupBox2.Controls.Add(this.labelInsideEdgeOffset);
            this.groupBox2.Controls.Add(this.labelSide);
            this.groupBox2.Controls.Add(this.labelLaneName);
            this.groupBox2.Controls.Add(this.labelSuperElevationType);
            this.groupBox2.Location = new System.Drawing.Point(0, 84);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 307);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SuperElevation Lane1:";
            // 
            // comboBoxSide
            // 
            this.comboBoxSide.FormattingEnabled = true;
            this.comboBoxSide.Location = new System.Drawing.Point(106, 47);
            this.comboBoxSide.Name = "comboBoxSide";
            this.comboBoxSide.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSide.TabIndex = 7;
            // 
            // comboBoxSuperElevationType
            // 
            this.comboBoxSuperElevationType.FormattingEnabled = true;
            this.comboBoxSuperElevationType.Location = new System.Drawing.Point(106, 19);
            this.comboBoxSuperElevationType.Name = "comboBoxSuperElevationType";
            this.comboBoxSuperElevationType.Size = new System.Drawing.Size(100, 21);
            this.comboBoxSuperElevationType.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 147);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(499, 160);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.comboBoxT1SuperPointType);
            this.tabPage1.Controls.Add(this.comboBoxT1TransitionType);
            this.tabPage1.Controls.Add(this.comboBoxT1PivotEdgeType);
            this.tabPage1.Controls.Add(this.textBoxT1NonLinearCurveLength);
            this.tabPage1.Controls.Add(this.textBoxT1Slope);
            this.tabPage1.Controls.Add(this.labelT1NonLinearCurveLength);
            this.tabPage1.Controls.Add(this.labelT1TransitionType);
            this.tabPage1.Controls.Add(this.labelT1SuperPointType);
            this.tabPage1.Controls.Add(this.labelT1Slope);
            this.tabPage1.Controls.Add(this.labelT1PivotEdgeType);
            this.tabPage1.Controls.Add(this.textBoxT1Distance);
            this.tabPage1.Controls.Add(this.labelT1Distance);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(491, 134);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Transition1";
            // 
            // comboBoxT1SuperPointType
            // 
            this.comboBoxT1SuperPointType.FormattingEnabled = true;
            this.comboBoxT1SuperPointType.Location = new System.Drawing.Point(99, 94);
            this.comboBoxT1SuperPointType.Name = "comboBoxT1SuperPointType";
            this.comboBoxT1SuperPointType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT1SuperPointType.TabIndex = 2;
            // 
            // comboBoxT1TransitionType
            // 
            this.comboBoxT1TransitionType.FormattingEnabled = true;
            this.comboBoxT1TransitionType.Location = new System.Drawing.Point(364, 55);
            this.comboBoxT1TransitionType.Name = "comboBoxT1TransitionType";
            this.comboBoxT1TransitionType.Size = new System.Drawing.Size(114, 21);
            this.comboBoxT1TransitionType.TabIndex = 2;
            // 
            // comboBoxT1PivotEdgeType
            // 
            this.comboBoxT1PivotEdgeType.FormattingEnabled = true;
            this.comboBoxT1PivotEdgeType.Location = new System.Drawing.Point(99, 55);
            this.comboBoxT1PivotEdgeType.Name = "comboBoxT1PivotEdgeType";
            this.comboBoxT1PivotEdgeType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT1PivotEdgeType.TabIndex = 2;
            // 
            // textBoxT1NonLinearCurveLength
            // 
            this.textBoxT1NonLinearCurveLength.Location = new System.Drawing.Point(364, 94);
            this.textBoxT1NonLinearCurveLength.Name = "textBoxT1NonLinearCurveLength";
            this.textBoxT1NonLinearCurveLength.Size = new System.Drawing.Size(114, 20);
            this.textBoxT1NonLinearCurveLength.TabIndex = 1;
            // 
            // textBoxT1Slope
            // 
            this.textBoxT1Slope.Location = new System.Drawing.Point(364, 16);
            this.textBoxT1Slope.Name = "textBoxT1Slope";
            this.textBoxT1Slope.Size = new System.Drawing.Size(114, 20);
            this.textBoxT1Slope.TabIndex = 1;
            // 
            // labelT1NonLinearCurveLength
            // 
            this.labelT1NonLinearCurveLength.AutoSize = true;
            this.labelT1NonLinearCurveLength.Location = new System.Drawing.Point(233, 98);
            this.labelT1NonLinearCurveLength.Name = "labelT1NonLinearCurveLength";
            this.labelT1NonLinearCurveLength.Size = new System.Drawing.Size(123, 13);
            this.labelT1NonLinearCurveLength.TabIndex = 0;
            this.labelT1NonLinearCurveLength.Text = "NonLinearCurve Length:";
            // 
            // labelT1TransitionType
            // 
            this.labelT1TransitionType.AutoSize = true;
            this.labelT1TransitionType.Location = new System.Drawing.Point(235, 59);
            this.labelT1TransitionType.Name = "labelT1TransitionType";
            this.labelT1TransitionType.Size = new System.Drawing.Size(83, 13);
            this.labelT1TransitionType.TabIndex = 0;
            this.labelT1TransitionType.Text = "Transition Type:";
            // 
            // labelT1SuperPointType
            // 
            this.labelT1SuperPointType.AutoSize = true;
            this.labelT1SuperPointType.Location = new System.Drawing.Point(4, 98);
            this.labelT1SuperPointType.Name = "labelT1SuperPointType";
            this.labelT1SuperPointType.Size = new System.Drawing.Size(89, 13);
            this.labelT1SuperPointType.TabIndex = 0;
            this.labelT1SuperPointType.Text = "SuperPoint Type:";
            // 
            // labelT1Slope
            // 
            this.labelT1Slope.AutoSize = true;
            this.labelT1Slope.Location = new System.Drawing.Point(235, 20);
            this.labelT1Slope.Name = "labelT1Slope";
            this.labelT1Slope.Size = new System.Drawing.Size(37, 13);
            this.labelT1Slope.TabIndex = 0;
            this.labelT1Slope.Text = "Slope:";
            // 
            // labelT1PivotEdgeType
            // 
            this.labelT1PivotEdgeType.AutoSize = true;
            this.labelT1PivotEdgeType.Location = new System.Drawing.Point(6, 59);
            this.labelT1PivotEdgeType.Name = "labelT1PivotEdgeType";
            this.labelT1PivotEdgeType.Size = new System.Drawing.Size(86, 13);
            this.labelT1PivotEdgeType.TabIndex = 0;
            this.labelT1PivotEdgeType.Text = "PivotEdge Type:";
            // 
            // textBoxT1Distance
            // 
            this.textBoxT1Distance.Location = new System.Drawing.Point(99, 16);
            this.textBoxT1Distance.Name = "textBoxT1Distance";
            this.textBoxT1Distance.Size = new System.Drawing.Size(111, 20);
            this.textBoxT1Distance.TabIndex = 1;
            // 
            // labelT1Distance
            // 
            this.labelT1Distance.AutoSize = true;
            this.labelT1Distance.Location = new System.Drawing.Point(6, 20);
            this.labelT1Distance.Name = "labelT1Distance";
            this.labelT1Distance.Size = new System.Drawing.Size(52, 13);
            this.labelT1Distance.TabIndex = 0;
            this.labelT1Distance.Text = "Distance:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.comboBoxT2SuperPointType);
            this.tabPage2.Controls.Add(this.comboBoxT2TransitionType);
            this.tabPage2.Controls.Add(this.comboBoxT2PivotEdgeType);
            this.tabPage2.Controls.Add(this.textBoxT2NonLinearCurveLength);
            this.tabPage2.Controls.Add(this.textBoxT2Slope);
            this.tabPage2.Controls.Add(this.labelT2NonLinearCurveLength);
            this.tabPage2.Controls.Add(this.labelT2TransitionType);
            this.tabPage2.Controls.Add(this.labelT2SuperPointType);
            this.tabPage2.Controls.Add(this.labelT2Slope);
            this.tabPage2.Controls.Add(this.labelT2PivotEdgeType);
            this.tabPage2.Controls.Add(this.textBoxT2Distance);
            this.tabPage2.Controls.Add(this.labelT2Distance);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(491, 134);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Transition2";
            // 
            // comboBoxT2SuperPointType
            // 
            this.comboBoxT2SuperPointType.FormattingEnabled = true;
            this.comboBoxT2SuperPointType.Location = new System.Drawing.Point(99, 94);
            this.comboBoxT2SuperPointType.Name = "comboBoxT2SuperPointType";
            this.comboBoxT2SuperPointType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT2SuperPointType.TabIndex = 12;
            // 
            // comboBoxT2TransitionType
            // 
            this.comboBoxT2TransitionType.FormattingEnabled = true;
            this.comboBoxT2TransitionType.Location = new System.Drawing.Point(364, 55);
            this.comboBoxT2TransitionType.Name = "comboBoxT2TransitionType";
            this.comboBoxT2TransitionType.Size = new System.Drawing.Size(114, 21);
            this.comboBoxT2TransitionType.TabIndex = 13;
            // 
            // comboBoxT2PivotEdgeType
            // 
            this.comboBoxT2PivotEdgeType.FormattingEnabled = true;
            this.comboBoxT2PivotEdgeType.Location = new System.Drawing.Point(99, 55);
            this.comboBoxT2PivotEdgeType.Name = "comboBoxT2PivotEdgeType";
            this.comboBoxT2PivotEdgeType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT2PivotEdgeType.TabIndex = 14;
            // 
            // textBoxT2NonLinearCurveLength
            // 
            this.textBoxT2NonLinearCurveLength.Location = new System.Drawing.Point(364, 94);
            this.textBoxT2NonLinearCurveLength.Name = "textBoxT2NonLinearCurveLength";
            this.textBoxT2NonLinearCurveLength.Size = new System.Drawing.Size(114, 20);
            this.textBoxT2NonLinearCurveLength.TabIndex = 9;
            // 
            // textBoxT2Slope
            // 
            this.textBoxT2Slope.Location = new System.Drawing.Point(364, 16);
            this.textBoxT2Slope.Name = "textBoxT2Slope";
            this.textBoxT2Slope.Size = new System.Drawing.Size(114, 20);
            this.textBoxT2Slope.TabIndex = 10;
            // 
            // labelT2NonLinearCurveLength
            // 
            this.labelT2NonLinearCurveLength.AutoSize = true;
            this.labelT2NonLinearCurveLength.Location = new System.Drawing.Point(233, 98);
            this.labelT2NonLinearCurveLength.Name = "labelT2NonLinearCurveLength";
            this.labelT2NonLinearCurveLength.Size = new System.Drawing.Size(123, 13);
            this.labelT2NonLinearCurveLength.TabIndex = 3;
            this.labelT2NonLinearCurveLength.Text = "NonLinearCurve Length:";
            // 
            // labelT2TransitionType
            // 
            this.labelT2TransitionType.AutoSize = true;
            this.labelT2TransitionType.Location = new System.Drawing.Point(235, 59);
            this.labelT2TransitionType.Name = "labelT2TransitionType";
            this.labelT2TransitionType.Size = new System.Drawing.Size(83, 13);
            this.labelT2TransitionType.TabIndex = 4;
            this.labelT2TransitionType.Text = "Transition Type:";
            // 
            // labelT2SuperPointType
            // 
            this.labelT2SuperPointType.AutoSize = true;
            this.labelT2SuperPointType.Location = new System.Drawing.Point(4, 98);
            this.labelT2SuperPointType.Name = "labelT2SuperPointType";
            this.labelT2SuperPointType.Size = new System.Drawing.Size(89, 13);
            this.labelT2SuperPointType.TabIndex = 5;
            this.labelT2SuperPointType.Text = "SuperPoint Type:";
            // 
            // labelT2Slope
            // 
            this.labelT2Slope.AutoSize = true;
            this.labelT2Slope.Location = new System.Drawing.Point(235, 20);
            this.labelT2Slope.Name = "labelT2Slope";
            this.labelT2Slope.Size = new System.Drawing.Size(37, 13);
            this.labelT2Slope.TabIndex = 6;
            this.labelT2Slope.Text = "Slope:";
            // 
            // labelT2PivotEdgeType
            // 
            this.labelT2PivotEdgeType.AutoSize = true;
            this.labelT2PivotEdgeType.Location = new System.Drawing.Point(6, 59);
            this.labelT2PivotEdgeType.Name = "labelT2PivotEdgeType";
            this.labelT2PivotEdgeType.Size = new System.Drawing.Size(86, 13);
            this.labelT2PivotEdgeType.TabIndex = 7;
            this.labelT2PivotEdgeType.Text = "PivotEdge Type:";
            // 
            // textBoxT2Distance
            // 
            this.textBoxT2Distance.Location = new System.Drawing.Point(99, 16);
            this.textBoxT2Distance.Name = "textBoxT2Distance";
            this.textBoxT2Distance.Size = new System.Drawing.Size(111, 20);
            this.textBoxT2Distance.TabIndex = 11;
            // 
            // labelT2Distance
            // 
            this.labelT2Distance.AutoSize = true;
            this.labelT2Distance.Location = new System.Drawing.Point(6, 20);
            this.labelT2Distance.Name = "labelT2Distance";
            this.labelT2Distance.Size = new System.Drawing.Size(52, 13);
            this.labelT2Distance.TabIndex = 8;
            this.labelT2Distance.Text = "Distance:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.comboBoxT3SuperPointType);
            this.tabPage3.Controls.Add(this.comboBoxT3TransitionType);
            this.tabPage3.Controls.Add(this.comboBoxT3PivotEdgeType);
            this.tabPage3.Controls.Add(this.textBoxT3NonLinearCurveLength);
            this.tabPage3.Controls.Add(this.textBoxT3Slope);
            this.tabPage3.Controls.Add(this.labelT3NonLinearCurveLength);
            this.tabPage3.Controls.Add(this.labelT3TransitionType);
            this.tabPage3.Controls.Add(this.labelT3SuperPointType);
            this.tabPage3.Controls.Add(this.labelT3Slope);
            this.tabPage3.Controls.Add(this.labelT3PivotEdgeType);
            this.tabPage3.Controls.Add(this.textBoxT3Distance);
            this.tabPage3.Controls.Add(this.labelT3Distance);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(491, 134);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Transition3";
            // 
            // comboBoxT3SuperPointType
            // 
            this.comboBoxT3SuperPointType.FormattingEnabled = true;
            this.comboBoxT3SuperPointType.Location = new System.Drawing.Point(99, 94);
            this.comboBoxT3SuperPointType.Name = "comboBoxT3SuperPointType";
            this.comboBoxT3SuperPointType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT3SuperPointType.TabIndex = 24;
            // 
            // comboBoxT3TransitionType
            // 
            this.comboBoxT3TransitionType.FormattingEnabled = true;
            this.comboBoxT3TransitionType.Location = new System.Drawing.Point(364, 55);
            this.comboBoxT3TransitionType.Name = "comboBoxT3TransitionType";
            this.comboBoxT3TransitionType.Size = new System.Drawing.Size(114, 21);
            this.comboBoxT3TransitionType.TabIndex = 25;
            // 
            // comboBoxT3PivotEdgeType
            // 
            this.comboBoxT3PivotEdgeType.FormattingEnabled = true;
            this.comboBoxT3PivotEdgeType.Location = new System.Drawing.Point(99, 55);
            this.comboBoxT3PivotEdgeType.Name = "comboBoxT3PivotEdgeType";
            this.comboBoxT3PivotEdgeType.Size = new System.Drawing.Size(111, 21);
            this.comboBoxT3PivotEdgeType.TabIndex = 26;
            // 
            // textBoxT3NonLinearCurveLength
            // 
            this.textBoxT3NonLinearCurveLength.Location = new System.Drawing.Point(364, 94);
            this.textBoxT3NonLinearCurveLength.Name = "textBoxT3NonLinearCurveLength";
            this.textBoxT3NonLinearCurveLength.Size = new System.Drawing.Size(114, 20);
            this.textBoxT3NonLinearCurveLength.TabIndex = 21;
            // 
            // textBoxT3Slope
            // 
            this.textBoxT3Slope.Location = new System.Drawing.Point(364, 16);
            this.textBoxT3Slope.Name = "textBoxT3Slope";
            this.textBoxT3Slope.Size = new System.Drawing.Size(114, 20);
            this.textBoxT3Slope.TabIndex = 22;
            // 
            // labelT3NonLinearCurveLength
            // 
            this.labelT3NonLinearCurveLength.AutoSize = true;
            this.labelT3NonLinearCurveLength.Location = new System.Drawing.Point(233, 98);
            this.labelT3NonLinearCurveLength.Name = "labelT3NonLinearCurveLength";
            this.labelT3NonLinearCurveLength.Size = new System.Drawing.Size(123, 13);
            this.labelT3NonLinearCurveLength.TabIndex = 15;
            this.labelT3NonLinearCurveLength.Text = "NonLinearCurve Length:";
            // 
            // labelT3TransitionType
            // 
            this.labelT3TransitionType.AutoSize = true;
            this.labelT3TransitionType.Location = new System.Drawing.Point(235, 59);
            this.labelT3TransitionType.Name = "labelT3TransitionType";
            this.labelT3TransitionType.Size = new System.Drawing.Size(83, 13);
            this.labelT3TransitionType.TabIndex = 16;
            this.labelT3TransitionType.Text = "Transition Type:";
            // 
            // labelT3SuperPointType
            // 
            this.labelT3SuperPointType.AutoSize = true;
            this.labelT3SuperPointType.Location = new System.Drawing.Point(4, 98);
            this.labelT3SuperPointType.Name = "labelT3SuperPointType";
            this.labelT3SuperPointType.Size = new System.Drawing.Size(89, 13);
            this.labelT3SuperPointType.TabIndex = 17;
            this.labelT3SuperPointType.Text = "SuperPoint Type:";
            // 
            // labelT3Slope
            // 
            this.labelT3Slope.AutoSize = true;
            this.labelT3Slope.Location = new System.Drawing.Point(235, 20);
            this.labelT3Slope.Name = "labelT3Slope";
            this.labelT3Slope.Size = new System.Drawing.Size(37, 13);
            this.labelT3Slope.TabIndex = 18;
            this.labelT3Slope.Text = "Slope:";
            // 
            // labelT3PivotEdgeType
            // 
            this.labelT3PivotEdgeType.AutoSize = true;
            this.labelT3PivotEdgeType.Location = new System.Drawing.Point(6, 59);
            this.labelT3PivotEdgeType.Name = "labelT3PivotEdgeType";
            this.labelT3PivotEdgeType.Size = new System.Drawing.Size(86, 13);
            this.labelT3PivotEdgeType.TabIndex = 19;
            this.labelT3PivotEdgeType.Text = "PivotEdge Type:";
            // 
            // textBoxT3Distance
            // 
            this.textBoxT3Distance.Location = new System.Drawing.Point(99, 16);
            this.textBoxT3Distance.Name = "textBoxT3Distance";
            this.textBoxT3Distance.Size = new System.Drawing.Size(111, 20);
            this.textBoxT3Distance.TabIndex = 23;
            // 
            // labelT3Distance
            // 
            this.labelT3Distance.AutoSize = true;
            this.labelT3Distance.Location = new System.Drawing.Point(6, 20);
            this.labelT3Distance.Name = "labelT3Distance";
            this.labelT3Distance.Size = new System.Drawing.Size(52, 13);
            this.labelT3Distance.TabIndex = 20;
            this.labelT3Distance.Text = "Distance:";
            // 
            // textBoxInsideEdgeOffset
            // 
            this.textBoxInsideEdgeOffset.Location = new System.Drawing.Point(382, 47);
            this.textBoxInsideEdgeOffset.Name = "textBoxInsideEdgeOffset";
            this.textBoxInsideEdgeOffset.Size = new System.Drawing.Size(100, 20);
            this.textBoxInsideEdgeOffset.TabIndex = 1;
            // 
            // textBoxLaneName
            // 
            this.textBoxLaneName.Location = new System.Drawing.Point(382, 19);
            this.textBoxLaneName.Name = "textBoxLaneName";
            this.textBoxLaneName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLaneName.TabIndex = 1;
            // 
            // textBoxLaneEndDistance
            // 
            this.textBoxLaneEndDistance.Location = new System.Drawing.Point(382, 103);
            this.textBoxLaneEndDistance.Name = "textBoxLaneEndDistance";
            this.textBoxLaneEndDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxLaneEndDistance.TabIndex = 1;
            // 
            // textBoxSlope
            // 
            this.textBoxSlope.Location = new System.Drawing.Point(382, 75);
            this.textBoxSlope.Name = "textBoxSlope";
            this.textBoxSlope.Size = new System.Drawing.Size(100, 20);
            this.textBoxSlope.TabIndex = 1;
            // 
            // textBoxLaneStartDistance
            // 
            this.textBoxLaneStartDistance.Location = new System.Drawing.Point(106, 103);
            this.textBoxLaneStartDistance.Name = "textBoxLaneStartDistance";
            this.textBoxLaneStartDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxLaneStartDistance.TabIndex = 1;
            // 
            // textBoxWidth
            // 
            this.textBoxWidth.Location = new System.Drawing.Point(106, 75);
            this.textBoxWidth.Name = "textBoxWidth";
            this.textBoxWidth.Size = new System.Drawing.Size(100, 20);
            this.textBoxWidth.TabIndex = 1;
            // 
            // labelLaneEndDistance
            // 
            this.labelLaneEndDistance.AutoSize = true;
            this.labelLaneEndDistance.Location = new System.Drawing.Point(274, 107);
            this.labelLaneEndDistance.Name = "labelLaneEndDistance";
            this.labelLaneEndDistance.Size = new System.Drawing.Size(74, 13);
            this.labelLaneEndDistance.TabIndex = 4;
            this.labelLaneEndDistance.Text = "End Distance:";
            // 
            // labelLaneStartDistance
            // 
            this.labelLaneStartDistance.AutoSize = true;
            this.labelLaneStartDistance.Location = new System.Drawing.Point(12, 107);
            this.labelLaneStartDistance.Name = "labelLaneStartDistance";
            this.labelLaneStartDistance.Size = new System.Drawing.Size(77, 13);
            this.labelLaneStartDistance.TabIndex = 4;
            this.labelLaneStartDistance.Text = "Start Distance:";
            // 
            // labelSlope
            // 
            this.labelSlope.AutoSize = true;
            this.labelSlope.Location = new System.Drawing.Point(274, 79);
            this.labelSlope.Name = "labelSlope";
            this.labelSlope.Size = new System.Drawing.Size(37, 13);
            this.labelSlope.TabIndex = 3;
            this.labelSlope.Text = "Slope:";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(12, 79);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(38, 13);
            this.labelWidth.TabIndex = 4;
            this.labelWidth.Text = "Width:";
            // 
            // labelInsideEdgeOffset
            // 
            this.labelInsideEdgeOffset.AutoSize = true;
            this.labelInsideEdgeOffset.Location = new System.Drawing.Point(274, 51);
            this.labelInsideEdgeOffset.Name = "labelInsideEdgeOffset";
            this.labelInsideEdgeOffset.Size = new System.Drawing.Size(97, 13);
            this.labelInsideEdgeOffset.TabIndex = 3;
            this.labelInsideEdgeOffset.Text = "Inside Edge Offset:";
            // 
            // labelSide
            // 
            this.labelSide.AutoSize = true;
            this.labelSide.Location = new System.Drawing.Point(12, 51);
            this.labelSide.Name = "labelSide";
            this.labelSide.Size = new System.Drawing.Size(31, 13);
            this.labelSide.TabIndex = 2;
            this.labelSide.Text = "Side:";
            // 
            // labelLaneName
            // 
            this.labelLaneName.AutoSize = true;
            this.labelLaneName.Location = new System.Drawing.Point(274, 23);
            this.labelLaneName.Name = "labelLaneName";
            this.labelLaneName.Size = new System.Drawing.Size(65, 13);
            this.labelLaneName.TabIndex = 1;
            this.labelLaneName.Text = "Lane Name:";
            // 
            // labelSuperElevationType
            // 
            this.labelSuperElevationType.AutoSize = true;
            this.labelSuperElevationType.Location = new System.Drawing.Point(12, 23);
            this.labelSuperElevationType.Name = "labelSuperElevationType";
            this.labelSuperElevationType.Size = new System.Drawing.Size(34, 13);
            this.labelSuperElevationType.TabIndex = 0;
            this.labelSuperElevationType.Text = "Type:";
            // 
            // textBoxEndDistance
            // 
            this.textBoxEndDistance.Location = new System.Drawing.Point(382, 51);
            this.textBoxEndDistance.Name = "textBoxEndDistance";
            this.textBoxEndDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxEndDistance.TabIndex = 1;
            // 
            // textBoxStartDistance
            // 
            this.textBoxStartDistance.Location = new System.Drawing.Point(106, 51);
            this.textBoxStartDistance.Name = "textBoxStartDistance";
            this.textBoxStartDistance.Size = new System.Drawing.Size(100, 20);
            this.textBoxStartDistance.TabIndex = 1;
            // 
            // textBoxSectionName
            // 
            this.textBoxSectionName.Location = new System.Drawing.Point(106, 20);
            this.textBoxSectionName.Name = "textBoxSectionName";
            this.textBoxSectionName.Size = new System.Drawing.Size(100, 20);
            this.textBoxSectionName.TabIndex = 1;
            // 
            // labelEndDistance
            // 
            this.labelEndDistance.AutoSize = true;
            this.labelEndDistance.Location = new System.Drawing.Point(273, 55);
            this.labelEndDistance.Name = "labelEndDistance";
            this.labelEndDistance.Size = new System.Drawing.Size(74, 13);
            this.labelEndDistance.TabIndex = 0;
            this.labelEndDistance.Text = "End Distance:";
            // 
            // labelStartDistance
            // 
            this.labelStartDistance.AutoSize = true;
            this.labelStartDistance.Location = new System.Drawing.Point(9, 55);
            this.labelStartDistance.Name = "labelStartDistance";
            this.labelStartDistance.Size = new System.Drawing.Size(77, 13);
            this.labelStartDistance.TabIndex = 0;
            this.labelStartDistance.Text = "Start Distance:";
            // 
            // labelFeatureName
            // 
            this.labelFeatureName.AutoSize = true;
            this.labelFeatureName.Location = new System.Drawing.Point(273, 24);
            this.labelFeatureName.Name = "labelFeatureName";
            this.labelFeatureName.Size = new System.Drawing.Size(77, 13);
            this.labelFeatureName.TabIndex = 0;
            this.labelFeatureName.Text = "Feature Name:";
            // 
            // labelSectionName
            // 
            this.labelSectionName.AutoSize = true;
            this.labelSectionName.Location = new System.Drawing.Point(9, 24);
            this.labelSectionName.Name = "labelSectionName";
            this.labelSectionName.Size = new System.Drawing.Size(77, 13);
            this.labelSectionName.TabIndex = 0;
            this.labelSectionName.Text = "Section Name:";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(278, 426);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(421, 426);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // SuperElevationPlaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 454);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Name = "SuperElevationPlaceForm";
            this.Text = "SuperElevation Place ";
            this.Load += new System.EventHandler(this.SuperElevationPlaceForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSectionName;
        private System.Windows.Forms.Label labelSectionName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxInsideEdgeOffset;
        private System.Windows.Forms.TextBox textBoxLaneName;
        private System.Windows.Forms.TextBox textBoxLaneEndDistance;
        private System.Windows.Forms.TextBox textBoxSlope;
        private System.Windows.Forms.TextBox textBoxLaneStartDistance;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.Label labelLaneEndDistance;
        private System.Windows.Forms.Label labelLaneStartDistance;
        private System.Windows.Forms.Label labelSlope;
        private System.Windows.Forms.Label labelWidth;
        private System.Windows.Forms.Label labelInsideEdgeOffset;
        private System.Windows.Forms.Label labelSide;
        private System.Windows.Forms.Label labelLaneName;
        private System.Windows.Forms.Label labelSuperElevationType;
        private System.Windows.Forms.TextBox textBoxEndDistance;
        private System.Windows.Forms.TextBox textBoxStartDistance;
        private System.Windows.Forms.Label labelEndDistance;
        private System.Windows.Forms.Label labelStartDistance;
        private System.Windows.Forms.Label labelFeatureName;
        private System.Windows.Forms.TextBox textBoxT1Slope;
        private System.Windows.Forms.Label labelT1NonLinearCurveLength;
        private System.Windows.Forms.Label labelT1TransitionType;
        private System.Windows.Forms.Label labelT1SuperPointType;
        private System.Windows.Forms.Label labelT1Slope;
        private System.Windows.Forms.Label labelT1PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT1Distance;
        private System.Windows.Forms.Label labelT1Distance;
        private System.Windows.Forms.ComboBox FeatureDef;
        private System.Windows.Forms.ComboBox comboBoxSide;
        private System.Windows.Forms.ComboBox comboBoxSuperElevationType;
        private System.Windows.Forms.ComboBox comboBoxT1SuperPointType;
        private System.Windows.Forms.ComboBox comboBoxT1TransitionType;
        private System.Windows.Forms.ComboBox comboBoxT1PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT1NonLinearCurveLength;
        private System.Windows.Forms.ComboBox comboBoxT2SuperPointType;
        private System.Windows.Forms.ComboBox comboBoxT2TransitionType;
        private System.Windows.Forms.ComboBox comboBoxT2PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT2NonLinearCurveLength;
        private System.Windows.Forms.TextBox textBoxT2Slope;
        private System.Windows.Forms.Label labelT2NonLinearCurveLength;
        private System.Windows.Forms.Label labelT2TransitionType;
        private System.Windows.Forms.Label labelT2SuperPointType;
        private System.Windows.Forms.Label labelT2Slope;
        private System.Windows.Forms.Label labelT2PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT2Distance;
        private System.Windows.Forms.Label labelT2Distance;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox comboBoxT3SuperPointType;
        private System.Windows.Forms.ComboBox comboBoxT3TransitionType;
        private System.Windows.Forms.ComboBox comboBoxT3PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT3NonLinearCurveLength;
        private System.Windows.Forms.TextBox textBoxT3Slope;
        private System.Windows.Forms.Label labelT3NonLinearCurveLength;
        private System.Windows.Forms.Label labelT3TransitionType;
        private System.Windows.Forms.Label labelT3SuperPointType;
        private System.Windows.Forms.Label labelT3Slope;
        private System.Windows.Forms.Label labelT3PivotEdgeType;
        private System.Windows.Forms.TextBox textBoxT3Distance;
        private System.Windows.Forms.Label labelT3Distance;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        }
    }