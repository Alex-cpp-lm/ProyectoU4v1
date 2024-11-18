namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loginP = new Panel();
            label5 = new Label();
            label4 = new Label();
            button1 = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            dataGridView2 = new DataGridView();
            perfilP = new Panel();
            idEmp = new Label();
            sueldo = new Label();
            usuario = new Label();
            nombre_apellidos = new Label();
            pictureBox1 = new PictureBox();
            productoP = new Panel();
            label8 = new Label();
            numericUpDown1 = new NumericUpDown();
            eliminarP = new Button();
            agregarB = new Button();
            precioPr = new Label();
            cantPr = new Label();
            nombrePr = new Label();
            codigoPr = new Label();
            productoImagen = new PictureBox();
            totalT = new Label();
            label7 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            cobroP = new Button();
            cancelar = new Button();
            panel4 = new Panel();
            textBox3 = new TextBox();
            label6 = new Label();
            busquedaa = new DataGridView();
            busquedaP = new Panel();
            label9 = new Label();
            textBox4 = new TextBox();
            loginP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            perfilP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            productoP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)productoImagen).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)busquedaa).BeginInit();
            busquedaP.SuspendLayout();
            SuspendLayout();
            // 
            // loginP
            // 
            loginP.Controls.Add(label5);
            loginP.Controls.Add(label4);
            loginP.Controls.Add(button1);
            loginP.Controls.Add(label3);
            loginP.Controls.Add(label2);
            loginP.Controls.Add(label1);
            loginP.Controls.Add(textBox2);
            loginP.Controls.Add(textBox1);
            loginP.Location = new Point(4, 4);
            loginP.Name = "loginP";
            loginP.Size = new Size(234, 280);
            loginP.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(3, 182);
            label5.Name = "label5";
            label5.Size = new Size(232, 15);
            label5.TabIndex = 7;
            label5.Text = "CONTRASEÑA O USUARIO INCORRECTOS!";
            label5.Visible = false;
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 226);
            label4.Name = "label4";
            label4.Size = new Size(143, 30);
            label4.TabIndex = 6;
            label4.Text = "si olvidaste tu contraseña,\r\n ve con tu gerente.";
            label4.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(75, 200);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "INGRESAR";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 125);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 4;
            label3.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(52, 57);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 3;
            label2.Text = "Usuario:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 12);
            label1.Name = "label1";
            label1.Size = new Size(152, 26);
            label1.TabIndex = 2;
            label1.Text = "INICIO DE SESION";
            label1.Click += label1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(50, 143);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(140, 23);
            textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(50, 80);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 23);
            textBox1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.EditMode = DataGridViewEditMode.EditOnKeystroke;
            dataGridView2.Location = new Point(3, 0);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(258, 296);
            dataGridView2.TabIndex = 8;
            dataGridView2.Visible = false;
            // 
            // perfilP
            // 
            perfilP.Controls.Add(idEmp);
            perfilP.Controls.Add(sueldo);
            perfilP.Controls.Add(usuario);
            perfilP.Controls.Add(nombre_apellidos);
            perfilP.Controls.Add(pictureBox1);
            perfilP.Enabled = false;
            perfilP.Location = new Point(12, 12);
            perfilP.Name = "perfilP";
            perfilP.Size = new Size(240, 79);
            perfilP.TabIndex = 1;
            perfilP.Visible = false;
            perfilP.MouseClick += perfilP_MouseClick;
            perfilP.MouseEnter += perfilP_MouseEnter;
            perfilP.MouseLeave += perfilP_MouseLeave;
            // 
            // idEmp
            // 
            idEmp.AutoSize = true;
            idEmp.Location = new Point(11, 107);
            idEmp.Name = "idEmp";
            idEmp.Size = new Size(38, 15);
            idEmp.TabIndex = 0;
            idEmp.Text = "label7";
            // 
            // sueldo
            // 
            sueldo.AutoSize = true;
            sueldo.Location = new Point(11, 82);
            sueldo.Name = "sueldo";
            sueldo.Size = new Size(38, 15);
            sueldo.TabIndex = 3;
            sueldo.Text = "label7";
            sueldo.Click += label7_Click;
            // 
            // usuario
            // 
            usuario.AutoSize = true;
            usuario.Location = new Point(65, 37);
            usuario.Name = "usuario";
            usuario.Size = new Size(56, 15);
            usuario.TabIndex = 2;
            usuario.Text = "USUARIO";
            // 
            // nombre_apellidos
            // 
            nombre_apellidos.AutoSize = true;
            nombre_apellidos.Location = new Point(65, 12);
            nombre_apellidos.Name = "nombre_apellidos";
            nombre_apellidos.Size = new Size(56, 15);
            nombre_apellidos.TabIndex = 1;
            nombre_apellidos.Text = "NOMBRE";
            nombre_apellidos.Click += label6_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(56, 67);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // productoP
            // 
            productoP.Controls.Add(label8);
            productoP.Controls.Add(numericUpDown1);
            productoP.Controls.Add(eliminarP);
            productoP.Controls.Add(agregarB);
            productoP.Controls.Add(precioPr);
            productoP.Controls.Add(cantPr);
            productoP.Controls.Add(nombrePr);
            productoP.Controls.Add(codigoPr);
            productoP.Controls.Add(productoImagen);
            productoP.Enabled = false;
            productoP.Location = new Point(267, 15);
            productoP.Name = "productoP";
            productoP.Size = new Size(346, 111);
            productoP.TabIndex = 6;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(240, 84);
            label8.Name = "label8";
            label8.Size = new Size(35, 15);
            label8.TabIndex = 8;
            label8.Text = "Cant:";
            label8.Click += label8_Click;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(281, 82);
            numericUpDown1.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(45, 23);
            numericUpDown1.TabIndex = 7;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // eliminarP
            // 
            eliminarP.Location = new Point(235, 53);
            eliminarP.Name = "eliminarP";
            eliminarP.Size = new Size(98, 23);
            eliminarP.TabIndex = 6;
            eliminarP.Text = "ELIMINAR (F10)";
            eliminarP.UseVisualStyleBackColor = true;
            eliminarP.Click += eliminarP_Click;
            // 
            // agregarB
            // 
            agregarB.Location = new Point(235, 22);
            agregarB.Name = "agregarB";
            agregarB.Size = new Size(98, 23);
            agregarB.TabIndex = 5;
            agregarB.Text = "AGREGAR (F9)";
            agregarB.UseVisualStyleBackColor = true;
            agregarB.Click += agregarB_Click;
            // 
            // precioPr
            // 
            precioPr.AutoSize = true;
            precioPr.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            precioPr.Location = new Point(92, 54);
            precioPr.Name = "precioPr";
            precioPr.Size = new Size(131, 30);
            precioPr.TabIndex = 4;
            precioPr.Text = "PRECIO $0.0";
            // 
            // cantPr
            // 
            cantPr.AutoSize = true;
            cantPr.Location = new Point(92, 37);
            cantPr.Name = "cantPr";
            cantPr.Size = new Size(125, 15);
            cantPr.TabIndex = 3;
            cantPr.Text = "cantidad en inventario";
            // 
            // nombrePr
            // 
            nombrePr.AutoSize = true;
            nombrePr.Location = new Point(155, 4);
            nombrePr.Name = "nombrePr";
            nombrePr.Size = new Size(120, 15);
            nombrePr.TabIndex = 2;
            nombrePr.Text = "nombre del producto";
            // 
            // codigoPr
            // 
            codigoPr.AutoSize = true;
            codigoPr.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic, GraphicsUnit.Point, 0);
            codigoPr.Location = new Point(14, 3);
            codigoPr.Name = "codigoPr";
            codigoPr.Size = new Size(102, 13);
            codigoPr.TabIndex = 1;
            codigoPr.Text = "codigo del producto";
            // 
            // productoImagen
            // 
            productoImagen.Location = new Point(14, 18);
            productoImagen.Name = "productoImagen";
            productoImagen.Size = new Size(72, 79);
            productoImagen.SizeMode = PictureBoxSizeMode.StretchImage;
            productoImagen.TabIndex = 0;
            productoImagen.TabStop = false;
            // 
            // totalT
            // 
            totalT.AutoSize = true;
            totalT.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totalT.Location = new Point(137, 398);
            totalT.Name = "totalT";
            totalT.Size = new Size(58, 32);
            totalT.TabIndex = 1;
            totalT.Text = "$0.0";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(51, 398);
            label7.Name = "label7";
            label7.Size = new Size(82, 30);
            label7.TabIndex = 0;
            label7.Text = "TOTAL:";
            label7.Click += label7_Click_1;
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(281, 140);
            panel2.Name = "panel2";
            panel2.Size = new Size(572, 348);
            panel2.TabIndex = 7;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(571, 345);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // cobroP
            // 
            cobroP.Location = new Point(132, 448);
            cobroP.Name = "cobroP";
            cobroP.Size = new Size(104, 40);
            cobroP.TabIndex = 0;
            cobroP.Text = "COBRAR(F12)";
            cobroP.UseVisualStyleBackColor = true;
            cobroP.Click += cobro_Click;
            // 
            // cancelar
            // 
            cancelar.Location = new Point(18, 448);
            cancelar.Name = "cancelar";
            cancelar.Size = new Size(108, 40);
            cancelar.TabIndex = 1;
            cancelar.Text = "CANCELAR(F11)";
            cancelar.UseVisualStyleBackColor = true;
            cancelar.Click += cancelar_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(dataGridView2);
            panel4.Controls.Add(loginP);
            panel4.Location = new Point(11, 93);
            panel4.Name = "panel4";
            panel4.Size = new Size(264, 292);
            panel4.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 3);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(163, 23);
            textBox3.TabIndex = 0;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(181, 7);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 1;
            label6.Text = "BUSCAR PRODUCTO";
            label6.Click += label6_Click_2;
            // 
            // busquedaa
            // 
            busquedaa.AllowUserToAddRows = false;
            busquedaa.AllowUserToDeleteRows = false;
            busquedaa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            busquedaa.Location = new Point(2, 32);
            busquedaa.Name = "busquedaa";
            busquedaa.ReadOnly = true;
            busquedaa.Size = new Size(366, 90);
            busquedaa.TabIndex = 0;
            busquedaa.CellClick += busquedaa_CellClick;
            // 
            // busquedaP
            // 
            busquedaP.Controls.Add(busquedaa);
            busquedaP.Controls.Add(label6);
            busquedaP.Controls.Add(textBox3);
            busquedaP.Enabled = false;
            busquedaP.Location = new Point(619, 12);
            busquedaP.Name = "busquedaP";
            busquedaP.Size = new Size(366, 123);
            busquedaP.TabIndex = 2;
            busquedaP.Paint += busquedaP_Paint;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(856, 170);
            label9.Name = "label9";
            label9.Size = new Size(129, 30);
            label9.TabIndex = 9;
            label9.Text = "Descripcion de la venta\r\n(opcional)";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(856, 203);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(132, 71);
            textBox4.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 396);
            Controls.Add(textBox4);
            Controls.Add(label9);
            Controls.Add(panel4);
            Controls.Add(totalT);
            Controls.Add(cobroP);
            Controls.Add(label7);
            Controls.Add(cancelar);
            Controls.Add(panel2);
            Controls.Add(productoP);
            Controls.Add(busquedaP);
            Controls.Add(perfilP);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            KeyUp += Form1_KeyUp;
            loginP.ResumeLayout(false);
            loginP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            perfilP.ResumeLayout(false);
            perfilP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            productoP.ResumeLayout(false);
            productoP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)productoImagen).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)busquedaa).EndInit();
            busquedaP.ResumeLayout(false);
            busquedaP.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel loginP;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Button button1;
        private Panel perfilP;
        private Label label5;
        private PictureBox pictureBox1;
        private Label nombre_apellidos;
        private Label usuario;
        private Label sueldo;
        private Label idEmp;
        private Label totalT;
        private Label label7;
        private Panel productoP;
        private Label nombrePr;
        private Label codigoPr;
        private PictureBox productoImagen;
        private Label cantPr;
        private Label precioPr;
        private Button agregarB;
        private Button eliminarP;
        private NumericUpDown numericUpDown1;
        private Label label8;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Button cobroP;
        private Button cancelar;
        private DataGridView dataGridView2;
        private Panel panel4;
        private TextBox textBox3;
        private Label label6;
        private DataGridView busquedaa;
        private Panel busquedaP;
        private Label label9;
        private TextBox textBox4;
    }
}
