using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstLabWindowsFormsApp.Main;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using ZedGraph;

namespace FirstLabWindowsFormsApp
{
    public partial class FirstTaskForm : Form
    {

        private Approximation _approximation;

        public FirstTaskForm()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, EventArgs e)
        {

            if (
                aTextBox.Text == string.Empty
                || bTextBox.Text == string.Empty
                || nTextBox.Text == string.Empty
            )
            {
                MessageBox.Show(
                    "Одно или несколько полей не заполнено, заполните поля чтобы продолжить работу",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                return;
            }
            
            if (radioButtonChebushev.Checked)
            {
                Distribute(new ChebushevDistribution());
            }
            else
            {
                Distribute(new UniformDistribution());
            }

            _approximation.SetData();
            if (
                _approximation.XDoubles != Array.Empty<double>()
                && _approximation.YDoubles != Array.Empty<double>()
                && _approximation.BDoubles != Array.Empty<double>()
            )
            {
                MessageBox.Show(
                    "Массивы данных успешно созданы",
                    "Данные заданы",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None
                );
            }
        }
        
        private void Distribute(IDistribution distribution)
        {
            if (
                aTextBox.Text == string.Empty
                || bTextBox.Text == string.Empty
                || nTextBox.Text == string.Empty
            )
            {
                MessageBox.Show(
                    "Одно или несколько полей не заполнено, заполните поля чтобы продолжить работу",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (_approximation != null)
            {
                _approximation.A = Convert.ToInt32(aTextBox.Text);
                _approximation.B = Convert.ToInt32(bTextBox.Text);
                _approximation.N = Convert.ToInt32(nTextBox.Text);

                _approximation.Distribution = distribution;
            } else
            {
                _approximation = new Approximation(
                    distribution,
                    Convert.ToInt32(aTextBox.Text),
                    Convert.ToInt32(bTextBox.Text),
                    Convert.ToInt32(nTextBox.Text)
                );
            }
        }

        private void Plot_Click(object sender, EventArgs e)
        {
            
            DrawGraph(_approximation.XDoubles, _approximation.YDoubles);

        }

        private void DrawGraph(IReadOnlyList<double> xData, IReadOnlyList<double> yData)
        {
            var pane = ApproximationPlot.GraphPane;
            pane.CurveList.Clear();

            var list = new PointPairList();

            var n = _approximation.N;

            for (int index = 0; index < n; index++)
            {

                list.Add(xData[index], yData[index]);

            }

            var myCurve = pane.AddCurve("Plot (xData,yData)", list, Color.Blue, SymbolType.Circle);

            ApproximationPlot.AxisChange();
            ApproximationPlot.Invalidate();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
