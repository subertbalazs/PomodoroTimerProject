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
        public string Name { get; }
        public int WorkInterval { get; }
        public int RestInterval { get; }
        public int NbrOfIntervals { get; }
        public bool NotSound { get; }
        public bool EndSound { get; }

        public Timer(string name, int workInterval, int restInterval, int nbrOfIntervals, bool notSound, bool endSound)
        {
            Name = name;
            WorkInterval = workInterval;
            RestInterval = restInterval;
            NbrOfIntervals = nbrOfIntervals;
            NotSound = notSound;
            EndSound = endSound;
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
