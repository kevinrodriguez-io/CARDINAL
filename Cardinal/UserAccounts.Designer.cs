namespace Cardinal {
    partial class UserAccounts {
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiTransactions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAccountCuttings = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnQuery = new System.Windows.Forms.Button();
            this.dgvUserAccounts = new System.Windows.Forms.DataGridView();
            this.txtType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCuttingDate = new System.Windows.Forms.DateTimePicker();
            this.txtCashPayment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransactions,
            this.tsmiAccountCuttings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(531, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiTransactions
            // 
            this.tsmiTransactions.Name = "tsmiTransactions";
            this.tsmiTransactions.Size = new System.Drawing.Size(112, 24);
            this.tsmiTransactions.Text = "Transacciones";
            this.tsmiTransactions.Click += new System.EventHandler(this.tsmiTransactions_Click);
            // 
            // tsmiAccountCuttings
            // 
            this.tsmiAccountCuttings.Name = "tsmiAccountCuttings";
            this.tsmiAccountCuttings.Size = new System.Drawing.Size(63, 24);
            this.tsmiAccountCuttings.Text = "Cortes";
            this.tsmiAccountCuttings.Click += new System.EventHandler(this.tsmiAccountCuttings_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(386, 89);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(132, 55);
            this.btnCreate.TabIndex = 24;
            this.btnCreate.Text = "Crear";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(287, 119);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(93, 25);
            this.btnDelete.TabIndex = 23;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(287, 88);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(93, 25);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(312, 31);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(206, 22);
            this.txtId.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(287, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "Id";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(287, 59);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(231, 23);
            this.btnQuery.TabIndex = 19;
            this.btnQuery.Text = "Consultar";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // dgvUserAccounts
            // 
            this.dgvUserAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserAccounts.Location = new System.Drawing.Point(12, 150);
            this.dgvUserAccounts.Name = "dgvUserAccounts";
            this.dgvUserAccounts.RowTemplate.Height = 24;
            this.dgvUserAccounts.Size = new System.Drawing.Size(506, 341);
            this.dgvUserAccounts.TabIndex = 25;
            this.dgvUserAccounts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserAccounts_CellClick);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(76, 31);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(205, 22);
            this.txtType.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Fecha de corte";
            // 
            // dtpCuttingDate
            // 
            this.dtpCuttingDate.CustomFormat = "dd";
            this.dtpCuttingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCuttingDate.Location = new System.Drawing.Point(126, 59);
            this.dtpCuttingDate.Name = "dtpCuttingDate";
            this.dtpCuttingDate.Size = new System.Drawing.Size(155, 22);
            this.dtpCuttingDate.TabIndex = 28;
            // 
            // txtCashPayment
            // 
            this.txtCashPayment.Location = new System.Drawing.Point(134, 89);
            this.txtCashPayment.Name = "txtCashPayment";
            this.txtCashPayment.Size = new System.Drawing.Size(147, 22);
            this.txtCashPayment.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "Pago de contado";
            // 
            // UserAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 503);
            this.Controls.Add(this.txtCashPayment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpCuttingDate);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvUserAccounts);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "UserAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserAccounts";
            this.Load += new System.EventHandler(this.UserAccounts_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserAccounts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.DataGridView dgvUserAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransactions;
        private System.Windows.Forms.ToolStripMenuItem tsmiAccountCuttings;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpCuttingDate;
        private System.Windows.Forms.TextBox txtCashPayment;
        private System.Windows.Forms.Label label2;
    }
}