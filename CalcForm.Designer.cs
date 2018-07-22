namespace LesGraphingCalc
{
    partial class CalcForm
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
            if (disposing && (components != null)) {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalcForm));
            this.lblFormula = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVariables = new System.Windows.Forms.Label();
            this.lblResultLbl = new System.Windows.Forms.Label();
            this.cbFormulas = new System.Windows.Forms.ComboBox();
            this.cbRanges = new System.Windows.Forms.ComboBox();
            this.cbVariables = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMouseOver = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.panelError = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtError = new System.Windows.Forms.TextBox();
            this.graphPanel = new System.Windows.Forms.PictureBox();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panelError.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormula
            // 
            this.lblFormula.AutoSize = true;
            this.lblFormula.Location = new System.Drawing.Point(7, 12);
            this.lblFormula.Name = "lblFormula";
            this.lblFormula.Size = new System.Drawing.Size(44, 13);
            this.lblFormula.TabIndex = 0;
            this.lblFormula.Text = "&Formula";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "&Ranges";
            // 
            // lblVariables
            // 
            this.lblVariables.AutoSize = true;
            this.lblVariables.Location = new System.Drawing.Point(7, 41);
            this.lblVariables.Name = "lblVariables";
            this.lblVariables.Size = new System.Drawing.Size(50, 13);
            this.lblVariables.TabIndex = 2;
            this.lblVariables.Text = "&Variables";
            // 
            // lblResultLbl
            // 
            this.lblResultLbl.AutoSize = true;
            this.lblResultLbl.Location = new System.Drawing.Point(7, 99);
            this.lblResultLbl.Name = "lblResultLbl";
            this.lblResultLbl.Size = new System.Drawing.Size(40, 13);
            this.lblResultLbl.TabIndex = 4;
            this.lblResultLbl.Text = "Result:";
            // 
            // cbFormulas
            // 
            this.cbFormulas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFormulas.DropDownHeight = 280;
            this.cbFormulas.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormulas.FormattingEnabled = true;
            this.cbFormulas.IntegralHeight = false;
            this.cbFormulas.Location = new System.Drawing.Point(63, 4);
            this.cbFormulas.Name = "cbFormulas";
            this.cbFormulas.Size = new System.Drawing.Size(385, 26);
            this.cbFormulas.TabIndex = 1;
            // 
            // cbRanges
            // 
            this.cbRanges.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbRanges.DropDownHeight = 200;
            this.cbRanges.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRanges.FormattingEnabled = true;
            this.cbRanges.IntegralHeight = false;
            this.cbRanges.ItemHeight = 18;
            this.cbRanges.Location = new System.Drawing.Point(63, 63);
            this.cbRanges.Name = "cbRanges";
            this.cbRanges.Size = new System.Drawing.Size(385, 26);
            this.cbRanges.TabIndex = 7;
            // 
            // cbVariables
            // 
            this.cbVariables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVariables.DropDownHeight = 280;
            this.cbVariables.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVariables.FormattingEnabled = true;
            this.cbVariables.IntegralHeight = false;
            this.cbVariables.Location = new System.Drawing.Point(63, 33);
            this.cbVariables.Name = "cbVariables";
            this.cbVariables.Size = new System.Drawing.Size(385, 26);
            this.cbVariables.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMouseOver);
            this.panel1.Controls.Add(this.cbRanges);
            this.panel1.Controls.Add(this.lblFormula);
            this.panel1.Controls.Add(this.lblVariables);
            this.panel1.Controls.Add(this.lblResultLbl);
            this.panel1.Controls.Add(this.cbVariables);
            this.panel1.Controls.Add(this.cbFormulas);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 122);
            this.panel1.TabIndex = 7;
            // 
            // lblMouseOver
            // 
            this.lblMouseOver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMouseOver.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMouseOver.Location = new System.Drawing.Point(68, 95);
            this.lblMouseOver.Name = "lblMouseOver";
            this.lblMouseOver.Size = new System.Drawing.Size(375, 20);
            this.lblMouseOver.TabIndex = 5;
            this.lblMouseOver.Text = "1.23456789 @ X=1.23456789";
            this.lblMouseOver.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblMouseOver.Visible = false;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(63, 91);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(385, 27);
            this.txtResult.TabIndex = 8;
            // 
            // panelError
            // 
            this.panelError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelError.Controls.Add(this.pictureBox1);
            this.panelError.Controls.Add(this.txtError);
            this.panelError.Location = new System.Drawing.Point(10, 132);
            this.panelError.Name = "panelError";
            this.panelError.Size = new System.Drawing.Size(432, 61);
            this.panelError.TabIndex = 8;
            this.panelError.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LesGraphingCalc.Properties.Resources.error;
            this.pictureBox1.Location = new System.Drawing.Point(4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtError
            // 
            this.txtError.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtError.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtError.Location = new System.Drawing.Point(37, 0);
            this.txtError.Multiline = true;
            this.txtError.Name = "txtError";
            this.txtError.ReadOnly = true;
            this.txtError.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtError.Size = new System.Drawing.Size(393, 60);
            this.txtError.TabIndex = 0;
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.graphPanel.Location = new System.Drawing.Point(0, 121);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(454, 332);
            this.graphPanel.TabIndex = 9;
            this.graphPanel.TabStop = false;
            this.graphPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPanel_MouseDown);
            this.graphPanel.MouseLeave += new System.EventHandler(this.picPanel_MouseLeave);
            this.graphPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picPanel_MouseMove);
            this.graphPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPanel_MouseUp);
            this.graphPanel.Resize += new System.EventHandler(this.picPanel_Resize);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.AccessibleDescription = "Zoom out";
            this.btnZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomOut.Image")));
            this.btnZoomOut.Location = new System.Drawing.Point(373, 122);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(37, 37);
            this.btnZoomOut.TabIndex = 9;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.AccessibleDescription = "Zoom in";
            this.btnZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("btnZoomIn.Image")));
            this.btnZoomIn.Location = new System.Drawing.Point(337, 122);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(37, 37);
            this.btnZoomIn.TabIndex = 8;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleDescription = "Copy to clipboard";
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.Location = new System.Drawing.Point(409, 122);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(37, 37);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // CalcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 453);
            this.Controls.Add(this.panelError);
            this.Controls.Add(this.btnZoomIn);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnZoomOut);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CalcForm";
            this.Text = " Graphing Calculator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalcForm_FormClosed);
            this.Load += new System.EventHandler(this.CalcForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelError.ResumeLayout(false);
            this.panelError.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblFormula;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVariables;
        private System.Windows.Forms.Label lblResultLbl;
        private System.Windows.Forms.ComboBox cbFormulas;
        private System.Windows.Forms.ComboBox cbRanges;
        private System.Windows.Forms.ComboBox cbVariables;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelError;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.PictureBox graphPanel;
        private System.Windows.Forms.Label lblMouseOver;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnCopy;
		private System.Windows.Forms.TextBox txtResult;
	}
}

