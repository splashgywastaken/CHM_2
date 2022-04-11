namespace NumericalMethodsLab2Part1
{
    partial class FirstTaskForm
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
            this.GraphsGroupBox = new System.Windows.Forms.GroupBox();
            this.ZedgraphControl = new ZedGraph.ZedGraphControl();
            this.InputGroupBox = new System.Windows.Forms.GroupBox();
            this.epsilonPower = new System.Windows.Forms.TextBox();
            this.epsilonNum = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PlotButton = new System.Windows.Forms.Button();
            this.SolveButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BaseConditionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.IntervalRightValueTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IntervalLeftValueTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FunctionComboBox = new System.Windows.Forms.ComboBox();
            this.OutputGroupBox = new System.Windows.Forms.GroupBox();
            this.YLastTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.XLastTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.responseTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errrorTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.OnTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.HTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.GraphsGroupBox.SuspendLayout();
            this.InputGroupBox.SuspendLayout();
            this.OutputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphsGroupBox
            // 
            this.GraphsGroupBox.Controls.Add(this.ZedgraphControl);
            this.GraphsGroupBox.Location = new System.Drawing.Point(12, 12);
            this.GraphsGroupBox.Name = "GraphsGroupBox";
            this.GraphsGroupBox.Size = new System.Drawing.Size(879, 714);
            this.GraphsGroupBox.TabIndex = 0;
            this.GraphsGroupBox.TabStop = false;
            this.GraphsGroupBox.Text = "Графики";
            // 
            // ZedgraphControl
            // 
            this.ZedgraphControl.Location = new System.Drawing.Point(6, 16);
            this.ZedgraphControl.Name = "ZedgraphControl";
            this.ZedgraphControl.ScrollGrace = 0D;
            this.ZedgraphControl.ScrollMaxX = 0D;
            this.ZedgraphControl.ScrollMaxY = 0D;
            this.ZedgraphControl.ScrollMaxY2 = 0D;
            this.ZedgraphControl.ScrollMinX = 0D;
            this.ZedgraphControl.ScrollMinY = 0D;
            this.ZedgraphControl.ScrollMinY2 = 0D;
            this.ZedgraphControl.Size = new System.Drawing.Size(867, 692);
            this.ZedgraphControl.TabIndex = 0;
            // 
            // InputGroupBox
            // 
            this.InputGroupBox.Controls.Add(this.epsilonPower);
            this.InputGroupBox.Controls.Add(this.epsilonNum);
            this.InputGroupBox.Controls.Add(this.label8);
            this.InputGroupBox.Controls.Add(this.PlotButton);
            this.InputGroupBox.Controls.Add(this.SolveButton);
            this.InputGroupBox.Controls.Add(this.label7);
            this.InputGroupBox.Controls.Add(this.NTextBox);
            this.InputGroupBox.Controls.Add(this.label6);
            this.InputGroupBox.Controls.Add(this.BaseConditionTextBox);
            this.InputGroupBox.Controls.Add(this.label5);
            this.InputGroupBox.Controls.Add(this.IntervalRightValueTextBox);
            this.InputGroupBox.Controls.Add(this.label4);
            this.InputGroupBox.Controls.Add(this.IntervalLeftValueTextBox);
            this.InputGroupBox.Controls.Add(this.label3);
            this.InputGroupBox.Controls.Add(this.label2);
            this.InputGroupBox.Controls.Add(this.label1);
            this.InputGroupBox.Controls.Add(this.FunctionComboBox);
            this.InputGroupBox.Location = new System.Drawing.Point(897, 12);
            this.InputGroupBox.Name = "InputGroupBox";
            this.InputGroupBox.Size = new System.Drawing.Size(254, 347);
            this.InputGroupBox.TabIndex = 1;
            this.InputGroupBox.TabStop = false;
            this.InputGroupBox.Text = "Ввод данных";
            // 
            // epsilonPower
            // 
            this.epsilonPower.Location = new System.Drawing.Point(145, 214);
            this.epsilonPower.Name = "epsilonPower";
            this.epsilonPower.Size = new System.Drawing.Size(103, 20);
            this.epsilonPower.TabIndex = 7;
            // 
            // epsilonNum
            // 
            this.epsilonNum.Location = new System.Drawing.Point(6, 214);
            this.epsilonNum.Name = "epsilonNum";
            this.epsilonNum.Size = new System.Drawing.Size(102, 20);
            this.epsilonNum.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(114, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "E-";
            // 
            // PlotButton
            // 
            this.PlotButton.Location = new System.Drawing.Point(6, 297);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(242, 44);
            this.PlotButton.TabIndex = 9;
            this.PlotButton.Text = "Построить графики";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(6, 247);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(242, 44);
            this.SolveButton.TabIndex = 8;
            this.SolveButton.Text = "Решить задачу";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "epsilon0 = ";
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(52, 165);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(196, 20);
            this.NTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(7, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 9;
            this.label6.Text = "n0 = ";
            // 
            // BaseConditionTextBox
            // 
            this.BaseConditionTextBox.Location = new System.Drawing.Point(52, 139);
            this.BaseConditionTextBox.Name = "BaseConditionTextBox";
            this.BaseConditionTextBox.Size = new System.Drawing.Size(196, 20);
            this.BaseConditionTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(7, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "y0 = ";
            // 
            // IntervalRightValueTextBox
            // 
            this.IntervalRightValueTextBox.Location = new System.Drawing.Point(52, 113);
            this.IntervalRightValueTextBox.Name = "IntervalRightValueTextBox";
            this.IntervalRightValueTextBox.Size = new System.Drawing.Size(196, 20);
            this.IntervalRightValueTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "b  = ";
            // 
            // IntervalLeftValueTextBox
            // 
            this.IntervalLeftValueTextBox.Location = new System.Drawing.Point(52, 87);
            this.IntervalLeftValueTextBox.Name = "IntervalLeftValueTextBox";
            this.IntervalLeftValueTextBox.Size = new System.Drawing.Size(196, 20);
            this.IntervalLeftValueTextBox.TabIndex = 2;
            this.IntervalLeftValueTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "a  = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Значения для интервала:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выбор функции";
            // 
            // FunctionComboBox
            // 
            this.FunctionComboBox.FormattingEnabled = true;
            this.FunctionComboBox.Items.AddRange(new object[] {
            "y\' = x + y/8, y(1,2) = 2,1",
            "y\' = cos(y) / (2 + x) - 0,3y^2"});
            this.FunctionComboBox.Location = new System.Drawing.Point(6, 39);
            this.FunctionComboBox.Name = "FunctionComboBox";
            this.FunctionComboBox.Size = new System.Drawing.Size(242, 21);
            this.FunctionComboBox.TabIndex = 1;
            this.FunctionComboBox.SelectedIndexChanged += new System.EventHandler(this.FunctionComboBox_SelectedIndexChanged);
            // 
            // OutputGroupBox
            // 
            this.OutputGroupBox.Controls.Add(this.HTextBox);
            this.OutputGroupBox.Controls.Add(this.label14);
            this.OutputGroupBox.Controls.Add(this.checkBox4);
            this.OutputGroupBox.Controls.Add(this.checkBox3);
            this.OutputGroupBox.Controls.Add(this.checkBox2);
            this.OutputGroupBox.Controls.Add(this.checkBox1);
            this.OutputGroupBox.Controls.Add(this.OnTextBox);
            this.OutputGroupBox.Controls.Add(this.label13);
            this.OutputGroupBox.Controls.Add(this.YLastTextBox);
            this.OutputGroupBox.Controls.Add(this.label12);
            this.OutputGroupBox.Controls.Add(this.XLastTextBox);
            this.OutputGroupBox.Controls.Add(this.label11);
            this.OutputGroupBox.Controls.Add(this.responseTextBox);
            this.OutputGroupBox.Controls.Add(this.label10);
            this.OutputGroupBox.Controls.Add(this.errrorTextBox);
            this.OutputGroupBox.Controls.Add(this.label9);
            this.OutputGroupBox.Location = new System.Drawing.Point(897, 365);
            this.OutputGroupBox.Name = "OutputGroupBox";
            this.OutputGroupBox.Size = new System.Drawing.Size(254, 361);
            this.OutputGroupBox.TabIndex = 2;
            this.OutputGroupBox.TabStop = false;
            this.OutputGroupBox.Text = "Вывод данных";
            // 
            // YLastTextBox
            // 
            this.YLastTextBox.Location = new System.Drawing.Point(6, 235);
            this.YLastTextBox.Name = "YLastTextBox";
            this.YLastTextBox.ReadOnly = true;
            this.YLastTextBox.Size = new System.Drawing.Size(242, 20);
            this.YLastTextBox.TabIndex = 7;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(7, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(225, 32);
            this.label12.TabIndex = 6;
            this.label12.Text = "Значение Y полученное \r\nв конце отрезка интегрирования";
            // 
            // XLastTextBox
            // 
            this.XLastTextBox.Location = new System.Drawing.Point(6, 177);
            this.XLastTextBox.Name = "XLastTextBox";
            this.XLastTextBox.ReadOnly = true;
            this.XLastTextBox.Size = new System.Drawing.Size(242, 20);
            this.XLastTextBox.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(7, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(225, 32);
            this.label11.TabIndex = 4;
            this.label11.Text = "Значение X полученное \r\nв конце отрезка интегрирования";
            // 
            // responseTextBox
            // 
            this.responseTextBox.Location = new System.Drawing.Point(6, 77);
            this.responseTextBox.Name = "responseTextBox";
            this.responseTextBox.ReadOnly = true;
            this.responseTextBox.Size = new System.Drawing.Size(242, 20);
            this.responseTextBox.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(3, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(162, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Индикатор ошибки Error";
            // 
            // errrorTextBox
            // 
            this.errrorTextBox.Location = new System.Drawing.Point(6, 35);
            this.errrorTextBox.Name = "errrorTextBox";
            this.errrorTextBox.ReadOnly = true;
            this.errrorTextBox.Size = new System.Drawing.Size(242, 20);
            this.errrorTextBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Погрешность";
            // 
            // OnTextBox
            // 
            this.OnTextBox.Location = new System.Drawing.Point(6, 119);
            this.OnTextBox.Name = "OnTextBox";
            this.OnTextBox.ReadOnly = true;
            this.OnTextBox.Size = new System.Drawing.Size(242, 20);
            this.OnTextBox.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(3, 100);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "Значение O(n)";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(0, 315);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "График 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(145, 315);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(73, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "График 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(0, 338);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(73, 17);
            this.checkBox3.TabIndex = 12;
            this.checkBox3.Text = "График 3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Checked = true;
            this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox4.Location = new System.Drawing.Point(144, 337);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(73, 17);
            this.checkBox4.TabIndex = 13;
            this.checkBox4.Text = "График 4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // HTextBox
            // 
            this.HTextBox.Location = new System.Drawing.Point(6, 281);
            this.HTextBox.Name = "HTextBox";
            this.HTextBox.ReadOnly = true;
            this.HTextBox.Size = new System.Drawing.Size(242, 20);
            this.HTextBox.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(8, 258);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(204, 16);
            this.label14.TabIndex = 14;
            this.label14.Text = "Значение минимального шага";
            // 
            // FirstTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 738);
            this.Controls.Add(this.OutputGroupBox);
            this.Controls.Add(this.InputGroupBox);
            this.Controls.Add(this.GraphsGroupBox);
            this.Name = "FirstTaskForm";
            this.Text = "Первое задание";
            this.GraphsGroupBox.ResumeLayout(false);
            this.InputGroupBox.ResumeLayout(false);
            this.InputGroupBox.PerformLayout();
            this.OutputGroupBox.ResumeLayout(false);
            this.OutputGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GraphsGroupBox;
        private System.Windows.Forms.GroupBox InputGroupBox;
        private System.Windows.Forms.GroupBox OutputGroupBox;
        private ZedGraph.ZedGraphControl ZedgraphControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox FunctionComboBox;
        private System.Windows.Forms.TextBox IntervalLeftValueTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IntervalRightValueTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox BaseConditionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.TextBox epsilonPower;
        private System.Windows.Forms.TextBox epsilonNum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox XLastTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox responseTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox errrorTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox YLastTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox HTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox OnTextBox;
        private System.Windows.Forms.Label label13;
    }
}

