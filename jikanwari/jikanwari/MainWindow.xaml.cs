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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;

namespace jikanwari
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<TextBlock> lTB = new List<TextBlock>();
        JikanWariItems Items = new JikanWariItems();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        void Load_JikanWari(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, System.IO.FileAccess.Read);
            fs.Close();
        }
        void Write_JikanWari(object It,string path)
        {

            StreamWriter writer = new StreamWriter(path);
            XmlSerializer sr = new XmlSerializer(typeof(JikanWariItems));
            sr.Serialize(writer, It);
            writer.Close();
            
          
        }

        void test()
        {
            JikanWariData data = new JikanWariData();
            Items.items = new List<JikanWariData>();
            data.t12 = "43434";
            data.t34 = "fdsfds";
            data.t56 = "fds";
            data.t78 = "543;";
            data.t910 = "t543";
            Items.items.Add(data);
            Items.items.Add(data);
            Write_JikanWari((object)Items,"D:\\xml.xml");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            test();
            for (int i = 1; i <= 7; i++)
                for (int j = 1; j <= 5; j++)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.TextAlignment = TextAlignment.Center;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    textblock.Text = "fdjk";
                    mainGrid.Children.Add(textblock);
                    Grid.SetColumn(textblock, i);
                    Grid.SetRow(textblock, j);
                    lTB.Add(textblock);
                }
        }
    }
}
