namespace FNviajes
{
    partial class FormUsuario
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
            this.dgvUsuario = new System.Windows.Forms.DataGridView();
            this.txtNivelDeAcceso = new System.Windows.Forms.TextBox();
            this.lblNivelDeAcceso = new System.Windows.Forms.Label();
            this.btnModificarNivelDeAcceso = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUsuario
            // 
            this.dgvUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuario.Location = new System.Drawing.Point(138, 12);
            this.dgvUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvUsuario.Name = "dgvUsuario";
            this.dgvUsuario.Size = new System.Drawing.Size(745, 365);
            this.dgvUsuario.TabIndex = 0;
            this.dgvUsuario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuario_CellClick_1);
            // 
            // txtNivelDeAcceso
            // 
            this.txtNivelDeAcceso.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNivelDeAcceso.Location = new System.Drawing.Point(13, 164);
            this.txtNivelDeAcceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtNivelDeAcceso.Name = "txtNivelDeAcceso";
            this.txtNivelDeAcceso.Size = new System.Drawing.Size(116, 26);
            this.txtNivelDeAcceso.TabIndex = 22;
            // 
            // lblNivelDeAcceso
            // 
            this.lblNivelDeAcceso.AutoSize = true;
            this.lblNivelDeAcceso.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNivelDeAcceso.Location = new System.Drawing.Point(9, 145);
            this.lblNivelDeAcceso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNivelDeAcceso.Name = "lblNivelDeAcceso";
            this.lblNivelDeAcceso.Size = new System.Drawing.Size(117, 16);
            this.lblNivelDeAcceso.TabIndex = 15;
            this.lblNivelDeAcceso.Text = "Nivel de acceso:";
            // 
            // btnModificarNivelDeAcceso
            // 
            this.btnModificarNivelDeAcceso.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarNivelDeAcceso.Location = new System.Drawing.Point(12, 209);
            this.btnModificarNivelDeAcceso.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModificarNivelDeAcceso.Name = "btnModificarNivelDeAcceso";
            this.btnModificarNivelDeAcceso.Size = new System.Drawing.Size(117, 64);
            this.btnModificarNivelDeAcceso.TabIndex = 23;
            this.btnModificarNivelDeAcceso.Text = "Modificar Nivel de Acceso";
            this.btnModificarNivelDeAcceso.UseVisualStyleBackColor = true;
            this.btnModificarNivelDeAcceso.Click += new System.EventHandler(this.btnModificarNivelDeAcceso_Click);
            // 
            // txtId
            // 
            this.txtId.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(14, 116);
            this.txtId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(116, 26);
            this.txtId.TabIndex = 25;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(10, 97);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(24, 16);
            this.lblId.TabIndex = 24;
            this.lblId.Text = "id:";
            // 
            // FormUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 436);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.btnModificarNivelDeAcceso);
            this.Controls.Add(this.txtNivelDeAcceso);
            this.Controls.Add(this.lblNivelDeAcceso);
            this.Controls.Add(this.dgvUsuario);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormUsuario";
            this.Text = "Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuario;
        private System.Windows.Forms.TextBox txtNivelDeAcceso;
        private System.Windows.Forms.Label lblNivelDeAcceso;
        private System.Windows.Forms.Button btnModificarNivelDeAcceso;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
    }
}