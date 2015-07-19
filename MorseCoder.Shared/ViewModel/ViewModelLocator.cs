using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MorseCoder.Design;
using MorseCoder.Interfaces;
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

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IMorseCoderSettings, DesignMorseCoderSettings>();
            }
            else
            {
                SimpleIoc.Default.Register<IMorseCoderSettings, MorseCoderSettings>();
            }            
        }
    }
}
