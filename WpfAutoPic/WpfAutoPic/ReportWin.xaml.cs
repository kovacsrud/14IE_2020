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

        }
    }
}
