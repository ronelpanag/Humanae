
namespace Humanae.Views
{
    partial class ApplicantNewView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicantNewView));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtIdentification = new System.Windows.Forms.MaskedTextBox();
            this.txtRecommendedBy = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.cmbAppliedPosition = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Candidato";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre(s)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido(s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Identificación";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 324);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Posición a la que aplica";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 407);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Departamento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 481);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Recomendado por";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(186, 123);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(453, 31);
            this.txtFirstName.TabIndex = 7;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(186, 197);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(453, 31);
            this.txtLastName.TabIndex = 8;
            // 
            // txtIdentification
            // 
            this.txtIdentification.Location = new System.Drawing.Point(186, 275);
            this.txtIdentification.Mask = "000-0000000-0";
            this.txtIdentification.Name = "txtIdentification";
            this.txtIdentification.Size = new System.Drawing.Size(453, 31);
            this.txtIdentification.TabIndex = 9;
            // 
            // txtRecommendedBy
            // 
            this.txtRecommendedBy.Location = new System.Drawing.Point(186, 509);
            this.txtRecommendedBy.Name = "txtRecommendedBy";
            this.txtRecommendedBy.Size = new System.Drawing.Size(453, 31);
            this.txtRecommendedBy.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 603);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DodgerBlue;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button2.Location = new System.Drawing.Point(708, 603);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 34);
            this.button2.TabIndex = 12;
            this.button2.Text = "Aceptar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(186, 435);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(453, 31);
            this.textBox4.TabIndex = 13;
            // 
            // cmbAppliedPosition
            // 
            this.cmbAppliedPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppliedPosition.FormattingEnabled = true;
            this.cmbAppliedPosition.Location = new System.Drawing.Point(186, 352);
            this.cmbAppliedPosition.Name = "cmbAppliedPosition";
            this.cmbAppliedPosition.Size = new System.Drawing.Size(453, 33);
            this.cmbAppliedPosition.TabIndex = 14;
            this.cmbAppliedPosition.SelectedIndexChanged += new System.EventHandler(this.cmbAppliedPosition_SelectedIndexChanged);
            // 
            // ApplicantNewView
            // 
            this.AcceptButton = this.button2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(832, 653);
            this.Controls.Add(this.cmbAppliedPosition);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRecommendedBy);
            this.Controls.Add(this.txtIdentification);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicantNewView";
            this.Text = "Humanae - Nuevo Candidato";
            this.Load += new System.EventHandler(this.ApplicantNewView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.MaskedTextBox txtIdentification;
        private System.Windows.Forms.TextBox txtRecommendedBy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.ComboBox cmbAppliedPosition;
    }
}