namespace NumericalMethodsLab1Part3
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PGraph = new ZedGraph.ZedGraphControl();
            this.ErrorGraph = new ZedGraph.ZedGraphControl();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.CompactTextBox = new System.Windows.Forms.TextBox();
            this.SATextBox = new System.Windows.Forms.TextBox();
            this.SBTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BuildSplineButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.funcCombobox = new System.Windows.Forms.ComboBox();
            this.IsUniformCheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.IsUniformCheckBox);
            this.groupBox1.Controls.Add(this.funcCombobox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BuildSplineButton);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.SBTextBox);
            this.groupBox1.Controls.Add(this.SATextBox);
            this.groupBox1.Controls.Add(this.CompactTextBox);
            this.groupBox1.Controls.Add(this.NTextBox);
            this.groupBox1.Controls.Add(this.BTextBox);
            this.groupBox1.Controls.Add(this.ATextBox);
            this.groupBox1.Location = new System.Drawing.Point(771, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 278);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ErrorGraph);
            this.groupBox2.Location = new System.Drawing.Point(771, 296);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 307);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Погрешность";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PGraph);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(753, 591);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Полином";
            // 
            // PGraph
            // 
            this.PGraph.Location = new System.Drawing.Point(6, 19);
            this.PGraph.Name = "PGraph";
            this.PGraph.ScrollGrace = 0D;
            this.PGraph.ScrollMaxX = 0D;
            this.PGraph.ScrollMaxY = 0D;
            this.PGraph.ScrollMaxY2 = 0D;
            this.PGraph.ScrollMinX = 0D;
            this.PGraph.ScrollMinY = 0D;
            this.PGraph.ScrollMinY2 = 0D;
            this.PGraph.Size = new System.Drawing.Size(741, 566);
            this.PGraph.TabIndex = 0;
            // 
            // ErrorGraph
            // 
            this.ErrorGraph.Location = new System.Drawing.Point(6, 19);
            this.ErrorGraph.Name = "ErrorGraph";
            this.ErrorGraph.ScrollGrace = 0D;
            this.ErrorGraph.ScrollMaxX = 0D;
            this.ErrorGraph.ScrollMaxY = 0D;
            this.ErrorGraph.ScrollMaxY2 = 0D;
            this.ErrorGraph.ScrollMinX = 0D;
            this.ErrorGraph.ScrollMinY = 0D;
            this.ErrorGraph.ScrollMinY2 = 0D;
            this.ErrorGraph.Size = new System.Drawing.Size(390, 282);
            this.ErrorGraph.TabIndex = 1;
            // 
            // ATextBox
            // 
            this.ATextBox.Location = new System.Drawing.Point(296, 19);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.Size = new System.Drawing.Size(100, 20);
            this.ATextBox.TabIndex = 0;
            // 
            // BTextBox
            // 
            this.BTextBox.Location = new System.Drawing.Point(296, 45);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(100, 20);
            this.BTextBox.TabIndex = 1;
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(296, 71);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(100, 20);
            this.NTextBox.TabIndex = 2;
            // 
            // CompactTextBox
            // 
            this.CompactTextBox.Location = new System.Drawing.Point(296, 97);
            this.CompactTextBox.Name = "CompactTextBox";
            this.CompactTextBox.Size = new System.Drawing.Size(100, 20);
            this.CompactTextBox.TabIndex = 3;
            // 
            // SATextBox
            // 
            this.SATextBox.Location = new System.Drawing.Point(296, 126);
            this.SATextBox.Name = "SATextBox";
            this.SATextBox.Size = new System.Drawing.Size(100, 20);
            this.SATextBox.TabIndex = 4;
            // 
            // SBTextBox
            // 
            this.SBTextBox.Location = new System.Drawing.Point(296, 152);
            this.SBTextBox.Name = "SBTextBox";
            this.SBTextBox.Size = new System.Drawing.Size(100, 20);
            this.SBTextBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(177, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "a (начало отрезка) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "b (конец отрезка) = ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "n (кол-во подотрезков) = ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(69, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 26);
            this.label4.TabIndex = 9;
            this.label4.Text = "Количество подотрезков \r\nна которые будет разбит каждый отрезок";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(250, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "S\'(a) = ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(250, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "S\'(b) = ";
            // 
            // BuildSplineButton
            // 
            this.BuildSplineButton.Location = new System.Drawing.Point(218, 201);
            this.BuildSplineButton.Name = "BuildSplineButton";
            this.BuildSplineButton.Size = new System.Drawing.Size(184, 37);
            this.BuildSplineButton.TabIndex = 13;
            this.BuildSplineButton.Text = "Построить сплайн";
            this.BuildSplineButton.UseVisualStyleBackColor = true;
            this.BuildSplineButton.Click += new System.EventHandler(this.BuildSplineButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Выбор функции";
            // 
            // funcCombobox
            // 
            this.funcCombobox.FormattingEnabled = true;
            this.funcCombobox.Items.AddRange(new object[] {
            "16 + x - 2x^2 + 3x^2",
            "2cos(x) - sin(x)",
            "cos(pi*x) + e^(-1/x)"});
            this.funcCombobox.Location = new System.Drawing.Point(7, 172);
            this.funcCombobox.Name = "funcCombobox";
            this.funcCombobox.Size = new System.Drawing.Size(283, 21);
            this.funcCombobox.TabIndex = 15;
            // 
            // IsUniformCheckBox
            // 
            this.IsUniformCheckBox.AutoSize = true;
            this.IsUniformCheckBox.Location = new System.Drawing.Point(9, 202);
            this.IsUniformCheckBox.Name = "IsUniformCheckBox";
            this.IsUniformCheckBox.Size = new System.Drawing.Size(198, 30);
            this.IsUniformCheckBox.TabIndex = 16;
            this.IsUniformCheckBox.Text = "Заполнить значения равномерно \r\n(иначе Чебышевым)\r\n";
            this.IsUniformCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsUniformCheckBox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 249);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Погрешность = ";
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(99, 246);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(297, 20);
            this.errorTextBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1185, 615);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl ErrorGraph;
        private ZedGraph.ZedGraphControl PGraph;
        private System.Windows.Forms.TextBox SBTextBox;
        private System.Windows.Forms.TextBox SATextBox;
        private System.Windows.Forms.TextBox CompactTextBox;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.Button BuildSplineButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox funcCombobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox IsUniformCheckBox;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label label8;
    }
}

