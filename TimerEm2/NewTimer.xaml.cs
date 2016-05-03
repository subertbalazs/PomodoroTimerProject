using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Promodoro;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TimerEm2
{

    public sealed partial class NewTimer : Page
    {
        public static List<Timer> Timers = new List<Timer>(); 

        public NewTimer()
        {
            this.InitializeComponent();
            Timer.IntervalMinuteComboFiller(cbWork);
            Timer.IntervalMinuteComboFiller(cbRest);
            Timer.NumberOfintervalComboFiller(cbIntervals);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (nameBox.Text != "")
                {
                    Timers.Add(new Timer(nameBox.Text, cbWork.SelectedIndex, cbRest.SelectedIndex, cbIntervals.SelectedIndex,
                                        endSound: false, notSound: false));
                    NewTimerFrame.Navigate(typeof (MainPage));
                }
            }
            catch (Exception)
            {

                nameBox.PlaceholderText = "Name field is empty.";
            }
        }

        public static void TimerChooserComboFiller(ComboBox c)
        {
            foreach (var i in Timers)
            {
                c.Items.Add(i.Name); // the combo should list the names, not the instances.
            }
        }

        private void btnBackNT_Click(object sender, RoutedEventArgs e)
        {
            NewTimerFrame.Navigate(typeof (MainPage));
        }

        private void cbWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void cbRest_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }
}
