namespace MouseShaker
{
    partial class MouseShakerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelWindow;
            System.Windows.Forms.GroupBox groupBoxConfig;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanelConfig;
            System.Windows.Forms.Label labelHotKey;
            System.Windows.Forms.Label labelFramerate;
            System.Windows.Forms.Label labelOffset;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            _numericUpDownFramerate = new System.Windows.Forms.NumericUpDown();
            _comboBoxHotKey = new System.Windows.Forms.ComboBox();
            _numericUpDownOffsetX = new System.Windows.Forms.NumericUpDown();
            _numericUpDownOffsetY = new System.Windows.Forms.NumericUpDown();
            _labelStatus = new System.Windows.Forms.Label();
            tableLayoutPanelWindow = new System.Windows.Forms.TableLayoutPanel();
            groupBoxConfig = new System.Windows.Forms.GroupBox();
            tableLayoutPanelConfig = new System.Windows.Forms.TableLayoutPanel();
            labelHotKey = new System.Windows.Forms.Label();
            labelFramerate = new System.Windows.Forms.Label();
            labelOffset = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            tableLayoutPanelWindow.SuspendLayout();
            groupBoxConfig.SuspendLayout();
            tableLayoutPanelConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownFramerate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownOffsetX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownOffsetY).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanelWindow
            // 
            tableLayoutPanelWindow.AutoSize = true;
            tableLayoutPanelWindow.ColumnCount = 1;
            tableLayoutPanelWindow.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelWindow.Controls.Add(groupBoxConfig, 0, 1);
            tableLayoutPanelWindow.Controls.Add(_labelStatus, 0, 0);
            tableLayoutPanelWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelWindow.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanelWindow.Name = "tableLayoutPanelWindow";
            tableLayoutPanelWindow.RowCount = 2;
            tableLayoutPanelWindow.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanelWindow.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelWindow.Size = new System.Drawing.Size(264, 209);
            tableLayoutPanelWindow.TabIndex = 0;
            // 
            // groupBoxConfig
            // 
            groupBoxConfig.AutoSize = true;
            groupBoxConfig.Controls.Add(tableLayoutPanelConfig);
            groupBoxConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBoxConfig.Location = new System.Drawing.Point(3, 97);
            groupBoxConfig.Name = "groupBoxConfig";
            groupBoxConfig.Size = new System.Drawing.Size(258, 109);
            groupBoxConfig.TabIndex = 2;
            groupBoxConfig.TabStop = false;
            groupBoxConfig.Text = "Config";
            // 
            // tableLayoutPanelConfig
            // 
            tableLayoutPanelConfig.AutoSize = true;
            tableLayoutPanelConfig.ColumnCount = 5;
            tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            tableLayoutPanelConfig.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanelConfig.Controls.Add(labelHotKey, 0, 0);
            tableLayoutPanelConfig.Controls.Add(labelFramerate, 0, 1);
            tableLayoutPanelConfig.Controls.Add(_numericUpDownFramerate, 1, 1);
            tableLayoutPanelConfig.Controls.Add(_comboBoxHotKey, 1, 0);
            tableLayoutPanelConfig.Controls.Add(labelOffset, 0, 2);
            tableLayoutPanelConfig.Controls.Add(label1, 1, 2);
            tableLayoutPanelConfig.Controls.Add(label2, 3, 2);
            tableLayoutPanelConfig.Controls.Add(_numericUpDownOffsetX, 2, 2);
            tableLayoutPanelConfig.Controls.Add(_numericUpDownOffsetY, 4, 2);
            tableLayoutPanelConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanelConfig.Location = new System.Drawing.Point(3, 19);
            tableLayoutPanelConfig.Name = "tableLayoutPanelConfig";
            tableLayoutPanelConfig.RowCount = 3;
            tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle());
            tableLayoutPanelConfig.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tableLayoutPanelConfig.Size = new System.Drawing.Size(252, 87);
            tableLayoutPanelConfig.TabIndex = 3;
            // 
            // labelHotKey
            // 
            labelHotKey.AutoSize = true;
            labelHotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            labelHotKey.Location = new System.Drawing.Point(3, 0);
            labelHotKey.Name = "labelHotKey";
            labelHotKey.Size = new System.Drawing.Size(58, 29);
            labelHotKey.TabIndex = 4;
            labelHotKey.Text = "Hot Key";
            labelHotKey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelFramerate
            // 
            labelFramerate.AutoSize = true;
            labelFramerate.Dock = System.Windows.Forms.DockStyle.Fill;
            labelFramerate.Location = new System.Drawing.Point(3, 29);
            labelFramerate.Name = "labelFramerate";
            labelFramerate.Size = new System.Drawing.Size(58, 29);
            labelFramerate.TabIndex = 6;
            labelFramerate.Text = "Framerate";
            labelFramerate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _numericUpDownFramerate
            // 
            tableLayoutPanelConfig.SetColumnSpan(_numericUpDownFramerate, 2);
            _numericUpDownFramerate.Dock = System.Windows.Forms.DockStyle.Fill;
            _numericUpDownFramerate.Location = new System.Drawing.Point(67, 32);
            _numericUpDownFramerate.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            _numericUpDownFramerate.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            _numericUpDownFramerate.Name = "_numericUpDownFramerate";
            _numericUpDownFramerate.Size = new System.Drawing.Size(88, 23);
            _numericUpDownFramerate.TabIndex = 7;
            _numericUpDownFramerate.Value = new decimal(new int[] { 60, 0, 0, 0 });
            // 
            // _comboBoxHotKey
            // 
            tableLayoutPanelConfig.SetColumnSpan(_comboBoxHotKey, 2);
            _comboBoxHotKey.Dock = System.Windows.Forms.DockStyle.Fill;
            _comboBoxHotKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            _comboBoxHotKey.FormattingEnabled = true;
            _comboBoxHotKey.Items.AddRange(new object[] { "F2", "F3", "F4", "F5", "F6", "F7", "F8", "F9", "F10", "F11", "F12" });
            _comboBoxHotKey.Location = new System.Drawing.Point(67, 3);
            _comboBoxHotKey.Name = "_comboBoxHotKey";
            _comboBoxHotKey.Size = new System.Drawing.Size(88, 23);
            _comboBoxHotKey.TabIndex = 5;
            _comboBoxHotKey.SelectedIndexChanged += ComboBoxHotKey_SelectedIndexChanged;
            // 
            // labelOffset
            // 
            labelOffset.AutoSize = true;
            labelOffset.Dock = System.Windows.Forms.DockStyle.Fill;
            labelOffset.Location = new System.Drawing.Point(3, 58);
            labelOffset.Name = "labelOffset";
            labelOffset.Size = new System.Drawing.Size(58, 29);
            labelOffset.TabIndex = 8;
            labelOffset.Text = "Offset";
            labelOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Location = new System.Drawing.Point(67, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(17, 29);
            label1.TabIndex = 9;
            label1.Text = "X:";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Location = new System.Drawing.Point(161, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(16, 29);
            label2.TabIndex = 10;
            label2.Text = "Y:";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _numericUpDownOffsetX
            // 
            _numericUpDownOffsetX.Location = new System.Drawing.Point(90, 61);
            _numericUpDownOffsetX.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _numericUpDownOffsetX.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            _numericUpDownOffsetX.Name = "_numericUpDownOffsetX";
            _numericUpDownOffsetX.Size = new System.Drawing.Size(65, 23);
            _numericUpDownOffsetX.TabIndex = 11;
            // 
            // _numericUpDownOffsetY
            // 
            _numericUpDownOffsetY.Location = new System.Drawing.Point(183, 61);
            _numericUpDownOffsetY.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            _numericUpDownOffsetY.Minimum = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            _numericUpDownOffsetY.Name = "_numericUpDownOffsetY";
            _numericUpDownOffsetY.Size = new System.Drawing.Size(66, 23);
            _numericUpDownOffsetY.TabIndex = 12;
            _numericUpDownOffsetY.Value = new decimal(new int[] { 1000, 0, 0, int.MinValue });
            // 
            // _labelStatus
            // 
            _labelStatus.AutoSize = true;
            _labelStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            _labelStatus.Font = new System.Drawing.Font("Yu Gothic UI", 36F);
            _labelStatus.Location = new System.Drawing.Point(3, 0);
            _labelStatus.Name = "_labelStatus";
            _labelStatus.Size = new System.Drawing.Size(258, 94);
            _labelStatus.TabIndex = 1;
            _labelStatus.Text = "Inactive";
            _labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MouseShakerForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(264, 209);
            Controls.Add(tableLayoutPanelWindow);
            Name = "MouseShakerForm";
            Text = "MouseShaker: Inactive";
            FormClosing += BurstClickForm_FormClosing;
            Load += BurstClickForm_Load;
            tableLayoutPanelWindow.ResumeLayout(false);
            tableLayoutPanelWindow.PerformLayout();
            groupBoxConfig.ResumeLayout(false);
            groupBoxConfig.PerformLayout();
            tableLayoutPanelConfig.ResumeLayout(false);
            tableLayoutPanelConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownFramerate).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownOffsetX).EndInit();
            ((System.ComponentModel.ISupportInitialize)_numericUpDownOffsetY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.NumericUpDown _numericUpDownFramerate;
        private System.Windows.Forms.ComboBox _comboBoxHotKey;
        private System.Windows.Forms.Label _labelStatus;
        private System.Windows.Forms.NumericUpDown _numericUpDownOffsetX;
        private System.Windows.Forms.NumericUpDown _numericUpDownOffsetY;
    }
}
