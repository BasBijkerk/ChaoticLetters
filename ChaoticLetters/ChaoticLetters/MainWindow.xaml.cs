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

namespace ChaoticLetters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Char> DocChars = new List<Char>();
        private List<Label> labels = new List<Label>();
        private List<String> fontlistz = new List<String>();
        private bool check = false;
        private int f = 0;
        private int z = 0;
        public MainWindow()
        {
            InitializeComponent();
            var fontlist = Fonts.SystemFontFamilies;
            foreach(FontFamily font in fontlist)
            {
                fontlistz.Add(font.ToString());
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Clear();
            var rng = new Random();
            
            foreach (Char zchar in tektBoks.Text)
            {
                DocChars.Add(zchar);
                if (DocChars.Count == tektBoks.Text.Length - 1)
                {
                    check = true;
                }
            }
            if (check == true)
            {
                for (int i = 0; i < DocChars.Count; i++)
                {
                    if (!DocChars[i].ToString().Contains('\n') && f <= 89)
                    {
                        Label MakeLabel = new Label();
                        MakeLabel.Content = DocChars[i];
                        MakeLabel.FontFamily = new FontFamily(fontlistz[rng.Next(0, fontlistz.Count-1)]);
                        if(i % 2 == 0)
                        {
                            MakeLabel.FontWeight = FontWeights.UltraBold;
                        }
                        
                        //MakeLabel.RenderTransform = Templ.RenderTransfo;
                        MakeLabel.Margin = new Thickness(Templ.Margin.Left + f * 8, Templ.Margin.Top + z * 10, 0, 0);
                        MakeLabel.Name = "R" + z + "L" + i;
                        f++;
                        labels.Add(MakeLabel);
                        zeGrid.Children.Add(MakeLabel);
                        //AddChild(MakeLabel);
                    }
                    if (DocChars[i].ToString().Contains('\n') || f == 90)
                    {
                        f = 0;
                        z++;
                    }
                }
            }
        }

        private void Clear()
        {
            foreach (Label label in labels)
            {
                zeGrid.Children.Remove(label);
            }
            DocChars.Clear();
            labels.Clear();
            f = 0;
            z = 0;
        }
        private void button_Clear(object sender, RoutedEventArgs e)
        {
            Clear();
        }
    }
}
