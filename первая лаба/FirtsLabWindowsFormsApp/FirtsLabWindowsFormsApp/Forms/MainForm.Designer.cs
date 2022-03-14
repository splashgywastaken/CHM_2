namespace FirstLabWindowsFormsApp.Forms;
partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.firstTaskButton = new System.Windows.Forms.Button();
            this.SecondTaskButton = new System.Windows.Forms.Button();
            this.ThirdTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Численные методы\r\nЛабораторная работа №1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // firstTaskButton
            // 
            this.firstTaskButton.Location = new System.Drawing.Point(12, 53);
            this.firstTaskButton.Name = "firstTaskButton";
            this.firstTaskButton.Size = new System.Drawing.Size(259, 57);
            this.firstTaskButton.TabIndex = 1;
            this.firstTaskButton.Text = "Первая задача";
            this.firstTaskButton.UseVisualStyleBackColor = false;
            this.firstTaskButton.Click += new System.EventHandler(this.FirstTaskButton_Click);
            // 
            // SecondTaskButton
            // 
            this.SecondTaskButton.Location = new System.Drawing.Point(12, 116);
            this.SecondTaskButton.Name = "SecondTaskButton";
            this.SecondTaskButton.Size = new System.Drawing.Size(259, 57);
            this.SecondTaskButton.TabIndex = 2;
            this.SecondTaskButton.Text = "Вторая задача";
            this.SecondTaskButton.UseVisualStyleBackColor = false;
            this.SecondTaskButton.Click += new System.EventHandler(this.SecondTaskButton_Click);
            // 
            // ThirdTaskButton
            // 
            this.ThirdTaskButton.Location = new System.Drawing.Point(12, 179);
            this.ThirdTaskButton.Name = "ThirdTaskButton";
            this.ThirdTaskButton.Size = new System.Drawing.Size(259, 57);
            this.ThirdTaskButton.TabIndex = 3;
            this.ThirdTaskButton.Text = "Третья задача";
            this.ThirdTaskButton.UseVisualStyleBackColor = false;
            this.ThirdTaskButton.Click += new System.EventHandler(this.ThirdTaskButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 245);
            this.Controls.Add(this.ThirdTaskButton);
            this.Controls.Add(this.SecondTaskButton);
            this.Controls.Add(this.firstTaskButton);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button firstTaskButton;
    private System.Windows.Forms.Button SecondTaskButton;
    private System.Windows.Forms.Button ThirdTaskButton;
}