using Microsoft.ML;
using Microsoft.ML.Data;
using XPlot.Plotly;

var mlContext = new MLContext(seed: 1);

IDataView trainingDataView = mlContext.Data.LoadFromTextFile<ModelInput>(
                                            path: "./Salary_Data.csv",
                                            hasHeader: true,
                                            separatorChar: ',',
                                            allowQuoting: true,
                                            allowSparse: false);

var split = mlContext.Data.TrainTestSplit(trainingDataView, testFraction: 0.2);
var years = split.TrainSet.GetColumn<float>("YearsExperience").ToArray();
var salary = split.TrainSet.GetColumn<float>("Salary").ToArray();

var yearsChart = Chart.Plot(new Graph.Scatter
{
    x = years,
    y = salary,
    mode = "markers"
});

yearsChart.WithTitle("Years Vs Salary");
//display(yearsChart);