using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateProject
{
    public class Utils
    {
        /// <summary>
        /// Creates a new stream to a path 
        /// Instantiates character reader by passing the stream to it
        /// Instantiates ReadManager object that will handle all the actions regarding the text file
        /// The ReadManager object projects the seperated words ordered by their letter count, and after the user presses enter
        /// clears the console and prints them in alphabetical order
        /// </summary>
        /// <param name="txtPath"></param>
        public static void Manage(string txtPath)
        {
            Stream stream = new FileStream(txtPath, FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);
            if (cr.MyListOfWords != null)
            {
                ReadManager rm = new ReadManager(cr);
                rm.ShowByWordCount();
                Console.Clear();
                rm.ShowAlphabetically();
            }
            Console.ReadLine();

        }
    }
}
