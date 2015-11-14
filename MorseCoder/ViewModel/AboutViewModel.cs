using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using Windows.System;

namespace MorseCoder.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        private const string AppProductId = "9nblggh69ftb";

        public AboutViewModel()
        {
            ReviewAppCommand = new RelayCommand(ReviewAppAction);
        }

        public RelayCommand ReviewAppCommand { get; private set; }

        private async void ReviewAppAction()
        {
            string reviewAppUri = string.Format("ms-windows-store://review/?ProductId={0}", AppProductId);
            await Launcher.LaunchUriAsync(new Uri(reviewAppUri));
        }
    }
}
