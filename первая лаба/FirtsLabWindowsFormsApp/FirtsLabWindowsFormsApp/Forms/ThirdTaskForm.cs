using System;
using System.Windows.Forms;

namespace FirstLabWindowsFormsApp.Forms;

public partial class ThirdTaskForm : Form
{
    public ThirdTaskForm()
    {
        InitializeComponent();
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}