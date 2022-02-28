using System;
using System.Windows.Forms;

namespace FirstLabWindowsFormsApp.Forms;

public partial class SecondTaskForm : Form
{
    public SecondTaskForm()
    {
        InitializeComponent();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}