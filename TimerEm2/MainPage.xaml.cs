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
using TimerEm2;


namespace Promodoro
{
    public sealed partial class MainPage : Page
    {
        DispatcherTimer workTimer = new DispatcherTimer();

        DispatcherTimer restTimer = new DispatcherTimer();


        public MainPage()
        {
            this.InitializeComponent();

            workTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);  
            workTimer.Tick += WorkTimer_Tick;
            
            restTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            restTimer.Tick += RestTimer_Tick;

            restMinuteBlock.Visibility = Visibility.Collapsed;
            restSecondBlock.Visibility = Visibility.Collapsed;
         }

        private void WorkTimer_Tick(object sender, object e)
        {
            TimerLogic.WorkMinuteChanger();
            TimerLogic.IsItLessThenTenWorkMinute(workMinuteBlock);
            TimerLogic.WorkSecondDecrementer(workSecondBlock);
            WorkEndChecker();
        }

        private void RestTimer_Tick(object sender, object e)
        {
            TimerLogic.RestMinuteChanger();
            TimerLogic.IsItLessThenTenRestMinute(restMinuteBlock);
            TimerLogic.RestSecondDecrementer(restSecondBlock);
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

        public void WBAppearer()
        {
            TimerLogic.TextBlockAppearer(workMinuteBlock, workSecondBlock, restMinuteBlock, restSecondBlock);
            TimerLogic.BtnAppearer(btnStartRest, btnStartWork);
            TimerLogic.StarterStopper(mediaElement);
            restTimer.Stop();
            workTimer.Start();
        }

        public void RBAppearer()
        {
            TimerLogic.TextBlockAppearer(restMinuteBlock, restSecondBlock, workMinuteBlock, workSecondBlock);
            TimerLogic.BtnAppearer(btnStartWork, btnStartRest);
            TimerLogic.StarterStopper(mediaElement);
            workTimer.Stop();
            restTimer.Start();
        }

        public void WorkEndChecker()
        {
            if (TimerLogic.workCurrentMinuteCount == 0 && TimerLogic.workCurrentSecondCount == -1)
            {

                TimerLogic.workCurrentMinuteCount = TimerLogic.workStarterMinuteCount;
                RBAppearer();
            }
        }

        public void RestEndChecker()
        {
            if (TimerLogic.restCurrentMinuteCount == 0 && TimerLogic.restCurrentSecondCount == -1)
            {
                TimerLogic.restCurrentMinuteCount = TimerLogic.restStarterMinuteCount;
                WBAppearer();
            }
        }

        public void TimerSequenceRepeater()
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
            MySplitview.IsPaneOpen = !MySplitview.IsPaneOpen;
            if (MySplitview.IsPaneOpen)
            {
                btnShowPane.Content = "\uE00E"; //<
            }
            else
            {
                btnShowPane.Content = "\uE00F"; //>
            }
        }

        private void Timers_Menu_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof (NewTimer));
            workTimer.Stop();
            restTimer.Stop();
        }
    }
}
