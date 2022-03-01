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

namespace Color_Preview_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TextBox ActiveBox;
        public List<TextBox> ActiveBoxes = new List<TextBox>();
        public SolidColorBrush white = new SolidColorBrush(Colors.White);
        public bool isFirstTime = true;

        public MainWindow()
        {
            InitializeComponent();
            SetActiveBox(RBox);
            RBox.Text = "0";
            GBox.Text = "0";
            BBox.Text = "0";
            isFirstTime = false;
        }

        private void RBox_GotFocus(object sender, RoutedEventArgs e){SetActiveBox(RBox);}
        private void GBox_GotFocus(object sender, RoutedEventArgs e){SetActiveBox(GBox);}
        private void BBox_GotFocus(object sender, RoutedEventArgs e){SetActiveBox(BBox);}

        private void SetActiveBox(TextBox t){
            ActiveBox = t;
            ActiveBox.Background = new SolidColorBrush(Color.FromArgb(255, 150, 150, 150));

            slider.Value = Convert.ToInt32(ActiveBox.Text);
            
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isFirstTime)
            { 
                try
                {
                    byte r = Convert.ToByte(RBox.Text);
                    byte g = Convert.ToByte(GBox.Text);
                    byte b = Convert.ToByte(BBox.Text);
                    double rD = (double)r;
                    double gD = (double)g;
                    double bD = (double)b;
                    byte Nr = Convert.ToByte(Math.Abs(127 - r));
                    byte Ng = Convert.ToByte(Math.Abs(127 - g));
                    byte Nb = Convert.ToByte(Math.Abs(127 - b));

                    if (ActiveBox.Name == "RBox")
                    {
                        ActiveBox.Background = new SolidColorBrush(Color.FromArgb(255, r, 0, 0));
                        ActiveBox.Foreground = new SolidColorBrush(Color.FromArgb(255, Nr, r, r));
                    }
                    if (ActiveBox.Name == "GBox")
                    {
                        ActiveBox.Background = new SolidColorBrush(Color.FromArgb(255, 0, g, 0));
                        ActiveBox.Foreground = new SolidColorBrush(Color.FromArgb(255, g, Ng, g));
                    }
                    if (ActiveBox.Name == "BBox")
                    {
                        ActiveBox.Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, b));
                        ActiveBox.Foreground = new SolidColorBrush(Color.FromArgb(255, b, b, Nb));
                    }
                    RBar.Width = (rD / 255) * 160;
                    GBar.Width = (gD / 255) * 160;
                    BBar.Width = (bD / 255) * 160;
                    GBar.Margin = new Thickness(RBar.Width + RBar.Margin.Left, GBar.Margin.Top, GBar.Margin.Right, GBar.Margin.Bottom);
                    BBar.Margin = new Thickness(GBar.Width + GBar.Margin.Left, BBar.Margin.Top, BBar.Margin.Right, BBar.Margin.Bottom);
                    //else { ActiveBox.Foreground = new SolidColorBrush(Colors.Black); }
                    UpdateColors(r, g, b);
                }
                catch
                {
                    MessageBox.Show("You need to enter a number between 0 and 255");
                    //ActiveBox.Text = "0";
                }
            }
        }
        private void UpdateColors(byte r, byte g, byte b)
        {
            rrr.Background = new SolidColorBrush(Color.FromArgb(255, r, r, r));
            rrg.Background = new SolidColorBrush(Color.FromArgb(255, r, r, g));
            rrb.Background = new SolidColorBrush(Color.FromArgb(255, r, r, b));
            rgr.Background = new SolidColorBrush(Color.FromArgb(255, r, g, r));
            rgg.Background = new SolidColorBrush(Color.FromArgb(255, r, g, g));
            rgb.Background = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            rbr.Background = new SolidColorBrush(Color.FromArgb(255, r, b, r));
            rbg.Background = new SolidColorBrush(Color.FromArgb(255, r, b, g));
            rbb.Background = new SolidColorBrush(Color.FromArgb(255, r, b, b));
            grr.Background = new SolidColorBrush(Color.FromArgb(255, g, r, r));
            grg.Background = new SolidColorBrush(Color.FromArgb(255, g, r, g));
            grb.Background = new SolidColorBrush(Color.FromArgb(255, g, r, b));
            ggr.Background = new SolidColorBrush(Color.FromArgb(255, g, g, r));
            ggg.Background = new SolidColorBrush(Color.FromArgb(255, g, g, g));
            ggb.Background = new SolidColorBrush(Color.FromArgb(255, g, g, b));
            gbr.Background = new SolidColorBrush(Color.FromArgb(255, g, b, r));
            gbg.Background = new SolidColorBrush(Color.FromArgb(255, g, b, g));
            gbb.Background = new SolidColorBrush(Color.FromArgb(255, g, b, b));
            brr.Background = new SolidColorBrush(Color.FromArgb(255, b, r, r));
            brg.Background = new SolidColorBrush(Color.FromArgb(255, b, r, g));
            brb.Background = new SolidColorBrush(Color.FromArgb(255, b, r, b));
            bgr.Background = new SolidColorBrush(Color.FromArgb(255, b, g, r));
            bgg.Background = new SolidColorBrush(Color.FromArgb(255, b, g, g));
            bgb.Background = new SolidColorBrush(Color.FromArgb(255, b, g, b));
            bbr.Background = new SolidColorBrush(Color.FromArgb(255, b, b, r));
            bbg.Background = new SolidColorBrush(Color.FromArgb(255, b, b, g));
            bbb.Background = new SolidColorBrush(Color.FromArgb(255, b, b, b));

        }

        private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if(ActiveBox != null){
                ActiveBox.Text = Convert.ToInt32(slider.Value).ToString();
            }
        }
    }
}
