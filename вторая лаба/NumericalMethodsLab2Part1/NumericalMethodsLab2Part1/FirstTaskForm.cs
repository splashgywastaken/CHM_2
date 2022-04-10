using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace NumericalMethodsLab2Part1
{
    public partial class FirstTaskForm : Form
    {
        private RungeKuttaMethod _rungeKuttaMethod;

        public FirstTaskForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlotButton_Click(object sender, EventArgs e)
        {
            Plot();
        }

        private void Plot()
        {

            var pane = RKZedgraphControl.GraphPane;
            pane.CurveList.Clear();

            PaneInit(pane);
            var n = _rungeKuttaMethod.GridN.Length;

            // Вывод аналитического решения если выбрана нужная функция
            if (FunctionComboBox.SelectedIndex == 0)
            {
                var y = new double[n];
                for (var index = 0; index < n; index++)
                {
                    var x = _rungeKuttaMethod.GridN[index];
                    y[index] = -8.0 * x + 65.1556 * Math.Exp(x / 8.0) - 64.0;
                }

                DrawScatterPlot(
                    pane,
                    _rungeKuttaMethod.GridN,
                    y,
                    n,
                    "Аналитическое решение задачи Коши",
                    Color.BlueViolet
                );

            }

            // Вывод численного решения задачи Коши, соответствующего сетке с количеством подотрезков разбиения n0 
            DrawGraph(
                pane,
                _rungeKuttaMethod.GridN,
                _rungeKuttaMethod.ResultN,
                n,
                "График численного решения (сетка с n0 подотрезков разбиения)",
                Color.Crimson
            );
            
            var y_array = _rungeKuttaMethod.ResultLast2Iterations.Dequeue();
            var x_array = Distribution.EvenNodes(
                _rungeKuttaMethod.A,
                _rungeKuttaMethod.B,
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

            y_array = _rungeKuttaMethod.ResultLast2Iterations.Dequeue();
            if (y_array != Array.Empty<double>())
            {
                x_array = Distribution.EvenNodes(
                    _rungeKuttaMethod.A,
                    _rungeKuttaMethod.B,
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

            RKZedgraphControl.AxisChange();
            RKZedgraphControl.Invalidate();
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
        
        // TODO: добить методы по формированию ответов

        private void SolveButton_Click(object sender, EventArgs e)
        {
            // Задаём значения для решения задачи:
            _rungeKuttaMethod = new RungeKuttaMethod(
                ControlTextToDouble(IntervalLeftValueTextBox),
                ControlTextToDouble(IntervalRightValueTextBox),
                ControlTextToInt(NTextBox),
                ControlTextToDouble(epsilonNum) * Math.Pow(10, -1 * ControlTextToInt(epsilonPower)),
                FunctionComboBox.SelectedIndex,
                ControlTextToDouble(BaseConditionTextBox)
            );

            var response = _rungeKuttaMethod.GetResult();

            SetTextForControl(responseTextBox, response);
            SetTextForControl(errrorTextBox, _rungeKuttaMethod.FindError());
            SetTextForControl(XLastTextBox, _rungeKuttaMethod.GridN.Last());
            SetTextForControl(YLastTextBox, _rungeKuttaMethod.ResultN.Last());

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
        {
            return Convert.ToDouble(textBox.Text);
        }

        private static int ControlTextToInt(Control textBox)
        {
            return Convert.ToInt32(textBox.Text);
        }

        private void FunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (FunctionComboBox.SelectedIndex)
            {
                case 0:
                {
                    IntervalLeftValueTextBox.Text = "1,2";
                    IntervalLeftValueTextBox.ReadOnly = true;

                    BaseConditionTextBox.Text = "2,1";
                    BaseConditionTextBox.ReadOnly = true;
                } 
                break;

                case 1:
                {
                    IntervalLeftValueTextBox.Text = "";
                    IntervalLeftValueTextBox.ReadOnly = false;

                    BaseConditionTextBox.Text = "";
                    BaseConditionTextBox.ReadOnly = false;
                    }
                break;
            }
        }
    }
}
