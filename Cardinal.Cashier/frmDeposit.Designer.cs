namespace Cardinal.Cashier
{
    public partial class frmDeposit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDeposit));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIDTransaction = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtWithDrawal = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.txtQuantity = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.dtDateDeposit = new Bunifu.Framework.UI.BunifuDatepicker();
            this.btnAccept = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.btnClear = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cmbCards = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo de Transaccion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tarjetas";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ID de Cuenta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Retiro";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Cantidad de Deposito";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Fecha";
            // 
            // txtIDTransaction
            // 
            this.txtIDTransaction.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtIDTransaction.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIDTransaction.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtIDTransaction.BorderThickness = 3;
            this.txtIDTransaction.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIDTransaction.Enabled = false;
            this.txtIDTransaction.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtIDTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtIDTransaction.isPassword = false;
            this.txtIDTransaction.Location = new System.Drawing.Point(153, 6);
            this.txtIDTransaction.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDTransaction.Name = "txtIDTransaction";
            this.txtIDTransaction.Size = new System.Drawing.Size(144, 25);
            this.txtIDTransaction.TabIndex = 7;
            this.txtIDTransaction.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtWithDrawal
            // 
            this.txtWithDrawal.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtWithDrawal.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtWithDrawal.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtWithDrawal.BorderThickness = 3;
            this.txtWithDrawal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWithDrawal.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtWithDrawal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtWithDrawal.isPassword = false;
            this.txtWithDrawal.Location = new System.Drawing.Point(388, 6);
            this.txtWithDrawal.Margin = new System.Windows.Forms.Padding(4);
            this.txtWithDrawal.Name = "txtWithDrawal";
            this.txtWithDrawal.Size = new System.Drawing.Size(144, 25);
            this.txtWithDrawal.TabIndex = 8;
            this.txtWithDrawal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtQuantity
            // 
            this.txtQuantity.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtQuantity.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtQuantity.BorderThickness = 3;
            this.txtQuantity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtQuantity.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.txtQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQuantity.isPassword = false;
            this.txtQuantity.Location = new System.Drawing.Point(153, 145);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(144, 25);
            this.txtQuantity.TabIndex = 10;
            this.txtQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // dtDateDeposit
            // 
            this.dtDateDeposit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dtDateDeposit.BorderRadius = 0;
            this.dtDateDeposit.ForeColor = System.Drawing.Color.White;
            this.dtDateDeposit.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtDateDeposit.FormatCustom = null;
            this.dtDateDeposit.Location = new System.Drawing.Point(390, 145);
            this.dtDateDeposit.Name = "dtDateDeposit";
            this.dtDateDeposit.Size = new System.Drawing.Size(261, 31);
            this.dtDateDeposit.TabIndex = 13;
            this.dtDateDeposit.Value = new System.DateTime(2018, 8, 4, 18, 45, 28, 122);
            // 
            // btnAccept
            // 
            this.btnAccept.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnAccept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnAccept.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAccept.BorderRadius = 0;
            this.btnAccept.ButtonText = "Aceptar";
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.DisabledColor = System.Drawing.Color.Gray;
            this.btnAccept.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAccept.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnAccept.Iconimage")));
            this.btnAccept.Iconimage_right = null;
            this.btnAccept.Iconimage_right_Selected = null;
            this.btnAccept.Iconimage_Selected = null;
            this.btnAccept.IconMarginLeft = 0;
            this.btnAccept.IconMarginRight = 0;
            this.btnAccept.IconRightVisible = true;
            this.btnAccept.IconRightZoom = 0D;
            this.btnAccept.IconVisible = true;
            this.btnAccept.IconZoom = 90D;
            this.btnAccept.IsTab = false;
            this.btnAccept.Location = new System.Drawing.Point(32, 260);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnAccept.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAccept.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAccept.selected = false;
            this.btnAccept.Size = new System.Drawing.Size(205, 42);
            this.btnAccept.TabIndex = 14;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccept.Textcolor = System.Drawing.Color.White;
            this.btnAccept.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(153, 77);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(144, 21);
            this.cmbCustomers.TabIndex = 15;
            this.cmbCustomers.SelectedValueChanged += new System.EventHandler(this.cmbCustomers_SelectedValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClear.BorderRadius = 0;
            this.btnClear.ButtonText = "        Limpiar";
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.DisabledColor = System.Drawing.Color.Gray;
            this.btnClear.Iconcolor = System.Drawing.Color.Transparent;
            this.btnClear.Iconimage = null;
            this.btnClear.Iconimage_right = null;
            this.btnClear.Iconimage_right_Selected = null;
            this.btnClear.Iconimage_Selected = null;
            this.btnClear.IconMarginLeft = 0;
            this.btnClear.IconMarginRight = 0;
            this.btnClear.IconRightVisible = true;
            this.btnClear.IconRightZoom = 0D;
            this.btnClear.IconVisible = true;
            this.btnClear.IconZoom = 90D;
            this.btnClear.IsTab = false;
            this.btnClear.Location = new System.Drawing.Point(429, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.btnClear.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnClear.OnHoverTextColor = System.Drawing.Color.White;
            this.btnClear.selected = false;
            this.btnClear.Size = new System.Drawing.Size(205, 42);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "        Limpiar";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Textcolor = System.Drawing.Color.White;
            this.btnClear.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // cmbCards
            // 
            this.cmbCards.FormattingEnabled = true;
            this.cmbCards.Location = new System.Drawing.Point(390, 86);
            this.cmbCards.Name = "cmbCards";
            this.cmbCards.Size = new System.Drawing.Size(142, 21);
            this.cmbCards.TabIndex = 17;
            // 
            // frmDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 373);
            this.Controls.Add(this.cmbCards);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.dtDateDeposit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtWithDrawal);
            this.Controls.Add(this.txtIDTransaction);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDeposito";
            this.Text = "frmDeposito";
            this.Load += new System.EventHandler(this.frmDeposito_Load);
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
        private Bunifu.Framework.UI.BunifuMetroTextbox txtIDTransaction;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtWithDrawal;
        private Bunifu.Framework.UI.BunifuMetroTextbox txtQuantity;
        private Bunifu.Framework.UI.BunifuDatepicker dtDateDeposit;
        private Bunifu.Framework.UI.BunifuFlatButton btnAccept;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private Bunifu.Framework.UI.BunifuFlatButton btnClear;
        private System.Windows.Forms.ComboBox cmbCards;
    }
}