using DevExpress.XtraVerticalGrid;
using DevExpress.XtraGrid;
namespace DXSample {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.vGridControl2 = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // vGridControl1
            // 
            this.vGridControl1.AllowDrop = true;
            this.vGridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vGridControl1.Location = new System.Drawing.Point(0, 0);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.OptionsView.MinRowAutoHeight = 30;
            this.vGridControl1.Size = new System.Drawing.Size(386, 279);
            this.vGridControl1.TabIndex = 0;
            // 
            // vGridControl2
            // 
            this.vGridControl2.AllowDrop = true;
            this.vGridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vGridControl2.Location = new System.Drawing.Point(386, 0);
            this.vGridControl2.Name = "vGridControl2";
            this.vGridControl2.OptionsView.MinRowAutoHeight = 30;
            this.vGridControl2.Size = new System.Drawing.Size(369, 279);
            this.vGridControl2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 279);
            this.Controls.Add(this.vGridControl2);
            this.Controls.Add(this.vGridControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private VGridControl vGridControl1;
        private VGridControl vGridControl2;
    }
}

