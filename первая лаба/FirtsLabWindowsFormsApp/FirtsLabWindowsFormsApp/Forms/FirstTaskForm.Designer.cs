namespace FirstLabWindowsFormsApp.Forms
{
    partial class FirstTaskForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ApproximationPlot = new ZedGraph.ZedGraphControl();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.plot = new System.Windows.Forms.Button();
            this.radioButtonUniform = new System.Windows.Forms.RadioButton();
            this.radioButtonChebushev = new System.Windows.Forms.RadioButton();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.coefficientsBox = new System.Windows.Forms.TextBox();
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ApproximationPlot
            // 
            this.ApproximationPlot.Location = new System.Drawing.Point(11, 12);
            this.ApproximationPlot.Name = "ApproximationPlot";
            this.ApproximationPlot.ScrollGrace = 0D;
            this.ApproximationPlot.ScrollMaxX = 0D;
            this.ApproximationPlot.ScrollMaxY = 0D;
            this.ApproximationPlot.ScrollMaxY2 = 0D;
            this.ApproximationPlot.ScrollMinX = 0D;
            this.ApproximationPlot.ScrollMinY = 0D;
            this.ApproximationPlot.ScrollMinY2 = 0D;
            this.ApproximationPlot.Size = new System.Drawing.Size(533, 426);
            this.ApproximationPlot.TabIndex = 0;
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(578, 31);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(210, 20);
            this.aTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "a =";
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(553, 260);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(238, 34);
            this.generate.TabIndex = 6;
            this.generate.Text = "Сгенерировать";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "b =";
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(578, 57);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(210, 20);
            this.bTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "n =";
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(578, 83);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(210, 20);
            this.nTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(549, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "Задать распределение";
            // 
            // plot
            // 
            this.plot.Location = new System.Drawing.Point(553, 300);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(238, 39);
            this.plot.TabIndex = 7;
            this.plot.Text = "Построить график";
            this.plot.UseVisualStyleBackColor = true;
            this.plot.Click += new System.EventHandler(this.Plot_Click);
            // 
            // radioButtonUniform
            // 
            this.radioButtonUniform.AutoSize = true;
            this.radioButtonUniform.Checked = true;
            this.radioButtonUniform.Location = new System.Drawing.Point(553, 237);
            this.radioButtonUniform.Name = "radioButtonUniform";
            this.radioButtonUniform.Size = new System.Drawing.Size(94, 17);
            this.radioButtonUniform.TabIndex = 18;
            this.radioButtonUniform.TabStop = true;
            this.radioButtonUniform.Text = "Равномерное";
            this.radioButtonUniform.UseVisualStyleBackColor = true;
            // 
            // radioButtonChebushev
            // 
            this.radioButtonChebushev.AutoSize = true;
            this.radioButtonChebushev.Location = new System.Drawing.Point(708, 237);
            this.radioButtonChebushev.Name = "radioButtonChebushev";
            this.radioButtonChebushev.Size = new System.Drawing.Size(79, 17);
            this.radioButtonChebushev.TabIndex = 19;
            this.radioButtonChebushev.TabStop = true;
            this.radioButtonChebushev.Text = "Чебышева";
            this.radioButtonChebushev.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(553, 405);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 33);
            this.ExitButton.TabIndex = 20;
            this.ExitButton.Text = "Вернуться на главную форму";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(550, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Коэффициенты для функций";
            // 
            // coefficientsBox
            // 
            this.coefficientsBox.Location = new System.Drawing.Point(553, 160);
            this.coefficientsBox.Multiline = true;
            this.coefficientsBox.Name = "coefficientsBox";
            this.coefficientsBox.Size = new System.Drawing.Size(234, 47);
            this.coefficientsBox.TabIndex = 22;
            // 
            // functionComboBox
            // 
            this.functionComboBox.FormattingEnabled = true;
            this.functionComboBox.Items.AddRange(new object[] {
            "синусоида (a,b)",
            "линейная функция (a,b)",
            "квадратичная функция (a,b,c)",
            "кубическая функция (a,b,c,d)"});
            this.functionComboBox.Location = new System.Drawing.Point(551, 109);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(236, 21);
            this.functionComboBox.TabIndex = 23;
            this.functionComboBox.Text = "Выбор функции";
            this.functionComboBox.SelectedIndexChanged += new System.EventHandler(this.FunctionComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(551, 346);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(141, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "Максимальное по модулю\r\nзначение погрешности\r\n";
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(699, 346);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(88, 20);
            this.errorTextBox.TabIndex = 25;
            // 
            // FirstTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.functionComboBox);
            this.Controls.Add(this.coefficientsBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.radioButtonChebushev);
            this.Controls.Add(this.radioButtonUniform);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.ApproximationPlot);
            this.Name = "FirstTaskForm";
            this.Text = "Главное окно";
            this.Load += new System.EventHandler(this.FirstTaskForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl ApproximationPlot;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button plot;
        private System.Windows.Forms.RadioButton radioButtonUniform;
        private System.Windows.Forms.RadioButton radioButtonChebushev;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox coefficientsBox;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox errorTextBox;
    }
}

