using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace RedGateProject
{
    class Program
    {
       
        /// <summary>
        /// Main tries to run the software by looking for the textfile at the default value
        /// If it fails, it requests for a full path to be provided by the user
        /// If the user fails to provide a correct path, the software pops an error message and terminates
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            

            try
            {
                Utils.Manage("TestFile.txt");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Please provide the path to the txt file");
                try
                {
                    Utils.Manage(Console.ReadLine());
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Wrong input. Software will shut down");
                    Console.ReadLine();
                }
            }
        }

        
    }
}

