using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedGateProject
{
    public class ReadManager
    {
       
        private Dictionary<string, int> myDictionary = new Dictionary<string, int>();
        private List<string> wordList;

        public Dictionary<string, int> MyDictionary
        {
            get
            {
                return myDictionary;
            }
        } //accessor for myDictionary mainly used for the testing

        /// <summary>
        /// Constructor accepting ICharReader interface object
        /// Gets tje word list from the reader, as long as there is text in the file
        /// Adds the words to the dictionary if they dont exist
        /// If the word has already been added, it adds 1 to the value of the word
        /// </summary>
        /// <param name="cr"></param>
        public ReadManager(ICharacterReader cr)
        {
            
            string text = ReadFile(cr);
            this.wordList = cr.MyListOfWords;
            for (int i = 0; 
                i < wordList.Count; i++)
            {
                if (myDictionary.ContainsKey(wordList[i]))
                {
                    myDictionary[wordList[i]]++;
                }
                else
                {
                    myDictionary.Add(wordList[i], 1);
                }

            }
            cr.Dispose();
        }


        private string ReadFile(ICharacterReader cr)
        {

            char c = ' ';
            string myText = "";
            int index = 0;
            do
            {
                c = cr.SimpleCharacterReader(index);
                myText += c;
                index++;
            }
            while (c != '¬');
            cr.Dispose();
            return myText;

        }


        /// <summary>
        /// Sorts the dictionary by word count
        /// </summary>
        public void ShowByWordCount()
        {
            Console.Clear();
            Console.WriteLine("Sorted by Word Count");
            foreach (KeyValuePair<string, int> word in myDictionary.OrderByDescending(key => key.Value))
            {

                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }

            Console.WriteLine("");
            Console.ReadLine();
        }

        /// <summary>
        /// Sorts the dictionary alphabetically
        /// </summary>
        public void ShowAlphabetically()
        {
            Console.Clear();
            Console.WriteLine("Sorted Alphabetically");
            foreach (KeyValuePair<string, int> word in myDictionary.OrderBy(key => key.Key))
            {
                Console.WriteLine("{0} - {1}", word.Key, word.Value);
            }
            Console.ReadLine();
        }
    }
}
