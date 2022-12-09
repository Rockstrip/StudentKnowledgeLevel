using InferenceLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace FuzzyAlzheimerUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : UiWindow
    {
        public MainWindow()
        {
            ModelCacheManager.InitializeModel();
            InitializeComponent();


        }

        //Change app theme
        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            Theme.Apply(Theme.GetAppTheme() is ThemeType.Dark ? ThemeType.Light : ThemeType.Dark);
        }

        private static readonly Regex _regex = new Regex("[^0-9,]+"); //regex that matches disallowed text
        //Allow only numeric input
        private void PreviewTextInputEvent(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = _regex.IsMatch(e.Text);
        }


        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var ml = double.Parse(ML_Value.Text)   / 10;
                var cs1 = double.Parse(CS1_Value.Text) / 10;
                var cs2 = double.Parse(CS2_Value.Text) / 10;
                    
                /*
                if (ml is < 0 or > 10 
                    || cs1 is < 0 or > 10 
                    || cs2 is < 0 or > 10)
                    throw new ArgumentException();
                    */
                
                var result = MamdaniInference.Process(new[] { ml, cs1, cs2 });

                Crisp_Value.Text = Math.Round(result.crispResult * 10, 2).ToString(CultureInfo.InvariantCulture);
                Word_Value.Text = GetSeverity(result.wordResult.term);
            }
            catch
            {
                var mb = new Wpf.Ui.Controls.MessageBox();
                mb.ButtonLeftName = "Гаразд";
                mb.ButtonRightName = "Скасувати";
                mb.Show("Помилка", "Сталася помилка. Перевірте коректність введених значень.");
            }
        }

        private string GetSeverity(Severity severity) =>
            severity switch
            {
                Severity.Unsatisfactory => "Низький",
                Severity.Satisfactory => "Середній",
                Severity.Good => "Задовільний",
                Severity.Excellent => "Високий",
                _ => throw new NotImplementedException()
            };
    }
}
