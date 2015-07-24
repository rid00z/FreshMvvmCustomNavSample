using Xamarin.Forms;
using PropertyChanged;
using FreshMvvm;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace FreshMvvmCustomNavSample
{
    [ImplementPropertyChanged]
    public class QuotePageModel : FreshBasePageModel
    {
        IDatabaseService _databaseService;
        IUserDialogs _userDialogs;
        public Quote Quote { get; set; }

        public QuotePageModel (IDatabaseService databaseService, IUserDialogs userDialogs)
        {
            _databaseService = databaseService;
            _userDialogs = userDialogs;
        }

        public override void Init (object initData)
        {			
            Quote = initData as Quote;
            if (Quote == null)
                Quote = new Quote ();
        }

        public Command SaveCommand {
            get {
                return new Command (async () => await SaveQuote());
            }
        }

        public async Task SaveQuote()
        {
            _userDialogs.ShowLoading("Saving Quote");

            try
            {
                await _databaseService.UpdateQuote (Quote);
            }
            finally
            {
                _userDialogs.HideLoading();
            }

            await CoreMethods.PopPageModel (Quote);
        }

        public Command TestModal {
            get {
                return new Command (async () => {
                    await CoreMethods.PushPageModel<ModalPageModel> (null, true);
                });
            }
        }
    }
}

