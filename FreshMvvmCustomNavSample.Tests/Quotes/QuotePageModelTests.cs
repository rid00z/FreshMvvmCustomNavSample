using System;
using NUnit.Framework;
using Moq;
using Acr.UserDialogs;
using System.Threading.Tasks;

namespace FreshMvvmCustomNavSample.Tests.Quotes
{
    [TestFixture]
    public class QuotePageModelTests
    {
        public QuotePageModelTests ()
        {
        }

        [Test]
        public async Task SaveQuote_UpdatesQuote()
        {
            //arrange 
            var databaseServiceMock = new Mock<IDatabaseService>();
            var userDialogsMock = new Mock<IUserDialogs> ();
            var coreMethodsMock = new Mock<FreshMvvm.IPageModelCoreMethods> ();
            var quotePageModel = new QuotePageModel (databaseServiceMock.Object, userDialogsMock.Object);
            quotePageModel.CoreMethods = coreMethodsMock.Object;
            
            //act
            await quotePageModel.SaveQuote();

            //assert
            databaseServiceMock.Verify (o => o.UpdateQuote (It.IsAny<Quote>()));
        }
    }
}

