using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAutoPic
{
    /// <summary>
    /// Interaction logic for ReportWin.xaml
    /// </summary>
    public partial class ReportWin : Window
    {
        MainWindow mainWindow;
        PrintDialog printDialog;
        public ReportWin(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            Paragraph cim = new Paragraph(new Run("Nyomtatás"));
            cim.FontSize = 50;
            Paragraph alcim = new Paragraph(new Run("Az adatok:"));
            alcim.FontSize = 20;
            flowDoc.Blocks.Add(cim);
            flowDoc.Blocks.Add(alcim);

            foreach (var i in mainWindow.autoContext.autok.Local)
            {
                Paragraph docrendszam = new Paragraph(new Run($"Rendszám:{i.Rendszam}"));
                Paragraph docgyartmany = new Paragraph(new Run($"Gyártmány:{i.Gyartmany}"));
                Paragraph doctipus = new Paragraph(new Run($"Típus:{i.Tipus}"));
                Image image = new Image();
                image.Source = i.Autokep;
                Paragraph autokep = new Paragraph();
                autokep.Inlines.Add(image);
                flowDoc.Blocks.Add(docrendszam);
                flowDoc.Blocks.Add(docgyartmany);
                flowDoc.Blocks.Add(doctipus);
                flowDoc.Blocks.Add(autokep);
            }

        }

        private void buttonNyomtat_Click(object sender, RoutedEventArgs e)
        {
            printDialog = new PrintDialog();

            IDocumentPaginatorSource idp = flowDoc;
            flowDoc.PageWidth = printDialog.PrintableAreaWidth;
            flowDoc.PageHeight = printDialog.PrintableAreaHeight;
            flowDoc.ColumnWidth= printDialog.PrintableAreaWidth;


            if (printDialog.ShowDialog()==true)
            {
                printDialog.PrintDocument(idp.DocumentPaginator,"Teszt");
            }
        }
    }
}
