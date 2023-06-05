using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms.DataVisualization.Charting;

namespace АнализДанных
{
    public partial class Form1 : Form
    {
        List<FileStream> files = new();
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
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(file, true))
                {
                    var sheet = doc.WorkbookPart.Workbook.Descendants<Sheet>().First();
                    var sheetPart = (WorksheetPart)doc.WorkbookPart.GetPartById(sheet.Id);
                    var cells = sheetPart.Worksheet.Descendants<Cell>().Select(c => c.InnerText).OfType<string>().ToList();
                    cells.ForEach(value => { listBox1.Items.Add(value); });
                        //listBox1.Invoke(new Action(() => { listBox1.Items.Add(value) }));
                    }
                });
            }
        }
    }
}