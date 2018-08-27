namespace SistemaCashValidador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnDepositar = new System.Windows.Forms.Button();
            this.inputEfectivo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbB500 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbB200 = new System.Windows.Forms.Label();
            this.lbB100 = new System.Windows.Forms.Label();
            this.lbB50 = new System.Windows.Forms.Label();
            this.lbB20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lbM1 = new System.Windows.Forms.Label();
            this.lbM2 = new System.Windows.Forms.Label();
            this.lbM5 = new System.Windows.Forms.Label();
            this.lbM10 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbCambio = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.btnCaja = new System.Windows.Forms.Button();
            this.lbMensajeProceso = new System.Windows.Forms.Label();
            this.listBilletes = new System.Windows.Forms.ListBox();
            this.listMonedas = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDepositar
            // 
            this.btnDepositar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDepositar.Location = new System.Drawing.Point(176, 48);
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(112, 23);
            this.btnDepositar.TabIndex = 1;
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.UseVisualStyleBackColor = true;
            this.btnDepositar.Click += new System.EventHandler(this.generarTransaccion);
            // 
            // inputEfectivo
            // 
            this.inputEfectivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputEfectivo.Location = new System.Drawing.Point(40, 48);
            this.inputEfectivo.Name = "inputEfectivo";
            this.inputEfectivo.Size = new System.Drawing.Size(120, 20);
            this.inputEfectivo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Billetes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Efectivo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Monedas";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbB500);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lbB200);
            this.groupBox1.Controls.Add(this.lbB100);
            this.groupBox1.Controls.Add(this.lbB50);
            this.groupBox1.Controls.Add(this.lbB20);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.lbM1);
            this.groupBox1.Controls.Add(this.lbM2);
            this.groupBox1.Controls.Add(this.lbM5);
            this.groupBox1.Controls.Add(this.lbM10);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(345, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 143);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Almacenado";
            // 
            // lbB500
            // 
            this.lbB500.AutoSize = true;
            this.lbB500.Location = new System.Drawing.Point(195, 27);
            this.lbB500.Name = "lbB500";
            this.lbB500.Size = new System.Drawing.Size(13, 13);
            this.lbB500.TabIndex = 14;
            this.lbB500.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(152, 27);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "$500 :";
            // 
            // lbB200
            // 
            this.lbB200.AutoSize = true;
            this.lbB200.Location = new System.Drawing.Point(127, 111);
            this.lbB200.Name = "lbB200";
            this.lbB200.Size = new System.Drawing.Size(13, 13);
            this.lbB200.TabIndex = 9;
            this.lbB200.Text = "0";
            // 
            // lbB100
            // 
            this.lbB100.AutoSize = true;
            this.lbB100.Location = new System.Drawing.Point(127, 79);
            this.lbB100.Name = "lbB100";
            this.lbB100.Size = new System.Drawing.Size(13, 13);
            this.lbB100.TabIndex = 10;
            this.lbB100.Text = "0";
            // 
            // lbB50
            // 
            this.lbB50.AutoSize = true;
            this.lbB50.Location = new System.Drawing.Point(127, 51);
            this.lbB50.Name = "lbB50";
            this.lbB50.Size = new System.Drawing.Size(13, 13);
            this.lbB50.TabIndex = 11;
            this.lbB50.Text = "0";
            // 
            // lbB20
            // 
            this.lbB20.AutoSize = true;
            this.lbB20.Location = new System.Drawing.Point(127, 27);
            this.lbB20.Name = "lbB20";
            this.lbB20.Size = new System.Drawing.Size(13, 13);
            this.lbB20.TabIndex = 12;
            this.lbB20.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(82, 111);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "$200 :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(82, 79);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "$100 :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(88, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "$50 :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(88, 27);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(31, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "$20 :";
            // 
            // lbM1
            // 
            this.lbM1.AutoSize = true;
            this.lbM1.Location = new System.Drawing.Point(49, 111);
            this.lbM1.Name = "lbM1";
            this.lbM1.Size = new System.Drawing.Size(13, 13);
            this.lbM1.TabIndex = 4;
            this.lbM1.Text = "0";
            // 
            // lbM2
            // 
            this.lbM2.AutoSize = true;
            this.lbM2.Location = new System.Drawing.Point(49, 79);
            this.lbM2.Name = "lbM2";
            this.lbM2.Size = new System.Drawing.Size(13, 13);
            this.lbM2.TabIndex = 4;
            this.lbM2.Text = "0";
            // 
            // lbM5
            // 
            this.lbM5.AutoSize = true;
            this.lbM5.Location = new System.Drawing.Point(49, 51);
            this.lbM5.Name = "lbM5";
            this.lbM5.Size = new System.Drawing.Size(13, 13);
            this.lbM5.TabIndex = 4;
            this.lbM5.Text = "0";
            // 
            // lbM10
            // 
            this.lbM10.AutoSize = true;
            this.lbM10.Location = new System.Drawing.Point(49, 27);
            this.lbM10.Name = "lbM10";
            this.lbM10.Size = new System.Drawing.Size(13, 13);
            this.lbM10.TabIndex = 4;
            this.lbM10.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "$1 :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "$2 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "$5:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "$10 :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbTotal);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.lbCambio);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(345, 208);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 78);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Transacción";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(88, 50);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(19, 13);
            this.lbTotal.TabIndex = 5;
            this.lbTotal.Text = "$0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbCambio
            // 
            this.lbCambio.AutoSize = true;
            this.lbCambio.Location = new System.Drawing.Point(88, 25);
            this.lbCambio.Name = "lbCambio";
            this.lbCambio.Size = new System.Drawing.Size(19, 13);
            this.lbCambio.TabIndex = 3;
            this.lbCambio.Text = "$0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Cambio";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnHistorial
            // 
            this.btnHistorial.Location = new System.Drawing.Point(357, 338);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Size = new System.Drawing.Size(95, 23);
            this.btnHistorial.TabIndex = 10;
            this.btnHistorial.Text = "Historial";
            this.btnHistorial.UseVisualStyleBackColor = true;
            // 
            // btnCaja
            // 
            this.btnCaja.Location = new System.Drawing.Point(475, 338);
            this.btnCaja.Name = "btnCaja";
            this.btnCaja.Size = new System.Drawing.Size(96, 23);
            this.btnCaja.TabIndex = 11;
            this.btnCaja.Text = "Caja";
            this.btnCaja.UseVisualStyleBackColor = true;
            this.btnCaja.Click += new System.EventHandler(this.btnCaja_Click);
            // 
            // lbMensajeProceso
            // 
            this.lbMensajeProceso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMensajeProceso.AutoSize = true;
            this.lbMensajeProceso.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lbMensajeProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensajeProceso.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbMensajeProceso.Location = new System.Drawing.Point(40, 399);
            this.lbMensajeProceso.Name = "lbMensajeProceso";
            this.lbMensajeProceso.Size = new System.Drawing.Size(68, 13);
            this.lbMensajeProceso.TabIndex = 12;
            this.lbMensajeProceso.Text = "Conectado";
            // 
            // listBilletes
            // 
            this.listBilletes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBilletes.FormattingEnabled = true;
            this.listBilletes.Location = new System.Drawing.Point(40, 110);
            this.listBilletes.Name = "listBilletes";
            this.listBilletes.Size = new System.Drawing.Size(120, 251);
            this.listBilletes.TabIndex = 13;
            // 
            // listMonedas
            // 
            this.listMonedas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listMonedas.FormattingEnabled = true;
            this.listMonedas.Location = new System.Drawing.Point(179, 110);
            this.listMonedas.Name = "listMonedas";
            this.listMonedas.Size = new System.Drawing.Size(120, 251);
            this.listMonedas.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.listMonedas);
            this.Controls.Add(this.listBilletes);
            this.Controls.Add(this.lbMensajeProceso);
            this.Controls.Add(this.btnCaja);
            this.Controls.Add(this.btnHistorial);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputEfectivo);
            this.Controls.Add(this.btnDepositar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Cash";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDepositar;
        private System.Windows.Forms.TextBox inputEfectivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbM1;
        private System.Windows.Forms.Label lbM2;
        private System.Windows.Forms.Label lbM5;
        private System.Windows.Forms.Label lbM10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbCambio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnHistorial;
        private System.Windows.Forms.Button btnCaja;
        private System.Windows.Forms.Label lbMensajeProceso;
        private System.Windows.Forms.ListBox listBilletes;
        private System.Windows.Forms.ListBox listMonedas;
        private System.Windows.Forms.Label lbB500;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbB200;
        private System.Windows.Forms.Label lbB100;
        private System.Windows.Forms.Label lbB50;
        private System.Windows.Forms.Label lbB20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}

