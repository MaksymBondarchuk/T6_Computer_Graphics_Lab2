namespace Bezier
{
    partial class MainForm
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
            this.pbox = new System.Windows.Forms.PictureBox();
            this.bDraw = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bClear = new System.Windows.Forms.Button();
            this.bRotate = new System.Windows.Forms.Button();
            this.lA = new System.Windows.Forms.Label();
            this.tA = new System.Windows.Forms.TextBox();
            this.lAgrads = new System.Windows.Forms.Label();
            this.tAgrads = new System.Windows.Forms.TextBox();
            this.cboxRotateCurve = new System.Windows.Forms.CheckBox();
            this.bZoom = new System.Windows.Forms.Button();
            this.cboxZoomCurve = new System.Windows.Forms.CheckBox();
            this.lYZoom = new System.Windows.Forms.Label();
            this.tYZoom = new System.Windows.Forms.TextBox();
            this.lXZoom = new System.Windows.Forms.Label();
            this.tXZoom = new System.Windows.Forms.TextBox();
            this.bMove = new System.Windows.Forms.Button();
            this.cboxMoveCurve = new System.Windows.Forms.CheckBox();
            this.lDY = new System.Windows.Forms.Label();
            this.tDY = new System.Windows.Forms.TextBox();
            this.lDX = new System.Windows.Forms.Label();
            this.tDX = new System.Windows.Forms.TextBox();
            this.cbox4 = new System.Windows.Forms.CheckBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.SuspendLayout();
            // 
            // pbox
            // 
            this.pbox.BackColor = System.Drawing.Color.Gainsboro;
            this.pbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbox.Location = new System.Drawing.Point(2, 2);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(1000, 400);
            this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbox.TabIndex = 0;
            this.pbox.TabStop = false;
            this.pbox.Click += new System.EventHandler(this.pbox_Click);
            this.pbox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbox_MouseMove);
            // 
            // bDraw
            // 
            this.bDraw.Enabled = false;
            this.bDraw.Location = new System.Drawing.Point(810, 408);
            this.bDraw.Name = "bDraw";
            this.bDraw.Size = new System.Drawing.Size(75, 52);
            this.bDraw.TabIndex = 1;
            this.bDraw.Text = "Draw";
            this.bDraw.UseVisualStyleBackColor = true;
            this.bDraw.Click += new System.EventHandler(this.bDraw_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(927, 408);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 2;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bClear
            // 
            this.bClear.Location = new System.Drawing.Point(927, 437);
            this.bClear.Name = "bClear";
            this.bClear.Size = new System.Drawing.Size(75, 23);
            this.bClear.TabIndex = 3;
            this.bClear.Text = "Clear";
            this.bClear.UseVisualStyleBackColor = true;
            this.bClear.Click += new System.EventHandler(this.bClear_Click);
            // 
            // bRotate
            // 
            this.bRotate.Enabled = false;
            this.bRotate.Location = new System.Drawing.Point(12, 408);
            this.bRotate.Name = "bRotate";
            this.bRotate.Size = new System.Drawing.Size(75, 23);
            this.bRotate.TabIndex = 4;
            this.bRotate.Text = "Rotate";
            this.bRotate.UseVisualStyleBackColor = true;
            this.bRotate.Click += new System.EventHandler(this.bRotate_Click);
            // 
            // lA
            // 
            this.lA.AutoSize = true;
            this.lA.Enabled = false;
            this.lA.Location = new System.Drawing.Point(118, 440);
            this.lA.Name = "lA";
            this.lA.Size = new System.Drawing.Size(63, 13);
            this.lA.TabIndex = 10;
            this.lA.Text = "Angle (rads)";
            // 
            // tA
            // 
            this.tA.Enabled = false;
            this.tA.Location = new System.Drawing.Point(12, 437);
            this.tA.Name = "tA";
            this.tA.Size = new System.Drawing.Size(100, 20);
            this.tA.TabIndex = 9;
            // 
            // lAgrads
            // 
            this.lAgrads.AutoSize = true;
            this.lAgrads.Enabled = false;
            this.lAgrads.Location = new System.Drawing.Point(118, 466);
            this.lAgrads.Name = "lAgrads";
            this.lAgrads.Size = new System.Drawing.Size(69, 13);
            this.lAgrads.TabIndex = 12;
            this.lAgrads.Text = "Angle (grads)";
            // 
            // tAgrads
            // 
            this.tAgrads.Enabled = false;
            this.tAgrads.Location = new System.Drawing.Point(12, 463);
            this.tAgrads.Name = "tAgrads";
            this.tAgrads.Size = new System.Drawing.Size(100, 20);
            this.tAgrads.TabIndex = 11;
            // 
            // cboxRotateCurve
            // 
            this.cboxRotateCurve.AutoSize = true;
            this.cboxRotateCurve.Enabled = false;
            this.cboxRotateCurve.Location = new System.Drawing.Point(12, 489);
            this.cboxRotateCurve.Name = "cboxRotateCurve";
            this.cboxRotateCurve.Size = new System.Drawing.Size(119, 17);
            this.cboxRotateCurve.TabIndex = 13;
            this.cboxRotateCurve.Text = "Rotate whole curve";
            this.cboxRotateCurve.UseVisualStyleBackColor = true;
            // 
            // bZoom
            // 
            this.bZoom.Enabled = false;
            this.bZoom.Location = new System.Drawing.Point(248, 408);
            this.bZoom.Name = "bZoom";
            this.bZoom.Size = new System.Drawing.Size(75, 23);
            this.bZoom.TabIndex = 14;
            this.bZoom.Text = "Zoom";
            this.bZoom.UseVisualStyleBackColor = true;
            this.bZoom.Click += new System.EventHandler(this.bZoom_Click);
            // 
            // cboxZoomCurve
            // 
            this.cboxZoomCurve.AutoSize = true;
            this.cboxZoomCurve.Enabled = false;
            this.cboxZoomCurve.Location = new System.Drawing.Point(248, 489);
            this.cboxZoomCurve.Name = "cboxZoomCurve";
            this.cboxZoomCurve.Size = new System.Drawing.Size(114, 17);
            this.cboxZoomCurve.TabIndex = 19;
            this.cboxZoomCurve.Text = "Zoom whole curve";
            this.cboxZoomCurve.UseVisualStyleBackColor = true;
            // 
            // lYZoom
            // 
            this.lYZoom.AutoSize = true;
            this.lYZoom.Enabled = false;
            this.lYZoom.Location = new System.Drawing.Point(354, 466);
            this.lYZoom.Name = "lYZoom";
            this.lYZoom.Size = new System.Drawing.Size(44, 13);
            this.lYZoom.TabIndex = 18;
            this.lYZoom.Text = "Y-Zoom";
            // 
            // tYZoom
            // 
            this.tYZoom.Enabled = false;
            this.tYZoom.Location = new System.Drawing.Point(248, 463);
            this.tYZoom.Name = "tYZoom";
            this.tYZoom.Size = new System.Drawing.Size(100, 20);
            this.tYZoom.TabIndex = 17;
            // 
            // lXZoom
            // 
            this.lXZoom.AutoSize = true;
            this.lXZoom.Enabled = false;
            this.lXZoom.Location = new System.Drawing.Point(354, 440);
            this.lXZoom.Name = "lXZoom";
            this.lXZoom.Size = new System.Drawing.Size(44, 13);
            this.lXZoom.TabIndex = 16;
            this.lXZoom.Text = "X-Zoom";
            // 
            // tXZoom
            // 
            this.tXZoom.Enabled = false;
            this.tXZoom.Location = new System.Drawing.Point(248, 437);
            this.tXZoom.Name = "tXZoom";
            this.tXZoom.Size = new System.Drawing.Size(100, 20);
            this.tXZoom.TabIndex = 15;
            // 
            // bMove
            // 
            this.bMove.Enabled = false;
            this.bMove.Location = new System.Drawing.Point(446, 408);
            this.bMove.Name = "bMove";
            this.bMove.Size = new System.Drawing.Size(75, 23);
            this.bMove.TabIndex = 20;
            this.bMove.Text = "Move";
            this.bMove.UseVisualStyleBackColor = true;
            this.bMove.Click += new System.EventHandler(this.bMove_Click);
            // 
            // cboxMoveCurve
            // 
            this.cboxMoveCurve.AutoSize = true;
            this.cboxMoveCurve.Enabled = false;
            this.cboxMoveCurve.Location = new System.Drawing.Point(446, 489);
            this.cboxMoveCurve.Name = "cboxMoveCurve";
            this.cboxMoveCurve.Size = new System.Drawing.Size(114, 17);
            this.cboxMoveCurve.TabIndex = 21;
            this.cboxMoveCurve.Text = "Move whole curve";
            this.cboxMoveCurve.UseVisualStyleBackColor = true;
            // 
            // lDY
            // 
            this.lDY.AutoSize = true;
            this.lDY.Enabled = false;
            this.lDY.Location = new System.Drawing.Point(552, 466);
            this.lDY.Name = "lDY";
            this.lDY.Size = new System.Drawing.Size(18, 13);
            this.lDY.TabIndex = 25;
            this.lDY.Text = "dy";
            // 
            // tDY
            // 
            this.tDY.Enabled = false;
            this.tDY.Location = new System.Drawing.Point(446, 463);
            this.tDY.Name = "tDY";
            this.tDY.Size = new System.Drawing.Size(100, 20);
            this.tDY.TabIndex = 24;
            // 
            // lDX
            // 
            this.lDX.AutoSize = true;
            this.lDX.Enabled = false;
            this.lDX.Location = new System.Drawing.Point(552, 440);
            this.lDX.Name = "lDX";
            this.lDX.Size = new System.Drawing.Size(18, 13);
            this.lDX.TabIndex = 23;
            this.lDX.Text = "dx";
            // 
            // tDX
            // 
            this.tDX.Enabled = false;
            this.tDX.Location = new System.Drawing.Point(446, 437);
            this.tDX.Name = "tDX";
            this.tDX.Size = new System.Drawing.Size(100, 20);
            this.tDX.TabIndex = 22;
            // 
            // cbox4
            // 
            this.cbox4.AutoSize = true;
            this.cbox4.Enabled = false;
            this.cbox4.Location = new System.Drawing.Point(810, 466);
            this.cbox4.Name = "cbox4";
            this.cbox4.Size = new System.Drawing.Size(94, 17);
            this.cbox4.TabIndex = 26;
            this.cbox4.Text = "Curve 4 points";
            this.cbox4.UseVisualStyleBackColor = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.FileName = "*.bmp";
            this.saveFileDialog.Filter = "BitMap files (*.bmp)|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.bDraw;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1005, 525);
            this.Controls.Add(this.cbox4);
            this.Controls.Add(this.lDY);
            this.Controls.Add(this.tDY);
            this.Controls.Add(this.lDX);
            this.Controls.Add(this.tDX);
            this.Controls.Add(this.cboxMoveCurve);
            this.Controls.Add(this.bMove);
            this.Controls.Add(this.cboxZoomCurve);
            this.Controls.Add(this.lYZoom);
            this.Controls.Add(this.tYZoom);
            this.Controls.Add(this.lXZoom);
            this.Controls.Add(this.tXZoom);
            this.Controls.Add(this.bZoom);
            this.Controls.Add(this.cboxRotateCurve);
            this.Controls.Add(this.lAgrads);
            this.Controls.Add(this.tAgrads);
            this.Controls.Add(this.lA);
            this.Controls.Add(this.tA);
            this.Controls.Add(this.bRotate);
            this.Controls.Add(this.bClear);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bDraw);
            this.Controls.Add(this.pbox);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bezier";
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Button bDraw;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bClear;
        private System.Windows.Forms.Button bRotate;
        private System.Windows.Forms.Label lA;
        private System.Windows.Forms.TextBox tA;
        private System.Windows.Forms.Label lAgrads;
        private System.Windows.Forms.TextBox tAgrads;
        private System.Windows.Forms.CheckBox cboxRotateCurve;
        private System.Windows.Forms.Button bZoom;
        private System.Windows.Forms.CheckBox cboxZoomCurve;
        private System.Windows.Forms.Label lYZoom;
        private System.Windows.Forms.TextBox tYZoom;
        private System.Windows.Forms.Label lXZoom;
        private System.Windows.Forms.TextBox tXZoom;
        private System.Windows.Forms.Button bMove;
        private System.Windows.Forms.CheckBox cboxMoveCurve;
        private System.Windows.Forms.Label lDY;
        private System.Windows.Forms.TextBox tDY;
        private System.Windows.Forms.Label lDX;
        private System.Windows.Forms.TextBox tDX;
        private System.Windows.Forms.CheckBox cbox4;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

