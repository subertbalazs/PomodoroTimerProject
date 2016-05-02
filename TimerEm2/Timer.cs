using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TimerEm2
{
    class Timer
    {
        
        public static void ComboFiller(ComboBox c)
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
    }
}
