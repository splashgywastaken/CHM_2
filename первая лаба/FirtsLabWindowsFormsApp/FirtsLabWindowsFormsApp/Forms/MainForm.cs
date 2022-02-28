using System;
using System.Windows.Forms;

namespace FirstLabWindowsFormsApp.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void FirstTaskButton_Click(object sender, EventArgs e)
    {
        OpenNewForm(new FirstTaskForm());
    }

    private void SecondTaskButton_Click(object sender, EventArgs e)
    {
        OpenNewForm(new SecondTaskForm());
    }

    private void ThirdTaskButton_Click(object sender, EventArgs e)
    {
        OpenNewForm(new ThirdTaskForm());
    }

    private static void OpenNewForm(Control form)
    {
        form.Show();
    }

}