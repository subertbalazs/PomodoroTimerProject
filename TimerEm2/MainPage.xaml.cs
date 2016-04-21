using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace TimerEm2
{
    public sealed partial class MainPage : Page
    {
        DispatcherTimer workTimer = new DispatcherTimer();

        DispatcherTimer restTimer = new DispatcherTimer();

        int workCurrentSecondCount;
        int workCurrentMinuteCount = 25;

        int restCurrentSecondCount;
        int restCurrentMinuteCount = 5;

        public MainPage()
        {
            this.InitializeComponent();

            workTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);  
            workTimer.Tick += WorkTimer_Tick;
            
            restTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            restTimer.Tick += RestTimer_Tick;

        }

        private void WorkTimer_Tick(object sender, object e)
        {
            ChangeMinuteCheckerWork();
            WorkTimeIncrementer();
            WorkEndChecker();
        }

        private void RestTimer_Tick(object sender, object e)
        {
            ChangeMinuteCheckerRest();
            RestTimeIncrementer();
            RestEndChecker();
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            workTimer.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
           workTimer.Stop();
           restTimer.Stop();
        }

        private void btnStartRest_Click(object sender, RoutedEventArgs e)
        {
            restTimer.Start();
        }

        private int ChangeMinuteCheckerWork()
        {
            if (workCurrentSecondCount == 0)
            {
                workCurrentSecondCount = 59;
                workCurrentMinuteCount --;
                IsItLessThenTenWorkMIN();
            }
            return workCurrentMinuteCount;
        }

        private int ChangeMinuteCheckerRest()
        {
            if (restCurrentSecondCount == 0)
            {
                restCurrentSecondCount = 59;
                restCurrentMinuteCount--;
                IsItLessThenTenRestMIN();
            }
            return restCurrentMinuteCount;
        }

        private void WorkTimeIncrementer()
        {
            if (workCurrentSecondCount < 10)
            {
                workSecondBlock.Text = "0" + workCurrentSecondCount--.ToString();
            }
            else
            {
                workSecondBlock.Text = workCurrentSecondCount--.ToString();
            }
        }

        private void RestTimeIncrementer()
        {
            if (restCurrentSecondCount < 10)
            {
                restSecondBlock.Text = "0" + restCurrentSecondCount--.ToString();
            }
            else
            {
                restSecondBlock.Text = restCurrentSecondCount--.ToString();
            }
        }

        private void IsItLessThenTenWorkMIN()
        {
            if (workCurrentMinuteCount < 10)
            {
                workMinuteBlock.Text = "0" + workCurrentMinuteCount.ToString();
            }
            else
            {
                workMinuteBlock.Text = workCurrentMinuteCount.ToString();
            }
        }

        private void IsItLessThenTenRestMIN()
        {
            if (restCurrentMinuteCount < 10)
            {
                restMinuteBlock.Text = "0" + restCurrentMinuteCount.ToString();
            }
            else
            {
                restMinuteBlock.Text = restCurrentMinuteCount.ToString();
            }
        }
    
        private void WorkEndChecker()
        {
            if (workCurrentMinuteCount <= 0 && workCurrentSecondCount <= 0)
            {
                workTimer.Stop();
                workCurrentMinuteCount = 1;
                restTimer.Start();
                startButton.Visibility = Visibility.Collapsed;
                btnStartRest.Visibility = Visibility.Visible;
            }
        }

        private void RestEndChecker()
        {
            if (restCurrentMinuteCount <= 0 && restCurrentSecondCount <= 0)
            {
                restTimer.Stop();
                restCurrentMinuteCount = 1;
                workTimer.Start();
                btnStartRest.Visibility = Visibility.Collapsed;
                startButton.Visibility = Visibility.Visible;
            }
        }

    }

}
