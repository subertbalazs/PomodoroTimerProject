using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Promodoro;

namespace TimerEm2
{
    class TimerLogic
    {
        public static int workStarterSecondCount = 5;
        public static int workStarterMinuteCount = 1;
        public static int workCurrentSecondCount;
        public static int workCurrentMinuteCount = workStarterMinuteCount;

        public static int restStarterSecondCount = 5;
        public static int restStarterMinuteCount = 1;
        public static int restCurrentSecondCount;
        public static int restCurrentMinuteCount = restStarterMinuteCount;

        
        public static void WorkMinuteChanger()
        {
            if (workCurrentSecondCount == -1)
            {
                workCurrentSecondCount = workStarterSecondCount;
                WorkMinuteDecrementer();             
            }
        }

        private static void WorkMinuteDecrementer()
        {
            workCurrentMinuteCount--;
        }

        public static void RestMinuteChanger()
        {
            if (restCurrentSecondCount == -1)
            {
                restCurrentSecondCount = restStarterSecondCount;
                RestMinuteDecrementer();              
            }
        }

        private static void RestMinuteDecrementer()
        {
            restCurrentMinuteCount--;
        }

        public static void WorkSecondDecrementer(TextBlock t)
        {
            if (workCurrentSecondCount < 10)
            {
                t.Text = "0" + workCurrentSecondCount--.ToString();
            }
            else
            {
                t.Text = workCurrentSecondCount--.ToString();
            }
        }

        public static void RestSecondDecrementer(TextBlock t)
        {
            if (restCurrentSecondCount < 10)
            {
                t.Text = "0" + restCurrentSecondCount--.ToString();
            }
            else
            {
                t.Text = restCurrentSecondCount--.ToString();
            }
        }

        public static void IsItLessThenTenWorkMinute(TextBlock t)
        {
            if (workCurrentMinuteCount < 10)
            {
                t.Text = "0" + workCurrentMinuteCount.ToString();
            }
            else
            {
                t.Text = workCurrentMinuteCount.ToString();
            }
        }

        public static void IsItLessThenTenRestMinute(TextBlock t)
        {
            if (restCurrentMinuteCount < 10)
            {
                t.Text = "0" + restCurrentMinuteCount.ToString();
            }
            else
            {
                t.Text = restCurrentMinuteCount.ToString();
            }
        }
        
        public static void TextBlockAppearer(TextBlock wmb, TextBlock wsb, TextBlock rmb, TextBlock rsb)
        {
            wmb.Visibility = Visibility.Visible;
            wsb.Visibility = Visibility.Visible;
            rmb.Visibility = Visibility.Collapsed;
            rsb.Visibility = Visibility.Collapsed;
        }

        public static void BtnAppearer(Button bsr, Button bsw)
        {
            bsr.Visibility = Visibility.Collapsed;
            bsw.Visibility = Visibility.Visible;
            bsw.Visibility = Visibility.Visible;
        }

        public static void StarterStopper(MediaElement m)
        {
            m.Play();
        }
        
    }
}
