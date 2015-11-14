using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MorseCoder.Design;
using MorseCoder.Interfaces;
using MorseCoder.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCoder.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        
        public AboutViewModel About
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutViewModel>();
            }
        }

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            INavigationService navigationService = CreateNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMorseCoderSettings, DesignMorseCoderSettings>();
            }
            else
            {
                SimpleIoc.Default.Register<IMorseCoderSettings, MorseCoderSettings>();
            }            
        }

        private static INavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();

            navigationService.Configure("About", typeof(AboutPage));

            return navigationService;
        }
    }
}
