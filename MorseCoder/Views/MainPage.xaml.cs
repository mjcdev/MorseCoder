using System;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MorseCoder.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.RegisterBackgroundTask();
            base.OnNavigatedTo(e);
        }

        private async void RegisterBackgroundTask()
        {
            var backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

            if (backgroundAccessStatus == BackgroundAccessStatus.AllowedMayUseActiveRealTimeConnectivity ||
               backgroundAccessStatus == BackgroundAccessStatus.AllowedWithAlwaysOnRealTimeConnectivity)
            {
                UnregisterTask(TaskName);
                RegisterTask(TaskName, TaskEntryPoint, TaskIntervalMinutes);    
            }
        }

        private const string TaskName = "LiveTileUpdate";
        private const string TaskEntryPoint = "MorseCoder.BackgroundTasks.LiveTileUpdate";
        private const uint TaskIntervalMinutes = 15;

        private void UnregisterTask(string taskName)
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == taskName)
                {
                    task.Value.Unregister(true);
                }
            }
        }

        private void RegisterTask(string taskName, string taskEntryPoint, uint intervalMinutes)
        {
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder();

            taskBuilder.Name = taskName;
            taskBuilder.TaskEntryPoint = taskEntryPoint;

            taskBuilder.SetTrigger(new TimeTrigger(intervalMinutes, false));

            var registration = taskBuilder.Register();
        }        
    }
}
