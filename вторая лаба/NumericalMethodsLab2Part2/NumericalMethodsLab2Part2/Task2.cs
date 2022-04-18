using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        private RungeKuttaMethod _method;

        private void GenerateDataButton_Click(object sender, EventArgs e)
        {
            GenerateData();
        }

        private void GenerateData()
        {
            _method = new RungeKuttaMethod(
                ControlTextToDouble(xRightValue),
                ControlTextToInt(N0TextBox),
                GetUserError()
            );

            var response = _method.Solve();

            SetTextForControl(ResponseTextBox, response);
            SetTextForControl(YErrorTextBox, _method.YError);
            SetTextForControl(ZErrorTextBox, _method.ZError);
            SetTextForControl(XLastTextBox, _method.LastXn);
            SetTextForControl(YLastTextBox, _method.LastYn);
            SetTextForControl(ZLastTextBox, _method.LastZn);
            SetTextForControl(OnTextBox, _method.LastN);
            SetTextForControl(HTextBox, _method.LastHn);

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
            PlotY();
            PlotZ();
        }

        private void PlotY()
        {
            var pane = YGraphControl.GraphPane;

            pane.Title.Text = "График Y";
            pane.YAxis.Title.Text = "Y axis";

            pane.CurveList.Clear();

            PaneInit(pane);
            var y_array = _method.Last2IterationsY.Dequeue();
            var x_array = Distribution.EvenNodes(
                _method.A,
                _method.B,
                y_array.Length
            );

            // Вывод численного решения задачи Коши, соответствующего сетке с количеством подотрезков разбиения n0 
            DrawGraph(
                pane,
                x_array,
                y_array,
                y_array.Length,
                "График численного решения (сетка с "+ y_array.Length +" подотрезков разбиения)",
                Color.Crimson
            );

            if (_method.Last2IterationsY.Count >= 1)
            {
                y_array = _method.Last2IterationsY.Dequeue();
                x_array = Distribution.EvenNodes(
                    _method.A,
                    _method.B,
                    y_array.Length
                );

                // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
                DrawGraph(
                    pane,
                    x_array,
                    y_array,
                    y_array.Length,
                    "График численного решения (сетка с " + y_array.Length + " подотрезков разбиения)",
                    Color.DarkViolet
                );
            }

            if (_method.Last2IterationsY.Count >= 1)
            {
                y_array = _method.Last2IterationsY.Dequeue();
                x_array = Distribution.EvenNodes(
                    _method.A,
                    _method.B,
                    y_array.Length
                );

                // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
                DrawGraph(
                    pane,
                    x_array,
                    y_array,
                    y_array.Length,
                    "График численного решения (сетка с " + y_array.Length + " подотрезков разбиения)",
                    Color.Green
                );
            }

            YGraphControl.AxisChange();
            YGraphControl.Invalidate();
        }

        private void PlotZ()
        {
            var pane = ZGraphControl.GraphPane;

            pane.Title.Text = "График Z";
            pane.YAxis.Title.Text = "Z axis";

            pane.CurveList.Clear();

            PaneInit(pane);
            var z_array = _method.Last2IterationsZ.Dequeue();
            var x_array = Distribution.EvenNodes(
                _method.A,
                _method.B,
                z_array.Length
            );

            // Вывод численного решения задачи Коши, соответствующего сетке с количеством подотрезков разбиения n0 
            DrawGraph(
                pane,
                x_array,
                z_array,
                z_array.Length,
                "График численного решения (сетка с " + z_array.Length + " подотрезков разбиения)",
                Color.Crimson
            );
            
            if (_method.Last2IterationsZ.Count >= 1)
            {
                z_array = _method.Last2IterationsZ.Dequeue();
                x_array = Distribution.EvenNodes(
                    _method.A,
                    _method.B,
                    z_array.Length
                );

                // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
                DrawGraph(
                    pane,
                    x_array,
                    z_array,
                    z_array.Length,
                    "График численного решения (сетка с " + z_array.Length + " подотрезков разбиения)",
                    Color.DarkViolet
                );
            }

            if (_method.Last2IterationsZ.Count >= 1)
            {
                z_array = _method.Last2IterationsZ.Dequeue();
                x_array = Distribution.EvenNodes(
                    _method.A,
                    _method.B,
                    z_array.Length
                );

                // Вывод численного решения задачи Коши, полученного в последних двух итерациях алгоритма решения
                DrawGraph(
                    pane,
                    x_array,
                    z_array,
                    z_array.Length,
                    "График численного решения (сетка с " + z_array.Length + " подотрезков разбиения)",
                    Color.Green
                );
            }

            ZGraphControl.AxisChange();
            ZGraphControl.Invalidate();
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

        private void YGraph1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(0, YGraph1, YGraphControl);
        }

        private void YGraph2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(1, YGraph2, YGraphControl);
        }

        private void YGraph3_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(2, YGraph3, YGraphControl);
        }

        private void ZGraph1_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(0, ZGraph1, ZGraphControl);
        }

        private void ZGraph2_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(1, ZGraph2, ZGraphControl);
        }

        private void ZGraph3_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGraphVisibility(2, ZGraph3, ZGraphControl);
        }

        private void ChangeGraphVisibility(int index, CheckBox checkBox, ZedGraphControl control)
        {
            var pane = control.GraphPane;

            if (pane.CurveList[index] != null)
            {
                pane.CurveList[index].IsVisible = checkBox.Checked;
            }

            control.AxisChange();
            control.Invalidate();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            _method = null;

            //Force garbage collection.
            GC.Collect();

            // Wait for all finalizers to complete before continuing.
            GC.WaitForPendingFinalizers();
        }
    }
}
