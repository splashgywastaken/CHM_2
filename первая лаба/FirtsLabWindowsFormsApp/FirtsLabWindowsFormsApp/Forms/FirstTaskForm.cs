using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using FirstLabWindowsFormsApp.Main;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using ZedGraph;

namespace FirstLabWindowsFormsApp.Forms;

public partial class FirstTaskForm : Form
{

    private Interpolation _interpolation;

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
            || coefficientsBox.Text == string.Empty
            || functionComboBox.SelectedItem == null
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

        _interpolation.GenerateData();

        errorTextBox.Text = Convert.ToString(
            _interpolation.GetMaxAbsoluteError(), 
            CultureInfo.InvariantCulture
            );

        if (
            _interpolation.XDoubles != Array.Empty<double>()
            && _interpolation.YDoubles != Array.Empty<double>()
            && _interpolation.BDoubles != Array.Empty<double>()
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

        if (_interpolation != null)
        {
            _interpolation.A = Convert.ToInt32(aTextBox.Text);
            _interpolation.B = Convert.ToInt32(bTextBox.Text);
            _interpolation.N = Convert.ToInt32(nTextBox.Text);

            _interpolation.Distribution = distribution;
        }
        else
        {
            _interpolation = new Interpolation(
                distribution,
                Convert.ToInt32(aTextBox.Text),
                Convert.ToInt32(bTextBox.Text),
                Convert.ToInt32(nTextBox.Text),
                coefficientsBox.Text.Split(' ').Select(Convert.ToDouble).ToArray(),
                functionComboBox.SelectedIndex
            );
        }
    }

    private void Plot_Click(object sender, EventArgs e)
    {
        var pane = ApproximationPlot.GraphPane;
        pane.CurveList.Clear();

        PaneInit(pane);

        DrawGraph(
            pane,
            _interpolation.XDoubles,
            _interpolation.BDoubles,
            "Полином",
            Color.Blue
        );
        DrawGraph(
            pane,
            _interpolation.XDoubles,
            _interpolation.YDoubles,
            "Функция",
            Color.Red
        );

        DrawGraph(
            pane,
            _interpolation.XDoubles,
            _interpolation.ErrorDoubles,
            "График погрешности интерполяции",
            Color.Green
        );

        //TODO: Add errors graph and Fix GenerateB method

        ApproximationPlot.AxisChange();
        ApproximationPlot.Invalidate();
    }

    private static void PaneInit(GraphPane pane)
    {
        // !!!
        // Включаем отображение сетки напротив крупных рисок по оси X
        pane.XAxis.MajorGrid.IsVisible = true;

        // Задаем вид пунктирной линии для крупных рисок по оси X:
        // Длина штрихов равна 10 пикселям, ...
        pane.XAxis.MajorGrid.DashOn = 10;
        // затем 5 пикселей - пропуск
        pane.XAxis.MajorGrid.DashOff = 5;


        // Включаем отображение сетки напротив крупных рисок по оси Y
        pane.YAxis.MajorGrid.IsVisible = true;

        // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
        pane.YAxis.MajorGrid.DashOn = 10;
        pane.YAxis.MajorGrid.DashOff = 5;


        // Включаем отображение сетки напротив мелких рисок по оси X
        pane.YAxis.MinorGrid.IsVisible = true;

        // Задаем вид пунктирной линии для крупных рисок по оси Y:
        // Длина штрихов равна одному пикселю, ...
        pane.YAxis.MinorGrid.DashOn = 1;

        // затем 2 пикселя - пропуск
        pane.YAxis.MinorGrid.DashOff = 2;

        // Включаем отображение сетки напротив мелких рисок по оси Y
        pane.XAxis.MinorGrid.IsVisible = true;

        // Аналогично задаем вид пунктирной линии для крупных рисок по оси Y
        pane.XAxis.MinorGrid.DashOn = 1;
        pane.XAxis.MinorGrid.DashOff = 2;

        pane.XAxis.Scale.Max = 15.0;
        pane.YAxis.Scale.Max = 15.0;
    }

    private void DrawGraph(
        GraphPane pane,
        IReadOnlyList<double> xData,
        IReadOnlyList<double> yData,
        string graphName,
        Color color
    )
    {
        var list = new PointPairList();

        var n = _interpolation.N;

        for (int index = 0; index < n; index++)
        {
            list.Add(xData[index], yData[index]);
        }

        pane.AddCurve(graphName, list, color, SymbolType.Circle);
    }

    private void ExitButton_Click(object sender, EventArgs e)
        => Close();

    private void FunctionComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (_interpolation == null)
        {
            return;
        }

        if (coefficientsBox.Text == string.Empty)
        {
            MessageBox.Show(
                "Заполните поле с коэффициентами",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
            
            functionComboBox.Text = "Выбор функции";

            return;
        }

        _interpolation.SetFunctionAndCoefficients(
            functionComboBox.SelectedIndex,
            coefficientsBox.Text.Split(' ').Select(Convert.ToDouble).ToArray()
        );
    }

    private void FirstTaskForm_Load(object sender, EventArgs e)
    {

    }

    private void ExitButton_Click_1(object sender, EventArgs e)
    {
        Close();
    }
}