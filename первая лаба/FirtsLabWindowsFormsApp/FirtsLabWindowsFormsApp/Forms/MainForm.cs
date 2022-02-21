using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirstLabWindowsFormsApp
{
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
}
