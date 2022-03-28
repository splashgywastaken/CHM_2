namespace NumericalMethodsLab1Part3
{
    partial class CubicSplineForm
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
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.IsUniformCheckBox = new System.Windows.Forms.CheckBox();
            this.funcCombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BuildSplineButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.BTextBox = new System.Windows.Forms.TextBox();
            this.ATextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ErrorGraph = new ZedGraph.ZedGraphControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rightConditionTextBox = new System.Windows.Forms.TextBox();
            this.leftConditionTextBox = new System.Windows.Forms.TextBox();
            this.conditionRightLabel = new System.Windows.Forms.Label();
            this.conditionLeftLabel = new System.Windows.Forms.Label();
            this.conditionLeftTrackBar = new System.Windows.Forms.TrackBar();
            this.conditionRightTrackBar = new System.Windows.Forms.TrackBar();
            this.PolynomialGraph = new ZedGraph.ZedGraphControl();
            this.setGraphSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorPointsToShowPercentageTextBox = new System.Windows.Forms.TextBox();
            this.errorPointsToShowTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conditionLeftTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionRightTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPointsToShowTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorPointsToShowTrackBar);
            this.groupBox1.Controls.Add(this.errorPointsToShowPercentageTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.setGraphSizeCheckBox);
            this.groupBox1.Controls.Add(this.errorTextBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.IsUniformCheckBox);
            this.groupBox1.Controls.Add(this.funcCombobox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.BuildSplineButton);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.NTextBox);
            this.groupBox1.Controls.Add(this.BTextBox);
            this.groupBox1.Controls.Add(this.ATextBox);
            this.groupBox1.Location = new System.Drawing.Point(890, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(492, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры";
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(97, 213);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(297, 20);
            this.errorTextBox.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Погрешность = ";
            // 
            // IsUniformCheckBox
            // 
            this.IsUniformCheckBox.AutoSize = true;
            this.IsUniformCheckBox.Checked = true;
            this.IsUniformCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsUniformCheckBox.Location = new System.Drawing.Point(196, 128);
            this.IsUniformCheckBox.Name = "IsUniformCheckBox";
            this.IsUniformCheckBox.Size = new System.Drawing.Size(198, 30);
            this.IsUniformCheckBox.TabIndex = 5;
            this.IsUniformCheckBox.Text = "Заполнить значения равномерно \r\n(иначе Чебышевым)\r\n";
            this.IsUniformCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IsUniformCheckBox.UseVisualStyleBackColor = true;
            // 
            // funcCombobox
            // 
            this.funcCombobox.FormattingEnabled = true;
            this.funcCombobox.Items.AddRange(new object[] {
            "16 + x - 2x^2 + 3x^3",
            "2cos(x) - sin(x)",
            "cos(pi*x) + e^(-1/x)",
            "x^2 + 2x"});
            this.funcCombobox.Location = new System.Drawing.Point(110, 101);
            this.funcCombobox.Name = "funcCombobox";
            this.funcCombobox.Size = new System.Drawing.Size(283, 21);
            this.funcCombobox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(308, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Выбор функции";
            // 
            // BuildSplineButton
            // 
            this.BuildSplineButton.Location = new System.Drawing.Point(209, 170);
            this.BuildSplineButton.Name = "BuildSplineButton";
            this.BuildSplineButton.Size = new System.Drawing.Size(184, 37);
            this.BuildSplineButton.TabIndex = 13;
            this.BuildSplineButton.Text = "Построить сплайн";
            this.BuildSplineButton.UseVisualStyleBackColor = true;
            this.BuildSplineButton.Click += new System.EventHandler(this.BuildSplineButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "n (кол-во подотрезков) = ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "b (конец отрезка) = ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "a (начало отрезка) = ";
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(147, 68);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(100, 20);
            this.NTextBox.TabIndex = 2;
            // 
            // BTextBox
            // 
            this.BTextBox.Location = new System.Drawing.Point(147, 42);
            this.BTextBox.Name = "BTextBox";
            this.BTextBox.Size = new System.Drawing.Size(100, 20);
            this.BTextBox.TabIndex = 1;
            // 
            // ATextBox
            // 
            this.ATextBox.Location = new System.Drawing.Point(147, 16);
            this.ATextBox.Name = "ATextBox";
            this.ATextBox.Size = new System.Drawing.Size(100, 20);
            this.ATextBox.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ErrorGraph);
            this.groupBox2.Location = new System.Drawing.Point(890, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(492, 379);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Погрешность";
            // 
            // ErrorGraph
            // 
            this.ErrorGraph.Location = new System.Drawing.Point(21, 19);
            this.ErrorGraph.Name = "ErrorGraph";
            this.ErrorGraph.ScrollGrace = 0D;
            this.ErrorGraph.ScrollMaxX = 0D;
            this.ErrorGraph.ScrollMaxY = 0D;
            this.ErrorGraph.ScrollMaxY2 = 0D;
            this.ErrorGraph.ScrollMinX = 0D;
            this.ErrorGraph.ScrollMinY = 0D;
            this.ErrorGraph.ScrollMinY2 = 0D;
            this.ErrorGraph.Size = new System.Drawing.Size(458, 354);
            this.ErrorGraph.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rightConditionTextBox);
            this.groupBox3.Controls.Add(this.leftConditionTextBox);
            this.groupBox3.Controls.Add(this.conditionRightLabel);
            this.groupBox3.Controls.Add(this.conditionLeftLabel);
            this.groupBox3.Controls.Add(this.conditionLeftTrackBar);
            this.groupBox3.Controls.Add(this.conditionRightTrackBar);
            this.groupBox3.Controls.Add(this.PolynomialGraph);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(872, 689);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Полином";
            // 
            // rightConditionTextBox
            // 
            this.rightConditionTextBox.Location = new System.Drawing.Point(84, 648);
            this.rightConditionTextBox.Name = "rightConditionTextBox";
            this.rightConditionTextBox.Size = new System.Drawing.Size(51, 20);
            this.rightConditionTextBox.TabIndex = 9;
            this.rightConditionTextBox.Text = "0";
            // 
            // leftConditionTextBox
            // 
            this.leftConditionTextBox.Location = new System.Drawing.Point(84, 602);
            this.leftConditionTextBox.Name = "leftConditionTextBox";
            this.leftConditionTextBox.Size = new System.Drawing.Size(51, 20);
            this.leftConditionTextBox.TabIndex = 8;
            this.leftConditionTextBox.Text = "0";
            this.leftConditionTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // conditionRightLabel
            // 
            this.conditionRightLabel.AutoSize = true;
            this.conditionRightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conditionRightLabel.Location = new System.Drawing.Point(9, 648);
            this.conditionRightLabel.Name = "conditionRightLabel";
            this.conditionRightLabel.Size = new System.Drawing.Size(69, 20);
            this.conditionRightLabel.TabIndex = 4;
            this.conditionRightLabel.Text = "S\'\'(xn) = ";
            // 
            // conditionLeftLabel
            // 
            this.conditionLeftLabel.AutoSize = true;
            this.conditionLeftLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.conditionLeftLabel.Location = new System.Drawing.Point(6, 600);
            this.conditionLeftLabel.Name = "conditionLeftLabel";
            this.conditionLeftLabel.Size = new System.Drawing.Size(72, 20);
            this.conditionLeftLabel.TabIndex = 3;
            this.conditionLeftLabel.Text = "S\'\'\'(x0) = ";
            this.conditionLeftLabel.Click += new System.EventHandler(this.conditionLeftLabel_Click);
            // 
            // conditionLeftTrackBar
            // 
            this.conditionLeftTrackBar.Location = new System.Drawing.Point(141, 587);
            this.conditionLeftTrackBar.Maximum = 1000;
            this.conditionLeftTrackBar.Name = "conditionLeftTrackBar";
            this.conditionLeftTrackBar.Size = new System.Drawing.Size(725, 45);
            this.conditionLeftTrackBar.TabIndex = 6;
            this.conditionLeftTrackBar.Scroll += new System.EventHandler(this.conditionLeftTrackBar_Scroll);
            // 
            // conditionRightTrackBar
            // 
            this.conditionRightTrackBar.Location = new System.Drawing.Point(141, 638);
            this.conditionRightTrackBar.Maximum = 1000;
            this.conditionRightTrackBar.Name = "conditionRightTrackBar";
            this.conditionRightTrackBar.Size = new System.Drawing.Size(725, 45);
            this.conditionRightTrackBar.SmallChange = 0;
            this.conditionRightTrackBar.TabIndex = 7;
            this.conditionRightTrackBar.Scroll += new System.EventHandler(this.conditionRightTrackBar_Scroll);
            // 
            // PolynomialGraph
            // 
            this.PolynomialGraph.Location = new System.Drawing.Point(6, 19);
            this.PolynomialGraph.Name = "PolynomialGraph";
            this.PolynomialGraph.ScrollGrace = 0D;
            this.PolynomialGraph.ScrollMaxX = 0D;
            this.PolynomialGraph.ScrollMaxY = 0D;
            this.PolynomialGraph.ScrollMaxY2 = 0D;
            this.PolynomialGraph.ScrollMinX = 0D;
            this.PolynomialGraph.ScrollMinY = 0D;
            this.PolynomialGraph.ScrollMinY2 = 0D;
            this.PolynomialGraph.Size = new System.Drawing.Size(860, 566);
            this.PolynomialGraph.TabIndex = 0;
            this.PolynomialGraph.Load += new System.EventHandler(this.PolynomialGraph_Load);
            // 
            // setGraphSizeCheckBox
            // 
            this.setGraphSizeCheckBox.AutoSize = true;
            this.setGraphSizeCheckBox.Checked = true;
            this.setGraphSizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.setGraphSizeCheckBox.Location = new System.Drawing.Point(4, 174);
            this.setGraphSizeCheckBox.Name = "setGraphSizeCheckBox";
            this.setGraphSizeCheckBox.Size = new System.Drawing.Size(193, 30);
            this.setGraphSizeCheckBox.TabIndex = 19;
            this.setGraphSizeCheckBox.Text = "Устанавливать автоматический \r\nмасштаб в графиках";
            this.setGraphSizeCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(350, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Сколько точек (в процентах) отображать на графике погрешностей";
            // 
            // errorPointsToShowPercentageTextBox
            // 
            this.errorPointsToShowPercentageTextBox.Location = new System.Drawing.Point(363, 239);
            this.errorPointsToShowPercentageTextBox.Name = "errorPointsToShowPercentageTextBox";
            this.errorPointsToShowPercentageTextBox.ReadOnly = true;
            this.errorPointsToShowPercentageTextBox.Size = new System.Drawing.Size(100, 20);
            this.errorPointsToShowPercentageTextBox.TabIndex = 21;
            this.errorPointsToShowPercentageTextBox.Text = "100";
            // 
            // errorPointsToShowTrackBar
            // 
            this.errorPointsToShowTrackBar.Location = new System.Drawing.Point(4, 259);
            this.errorPointsToShowTrackBar.Maximum = 100;
            this.errorPointsToShowTrackBar.Minimum = 1;
            this.errorPointsToShowTrackBar.Name = "errorPointsToShowTrackBar";
            this.errorPointsToShowTrackBar.Size = new System.Drawing.Size(488, 45);
            this.errorPointsToShowTrackBar.TabIndex = 22;
            this.errorPointsToShowTrackBar.Value = 100;
            this.errorPointsToShowTrackBar.Scroll += new System.EventHandler(this.errorPointsToShowTrackBar_Scroll);
            // 
            // CubicSplineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 719);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CubicSplineForm";
            this.Text = "Построение кубического сплайна";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conditionLeftTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionRightTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPointsToShowTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl ErrorGraph;
        private ZedGraph.ZedGraphControl PolynomialGraph;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.TextBox BTextBox;
        private System.Windows.Forms.TextBox ATextBox;
        private System.Windows.Forms.Button BuildSplineButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox funcCombobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox IsUniformCheckBox;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label conditionRightLabel;
        private System.Windows.Forms.Label conditionLeftLabel;
        private System.Windows.Forms.TrackBar conditionLeftTrackBar;
        private System.Windows.Forms.TrackBar conditionRightTrackBar;
        private System.Windows.Forms.TextBox leftConditionTextBox;
        private System.Windows.Forms.TextBox rightConditionTextBox;
        private System.Windows.Forms.CheckBox setGraphSizeCheckBox;
        private System.Windows.Forms.TrackBar errorPointsToShowTrackBar;
        private System.Windows.Forms.TextBox errorPointsToShowPercentageTextBox;
        private System.Windows.Forms.Label label4;
    }
}

