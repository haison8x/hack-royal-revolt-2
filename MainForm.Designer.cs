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
            this.HackButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.HackSpeedOption = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MoveSpeedNumber = new System.Windows.Forms.NumericUpDown();
            this.AttackRateNumber = new System.Windows.Forms.NumericUpDown();
            this.AttackRangeNumber = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.MoveSpeedNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackRateNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackRangeNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // HackButton
            // 
            this.HackButton.Enabled = true;
            this.HackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HackButton.Location = new System.Drawing.Point(24, 126);
            this.HackButton.Name = "HackButton";
            this.HackButton.Size = new System.Drawing.Size(498, 43);
            this.HackButton.TabIndex = 2;
            this.HackButton.Text = "Hack";
            this.HackButton.UseVisualStyleBackColor = true;
            this.HackButton.Click += new System.EventHandler(this.HackButtonClick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(486, 353);
            this.label1.TabIndex = 3;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // HackSpeedOption
            // 
            this.HackSpeedOption.AutoSize = true;
            this.HackSpeedOption.Location = new System.Drawing.Point(230, 19);
            this.HackSpeedOption.Name = "HackSpeedOption";
            this.HackSpeedOption.Size = new System.Drawing.Size(86, 17);
            this.HackSpeedOption.TabIndex = 31;
            this.HackSpeedOption.Text = "Hack Speed";
            this.HackSpeedOption.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "MoveSpeed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "AttackRate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "AttackRange";
            // 
            // MoveSpeedNumber
            // 
            this.MoveSpeedNumber.Location = new System.Drawing.Point(104, 73);
            this.MoveSpeedNumber.Name = "MoveSpeedNumber";
            this.MoveSpeedNumber.Size = new System.Drawing.Size(120, 20);
            this.MoveSpeedNumber.TabIndex = 27;
            this.MoveSpeedNumber.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // AttackRateNumber
            // 
            this.AttackRateNumber.Location = new System.Drawing.Point(104, 45);
            this.AttackRateNumber.Name = "AttackRateNumber";
            this.AttackRateNumber.Size = new System.Drawing.Size(120, 20);
            this.AttackRateNumber.TabIndex = 26;
            this.AttackRateNumber.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // AttackRangeNumber
            // 
            this.AttackRangeNumber.Location = new System.Drawing.Point(104, 19);
            this.AttackRangeNumber.Name = "AttackRangeNumber";
            this.AttackRangeNumber.Size = new System.Drawing.Size(120, 20);
            this.AttackRangeNumber.TabIndex = 25;
            this.AttackRangeNumber.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 485);
            this.Controls.Add(this.HackSpeedOption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MoveSpeedNumber);
            this.Controls.Add(this.AttackRateNumber);
            this.Controls.Add(this.AttackRangeNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HackButton);
            this.Name = "MainForm";
            this.Text = "Hack Toxic";
            ((System.ComponentModel.ISupportInitialize)(this.MoveSpeedNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackRateNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AttackRangeNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button HackButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox HackSpeedOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown MoveSpeedNumber;
        private System.Windows.Forms.NumericUpDown AttackRateNumber;
        private System.Windows.Forms.NumericUpDown AttackRangeNumber;
    }
}