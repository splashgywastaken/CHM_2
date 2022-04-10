using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace NumericalMethodsLab2Part2
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
        }

        private RungeKuttaMethod method;

        private void GenerateDataButton_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void GenerateData()
        {
            method = new RungeKuttaMethod(
                ControlTextToDouble(xRightValue),
                ControlTextToInt(N0TextBox),
                GetUserError()
            );

            var response = method.GetResult();

            SetTextForControl(ResponseTextBox, response);
            SetTextForControl(ErrorTextBox, RungeKuttaMethod.FindError());
            SetTextForControl(XLastTextBox, method.GridN.Last());
            SetTextForControl(YLastTextBox, method.Yn.Last());

            switch (response)
            {
                case 0:
                {
                    DisplayMessage(
                        "Error=0 – завершение в соответствии с назначенным условием о достижении заданной точности",
                        "Задача решена",
                        MessageBoxIcon.Asterisk
                    );
                }
                    break;

                case 1:
                {
                    DisplayMessage(
                        "Error=1 – процесс решения прекращен, т.к. с уменьшением шага погрешность не уменьшается",
                        "Задача не решена",
                        MessageBoxIcon.Error
                    );
                }
                    break;

                case 2:
                {
                    DisplayMessage(
                        "Error=2 - процесс решения прекращен, т.к. значение шага стало недопустимо малым",
                        "Задача не решена",
                        MessageBoxIcon.Error
                    );
                }
                    break;

                case 3:
                {
                    DisplayMessage(
                        "Error=3 - процесс решения прекращен, т.к. дальнейшее применение метода невозможно",
                        "Задача не решена",
                        MessageBoxIcon.Error
                    );
                }
                    break;

                default:
                {
                    DisplayMessage(
                        "Error=4 – решение не получено, двухсторонний метод Рунге-Кутта с данным начальным шагом не применим",
                        "Задача не решена",
                        MessageBoxIcon.Error
                    );
                }
                    break;
            }

        }

        private static void DisplayMessage(
            string message,
            string header,
            MessageBoxIcon icon
        )
        {
            MessageBox.Show(
                message,
                header,
                MessageBoxButtons.OK,
                icon
            );
        }

        private static void SetTextForControl(Control control, object obj)
        {
            control.Text = obj.ToString();
        }

        private static double ControlTextToDouble(Control textBox)
            => Convert.ToDouble(textBox.Text);

        private static int ControlTextToInt(Control textBox)
            => Convert.ToInt32(textBox.Text);

        private double GetUserError()
            => ControlTextToDouble(EpsilonLeft)
               *
               Math.Pow(10, -1 * ControlTextToInt(EpsilonRight));

        private void PlotButton_Click(object sender, EventArgs e)
        {
            Plot();
        }

        private void Plot()
        {

            var pane = MainZedgraphControl.GraphPane;
            pane.CurveList.Clear();

            PaneInit(pane);
            var n = method.GridN.Length;

            // Вывод численного решения задачи Коши, соответствующего сетке с количеством подотрезков разбиения n0 
            DrawGraph(
                pane,
                method.GridN,
                method.Yn,
                n,
                "График численного решения (сетка с n0 подотрезков разбиения)",
                Color.Crimson
            );

            var y_array = method.Last2IterationsZ.Dequeue();
            var x_array = Distribution.EvenNodes(
                method.A,
                method.B,
                y_array.Length
            );

            // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
            DrawGraph(
                pane,
                x_array,
                y_array,
                y_array.Length,
                "Предпоследнее решение",
                Color.Black
            );

            y_array = method.Last2IterationsZ.Dequeue();
            if (y_array != Array.Empty<double>())
            {
                x_array = Distribution.EvenNodes(
                    method.A,
                    method.B,
                    y_array.Length
                );

                // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
                DrawGraph(
                    pane,
                    x_array,
                    y_array,
                    y_array.Length,
                    "Последнее решение",
                    Color.Green
                );
            }

            MainZedgraphControl.AxisChange();
            MainZedgraphControl.Invalidate();
        }

        private void PaneInit(GraphPane pane)
        {
            // !!!
            // Включаем отображение сетки напротив крупных рисок по оси X
            pane.XAxis.MajorGrid.IsVisible = true;

            // Включаем отображение сетки напротив крупных рисок по оси Y
            pane.YAxis.MajorGrid.IsVisible = true;

            // Установим масштаб по умолчанию для оси X
            pane.XAxis.Scale.MinAuto = true;
            pane.XAxis.Scale.MaxAuto = true;

            // Установим масштаб по умолчанию для оси Y
            pane.YAxis.Scale.MinAuto = true;
            pane.YAxis.Scale.MaxAuto = true;
        }

        private void DrawScatterPlot(
            GraphPane pane,
            IReadOnlyList<double> xData,
            IReadOnlyList<double> yData,
            int n,
            string graphName,
            Color color
            )
        {
            var list = new PointPairList();

            for (var index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            var myCurve = pane.AddCurve(graphName, list, color, SymbolType.Diamond);

            // !!!
            // У кривой линия будет невидимой
            myCurve.Line.IsVisible = false;

            // !!!
            // Цвет заполнения отметок (ромбиков) - голубой
            myCurve.Symbol.Fill.Color = color;

            // !!!
            // Тип заполнения - сплошная заливка
            myCurve.Symbol.Fill.Type = FillType.Solid;

            // !!!
            // Размер ромбиков
            myCurve.Symbol.Size = 7;
        }

        private void DrawGraph(
            GraphPane pane,
            IReadOnlyList<double> xData,
            IReadOnlyList<double> yData,
            int n,
            string graphName,
            Color color
        )
        {
            var list = new PointPairList();

            for (var index = 0; index < n; index++)
            {
                list.Add(xData[index], yData[index]);
            }

            pane.AddCurve(graphName, list, color, SymbolType.Circle);
        }

    }
}
