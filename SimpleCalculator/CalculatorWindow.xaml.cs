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

namespace SimpleCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CalculatorWindow : Window
    {
        public CalculatorWindow()
        {
            InitializeComponent();
        }
        private void Update_Result()
        {
            TextBox_Result.Background = Brushes.White;
            bool validInputs = ValidInputs();
            if (validInputs)
            {
                string operation = ComboBox_Operation.SelectionBoxItem as string;
                string units = ComboBox_Units.SelectionBoxItem as string;
                if (operation == "Volume")
                {
                    double volume = Convert.ToDouble(TextBox_Length.Text) * Convert.ToDouble(TextBox_Width.Text) * Convert.ToDouble(TextBox_Height.Text);
                    TextBox_Result.Text = volume.ToString();
                    if (units == "Feet") TextBox_Result.Text += " f\xB3";
                    else if (units == "Meters") TextBox_Result.Text += " m\xB3";
                    else ResultError("Invalid units.");
                }
                else if (operation == "Surface Area")
                {
                    double surfaceArea =
                        2 *
                        ((Convert.ToDouble(TextBox_Length.Text) * Convert.ToDouble(TextBox_Width.Text))
                        +
                        (Convert.ToDouble(TextBox_Height.Text) * Convert.ToDouble(TextBox_Length.Text))
                        +
                        (Convert.ToDouble(TextBox_Height.Text) * Convert.ToDouble(TextBox_Width.Text)));
                    TextBox_Result.Text = surfaceArea.ToString();
                    if (units == "Feet") TextBox_Result.Text += " f\xB2";
                    else if (units == "Meters") TextBox_Result.Text += " m\xB2";
                    else ResultError("Invalid units.");
                }
                else ResultError("Invalid operation.");
            }
        }
        private bool ValidInputs()
        {
           bool validInputs = true;
           if (!double.TryParse(TextBox_Width.Text, out double tempWidth))
            {
                validInputs = false;
                ResultError("Invalid width.");
            }
            else if (!double.TryParse(TextBox_Length.Text, out double tempLength))
            {
                validInputs = false;
                ResultError("Invalid length.");
            }
            else if (!double.TryParse(TextBox_Height.Text, out double tempHeight))
            {
                validInputs = false;
                ResultError("Invalid height.");
            }
            return validInputs;
        }
        private void ResultError(string errorMessage)
        {
            TextBox_Result.Background = Brushes.Red;
            TextBox_Result.Text = errorMessage;
        }
        private void Button_Calculate_Click(object sender, RoutedEventArgs e)
        {
            Update_Result();
        }
        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            TextBox_Result.Background = Brushes.White;
            TextBox_Length.Text = "";
            TextBox_Width.Text = "";
            TextBox_Height.Text = "";
            TextBox_Result.Text = "";
        }
    }
}
