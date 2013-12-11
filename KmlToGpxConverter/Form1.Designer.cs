namespace KmlToGpxConverter
{
    partial class Form1
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
            this.checkBoxStripElevationData = new System.Windows.Forms.CheckBox();
            this.numericUpDownElevationAdjustment = new System.Windows.Forms.NumericUpDown();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownElevationAdjustment)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.checkBoxStripElevationData);
            this.groupBox1.Controls.Add(this.numericUpDownElevationAdjustment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elevation adjustment";
            // 
            // checkBoxStripElevationData
            // 
            this.checkBoxStripElevationData.AutoSize = true;
            this.checkBoxStripElevationData.Checked = global::KmlToGpxConverter.Properties.Settings.Default.StripElevationData;
            this.checkBoxStripElevationData.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::KmlToGpxConverter.Properties.Settings.Default, "StripElevationData", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.checkBoxStripElevationData.Location = new System.Drawing.Point(7, 46);
            this.checkBoxStripElevationData.Name = "checkBoxStripElevationData";
            this.checkBoxStripElevationData.Size = new System.Drawing.Size(117, 17);
            this.checkBoxStripElevationData.TabIndex = 1;
            this.checkBoxStripElevationData.Text = "Strip elevation data";
            this.checkBoxStripElevationData.UseVisualStyleBackColor = true;
            this.checkBoxStripElevationData.CheckedChanged += new System.EventHandler(this.checkBoxStripElevationData_CheckedChanged);
            // 
            // numericUpDownElevationAdjustment
            // 
            this.numericUpDownElevationAdjustment.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::KmlToGpxConverter.Properties.Settings.Default, "ElevationAdjustment", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.numericUpDownElevationAdjustment.DecimalPlaces = 2;
            this.numericUpDownElevationAdjustment.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownElevationAdjustment.Location = new System.Drawing.Point(6, 19);
            this.numericUpDownElevationAdjustment.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownElevationAdjustment.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericUpDownElevationAdjustment.Name = "numericUpDownElevationAdjustment";
            this.numericUpDownElevationAdjustment.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownElevationAdjustment.TabIndex = 0;
            this.numericUpDownElevationAdjustment.Value = global::KmlToGpxConverter.Properties.Settings.Default.ElevationAdjustment;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 97);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(304, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(157, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 72);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Drop files here...";
            this.groupBox2.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragDrop);
            this.groupBox2.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragEnter);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 119);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBox2_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownElevationAdjustment)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericUpDownElevationAdjustment;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxStripElevationData;

    }
}

