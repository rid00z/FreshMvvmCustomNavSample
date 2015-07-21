using System;

using Xamarin.Forms;
using FreshMvvm;

namespace FreshMvvmCustomNavSample
{
    public class App : Application
    {
        public App ()
        {
            FreshIOC.Container.Register<IDatabaseService, DatabaseService> ();

            MainPage = new LaunchPage(this);
        }

        public void AdvancedCustomNav ()
        {
            MainPage = new MasterTabbedNavigationService ();
        }

        public void BasicCustomNav ()
        {
            //Get the first page to be displayed
            var page = FreshPageModelResolver.ResolvePageModel<MainMenuPageModel> ();

            //create our navigation service
            var customNavigationService = new SimpleCustomNavigationService (page);

            //register the Navigation service in the app, this enables us to push model to model
            FreshIOC.Container.Register<IFreshNavigationService> (customNavigationService);

            //display navigation service in main page
            MainPage = customNavigationService;
        }

        public void SwitchOnIdiom ()
        {
            if (Device.Idiom == TargetIdiom.Phone) {
                var masterDetailNav = new FreshMasterDetailNavigationContainer ();
                masterDetailNav.Init ("Menu");
                masterDetailNav.AddPage<ContactListPageModel> ("Contacts", null);
                masterDetailNav.AddPage<QuoteListPageModel> ("Quotes", null);
                MainPage = masterDetailNav;
            } else {
                var tabbedNavigation = new FreshTabbedNavigationContainer ();
                tabbedNavigation.AddTab<ContactListPageModel> ("Contacts", "contacts.png", null);
                tabbedNavigation.AddTab<QuoteListPageModel> ("Quotes", "document.png", null);
                MainPage = tabbedNavigation;
            }
        }

        protected override void OnStart ()
        {
            // Handle when your app starts
        }

        protected override void OnSleep ()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume ()
        {
            // Handle when your app resumes
        }
    }
}

