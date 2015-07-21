using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FreshMvvmCustomNavSample
{
    public class SimpleCustomNavigationService : NavigationPage, FreshMvvm.IFreshNavigationService
    {
        public SimpleCustomNavigationService (Page page) : base (page)
        {
        }

        public async Task PopToRoot (bool animate = true)
        {
            await Navigation.PopToRootAsync (animate);
        }

        public async Task PushPage (Page page, FreshMvvm.FreshBasePageModel model, bool modal = false, bool animate = true)
        {
            if (modal)
                await Navigation.PushModalAsync (page, animate);
            else
                await Navigation.PushAsync (page, animate);
        }

        public async Task PopPage (bool modal = false, bool animate = true)
        {
            if (modal)
                await Navigation.PopModalAsync (animate);
            else
                await Navigation.PopAsync (animate);
        }
    }
}

