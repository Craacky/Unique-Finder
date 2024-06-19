namespace Unique_Finder
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            groupBox1 = new System.Windows.Forms.GroupBox();
            button6 = new System.Windows.Forms.Button();
            textBox2 = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            textBox3 = new System.Windows.Forms.TextBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            textBox4 = new System.Windows.Forms.TextBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            textBox5 = new System.Windows.Forms.TextBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            button5 = new System.Windows.Forms.Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button6);
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            groupBox1.Location = new System.Drawing.Point(14, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(652, 100);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Требования для работы приложения";
            // 
            // button6
            // 
            button6.Image = Properties.Resources.Reset1;
            button6.Location = new System.Drawing.Point(569, 30);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(52, 55);
            button6.TabIndex = 1;
            button6.UseVisualStyleBackColor = true;
            button6.Click += Button6_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox2.Location = new System.Drawing.Point(225, 62);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new System.Drawing.Size(329, 23);
            textBox2.TabIndex = 3;
            textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox1.Location = new System.Drawing.Point(225, 30);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(329, 23);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(26, 64);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(143, 15);
            label2.TabIndex = 1;
            label2.Text = "Корректная база данных";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(26, 32);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(117, 15);
            label1.TabIndex = 0;
            label1.Text = "Microsoft SQL Server";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox3);
            groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            groupBox2.Location = new System.Drawing.Point(16, 135);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(650, 55);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Статус";
            // 
            // textBox3
            // 
            textBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox3.Location = new System.Drawing.Point(24, 22);
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new System.Drawing.Size(595, 23);
            textBox3.TabIndex = 0;
            textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button2);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(textBox4);
            groupBox3.Location = new System.Drawing.Point(16, 206);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(649, 110);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Проверка уникальности исходного файла";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(381, 60);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(238, 35);
            button2.TabIndex = 2;
            button2.Text = "Проверка";
            button2.UseVisualStyleBackColor = true;
            button2.Click += Button2_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(24, 60);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(236, 35);
            button1.TabIndex = 1;
            button1.Text = "Открыть исходный файл";
            button1.UseVisualStyleBackColor = true;
            button1.Click += Button1_Click;
            // 
            // textBox4
            // 
            textBox4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBox4.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox4.Location = new System.Drawing.Point(24, 22);
            textBox4.Name = "textBox4";
            textBox4.ReadOnly = true;
            textBox4.Size = new System.Drawing.Size(595, 23);
            textBox4.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(button4);
            groupBox4.Controls.Add(button3);
            groupBox4.Controls.Add(textBox5);
            groupBox4.Location = new System.Drawing.Point(14, 330);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(649, 119);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Проверка сходства с базой данных и формирование итогового файла";
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(383, 70);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(238, 34);
            button4.TabIndex = 2;
            button4.Text = "Открыть файл камеры";
            button4.UseVisualStyleBackColor = true;
            button4.Click += Button4_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(26, 70);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(236, 34);
            button3.TabIndex = 1;
            button3.Text = "Проверка файла с БД";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Button3_Click;
            // 
            // textBox5
            // 
            textBox5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            textBox5.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            textBox5.Location = new System.Drawing.Point(26, 27);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new System.Drawing.Size(595, 23);
            textBox5.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button5);
            groupBox5.Location = new System.Drawing.Point(14, 466);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(651, 70);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Добавление данных файла в базу данных";
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(33, 24);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(588, 31);
            button5.TabIndex = 0;
            button5.Text = "Добавить";
            button5.UseVisualStyleBackColor = true;
            button5.Click += Button5_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(678, 558);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Unique Finder";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
    }
}
