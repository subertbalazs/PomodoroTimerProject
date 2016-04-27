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


namespace Promodoro
{
    public sealed partial class MainPage : Page
    {
        DispatcherTimer workTimer = new DispatcherTimer();

        DispatcherTimer restTimer = new DispatcherTimer();

        static int workStarterSecondCount = 5;
        static int workStarterMinuteCount = 1;
        int workCurrentSecondCount;
        int workCurrentMinuteCount = workStarterMinuteCount;

        static int restStarterSecondCount = 5;
        static int restStarterMinuteCount = 1;
        int restCurrentSecondCount;
        int restCurrentMinuteCount = restStarterMinuteCount;

        public MainPage()
        {
            this.InitializeComponent();

            workTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);  
            workTimer.Tick += WorkTimer_Tick;
            
            restTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            restTimer.Tick += RestTimer_Tick;

            restMinuteBlock.Visibility = Visibility.Collapsed;
            restSecondBlock.Visibility = Visibility.Collapsed;
            restColonBlock.Visibility = Visibility.Collapsed;

        }

        private void WorkTimer_Tick(object sender, object e)
        {
            WorkMinuteChanger();
            WorkSecondDecrementer();
            WorkEndChecker();
        }

        private void RestTimer_Tick(object sender, object e)
        {
            RestMinuteChanger();
            RestSecondDecrementer();
            TimerSequenceRepeater();
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

        private void WorkMinuteChanger()
        {
            if (workCurrentSecondCount == -1)
            {
                workCurrentSecondCount = workStarterSecondCount;
                WorkMinuteDecrementer();
                IsItLessThenTenWorkMinute();
            }
        }

        private void WorkMinuteDecrementer()
        {
            workCurrentMinuteCount--;
        }

        private void RestMinuteChanger()
        {
            if (restCurrentSecondCount == -1)
            {
                restCurrentSecondCount = restStarterSecondCount;
                RestMinuteDecrementer();
                IsItLessThenTenRestMinute();
            }
        }

        private void RestMinuteDecrementer()
        {
               restCurrentMinuteCount--;
        }

        private void WorkSecondDecrementer()
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

        private void RestSecondDecrementer()
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

        private void IsItLessThenTenWorkMinute()
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

        private void IsItLessThenTenRestMinute()
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
            if (workCurrentMinuteCount == 0 && workCurrentSecondCount == -1)
            {
                mediaElement.Play();
                workTimer.Stop();
                workCurrentMinuteCount = workStarterMinuteCount;

                restTimer.Start();
                btnStartWork.Visibility = Visibility.Collapsed;
                btnStartRest.Visibility = Visibility.Visible;
                workMinuteBlock.Visibility = Visibility.Collapsed;
                workSecondBlock.Visibility = Visibility.Collapsed;
                restMinuteBlock.Visibility = Visibility.Visible;
                restSecondBlock.Visibility = Visibility.Visible;
                restColonBlock.Visibility = Visibility.Visible;
                workColonBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void RestEndChecker()
        {
            if (restCurrentMinuteCount == 0 && restCurrentSecondCount == -1)
            {
                mediaElement.Play();
                restTimer.Stop();
                restCurrentMinuteCount = restStarterMinuteCount;

                workTimer.Start();
                btnStartRest.Visibility = Visibility.Collapsed;
                btnStartWork.Visibility = Visibility.Visible;

                workMinuteBlock.Visibility = Visibility.Visible;
                workSecondBlock.Visibility = Visibility.Visible;
                workColonBlock.Visibility = Visibility.Visible;
                btnStartWork.Visibility = Visibility.Visible;
                restMinuteBlock.Visibility = Visibility.Collapsed;
                restSecondBlock.Visibility = Visibility.Collapsed;
                restColonBlock.Visibility = Visibility.Collapsed;
            }
        }

        private void TimerSequenceRepeater()
        {
            if (repeaterBox.IsChecked.Value)
            {
                RestEndChecker();
            }
            else
            {
                RestEndChecker();
                workTimer.Stop();
            }
        }

        private void BtnShowPane_OnClick(object sender, RoutedEventArgs e)
        {
            MySplitview.IsPaneOpen =!MySplitview.IsPaneOpen;
            if (MySplitview.IsPaneOpen)
            {
            btnShowPane.Content = "\uE00E"; //<
            }
            else
            {
            btnShowPane.Content = "\uE00F"; //>
            }
        }
    }
}
