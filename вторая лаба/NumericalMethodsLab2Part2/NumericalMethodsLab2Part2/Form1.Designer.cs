namespace NumericalMethodsLab2Part2
{
    partial class Task2
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainZedgraphControl = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.EpsilonRight = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.EpsilonLeft = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.N0TextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.xRightValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.xLeftValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.YLastTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.XLastTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ResponseTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ErrorTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.PlotButton = new System.Windows.Forms.Button();
            this.GenerateDataButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "y_1\'(x) = ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MainZedgraphControl);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(814, 618);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Графики решений";
            // 
            // MainZedgraphControl
            // 
            this.MainZedgraphControl.Location = new System.Drawing.Point(6, 19);
            this.MainZedgraphControl.Name = "MainZedgraphControl";
            this.MainZedgraphControl.ScrollGrace = 0D;
            this.MainZedgraphControl.ScrollMaxX = 0D;
            this.MainZedgraphControl.ScrollMaxY = 0D;
            this.MainZedgraphControl.ScrollMaxY2 = 0D;
            this.MainZedgraphControl.ScrollMinX = 0D;
            this.MainZedgraphControl.ScrollMinY = 0D;
            this.MainZedgraphControl.ScrollMinY2 = 0D;
            this.MainZedgraphControl.Size = new System.Drawing.Size(802, 593);
            this.MainZedgraphControl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.EpsilonRight);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.EpsilonLeft);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.N0TextBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.xRightValue);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.xLeftValue);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(832, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 165);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Входные данные";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(233, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Начальные условия:";
            // 
            // EpsilonRight
            // 
            this.EpsilonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EpsilonRight.Location = new System.Drawing.Point(173, 134);
            this.EpsilonRight.Name = "EpsilonRight";
            this.EpsilonRight.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EpsilonRight.Size = new System.Drawing.Size(49, 22);
            this.EpsilonRight.TabIndex = 21;
            this.EpsilonRight.Text = "10";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(142, 134);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(25, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "E-";
            // 
            // EpsilonLeft
            // 
            this.EpsilonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EpsilonLeft.Location = new System.Drawing.Point(87, 134);
            this.EpsilonLeft.Name = "EpsilonLeft";
            this.EpsilonLeft.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.EpsilonLeft.Size = new System.Drawing.Size(49, 22);
            this.EpsilonLeft.TabIndex = 19;
            this.EpsilonLeft.Text = "4";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(9, 134);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(85, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "epsilon0 = ";
            // 
            // N0TextBox
            // 
            this.N0TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.N0TextBox.Location = new System.Drawing.Point(288, 93);
            this.N0TextBox.Name = "N0TextBox";
            this.N0TextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.N0TextBox.Size = new System.Drawing.Size(49, 26);
            this.N0TextBox.TabIndex = 17;
            this.N0TextBox.Text = "4";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(238, 97);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label12.Size = new System.Drawing.Size(44, 20);
            this.label12.TabIndex = 16;
            this.label12.Text = "n0 = ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(109, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "b";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(42, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 16);
            this.label11.TabIndex = 14;
            this.label11.Text = "a";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(336, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "z(0) = 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(269, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "y(0) = 1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(130, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "]";
            // 
            // xRightValue
            // 
            this.xRightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xRightValue.Location = new System.Drawing.Point(96, 97);
            this.xRightValue.Name = "xRightValue";
            this.xRightValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.xRightValue.Size = new System.Drawing.Size(28, 22);
            this.xRightValue.TabIndex = 8;
            this.xRightValue.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(79, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = ";";
            // 
            // xLeftValue
            // 
            this.xLeftValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xLeftValue.Location = new System.Drawing.Point(45, 97);
            this.xLeftValue.Name = "xLeftValue";
            this.xLeftValue.ReadOnly = true;
            this.xLeftValue.Size = new System.Drawing.Size(28, 22);
            this.xLeftValue.TabIndex = 6;
            this.xLeftValue.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "x : [";
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(90, 46);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(121, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "z^2/y - zx/(x^2+1)";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(90, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(121, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "y_2\'(x) =  ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.YLastTextBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.XLastTextBox);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.ResponseTextBox);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.ErrorTextBox);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.PlotButton);
            this.groupBox3.Controls.Add(this.GenerateDataButton);
            this.groupBox3.Location = new System.Drawing.Point(832, 183);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(444, 447);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Генерация данных и выходные данные";
            // 
            // YLastTextBox
            // 
            this.YLastTextBox.Location = new System.Drawing.Point(237, 172);
            this.YLastTextBox.Name = "YLastTextBox";
            this.YLastTextBox.ReadOnly = true;
            this.YLastTextBox.Size = new System.Drawing.Size(196, 20);
            this.YLastTextBox.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(6, 172);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(225, 32);
            this.label15.TabIndex = 30;
            this.label15.Text = "Значение Y полученное \r\nв конце отрезка интегрирования";
            // 
            // XLastTextBox
            // 
            this.XLastTextBox.Location = new System.Drawing.Point(237, 137);
            this.XLastTextBox.Name = "XLastTextBox";
            this.XLastTextBox.ReadOnly = true;
            this.XLastTextBox.Size = new System.Drawing.Size(196, 20);
            this.XLastTextBox.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(6, 125);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(225, 32);
            this.label16.TabIndex = 28;
            this.label16.Text = "Значение X полученное \r\nв конце отрезка интегрирования";
            // 
            // ResponseTextBox
            // 
            this.ResponseTextBox.Location = new System.Drawing.Point(191, 91);
            this.ResponseTextBox.Name = "ResponseTextBox";
            this.ResponseTextBox.ReadOnly = true;
            this.ResponseTextBox.Size = new System.Drawing.Size(242, 20);
            this.ResponseTextBox.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(6, 93);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(179, 18);
            this.label17.TabIndex = 26;
            this.label17.Text = "Индикатор ошибки Error";
            // 
            // ErrorTextBox
            // 
            this.ErrorTextBox.Location = new System.Drawing.Point(191, 65);
            this.ErrorTextBox.Name = "ErrorTextBox";
            this.ErrorTextBox.ReadOnly = true;
            this.ErrorTextBox.Size = new System.Drawing.Size(242, 20);
            this.ErrorTextBox.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(6, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 18);
            this.label18.TabIndex = 24;
            this.label18.Text = "Погрешность";
            // 
            // PlotButton
            // 
            this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlotButton.Location = new System.Drawing.Point(241, 19);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(197, 28);
            this.PlotButton.TabIndex = 23;
            this.PlotButton.Text = "Построить график";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // GenerateDataButton
            // 
            this.GenerateDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateDataButton.Location = new System.Drawing.Point(16, 19);
            this.GenerateDataButton.Name = "GenerateDataButton";
            this.GenerateDataButton.Size = new System.Drawing.Size(195, 28);
            this.GenerateDataButton.TabIndex = 22;
            this.GenerateDataButton.Text = "Сгенерировать данные";
            this.GenerateDataButton.UseVisualStyleBackColor = true;
            this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 642);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Task2";
            this.Text = "Задача 2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox xLeftValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox xRightValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox EpsilonRight;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox EpsilonLeft;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox N0TextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.Button GenerateDataButton;
        private ZedGraph.ZedGraphControl MainZedgraphControl;
        private System.Windows.Forms.TextBox YLastTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox XLastTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ResponseTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox ErrorTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
    }
}

