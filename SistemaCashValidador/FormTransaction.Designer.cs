namespace SistemaCashValidador
{
    partial class FormTransaction
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDepositar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb1 = new System.Windows.Forms.TextBox();
            this.tb2 = new System.Windows.Forms.TextBox();
            this.tb5 = new System.Windows.Forms.TextBox();
            this.tb10 = new System.Windows.Forms.TextBox();
            this.tb20 = new System.Windows.Forms.TextBox();
            this.tb500 = new System.Windows.Forms.TextBox();
            this.tb50 = new System.Windows.Forms.TextBox();
            this.tb100 = new System.Windows.Forms.TextBox();
            this.tb200 = new System.Windows.Forms.TextBox();
            this.tbPago = new System.Windows.Forms.TextBox();
            this.tbCambio = new System.Windows.Forms.TextBox();
            this.tbDeposito = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(743, 36);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(743, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transacciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDepositar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 332);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(743, 49);
            this.panel2.TabIndex = 1;
            // 
            // btnDepositar
            // 
            this.btnDepositar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.btnDepositar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(98)))), ((int)(((byte)(117)))));
            this.btnDepositar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(152)))), ((int)(((byte)(181)))));
            this.btnDepositar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDepositar.ForeColor = System.Drawing.Color.White;
            this.btnDepositar.Location = new System.Drawing.Point(647, 11);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(84, 29);
            this.btnDepositar.TabIndex = 2;
            this.btnDepositar.Text = "Cerrar";
            this.btnDepositar.UseVisualStyleBackColor = false;
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox2);
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.tbDeposito);
            this.panel3.Controls.Add(this.tbCambio);
            this.panel3.Controls.Add(this.tbPago);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(743, 296);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(70, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pago";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(268, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Cambio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(471, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Depositado";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(22, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "$1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(22, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "$2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(153, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "$5";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(144, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "$10";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(25, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "$20";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(25, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "$50";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(170, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 20);
            this.label11.TabIndex = 0;
            this.label11.Text = "$100";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(170, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 20);
            this.label12.TabIndex = 0;
            this.label12.Text = "$200";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(16, 111);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 20);
            this.label13.TabIndex = 0;
            this.label13.Text = "$500";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb10);
            this.groupBox1.Controls.Add(this.tb5);
            this.groupBox1.Controls.Add(this.tb2);
            this.groupBox1.Controls.Add(this.tb1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(48, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 149);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Monedas";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tb50);
            this.groupBox2.Controls.Add(this.tb500);
            this.groupBox2.Controls.Add(this.tb200);
            this.groupBox2.Controls.Add(this.tb100);
            this.groupBox2.Controls.Add(this.tb20);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Location = new System.Drawing.Point(382, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 149);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Billetes";
            // 
            // tb1
            // 
            this.tb1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb1.Location = new System.Drawing.Point(55, 35);
            this.tb1.Name = "tb1";
            this.tb1.ReadOnly = true;
            this.tb1.Size = new System.Drawing.Size(62, 26);
            this.tb1.TabIndex = 1;
            this.tb1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb2
            // 
            this.tb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb2.Location = new System.Drawing.Point(55, 91);
            this.tb2.Name = "tb2";
            this.tb2.ReadOnly = true;
            this.tb2.Size = new System.Drawing.Size(62, 26);
            this.tb2.TabIndex = 1;
            this.tb2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb5
            // 
            this.tb5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb5.Location = new System.Drawing.Point(196, 35);
            this.tb5.Name = "tb5";
            this.tb5.ReadOnly = true;
            this.tb5.Size = new System.Drawing.Size(62, 26);
            this.tb5.TabIndex = 1;
            this.tb5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb10
            // 
            this.tb10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb10.Location = new System.Drawing.Point(196, 91);
            this.tb10.Name = "tb10";
            this.tb10.ReadOnly = true;
            this.tb10.Size = new System.Drawing.Size(62, 26);
            this.tb10.TabIndex = 1;
            this.tb10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb20
            // 
            this.tb20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb20.Location = new System.Drawing.Point(67, 30);
            this.tb20.Name = "tb20";
            this.tb20.ReadOnly = true;
            this.tb20.Size = new System.Drawing.Size(62, 26);
            this.tb20.TabIndex = 1;
            this.tb20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb500
            // 
            this.tb500.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb500.Location = new System.Drawing.Point(67, 106);
            this.tb500.Name = "tb500";
            this.tb500.ReadOnly = true;
            this.tb500.Size = new System.Drawing.Size(62, 26);
            this.tb500.TabIndex = 1;
            this.tb500.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb50
            // 
            this.tb50.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb50.Location = new System.Drawing.Point(67, 67);
            this.tb50.Name = "tb50";
            this.tb50.ReadOnly = true;
            this.tb50.Size = new System.Drawing.Size(62, 26);
            this.tb50.TabIndex = 1;
            this.tb50.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb100
            // 
            this.tb100.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb100.Location = new System.Drawing.Point(221, 30);
            this.tb100.Name = "tb100";
            this.tb100.ReadOnly = true;
            this.tb100.Size = new System.Drawing.Size(62, 26);
            this.tb100.TabIndex = 1;
            this.tb100.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb200
            // 
            this.tb200.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb200.Location = new System.Drawing.Point(221, 70);
            this.tb200.Name = "tb200";
            this.tb200.ReadOnly = true;
            this.tb200.Size = new System.Drawing.Size(62, 26);
            this.tb200.TabIndex = 1;
            this.tb200.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPago
            // 
            this.tbPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPago.Location = new System.Drawing.Point(122, 51);
            this.tbPago.Name = "tbPago";
            this.tbPago.ReadOnly = true;
            this.tbPago.Size = new System.Drawing.Size(106, 26);
            this.tbPago.TabIndex = 1;
            this.tbPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbCambio
            // 
            this.tbCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCambio.Location = new System.Drawing.Point(337, 51);
            this.tbCambio.Name = "tbCambio";
            this.tbCambio.ReadOnly = true;
            this.tbCambio.Size = new System.Drawing.Size(106, 26);
            this.tbCambio.TabIndex = 1;
            this.tbCambio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbDeposito
            // 
            this.tbDeposito.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDeposito.Location = new System.Drawing.Point(568, 51);
            this.tbDeposito.Name = "tbDeposito";
            this.tbDeposito.ReadOnly = true;
            this.tbDeposito.Size = new System.Drawing.Size(106, 26);
            this.tbDeposito.TabIndex = 1;
            this.tbDeposito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 381);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Message";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb50;
        private System.Windows.Forms.TextBox tb500;
        private System.Windows.Forms.TextBox tb200;
        private System.Windows.Forms.TextBox tb100;
        private System.Windows.Forms.TextBox tb20;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb10;
        private System.Windows.Forms.TextBox tb5;
        private System.Windows.Forms.TextBox tb2;
        private System.Windows.Forms.TextBox tb1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDeposito;
        private System.Windows.Forms.TextBox tbCambio;
        private System.Windows.Forms.TextBox tbPago;
    }
}