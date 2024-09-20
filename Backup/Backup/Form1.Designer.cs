namespace Backup
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnCerrar = new Button();
            progressBar1 = new ProgressBar();
            lblStatus = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(156, 158);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(112, 34);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Visible = false;
            btnCerrar.Click += btnCerrar_Click_1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(12, 118);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(405, 34);
            progressBar1.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.Font = new Font("Segoe UI", 12F);
            lblStatus.Location = new Point(1, 75);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(428, 40);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Realizando Backup";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7F);
            label1.Location = new Point(254, 248);
            label1.Name = "label1";
            label1.Size = new Size(163, 19);
            label1.TabIndex = 3;
            label1.Text = "Developer By Informática";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(429, 276);
            Controls.Add(label1);
            Controls.Add(lblStatus);
            Controls.Add(progressBar1);
            Controls.Add(btnCerrar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Megavisión";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private ProgressBar progressBar1;
        private Label lblStatus;
        private Label label1;
    }
}
