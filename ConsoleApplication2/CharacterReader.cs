using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RedGateProject
{
    public class CharacterReader : ICharacterReader
    {
        

        private List<string> myListOfWords;
        private string text;
        private StreamReader sr;

        public string Text
        {
            get
            {
                return text;
            }
            
        } 

        public List<string> MyListOfWords//full list of words in the file
        {
            get
            {
                return this.myListOfWords;
            }
        }

        /// <summary>
        /// Constructor of the Class
        /// Takes a stream, reads from it, trims the punctuation, splits it into words and assigns it to a list.
        /// If the text file is empty, the software pops an error message and terminates
        /// </summary>
        /// <param name="stream"></param>
        public CharacterReader(Stream stream)
        {
            using ( sr = new StreamReader(stream))
            {
                text = sr.ReadToEnd();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    var punctuation = text.Where(char.IsPunctuation).Distinct().ToArray();
                    myListOfWords = (text.Split(' ').Select(x => x.Trim(punctuation))).ToList();
                }
                else
                {
                    text = "";
                    Console.WriteLine("The text file was empty and this is an error message");
                }
            }
        }
        /// <summary>
        /// Takes and integer as a parameter tha represents the index of the character that is going to be returned. 
        /// The ¬ character is used as a special character returned only when the end of stream is reached, therefore in case we find it in the file
        /// we return - instead to avoid unintentionally closing the stream.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public char SimpleCharacterReader(int index)
        {
            
            char c = ' ';
            if (text.Length > index)
            {
                if(text[index] != '¬')
                {
                    c = text[index];
                }
                else
                {
                    c = '-';
                }
            }
            else
            {
                //throw new EndOfStreamException("Reached the end of the stream");
                //Console.WriteLine("Reached the end of the stream. Current index is: " + index);
                c = '¬';
            }
            return c;
        }

        /// <summary>
        /// This method allows finallisation of the StreamWriter from outside the class.
        /// </summary>
        public void Dispose()
        {
            sr.Close();
        }
        
    }
    /// <summary>
    /// SimpleCharacterReader, Dispose and List of all words in the text file
    /// </summary>
    public interface ICharacterReader
    {

        char SimpleCharacterReader(int index);

        void Dispose();

        List<string> MyListOfWords { get; }
    }
}
