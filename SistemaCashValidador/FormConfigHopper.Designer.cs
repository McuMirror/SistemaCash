namespace SistemaCashValidador
{
    partial class FormConfigHopper
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
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectHooperAcceptor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.selectHopperDispenser = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectBillAcceptor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.selectBillDispenser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(212, 244);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hopper Acceptor";
            // 
            // selectHooperAcceptor
            // 
            this.selectHooperAcceptor.FormattingEnabled = true;
            this.selectHooperAcceptor.Items.AddRange(new object[] {
            "Seleccionar",
            "COMBOT",
            "ASAHI",
            "PRUEBA"});
            this.selectHooperAcceptor.Location = new System.Drawing.Point(166, 69);
            this.selectHooperAcceptor.Name = "selectHooperAcceptor";
            this.selectHooperAcceptor.Size = new System.Drawing.Size(121, 21);
            this.selectHooperAcceptor.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(264, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Establesca los dispositvos a utilizar para el sistma cash";
            // 
            // selectHopperDispenser
            // 
            this.selectHopperDispenser.FormattingEnabled = true;
            this.selectHopperDispenser.Items.AddRange(new object[] {
            "Seleccionar",
            "COMBOT",
            "ASAHI",
            "PRUEBA"});
            this.selectHopperDispenser.Location = new System.Drawing.Point(166, 110);
            this.selectHopperDispenser.Name = "selectHopperDispenser";
            this.selectHopperDispenser.Size = new System.Drawing.Size(121, 21);
            this.selectHopperDispenser.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Hopper Dispenser";
            // 
            // selectBillAcceptor
            // 
            this.selectBillAcceptor.FormattingEnabled = true;
            this.selectBillAcceptor.Items.AddRange(new object[] {
            "Seleccionar",
            "SCADVANCE",
            "PRUEBA"});
            this.selectBillAcceptor.Location = new System.Drawing.Point(166, 149);
            this.selectBillAcceptor.Name = "selectBillAcceptor";
            this.selectBillAcceptor.Size = new System.Drawing.Size(121, 21);
            this.selectBillAcceptor.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Bill Acceptor";
            // 
            // selectBillDispenser
            // 
            this.selectBillDispenser.FormattingEnabled = true;
            this.selectBillDispenser.Items.AddRange(new object[] {
            "Seleccionar",
            "F53",
            "PRUEBA"});
            this.selectBillDispenser.Location = new System.Drawing.Point(166, 190);
            this.selectBillDispenser.Name = "selectBillDispenser";
            this.selectBillDispenser.Size = new System.Drawing.Size(121, 21);
            this.selectBillDispenser.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Bill Dispenser";
            // 
            // FormConfigHopper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 289);
            this.Controls.Add(this.selectBillDispenser);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectBillAcceptor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.selectHopperDispenser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectHooperAcceptor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Name = "FormConfigHopper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Dispositvos";
            this.Load += new System.EventHandler(this.FormConfigHopper_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox selectHooperAcceptor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox selectHopperDispenser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectBillAcceptor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox selectBillDispenser;
        private System.Windows.Forms.Label label5;
    }
}