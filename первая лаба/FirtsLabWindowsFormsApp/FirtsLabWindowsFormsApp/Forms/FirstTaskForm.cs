using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FirstLabWindowsFormsApp.Main;
using FirstLabWindowsFormsApp.Strategies.Distribution;
using ZedGraph;

namespace FirstLabWindowsFormsApp.Forms;

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

        _approximation.GenerateData();
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
        }
        else
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
        var pane = ApproximationPlot.GraphPane;
        pane.CurveList.Clear();

        PaneInit(pane);

        DrawGraph(
            pane,
            _approximation.XDoubles,
            _approximation.BDoubles,
            "Полином",
            Color.Blue
        );
        DrawGraph(
            pane,
            _approximation.XDoubles,
            _approximation.YDoubles,
            "Парабола",
            Color.Red
        );

        ApproximationPlot.AxisChange();
        ApproximationPlot.Invalidate();
    }

    private void PaneInit(ZedGraph.GraphPane pane)
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
    }

    private void DrawGraph(
        ZedGraph.GraphPane pane,
        IReadOnlyList<double> xData,
        IReadOnlyList<double> yData,
        string graphName,
        Color color
    )
    {
        var list = new PointPairList();

        var n = _approximation.N;

        for (int index = 0; index < n; index++)
        {

            list.Add(xData[index], yData[index]);

        }

        var myCurve = pane.AddCurve(graphName, list, color, SymbolType.Circle);
    }

    private void ExitButton_Click(object sender, EventArgs e)
    {
        Close();
    }
}