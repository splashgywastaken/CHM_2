namespace FirstLabWindowsFormsApp.Forms
{
    partial class SecondTaskForm
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.ApproximationPlot = new ZedGraph.ZedGraphControl();
            this.label3 = new System.Windows.Forms.Label();
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.aTextBox = new System.Windows.Forms.TextBox();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonChebushev = new System.Windows.Forms.RadioButton();
            this.radioButtonUniform = new System.Windows.Forms.RadioButton();
            this.plot = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.generate = new System.Windows.Forms.Button();
            this.experimentalCoefficientsTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.approximationCoefficientsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(550, 457);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(238, 33);
            this.ExitButton.TabIndex = 18;
            this.ExitButton.Text = "Вернуться на главную форму";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
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
            this.ApproximationPlot.Size = new System.Drawing.Size(533, 478);
            this.ApproximationPlot.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(550, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "n =";
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(578, 64);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(210, 20);
            this.nTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(550, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "b =";
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(578, 38);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(210, 20);
            this.bTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "a =";
            // 
            // aTextBox
            // 
            this.aTextBox.Location = new System.Drawing.Point(578, 12);
            this.aTextBox.Name = "aTextBox";
            this.aTextBox.Size = new System.Drawing.Size(210, 20);
            this.aTextBox.TabIndex = 1;
            // 
            // errorTextBox
            // 
            this.errorTextBox.Location = new System.Drawing.Point(550, 431);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(238, 20);
            this.errorTextBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(552, 389);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(183, 39);
            this.label6.TabIndex = 37;
            this.label6.Text = "Среднеквадратичная погрешность\r\n аппроксимации\r\n\r\n";
            // 
            // radioButtonChebushev
            // 
            this.radioButtonChebushev.AutoSize = true;
            this.radioButtonChebushev.Location = new System.Drawing.Point(709, 280);
            this.radioButtonChebushev.Name = "radioButtonChebushev";
            this.radioButtonChebushev.Size = new System.Drawing.Size(79, 17);
            this.radioButtonChebushev.TabIndex = 6;
            this.radioButtonChebushev.TabStop = true;
            this.radioButtonChebushev.Text = "Чебышева";
            this.radioButtonChebushev.UseVisualStyleBackColor = true;
            // 
            // radioButtonUniform
            // 
            this.radioButtonUniform.AutoSize = true;
            this.radioButtonUniform.Checked = true;
            this.radioButtonUniform.Location = new System.Drawing.Point(554, 280);
            this.radioButtonUniform.Name = "radioButtonUniform";
            this.radioButtonUniform.Size = new System.Drawing.Size(94, 17);
            this.radioButtonUniform.TabIndex = 5;
            this.radioButtonUniform.TabStop = true;
            this.radioButtonUniform.Text = "Равномерное";
            this.radioButtonUniform.UseVisualStyleBackColor = true;
            // 
            // plot
            // 
            this.plot.Location = new System.Drawing.Point(554, 343);
            this.plot.Name = "plot";
            this.plot.Size = new System.Drawing.Size(238, 39);
            this.plot.TabIndex = 8;
            this.plot.Text = "Построить график";
            this.plot.UseVisualStyleBackColor = true;
            this.plot.Click += new System.EventHandler(this.plot_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(550, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 24);
            this.label4.TabIndex = 34;
            this.label4.Text = "Задать распределение";
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(554, 303);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(238, 34);
            this.generate.TabIndex = 7;
            this.generate.Text = "Сгенерировать";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // experimentalCoefficientsTextBox
            // 
            this.experimentalCoefficientsTextBox.Location = new System.Drawing.Point(550, 116);
            this.experimentalCoefficientsTextBox.Multiline = true;
            this.experimentalCoefficientsTextBox.Name = "experimentalCoefficientsTextBox";
            this.experimentalCoefficientsTextBox.Size = new System.Drawing.Size(234, 47);
            this.experimentalCoefficientsTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(547, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 26);
            this.label5.TabIndex = 39;
            this.label5.Text = "Коэффициенты для \r\nэкспериментальной функции";
            // 
            // approximationCoefficientsTextBox
            // 
            this.approximationCoefficientsTextBox.Location = new System.Drawing.Point(550, 195);
            this.approximationCoefficientsTextBox.Multiline = true;
            this.approximationCoefficientsTextBox.Name = "approximationCoefficientsTextBox";
            this.approximationCoefficientsTextBox.ReadOnly = true;
            this.approximationCoefficientsTextBox.Size = new System.Drawing.Size(234, 47);
            this.approximationCoefficientsTextBox.TabIndex = 42;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(547, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 26);
            this.label7.TabIndex = 41;
            this.label7.Text = "Коэффициенты для \r\nфункции аппроксимации";
            // 
            // SecondTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.approximationCoefficientsTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.experimentalCoefficientsTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.radioButtonChebushev);
            this.Controls.Add(this.radioButtonUniform);
            this.Controls.Add(this.plot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.aTextBox);
            this.Controls.Add(this.ApproximationPlot);
            this.Controls.Add(this.ExitButton);
            this.Name = "SecondTaskForm";
            this.Text = "SecondTaskForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private ZedGraph.ZedGraphControl ApproximationPlot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox aTextBox;
        private System.Windows.Forms.TextBox errorTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonChebushev;
        private System.Windows.Forms.RadioButton radioButtonUniform;
        private System.Windows.Forms.Button plot;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox experimentalCoefficientsTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox approximationCoefficientsTextBox;
        private System.Windows.Forms.Label label7;
    }
}