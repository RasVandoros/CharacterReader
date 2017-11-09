using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedGateProject;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CharacterReaderTests
{
    [TestClass]
    public class CharacterReaderTests
    {

        /// <summary>
        /// Checks the functionality of the SimpleCharacterReader
        /// </summary>
        [TestMethod]
        public void test_SimpleCharReader()
        {
            //arrange
            int index = 0;
            char expected = 'T';
            Stream stream = new FileStream("TestFile.txt", FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);

            //act
            char actual = cr.SimpleCharacterReader(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the simpleCharReader method, making sure that it does as intended asked for an out of reach character
        /// </summary>
        [TestMethod]
        public void test_SimpleCharReaderEndOfText()
        {
            //arrange
            int index = 16;
            char expected = '¬';
            Stream stream = new FileStream("TestFile.txt", FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);

            //act
            char actual = cr.SimpleCharacterReader(index);

            //assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check if the constructor is working as intended
        /// </summary>
        [TestMethod]
        public void test_Constructor()
        {
            //arrange
            string text = "This is a test.";
            Stream stream = new FileStream("TestFile.txt", FileMode.Open);


            //act
            CharacterReader cr = new CharacterReader(stream);
            //assert

            Assert.AreEqual(text, cr.Text);
        }


        /// <summary>
        /// this method checks if the constuctor is working properly when dealing with an empty txt file. 
        /// </summary>
        [TestMethod]
        public void test_ConstructorEmtyTxtFile()
        {
            //arrange
            string text = "";
            Stream stream = new FileStream("EmptyTxt.txt", FileMode.Open);


            //act
            CharacterReader cr = new CharacterReader(stream);

            //assert
            Assert.AreEqual(text, cr.Text);
        }

        /// <summary>
        /// Checks if the word list is created properly
        /// </summary>
        [TestMethod]
        public void test_WordList()
        {
            //arrange
            List<string> list = new List<string>();
            list.Add("This");
            list.Add("is");
            list.Add("a");
            list.Add("test");

            Stream stream = new FileStream("TestFile.txt", FileMode.Open);


            //act
            CharacterReader cr = new CharacterReader(stream);

            //assert
            CollectionAssert.AreEqual(list, cr.MyListOfWords);
        }

        /// <summary>
        /// Checks if the word list is handled appropriatelly when the text file is empty
        /// </summary>
        [TestMethod]
        public void test_EmptyWordList()
        {
            //arrange
            Stream stream = new FileStream("EmptyTxt.txt", FileMode.Open);

            //act
            CharacterReader cr = new CharacterReader(stream);

            //assert
            CollectionAssert.AreEqual(null, cr.MyListOfWords);
        }


        [TestMethod]
        public void test_Dictionary()
        {
            //arrange
            Stream stream = new FileStream("TestFile.txt", FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            myDictionary.Add("This", 1);
            myDictionary.Add("is", 1);
            myDictionary.Add("a", 1);
            myDictionary.Add("test", 1);

            //act
            ReadManager rm = new ReadManager(cr);


            //assert
            CollectionAssert.AreEqual(myDictionary, rm.MyDictionary);
        }

        /// <summary>
        /// This method replicates the process of sorting the dictionary by word count to make sure its been done properly. 
        /// </summary>
        [TestMethod]
        public void test_WordCountDictionary()
        {
            //arrange
            Stream stream = new FileStream("TestFile2.txt", FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            myDictionary.Add("test", 2);
            myDictionary.Add("This", 1);
            myDictionary.Add("is", 1);
            myDictionary.Add("a", 1);


            //act
            ReadManager rm = new ReadManager(cr);
            Dictionary<string, int> myActualDictionary = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> word in rm.MyDictionary.OrderByDescending(key => key.Value))
            {

                myActualDictionary.Add(word.Key, word.Value);
            }

            //assert
            CollectionAssert.AreEqual(myDictionary, myActualDictionary);
        }


        /// <summary>
        /// This method replicates the process of sorting the dictionary alphabetically to make sure its been done properly. 
        /// </summary>
        [TestMethod]
        public void test_AlphabeticalDictionary()
        {
            //arrange
            Stream stream = new FileStream("TestFile2.txt", FileMode.Open);
            CharacterReader cr = new CharacterReader(stream);
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            myDictionary.Add("a", 1);
            myDictionary.Add("is", 1);
            myDictionary.Add("test", 2);
            myDictionary.Add("This", 1);


            //act
            ReadManager rm = new ReadManager(cr);
            Dictionary<string, int> myActualDictionary = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> word in myDictionary.OrderBy(key => key.Key))
            {
                myActualDictionary.Add(word.Key, word.Value);
            }

            //assert
            CollectionAssert.AreEqual(myDictionary, myActualDictionary);
        }


        /// <summary>
        /// This method replicates the process of sorting the dictionary alphabetically to make sure its been done properly. 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void test_UtilsManage()
        {
            //arrange
            string path;
            path = "TestFile123.txt";

            //act
            Utils.Manage(path);

            //assert
            Assert.Fail();

        }
    }
}
