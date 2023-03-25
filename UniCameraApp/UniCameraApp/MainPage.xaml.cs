using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UniCameraApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BtnPickImg_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions()
                {
                    Title = "Please pick a photo"
                });

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    resultImage.Source = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message.ToString(), "Ok");
            }
        }

        private async void BtnCam_OnClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.CapturePhotoAsync();

                if (result != null)
                {
                    var stream = await result.OpenReadAsync();

                    resultImage.Source = ImageSource.FromStream((() => stream));
                }
            }
            catch (Exception exception)
            {
                await DisplayAlert("Error", exception.Message.ToString(), "Ok");
            }
        }
    }
}
