using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        double x, y;

        private void Button_Clicked(object sender, EventArgs e)
        {
            bottomSheet.TranslateTo(0, 0, 250);
        }

        private void Button_ToTop_Clicked(object sender, EventArgs e)
        {
            bottomSheet.TranslateTo(bottomSheet.X, -(Height * 0.85));
        }

        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            var translateY = Math.Max(Math.Min(0, -bottomSheet.TranslationY + e.TotalY), -Math.Abs((Height * 0.1) - Height));
            // Handle the pan
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    bottomSheet.TranslateTo(bottomSheet.X, bottomSheet.TranslationY + e.TotalY, 50);
                    break;
                case GestureStatus.Completed:
                case GestureStatus.Canceled:
                    y = bottomSheet.TranslationY;

                    Console.WriteLine("TranslationY: ["+ Math.Abs(bottomSheet.TranslationY) + " ]");
                    if (Math.Abs(bottomSheet.TranslationY) > Height * .2 )
                    {
                        bottomSheet.TranslateTo(bottomSheet.X, -(Height * 0.85));
                    }
                    else
                    {
                    //bottomSheet.TranslateTo(bottomSheet.X, translateY, 50);
                        bottomSheet.TranslateTo(bottomSheet.X, 0);
                    }

                    break;

            }

        }
    }
}
