using Aspose.Cells;
using System.Collections.Concurrent;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace АнализДанных
{
    public partial class Form1 : Form
    {
        ConcurrentDictionary<string, Dictionary<string, double>> fileParameterValue = new();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Multiselect = true;

            chart1.Series[0].Name = "VALUE";
            chart1.Series[0].MarkerStep = 5;
            for (int i = 0; i < 10; i++)
            {
                chart1.Series[0].Points.Add(new DataPoint(i + 5, i * 400));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Parallel.ForEach(openFileDialog1.FileNames, file =>
                {
                    using (Workbook doc = new Workbook(file))
                    {
                        //ListBox listBox = new ListBox();
                        var sheet = doc.Worksheets[0];
                        var cells = sheet.Cells;
                        int rows = cells.MaxDataRow;
                        int cols = cells.MaxDataColumn;
                        StringBuilder @string = new StringBuilder();
                        Dictionary<string, double> parametrValues = new Dictionary<string, double>();

                        for (int i = 1; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j += 2)
                            {
                                try
                                {
                                    parametrValues.Add(cells[i, 0].Value.ToString(), double.Parse(cells[i, 2].Value.ToString()));
                                }
                                catch
                                {
                                    continue;
                                }
                                @string.Append(sheet.Cells[i, j].Value + " ");
                            }
                            //Action action = () => { listBox1.Items.Add(@string); };                           
                            //listBox1.Invoke(action);
                            //@string.Clear();
                            //var cells = sheetPart.Worksheet.Descendants<Cell>().Select(c => c.InnerText).ToList();
                            //cells.ForEach(cell=> { listBox.Items.Add(cell); });
                            //Action action = () => { listBox1.Items.AddRange(listBox.Items); };
                            //listBox1.Invoke(action);
                        }
                        fileParameterValue.OrderBy(s => s.Key);
                        fileParameterValue.TryAdd(doc.FileName.Substring(doc.FileName.Length - 13, 8).Replace("_", ":"), parametrValues);
                    }
                });
            }

            comboBox1.Items.AddRange(fileParameterValue.ElementAt(0).Value.Keys.ToArray());
            listBox1.Items.Add(fileParameterValue.Values.Count);

        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }
    }
}