using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TimerEm2
{
    public class Timer
    {
        private string name;
        private int workInterval;
        private int restInterval;
        private int nbrOfIntervals;
        private bool notSound;
        private bool endSound;

        public Timer(string name, int workInterval, int restInterval, int nbrOfIntervals, bool notSound, bool endSound)
        {
            this.name = name;
            this.workInterval = workInterval;
            this.restInterval = restInterval;
            this.nbrOfIntervals = nbrOfIntervals;
            this.notSound = notSound;
            this.endSound = endSound;
        }
        
        public static void IntervalMinuteComboFiller(ComboBox c)
        {

            Dictionary<string, int> minutesDictionary = new Dictionary<string, int>();

            minutesDictionary.Add("5 minutes", 5);
            minutesDictionary.Add("10 minutes", 10);
            minutesDictionary.Add("15 minutes", 15);
            minutesDictionary.Add("20 minutes", 20);
            minutesDictionary.Add("25 minutes", 25);
            minutesDictionary.Add("30 minutes", 30);

            foreach (var i in minutesDictionary)
            {
                c.Items.Add(i.Key);
            }
        }

        public static void NumberOfintervalComboFiller(ComboBox c)
        {
            List<int> numberOfIntervalList = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9};

            foreach (var i in numberOfIntervalList)
            {
                c.Items.Add(i);
            }
        }

     
    }
}
