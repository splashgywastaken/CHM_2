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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ZGraphControl = new ZedGraph.ZedGraphControl();
            this.YGraphControl = new ZedGraph.ZedGraphControl();
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
            this.PlotButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.GenerateDataButton = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ZErrorTextBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.ZLastTextBox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ZGraph3 = new System.Windows.Forms.CheckBox();
            this.ZGraph2 = new System.Windows.Forms.CheckBox();
            this.ZGraph1 = new System.Windows.Forms.CheckBox();
            this.YGraph3 = new System.Windows.Forms.CheckBox();
            this.YGraph2 = new System.Windows.Forms.CheckBox();
            this.YGraph1 = new System.Windows.Forms.CheckBox();
            this.HTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.OnTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.YLastTextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.XLastTextBox = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.ResponseTextBox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.YErrorTextBox = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(53, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "y\'(x) = ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(12, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1003, 528);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Графики решений";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ZGraphControl, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.YGraphControl, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(991, 512);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ZGraphControl
            // 
            this.ZGraphControl.Location = new System.Drawing.Point(498, 3);
            this.ZGraphControl.Name = "ZGraphControl";
            this.ZGraphControl.ScrollGrace = 0D;
            this.ZGraphControl.ScrollMaxX = 0D;
            this.ZGraphControl.ScrollMaxY = 0D;
            this.ZGraphControl.ScrollMaxY2 = 0D;
            this.ZGraphControl.ScrollMinX = 0D;
            this.ZGraphControl.ScrollMinY = 0D;
            this.ZGraphControl.ScrollMinY2 = 0D;
            this.ZGraphControl.Size = new System.Drawing.Size(489, 506);
            this.ZGraphControl.TabIndex = 1;
            // 
            // YGraphControl
            // 
            this.YGraphControl.Location = new System.Drawing.Point(3, 3);
            this.YGraphControl.Name = "YGraphControl";
            this.YGraphControl.ScrollGrace = 0D;
            this.YGraphControl.ScrollMaxX = 0D;
            this.YGraphControl.ScrollMaxY = 0D;
            this.YGraphControl.ScrollMaxY2 = 0D;
            this.YGraphControl.ScrollMinX = 0D;
            this.YGraphControl.ScrollMinY = 0D;
            this.YGraphControl.ScrollMinY2 = 0D;
            this.YGraphControl.Size = new System.Drawing.Size(489, 506);
            this.YGraphControl.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clearButton);
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
            this.groupBox2.Controls.Add(this.PlotButton);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.GenerateDataButton);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1264, 84);
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
            this.EpsilonRight.Location = new System.Drawing.Point(807, 42);
            this.EpsilonRight.Name = "EpsilonRight";
            this.EpsilonRight.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.EpsilonRight.Size = new System.Drawing.Size(49, 22);
            this.EpsilonRight.TabIndex = 21;
            this.EpsilonRight.Text = "7";
            this.EpsilonRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(776, 42);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(25, 20);
            this.label14.TabIndex = 20;
            this.label14.Text = "E-";
            // 
            // EpsilonLeft
            // 
            this.EpsilonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EpsilonLeft.Location = new System.Drawing.Point(721, 42);
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
            this.label13.Location = new System.Drawing.Point(643, 42);
            this.label13.Name = "label13";
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label13.Size = new System.Drawing.Size(85, 20);
            this.label13.TabIndex = 18;
            this.label13.Text = "epsilon0 = ";
            // 
            // N0TextBox
            // 
            this.N0TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.N0TextBox.Location = new System.Drawing.Point(588, 40);
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
            this.label12.Location = new System.Drawing.Point(538, 44);
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
            this.label10.Location = new System.Drawing.Point(500, 25);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 16);
            this.label10.TabIndex = 15;
            this.label10.Text = "b";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(433, 25);
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
            this.label5.Location = new System.Drawing.Point(521, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "]";
            // 
            // xRightValue
            // 
            this.xRightValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xRightValue.Location = new System.Drawing.Point(487, 45);
            this.xRightValue.Name = "xRightValue";
            this.xRightValue.Size = new System.Drawing.Size(28, 22);
            this.xRightValue.TabIndex = 8;
            this.xRightValue.Text = "1";
            this.xRightValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(470, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = ";";
            // 
            // xLeftValue
            // 
            this.xLeftValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.xLeftValue.Location = new System.Drawing.Point(436, 45);
            this.xLeftValue.Name = "xLeftValue";
            this.xLeftValue.ReadOnly = true;
            this.xLeftValue.Size = new System.Drawing.Size(28, 22);
            this.xLeftValue.TabIndex = 6;
            this.xLeftValue.Text = "0";
            // 
            // PlotButton
            // 
            this.PlotButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlotButton.Location = new System.Drawing.Point(1094, 19);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(159, 28);
            this.PlotButton.TabIndex = 23;
            this.PlotButton.Text = "Построить график";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(404, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "x : [";
            // 
            // GenerateDataButton
            // 
            this.GenerateDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateDataButton.Location = new System.Drawing.Point(917, 19);
            this.GenerateDataButton.Name = "GenerateDataButton";
            this.GenerateDataButton.Size = new System.Drawing.Size(171, 28);
            this.GenerateDataButton.TabIndex = 22;
            this.GenerateDataButton.Text = "Сгенерировать данные";
            this.GenerateDataButton.UseVisualStyleBackColor = true;
            this.GenerateDataButton.Click += new System.EventHandler(this.GenerateDataButton_Click);
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
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "z\'(x) =  ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ZErrorTextBox);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.ZLastTextBox);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.ZGraph3);
            this.groupBox3.Controls.Add(this.ZGraph2);
            this.groupBox3.Controls.Add(this.ZGraph1);
            this.groupBox3.Controls.Add(this.YGraph3);
            this.groupBox3.Controls.Add(this.YGraph2);
            this.groupBox3.Controls.Add(this.YGraph1);
            this.groupBox3.Controls.Add(this.HTextBox);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.OnTextBox);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.YLastTextBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.XLastTextBox);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.ResponseTextBox);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.YErrorTextBox);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Location = new System.Drawing.Point(1021, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(255, 528);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Генерация данных и выходные данные";
            // 
            // ZErrorTextBox
            // 
            this.ZErrorTextBox.Location = new System.Drawing.Point(19, 80);
            this.ZErrorTextBox.Name = "ZErrorTextBox";
            this.ZErrorTextBox.ReadOnly = true;
            this.ZErrorTextBox.Size = new System.Drawing.Size(231, 20);
            this.ZErrorTextBox.TabIndex = 47;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(119, 61);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(130, 16);
            this.label23.TabIndex = 46;
            this.label23.Text = "Погрешность для Z";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(92, 445);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(156, 16);
            this.label22.TabIndex = 45;
            this.label22.Text = "Видимость графиков Z";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(92, 406);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(157, 16);
            this.label21.TabIndex = 44;
            this.label21.Text = "Видимость графиков Y";
            // 
            // ZLastTextBox
            // 
            this.ZLastTextBox.Location = new System.Drawing.Point(13, 299);
            this.ZLastTextBox.Name = "ZLastTextBox";
            this.ZLastTextBox.ReadOnly = true;
            this.ZLastTextBox.Size = new System.Drawing.Size(231, 20);
            this.ZLastTextBox.TabIndex = 43;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(19, 264);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(225, 32);
            this.label20.TabIndex = 42;
            this.label20.Text = "Значение Z полученное \r\nв конце отрезка интегрирования";
            // 
            // ZGraph3
            // 
            this.ZGraph3.AutoSize = true;
            this.ZGraph3.Checked = true;
            this.ZGraph3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZGraph3.Location = new System.Drawing.Point(176, 464);
            this.ZGraph3.Name = "ZGraph3";
            this.ZGraph3.Size = new System.Drawing.Size(73, 17);
            this.ZGraph3.TabIndex = 41;
            this.ZGraph3.Text = "График 3";
            this.ZGraph3.UseVisualStyleBackColor = true;
            this.ZGraph3.CheckedChanged += new System.EventHandler(this.ZGraph3_CheckedChanged);
            // 
            // ZGraph2
            // 
            this.ZGraph2.AutoSize = true;
            this.ZGraph2.Checked = true;
            this.ZGraph2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZGraph2.Location = new System.Drawing.Point(97, 464);
            this.ZGraph2.Name = "ZGraph2";
            this.ZGraph2.Size = new System.Drawing.Size(73, 17);
            this.ZGraph2.TabIndex = 40;
            this.ZGraph2.Text = "График 2";
            this.ZGraph2.UseVisualStyleBackColor = true;
            this.ZGraph2.CheckedChanged += new System.EventHandler(this.ZGraph2_CheckedChanged);
            // 
            // ZGraph1
            // 
            this.ZGraph1.AutoSize = true;
            this.ZGraph1.Checked = true;
            this.ZGraph1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ZGraph1.Location = new System.Drawing.Point(18, 464);
            this.ZGraph1.Name = "ZGraph1";
            this.ZGraph1.Size = new System.Drawing.Size(73, 17);
            this.ZGraph1.TabIndex = 39;
            this.ZGraph1.Text = "График 1";
            this.ZGraph1.UseVisualStyleBackColor = true;
            this.ZGraph1.CheckedChanged += new System.EventHandler(this.ZGraph1_CheckedChanged);
            // 
            // YGraph3
            // 
            this.YGraph3.AutoSize = true;
            this.YGraph3.Checked = true;
            this.YGraph3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YGraph3.Location = new System.Drawing.Point(176, 425);
            this.YGraph3.Name = "YGraph3";
            this.YGraph3.Size = new System.Drawing.Size(73, 17);
            this.YGraph3.TabIndex = 38;
            this.YGraph3.Text = "График 3";
            this.YGraph3.UseVisualStyleBackColor = true;
            this.YGraph3.CheckedChanged += new System.EventHandler(this.YGraph3_CheckedChanged);
            // 
            // YGraph2
            // 
            this.YGraph2.AutoSize = true;
            this.YGraph2.Checked = true;
            this.YGraph2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YGraph2.Location = new System.Drawing.Point(97, 425);
            this.YGraph2.Name = "YGraph2";
            this.YGraph2.Size = new System.Drawing.Size(73, 17);
            this.YGraph2.TabIndex = 37;
            this.YGraph2.Text = "График 2";
            this.YGraph2.UseVisualStyleBackColor = true;
            this.YGraph2.CheckedChanged += new System.EventHandler(this.YGraph2_CheckedChanged);
            // 
            // YGraph1
            // 
            this.YGraph1.AutoSize = true;
            this.YGraph1.Checked = true;
            this.YGraph1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.YGraph1.Location = new System.Drawing.Point(18, 425);
            this.YGraph1.Name = "YGraph1";
            this.YGraph1.Size = new System.Drawing.Size(73, 17);
            this.YGraph1.TabIndex = 36;
            this.YGraph1.Text = "График 1";
            this.YGraph1.UseVisualStyleBackColor = true;
            this.YGraph1.CheckedChanged += new System.EventHandler(this.YGraph1_CheckedChanged);
            // 
            // HTextBox
            // 
            this.HTextBox.Location = new System.Drawing.Point(18, 383);
            this.HTextBox.Name = "HTextBox";
            this.HTextBox.ReadOnly = true;
            this.HTextBox.Size = new System.Drawing.Size(231, 20);
            this.HTextBox.TabIndex = 35;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(45, 364);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(204, 16);
            this.label19.TabIndex = 34;
            this.label19.Text = "Значение минимального шага";
            // 
            // OnTextBox
            // 
            this.OnTextBox.Location = new System.Drawing.Point(18, 341);
            this.OnTextBox.Name = "OnTextBox";
            this.OnTextBox.ReadOnly = true;
            this.OnTextBox.Size = new System.Drawing.Size(231, 20);
            this.OnTextBox.TabIndex = 33;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(149, 322);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "Значение O(n)";
            // 
            // YLastTextBox
            // 
            this.YLastTextBox.Location = new System.Drawing.Point(18, 238);
            this.YLastTextBox.Name = "YLastTextBox";
            this.YLastTextBox.ReadOnly = true;
            this.YLastTextBox.Size = new System.Drawing.Size(231, 20);
            this.YLastTextBox.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(24, 203);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(225, 32);
            this.label15.TabIndex = 30;
            this.label15.Text = "Значение Y полученное \r\nв конце отрезка интегрирования";
            // 
            // XLastTextBox
            // 
            this.XLastTextBox.Location = new System.Drawing.Point(18, 180);
            this.XLastTextBox.Name = "XLastTextBox";
            this.XLastTextBox.ReadOnly = true;
            this.XLastTextBox.Size = new System.Drawing.Size(231, 20);
            this.XLastTextBox.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(24, 145);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(225, 32);
            this.label16.TabIndex = 28;
            this.label16.Text = "Значение X полученное \r\nв конце отрезка интегрирования";
            // 
            // ResponseTextBox
            // 
            this.ResponseTextBox.Location = new System.Drawing.Point(18, 122);
            this.ResponseTextBox.Name = "ResponseTextBox";
            this.ResponseTextBox.ReadOnly = true;
            this.ResponseTextBox.Size = new System.Drawing.Size(231, 20);
            this.ResponseTextBox.TabIndex = 27;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(87, 103);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(162, 16);
            this.label17.TabIndex = 26;
            this.label17.Text = "Индикатор ошибки Error";
            // 
            // YErrorTextBox
            // 
            this.YErrorTextBox.Location = new System.Drawing.Point(18, 38);
            this.YErrorTextBox.Name = "YErrorTextBox";
            this.YErrorTextBox.ReadOnly = true;
            this.YErrorTextBox.Size = new System.Drawing.Size(231, 20);
            this.YErrorTextBox.TabIndex = 25;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(119, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 16);
            this.label18.TabIndex = 24;
            this.label18.Text = "Погрешность для Y";
            // 
            // clearButton
            // 
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(1094, 53);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(159, 23);
            this.clearButton.TabIndex = 24;
            this.clearButton.Text = "Очистить память";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
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
            this.tableLayoutPanel1.ResumeLayout(false);
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
        private System.Windows.Forms.TextBox YLastTextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox XLastTextBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox ResponseTextBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox YErrorTextBox;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox HTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox OnTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox ZLastTextBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox ZGraph3;
        private System.Windows.Forms.CheckBox ZGraph2;
        private System.Windows.Forms.CheckBox ZGraph1;
        private System.Windows.Forms.CheckBox YGraph3;
        private System.Windows.Forms.CheckBox YGraph2;
        private System.Windows.Forms.CheckBox YGraph1;
        private System.Windows.Forms.TextBox ZErrorTextBox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private ZedGraph.ZedGraphControl ZGraphControl;
        private ZedGraph.ZedGraphControl YGraphControl;
        private System.Windows.Forms.Button clearButton;
    }
}

