using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
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

namespace KalkulatorElektronika
{
    public partial class MainWindow : Window
    {
        private IResistance resistance;
        private IConductance conductance;

        public MainWindow()
        {
            InitializeComponent();
        }

        Regex regex = new Regex("^[0-9]+[,]?[0-9]*$");
        
        //// resistors
        
        private void Hyperlink4_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Resistor");
        }

        private void Parallel_Checked(object sender, RoutedEventArgs e)
        {
            R1text.Clear();
            R2text.Clear();
            Rxtext.Clear();
            this.resistance = new ParallelResistance();
            ImageSource image = new BitmapImage(new Uri("Images/parallelR.png", UriKind.Relative));
            this.image.Source = image;
        }

        private void Series_Checked(object sender, RoutedEventArgs e)        
        {
            R1text.Clear();
            R2text.Clear();
            Rxtext.Clear();
            this.resistance = new SeriesResistance();
            ImageSource image = new BitmapImage(new Uri("Images/seriesR.png", UriKind.Relative));
            this.image.Source = image;
        }

        private void ValidationR1text(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(R1text.Text + e.Text);
        }

        private void ValidationR2text(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(R2text.Text + e.Text);
        }

        private void ValidationRxtext(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(Rxtext.Text + e.Text);
        }
        
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            R1text.Clear();
            R2text.Clear();
            Rxtext.Clear();
        }

        private void ButtonComputeR1_Click(object sender, RoutedEventArgs e)
        {
            if (R2text.Text.Length > 0 && Rxtext.Text.Length > 0 && R2text.Text.IndexOf(" ") == (-1) && Rxtext.Text.IndexOf(" ") == (-1))
            {
                R1text.Clear();
                double resistor2 = double.Parse(R2text.Text);
                double resistorX = double.Parse(Rxtext.Text);
                this.resistance.Resistor2 = resistor2;
                this.resistance.ResistorX = resistorX;

                try
                {
                    R1text.Text = resistance.Resistor1.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    R1text.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ButtonComputeR2_Click(object sender, RoutedEventArgs e)
        {
            if (R1text.Text.Length > 0 && Rxtext.Text.Length > 0 && R1text.Text.IndexOf(" ") == (-1) && Rxtext.Text.IndexOf(" ") == (-1))
            {
                R2text.Clear();
                double resistor1 = double.Parse(R1text.Text);
                double resistorX = double.Parse(Rxtext.Text);
                this.resistance.Resistor1 = resistor1;
                this.resistance.ResistorX = resistorX;

                try
                {
                    R2text.Text = resistance.Resistor2.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    R2text.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ButtonComputeRx_Click(object sender, RoutedEventArgs e)
        {
            if (R2text.Text.Length > 0 && R1text.Text.Length > 0 && R2text.Text.IndexOf(" ") == (-1) && R1text.Text.IndexOf(" ") == (-1))
            {
                Rxtext.Clear();
                double resistor2 = double.Parse(R2text.Text);
                double resistor1 = double.Parse(R1text.Text);
                this.resistance.Resistor2 = resistor2;
                this.resistance.Resistor1 = resistor1;

                try
                {
                    Rxtext.Text = resistance.ResistorX.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    Rxtext.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }
        
        //// wave length

        double frequency;
        double er;
        double length;
        
        private void FrequencyText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(FrequencyBox.Text + e.Text);
        }

        private void ErText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(ErBox.Text + e.Text);
        }

        private void ComputeButton_Click(object sender, RoutedEventArgs e)
        {
            if (FrequencyBox.Text.Length > 0 && ErBox.Text.Length > 0 && FrequencyBox.Text.IndexOf(" ") == (-1) && ErBox.Text.IndexOf(" ") == (-1) )
            {
                this.frequency = double.Parse(FrequencyBox.Text);
                this.er = double.Parse(ErBox.Text);
                this.length = 3 * 100000000 / (this.frequency * Math.Sqrt(this.er));

                if (this.length > 0)
                {
                    WaveBox.Text = this.length.ToString();
                }
                else
                {
                    MessageBox.Show("Please enter valid values!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }            
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            ErBox.Clear();
            WaveBox.Clear();
            FrequencyBox.Clear();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Frequency");
        }

        private void Hyperlink2_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Wavelength");
        }

        private void Hyperlink3_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Speed_of_light");
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string div = slider.Value.ToString();
            
            switch (div)
            {
                case "0":
                    LengthDivideBox.Text = "Full Wave Length[cm]";
                    WaveBox.Text = this.length.ToString();
                    break;

                case "1":
                    LengthDivideBox.Text = "3/4 Wave Length[cm]";
                    WaveBox.Text = (0.75 *this.length).ToString();
                    break;

                case "2":
                    LengthDivideBox.Text = "5/8 Wave Length[cm]";
                    WaveBox.Text = (0.625 * this.length).ToString();
                    break;

                case "3":
                    LengthDivideBox.Text = "1/2 Wave Length[cm]";
                    WaveBox.Text = (0.5 * this.length).ToString();
                    break;

                case "4":
                    LengthDivideBox.Text = "1/4 Wave Length[cm]";
                    WaveBox.Text = (0.25 * this.length).ToString();
                    break;

                case "5":
                    LengthDivideBox.Text = "1/10 Wave Length[cm]";
                    WaveBox.Text = (0.1 * this.length).ToString();
                    break;

                case "6":
                    LengthDivideBox.Text = "1/15 Wave Length[cm]";
                    WaveBox.Text = (0.066667 * this.length).ToString();
                    break;

                case "7":
                    LengthDivideBox.Text = "1/20 Wave Length[cm]";
                    WaveBox.Text = (0.05 * this.length).ToString();
                    break;

                default:
                    LengthDivideBox.Text = "Default case";
                    break;
            } 
        }

        //// Ohms Law
        double e;
        double i;
        double r;

        private void ValidationE(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(EtextBox.Text + e.Text);
        }

        private void ValidationI(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(ItextBox.Text + e.Text);
        }

        private void ValidationR(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(RtextBox.Text + e.Text);
        }
        
        private void ClearOhmsButton(object sender, RoutedEventArgs e)
        {
            RtextBox.Clear();
            EtextBox.Clear();
            ItextBox.Clear();
            PTextBox.Clear();
        }

        private void ComputeR_Click(object sender, RoutedEventArgs e)
        {
            if (EtextBox.Text.Length > 0 && ItextBox.Text.Length > 0 && EtextBox.Text.IndexOf(" ") == (-1) && ItextBox.Text.IndexOf(" ") == (-1))
            {
                RtextBox.Clear();
                this.e = double.Parse(EtextBox.Text);
                this.i = double.Parse(ItextBox.Text);

                RtextBox.Text = (this.e / this.i).ToString();
                PTextBox.Text = (this.e * this.i).ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ComputeI_Click(object sender, RoutedEventArgs e)
        {
            if (EtextBox.Text.Length > 0 && RtextBox.Text.Length > 0 && EtextBox.Text.IndexOf(" ") == (-1) && RtextBox.Text.IndexOf(" ") == (-1))
            {
                ItextBox.Clear();
                this.e = double.Parse(EtextBox.Text);
                this.r = double.Parse(RtextBox.Text);

                ItextBox.Text = (this.e / this.r).ToString();
                PTextBox.Text = (this.e * this.e / this.r).ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ComputeE_Click(object sender, RoutedEventArgs e)
        {
            if (RtextBox.Text.Length > 0 && ItextBox.Text.Length > 0 && RtextBox.Text.IndexOf(" ") == (-1) && ItextBox.Text.IndexOf(" ") == (-1))
            {
                EtextBox.Clear();
                this.r = double.Parse(RtextBox.Text);
                this.i = double.Parse(ItextBox.Text);

                EtextBox.Text = (this.i * this.r).ToString();
                PTextBox.Text = (this.i * this.i * this.r).ToString();
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void Hyperlink_RequestNavigate_5(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Electromotive_force");
        }

        private void Hyperlink_RequestNavigate_6(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Electrical_resistance_and_conductance");
        }

        private void Hyperlink_RequestNavigate_7(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Power_(physics)");
        }

        private void Hyperlink_RequestNavigate_8(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Frequency");
        }

        //// ppm calcul
                
        private void ComputeButton2_Click(object sender, RoutedEventArgs e)
        {
            if (CenterFrequency1.Text.Length > 0 && MaxFrequency1.Text.Length > 0 && CenterFrequency1.Text.IndexOf(" ") == (-1) && MaxFrequency1.Text.IndexOf(" ") == (-1))
            {
                double frequency2;
                double maxfrequency2;
                double variationOfFrequency2;

                frequency2 = double.Parse(CenterFrequency1.Text);
                maxfrequency2 = double.Parse(MaxFrequency1.Text);
                variationOfFrequency2 = maxfrequency2 - frequency2;

                if (maxfrequency2 <= frequency2)
                {
                    VariationOfFrequency1.Clear();
                    PPMValue1.Clear();
                    MessageBox.Show("Please enter valid values!");
                }
                else
                {
                    VariationOfFrequency1.Text = variationOfFrequency2.ToString();
                    PPMValue1.Text = (variationOfFrequency2 * 1000000 / frequency2).ToString();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ComputeButton1_Click(object sender, RoutedEventArgs e)
        {
            if (PPMValue.Text.Length > 0 && centerFrequency.Text.Length > 0 && PPMValue.Text.IndexOf(" ") == (-1) && centerFrequency.Text.IndexOf(" ") == (-1))
            {
                double ppm1;
                double frequency1;
                double maxfrequency1;
                double minfrequency1;
                double variationOfFrequency1;

                ppm1 = double.Parse(PPMValue.Text);
                frequency1 = double.Parse(centerFrequency.Text);
                variationOfFrequency1 = frequency1 * ppm1 / 1000000;
                maxfrequency1 = variationOfFrequency1 + frequency1;
                minfrequency1 = frequency1 - variationOfFrequency1;

                if (minfrequency1 > 0 && maxfrequency1 > 0 && variationOfFrequency1 > 0)
                {
                    VariationOfFrequency.Text = variationOfFrequency1.ToString();
                    MaxFrequency.Text = maxfrequency1.ToString();
                    MinFrequency.Text = minfrequency1.ToString();
                }
                else
                {
                    VariationOfFrequency.Clear();
                    MaxFrequency.Clear();
                    MinFrequency.Clear();
                    MessageBox.Show("Please enter valid values!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }
            
        private void Hyperlink_RequestNavigate_9(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Frequency");
        }

        private void ValidationCenterFrequency(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(centerFrequency.Text + e.Text);
        }

        private void ValidationPPMValue(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(PPMValue.Text + e.Text);
        }

        private void ValidationCenterFrequency1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(CenterFrequency1.Text + e.Text);
        }

        private void ValidationMaximumFrequency1(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(MaxFrequency1 .Text + e.Text);
        }
     
        private void ClearAll2(object sender, RoutedEventArgs e)
        {
            CenterFrequency1.Clear();
            MaxFrequency1.Clear();
            VariationOfFrequency1.Clear();
            PPMValue1.Clear();
        }

        private void ClarAll1(object sender, RoutedEventArgs e)
        {
            PPMValue.Clear();
            centerFrequency.Clear();
            VariationOfFrequency.Clear();
            MaxFrequency.Clear();
            MinFrequency.Clear();
        }

        ////capacitors
        
        private void ValidationC1Text(object sender, TextCompositionEventArgs e)
        {
           e.Handled = !this.regex.IsMatch(C1textBox.Text + e.Text);
        }

        private void ValidationC2Text(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(C2textBox.Text + e.Text);
        }

        private void ValidationCxText(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(CxTextBox.Text + e.Text);
        }

        private void ClearC_Click(object sender, RoutedEventArgs e)
        {
            C1textBox.Clear();
            C2textBox.Clear();
            CxTextBox.Clear();
        }

        private void Hyperlink_RequestNavigate_10(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Capacitor");
        }

        private void CheckParallel1_Checked(object sender, RoutedEventArgs e)
        {
            C1textBox.Clear();
            C2textBox.Clear();
            CxTextBox.Clear();
            this.conductance = new ParallelConductance();
            ImageSource image = new BitmapImage(new Uri("Images/parallelC.png", UriKind.Relative));
            this.image4.Source = image;
        }

        private void CheckSeries1_Checked(object sender, RoutedEventArgs e)
        {
            C1textBox.Clear();
            C2textBox.Clear();
            CxTextBox.Clear();
            this.conductance = new SeriesConductance();
            ImageSource image = new BitmapImage(new Uri("Images/seriesC.png", UriKind.Relative));
            this.image4.Source = image;
        }

        private void ComputeC1_Click(object sender, RoutedEventArgs e)
        {
            if (C2textBox.Text.Length > 0 && CxTextBox.Text.Length > 0 && C2textBox.Text.IndexOf(" ") == (-1) && CxTextBox.Text.IndexOf(" ") == (-1))
            {
                C1textBox.Clear();
                double condensator2 = double.Parse(C2textBox.Text);
                double condensatorX = double.Parse(CxTextBox.Text);
                this.conductance.Condensator2 = condensator2;
                this.conductance.CondensatorX = condensatorX;

                try
                {
                    C1textBox.Text = conductance.Condensator1.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    C1textBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ComputeC2_Click(object sender, RoutedEventArgs e)
        {
            if (C1textBox.Text.Length > 0 && CxTextBox.Text.Length > 0 && C1textBox.Text.IndexOf(" ") == (-1) && CxTextBox.Text.IndexOf(" ") == (-1))
            {
                R2text.Clear();
                double condensator1 = double.Parse(C1textBox.Text);
                double condensatorX = double.Parse(CxTextBox.Text);
                this.conductance.Condensator1 = condensator1;
                this.conductance.CondensatorX = condensatorX;

                try
                {
                    C2textBox.Text = conductance.Condensator2.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    C2textBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }

        private void ComputeCx_Click(object sender, RoutedEventArgs e)
        {
            if (C1textBox.Text.Length > 0 && C2textBox.Text.Length > 0 && C1textBox.Text.IndexOf(" ") == (-1) && C2textBox.Text.IndexOf(" ") == (-1))
            {
                CxTextBox.Clear();
                double condensator2 = double.Parse(C2textBox.Text);
                double condensator1 = double.Parse(C1textBox.Text);
                this.conductance.Condensator2 = condensator2;
                this.conductance.Condensator1 = condensator1;

                try
                {
                    CxTextBox.Text = conductance.CondensatorX.ToString();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message);
                    CxTextBox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }
        
        //// thermal reliefs

        int flag;
       
        private void ValidationHoleDiameter(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(HoleDiamTextBox.Text + e.Text);
        }

        private void ValidationPadDiameter(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !this.regex.IsMatch(PadDiamTextBox.Text + e.Text);
        }

        private void ClearAllThermalReliefs_Click(object sender, RoutedEventArgs e)
        {
            HoleDiamTextBox.Clear();
            PadDiamTextBox.Clear();
            ThermalWidthTextBox.Clear();
        }

        private void _2webConectionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ThermalWidthTextBox.Clear();
            this.flag = 2;
            ImageSource image = new BitmapImage(new Uri("Images/2way.png", UriKind.Relative));
            this.image5.Source = image;
        }

        private void _3webConectionRadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            ThermalWidthTextBox.Clear();
            this.flag = 3;
            ImageSource image = new BitmapImage(new Uri("Images/3way.png", UriKind.Relative));
            this.image5.Source = image;
        }

        private void _4webConectionRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ThermalWidthTextBox.Clear();
            this.flag = 4;
            ImageSource image = new BitmapImage(new Uri("Images/4way.png", UriKind.Relative));
            this.image5.Source = image;
        }

        private void ComputeTheramWidthButton_Click(object sender, RoutedEventArgs e)
        {
            double minLandSize;
            double percentDifference;
            double totalWebWidth;
            double holeDiameter;
            double padDiameter;
            double thermalWidth;

            if (HoleDiamTextBox.Text.Length > 0 && PadDiamTextBox.Text.Length > 0 && HoleDiamTextBox.Text.IndexOf(" ") == (-1) && PadDiamTextBox.Text.IndexOf(" ") == (-1))
            {
                holeDiameter = double.Parse(HoleDiamTextBox.Text);
                padDiameter = double.Parse(PadDiamTextBox.Text);

                minLandSize = holeDiameter + 0.35;
                percentDifference = (padDiameter - minLandSize) / minLandSize;

                totalWebWidth = (minLandSize * 0.6) * (1 - percentDifference);

                if (totalWebWidth > 0)
                {
                    if (this.flag == 2)
                    {
                        thermalWidth = totalWebWidth / 2;
                        ThermalWidthTextBox.Text = thermalWidth.ToString();
                    }
                    else if (this.flag == 3)
                    {
                        thermalWidth = totalWebWidth / 3;
                        ThermalWidthTextBox.Text = thermalWidth.ToString();
                    }
                    else if (this.flag == 4)
                    {
                        thermalWidth = totalWebWidth / 4;
                        ThermalWidthTextBox.Text = thermalWidth.ToString();
                    }
                    else
                    {
                        ThermalWidthTextBox.Text = string.Empty;
                    }
                }
                else
                {
                    ThermalWidthTextBox.Clear();
                    MessageBox.Show("Please enter valid values!");
                }
            }
            else
            {
                MessageBox.Show("Please enter valid values!");
            }
        }
    }
}