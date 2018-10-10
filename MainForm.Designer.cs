namespace HackRR2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RecordButton = new System.Windows.Forms.Button();
            this.HackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RecordButton
            // 
            this.RecordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecordButton.Location = new System.Drawing.Point(12, 33);
            this.RecordButton.Name = "RecordButton";
            this.RecordButton.Size = new System.Drawing.Size(225, 43);
            this.RecordButton.TabIndex = 0;
            this.RecordButton.Text = "Save Original Value";
            this.RecordButton.UseVisualStyleBackColor = true;
            this.RecordButton.Click += new System.EventHandler(this.RecordButtonClick);
            // 
            // HackButton
            // 
            this.HackButton.Enabled = false;
            this.HackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HackButton.Location = new System.Drawing.Point(273, 33);
            this.HackButton.Name = "HackButton";
            this.HackButton.Size = new System.Drawing.Size(201, 43);
            this.HackButton.TabIndex = 2;
            this.HackButton.Text = "Hack";
            this.HackButton.UseVisualStyleBackColor = true;
            this.HackButton.Click += new System.EventHandler(this.HackButtonClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 353);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HackButton);
            this.Controls.Add(this.RecordButton);
            this.Name = "MainForm";
            this.Text = "Hack Toxic";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RecordButton;
        private System.Windows.Forms.Button HackButton;
        private System.Windows.Forms.Label label1;
    }
}