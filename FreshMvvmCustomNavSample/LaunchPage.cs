using System;
using Xamarin.Forms;
using System.Collections.Generic;
using FreshMvvmCustomNavSample;

namespace FreshMvvmCustomNavSample
{
    public class LaunchPage : ContentPage
    {
        public LaunchPage (App app)
        {
            Title = "Select Sample";
            var list = new ListView ();
            list.ItemsSource = new List<string> {
                "Basic Custom",
                "Advanced Custom",
                "SwitchOnIdiom"
            };
            list.ItemTapped += (object sender, ItemTappedEventArgs e) => {
                if ((string)e.Item == "Basic Custom")
                    app.BasicCustomNav ();
                else if ((string)e.Item == "Advanced Custom")
                    app.AdvancedCustomNav ();
                else if ((string)e.Item == "SwitchOnIdiom")
                    app.SwitchOnIdiom();
            };
            this.Content = list;
        }
    }
}

