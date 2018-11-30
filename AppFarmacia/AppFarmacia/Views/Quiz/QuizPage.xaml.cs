using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace AppFarmacia.Views.Quiz
{
    public partial class QuizPage : ContentPage
    {
        public QuizPage()
        {
            InitializeComponent();
            ansPicker.ItemsSource = new[]
            {
                "Red",
                "Blue",
                "Green",
                "Yellow",
                "Orange"
            };
            ansPicker.CheckedChanged += AnsPicker_CheckedChanged;
        }

        private void AnsPicker_CheckedChanged(object sender, int e)
        {

            if (!(sender is CustomRadioButton radio) || radio.Id == -1)
            {
                return;
            }

            DisplayAlert("Info", radio.Text, "OK");
        }
    }
    
}
