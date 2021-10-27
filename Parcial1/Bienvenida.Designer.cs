
namespace Parcial1
{
    partial class Bienvenida
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.btnMascotasPersona = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConsultarMascotas = new System.Windows.Forms.Button();
            this.btnEliminarMascota = new System.Windows.Forms.Button();
            this.btnActualizarMascota = new System.Windows.Forms.Button();
            this.btnConsultarMascota = new System.Windows.Forms.Button();
            this.btnIngresarMascota = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConsultarPersonas = new System.Windows.Forms.Button();
            this.btnEliminarPersona = new System.Windows.Forms.Button();
            this.btnActualizarPersona = new System.Windows.Forms.Button();
            this.btnConsultarPersona = new System.Windows.Forms.Button();
            this.btnIngresarPersona = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSalir);
            this.groupBox1.Controls.Add(this.dgvConsultas);
            this.groupBox1.Controls.Add(this.btnMascotasPersona);
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 674);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(602, 402);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 57);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Location = new System.Drawing.Point(31, 490);
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.Size = new System.Drawing.Size(703, 178);
            this.dgvConsultas.TabIndex = 5;
            // 
            // btnMascotasPersona
            // 
            this.btnMascotasPersona.Location = new System.Drawing.Point(31, 401);
            this.btnMascotasPersona.Name = "btnMascotasPersona";
            this.btnMascotasPersona.Size = new System.Drawing.Size(327, 58);
            this.btnMascotasPersona.TabIndex = 4;
            this.btnMascotasPersona.Text = "Consultar mascotas de una persona";
            this.btnMascotasPersona.UseVisualStyleBackColor = true;
            this.btnMascotasPersona.Click += new System.EventHandler(this.btnMascotasPersona_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(414, 401);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(128, 58);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(311, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bienvenido";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnConsultarMascotas);
            this.groupBox3.Controls.Add(this.btnEliminarMascota);
            this.groupBox3.Controls.Add(this.btnActualizarMascota);
            this.groupBox3.Controls.Add(this.btnConsultarMascota);
            this.groupBox3.Controls.Add(this.btnIngresarMascota);
            this.groupBox3.Location = new System.Drawing.Point(414, 88);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(320, 307);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Mascota";
            // 
            // btnConsultarMascotas
            // 
            this.btnConsultarMascotas.Location = new System.Drawing.Point(51, 232);
            this.btnConsultarMascotas.Name = "btnConsultarMascotas";
            this.btnConsultarMascotas.Size = new System.Drawing.Size(213, 40);
            this.btnConsultarMascotas.TabIndex = 4;
            this.btnConsultarMascotas.Text = "Consultar mascotas";
            this.btnConsultarMascotas.UseVisualStyleBackColor = true;
            this.btnConsultarMascotas.Click += new System.EventHandler(this.btnConsultarMascotas_Click);
            // 
            // btnEliminarMascota
            // 
            this.btnEliminarMascota.Location = new System.Drawing.Point(51, 184);
            this.btnEliminarMascota.Name = "btnEliminarMascota";
            this.btnEliminarMascota.Size = new System.Drawing.Size(213, 42);
            this.btnEliminarMascota.TabIndex = 3;
            this.btnEliminarMascota.Text = "Eliminar mascota";
            this.btnEliminarMascota.UseVisualStyleBackColor = true;
            this.btnEliminarMascota.Click += new System.EventHandler(this.btnEliminarMascota_Click);
            // 
            // btnActualizarMascota
            // 
            this.btnActualizarMascota.Location = new System.Drawing.Point(51, 137);
            this.btnActualizarMascota.Name = "btnActualizarMascota";
            this.btnActualizarMascota.Size = new System.Drawing.Size(213, 41);
            this.btnActualizarMascota.TabIndex = 2;
            this.btnActualizarMascota.Text = "Actualizar mascota";
            this.btnActualizarMascota.UseVisualStyleBackColor = true;
            this.btnActualizarMascota.Click += new System.EventHandler(this.btnActualizarMascota_Click);
            // 
            // btnConsultarMascota
            // 
            this.btnConsultarMascota.Location = new System.Drawing.Point(51, 91);
            this.btnConsultarMascota.Name = "btnConsultarMascota";
            this.btnConsultarMascota.Size = new System.Drawing.Size(213, 40);
            this.btnConsultarMascota.TabIndex = 1;
            this.btnConsultarMascota.Text = "Consultar mascota";
            this.btnConsultarMascota.UseVisualStyleBackColor = true;
            this.btnConsultarMascota.Click += new System.EventHandler(this.btnConsultarMascota_Click);
            // 
            // btnIngresarMascota
            // 
            this.btnIngresarMascota.Location = new System.Drawing.Point(51, 47);
            this.btnIngresarMascota.Name = "btnIngresarMascota";
            this.btnIngresarMascota.Size = new System.Drawing.Size(213, 38);
            this.btnIngresarMascota.TabIndex = 0;
            this.btnIngresarMascota.Text = "Ingresar mascota";
            this.btnIngresarMascota.UseVisualStyleBackColor = true;
            this.btnIngresarMascota.Click += new System.EventHandler(this.btnIngresarMascota_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnConsultarPersonas);
            this.groupBox2.Controls.Add(this.btnEliminarPersona);
            this.groupBox2.Controls.Add(this.btnActualizarPersona);
            this.groupBox2.Controls.Add(this.btnConsultarPersona);
            this.groupBox2.Controls.Add(this.btnIngresarPersona);
            this.groupBox2.Location = new System.Drawing.Point(31, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 307);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Persona";
            // 
            // btnConsultarPersonas
            // 
            this.btnConsultarPersonas.Location = new System.Drawing.Point(56, 232);
            this.btnConsultarPersonas.Name = "btnConsultarPersonas";
            this.btnConsultarPersonas.Size = new System.Drawing.Size(214, 40);
            this.btnConsultarPersonas.TabIndex = 7;
            this.btnConsultarPersonas.Text = "Consultar personas";
            this.btnConsultarPersonas.UseVisualStyleBackColor = true;
            this.btnConsultarPersonas.Click += new System.EventHandler(this.btnConsultarPersonas_Click);
            // 
            // btnEliminarPersona
            // 
            this.btnEliminarPersona.Location = new System.Drawing.Point(56, 184);
            this.btnEliminarPersona.Name = "btnEliminarPersona";
            this.btnEliminarPersona.Size = new System.Drawing.Size(214, 42);
            this.btnEliminarPersona.TabIndex = 6;
            this.btnEliminarPersona.Text = "Eliminar persona";
            this.btnEliminarPersona.UseVisualStyleBackColor = true;
            this.btnEliminarPersona.Click += new System.EventHandler(this.btnEliminarPersona_Click);
            // 
            // btnActualizarPersona
            // 
            this.btnActualizarPersona.Location = new System.Drawing.Point(56, 137);
            this.btnActualizarPersona.Name = "btnActualizarPersona";
            this.btnActualizarPersona.Size = new System.Drawing.Size(214, 41);
            this.btnActualizarPersona.TabIndex = 5;
            this.btnActualizarPersona.Text = "Actualizar persona";
            this.btnActualizarPersona.UseVisualStyleBackColor = true;
            this.btnActualizarPersona.Click += new System.EventHandler(this.btnActualizarPersona_Click);
            // 
            // btnConsultarPersona
            // 
            this.btnConsultarPersona.Location = new System.Drawing.Point(56, 91);
            this.btnConsultarPersona.Name = "btnConsultarPersona";
            this.btnConsultarPersona.Size = new System.Drawing.Size(214, 40);
            this.btnConsultarPersona.TabIndex = 4;
            this.btnConsultarPersona.Text = "Consultar persona";
            this.btnConsultarPersona.UseVisualStyleBackColor = true;
            this.btnConsultarPersona.Click += new System.EventHandler(this.btnConsultarPersona_Click);
            // 
            // btnIngresarPersona
            // 
            this.btnIngresarPersona.Location = new System.Drawing.Point(56, 47);
            this.btnIngresarPersona.Name = "btnIngresarPersona";
            this.btnIngresarPersona.Size = new System.Drawing.Size(214, 38);
            this.btnIngresarPersona.TabIndex = 3;
            this.btnIngresarPersona.Text = "Ingresar persona";
            this.btnIngresarPersona.UseVisualStyleBackColor = true;
            this.btnIngresarPersona.Click += new System.EventHandler(this.btnIngresarPersona_Click);
            // 
            // Bienvenida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 707);
            this.Controls.Add(this.groupBox1);
            this.Name = "Bienvenida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bienvenida";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.Button btnMascotasPersona;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnConsultarMascotas;
        private System.Windows.Forms.Button btnEliminarMascota;
        private System.Windows.Forms.Button btnActualizarMascota;
        private System.Windows.Forms.Button btnConsultarMascota;
        private System.Windows.Forms.Button btnIngresarMascota;
        private System.Windows.Forms.Button btnConsultarPersonas;
        private System.Windows.Forms.Button btnEliminarPersona;
        private System.Windows.Forms.Button btnActualizarPersona;
        private System.Windows.Forms.Button btnConsultarPersona;
        private System.Windows.Forms.Button btnIngresarPersona;
        private System.Windows.Forms.Button btnSalir;
    }
}