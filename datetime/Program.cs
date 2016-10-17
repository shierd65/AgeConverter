using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datetime
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime birthDate = GetBirthDate();
            TimeSpan age = DateTime.Now - birthDate;

            int selection = GetSelection();
            while (selection != 5)
            {
                PrintFormattedAge(selection, age);
                selection = GetSelection();
            }
        }

        static void PrintFormattedAge(int selection, TimeSpan age)
        {

            Dictionary<int, Action> commands = new Dictionary<int, Action>()
            {
                {1, () => {Console.WriteLine(age.TotalDays + " days"); } },
                {2, () => {Console.WriteLine(age.TotalHours + " hours"); } },
                {3, () => {Console.WriteLine(age.TotalMinutes + " minutes"); } },
                {4, () => {Console.WriteLine(age.TotalSeconds + " seconds"); } }
            };

            commands[selection].Invoke();

            /*switch (selection)
            //{
            //    case 1:
            //        {
            //            Console.WriteLine($"{(int)age.TotalDays} days");
            //            break;
            //        }
            //    case 2:
            //        {
            //            Console.WriteLine($"{(long)age.TotalHours} hours");
            //            break;
            //        }
            //    case 3:
            //        {
            //            Console.WriteLine($"{(long)age.TotalMinutes} minutes");
            //            break;
            //        }
            //    case 4:
            //        {
            //            Console.WriteLine($"{(long)age.TotalSeconds} seconds");
            //            break;
            //        }
            //    default:
            //        {
            //            GetSelection();
            //            break;
            //        }
            //}
            */

        }

        static int GetSelection()
        {
            int selection;
            bool properSelection;

            do
            {
                Console.Write("Enter 1 for days, 2 for hours, 3 for minutes, 4 for seconds or 5 to quit. ");
                properSelection = int.TryParse(Console.ReadLine(), out selection);
            }
            while (!properSelection);

            return selection;
        }

        static DateTime GetBirthDate()
        {
            DateTime birthDate;
            bool properBirthdate;

            do
            {
                Console.Write("Enter date of birth (m/d/y): ");
                properBirthdate = DateTime.TryParse(Console.ReadLine(), out birthDate);
            }
            while (!properBirthdate);

            return birthDate;
        }

    }
}
