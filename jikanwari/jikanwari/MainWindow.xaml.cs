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
        const string JikanWariPath = "Data\\xml.xml";
        string EvenPath;
        List<TextBlock> lTB = new List<TextBlock>();
        JikanWariData data;
        public MainWindow()
        {
            InitializeComponent();
        }

        object Load_Data(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.GetEncoding("Shift_JIS"), false);
            XmlSerializer sr = new XmlSerializer(typeof(JikanWariData));
            return sr.Deserialize(reader);
        }

        void WriteData(EvenItems da, string path)
        {
            FileStream writer = new FileStream(path,FileMode.OpenOrCreate  );
            XmlSerializer sr = new XmlSerializer(typeof(EvenItems));
            sr.Serialize()
            writer.Close();
        }

        string GetEvenPath()
        {
            string path;
            path = "Data\\" + DateTime.Today;
            while (path.IndexOf("/") >= 0) path = path.Remove(path.IndexOf("/"), 1);
            path = path.Split(' ')[0] + ".xml";
            return path;
        }

        void Test()
        {
            EvenItems EvItem = new EvenItems();
            EvItem.EvData = new List<EvenData>();
            
            EvenData da = new EvenData();
            da.HocBu = true;
            //da.Mau = new SolidColorBrush(Colors.Bisque);
            EvItem.EvData.Add(da);
            da.HocBu = false;
            //da.Mau = new SolidColorBrush(Colors.Black);
            EvItem.EvData.Add(da);
            
            da.HocBu = true;
            //.Mau = new SolidColorBrush(Colors.Bisque);
            EvItem.EvData.Add(da);
            da.HocBu = false;
            //da.Mau = new SolidColorBrush(Colors.Black);
            EvItem.EvData.Add(da);
            WriteData(EvItem, "D:\\xml.xml");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EvenPath = GetEvenPath();
            
            data = (JikanWariData)Load_Data(JikanWariPath);
            Test();
            for (int i = 1; i <= 7; i++)
                for (int j = 1; j <= 5; j++)
                {
                    TextBlock textblock = new TextBlock();
                    textblock.TextAlignment = TextAlignment.Center;
                    textblock.HorizontalAlignment = HorizontalAlignment.Center;
                    textblock.VerticalAlignment = VerticalAlignment.Center;
                    textblock.Text = data.Data[i - 1][j - 1];
                    textblock.Foreground = new SolidColorBrush(Colors.White);
                    Border bo = new Border();
                    bo.BorderThickness = new Thickness(1, 1, 0, 0);
                    bo.BorderBrush = new SolidColorBrush(Color.FromRgb(62, 147, 195));
                    mainGrid.Children.Add(bo);
                    Grid.SetColumn(bo, i);
                    Grid.SetRow(bo, j);
                    mainGrid.Children.Add(textblock);
                    Grid.SetColumn(textblock, i);
                    Grid.SetRow(textblock, j);
                    lTB.Add(textblock);
                }
        }
    }
}
