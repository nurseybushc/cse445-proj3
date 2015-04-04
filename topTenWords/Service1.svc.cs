using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace topTenWords
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        ServiceReference1.ServiceClient proxy;

        public string[] topTen(string website)
        {
            proxy = new ServiceReference1.ServiceClient();
            string websiteString = proxy.GetWebContent(website);
            List<string> words = new List<string>();
            List<int> wordCount = new List<int>();
            string[] websiteStringParsed = websiteString.Split(new Char[] {' ', ',', '.', '\n', '\t', '>', '<', '&', '+', ';', '='});

            bool wordExists;
            int loopCount = 0;
            foreach (string value in websiteStringParsed) {

                if (value.All(Char.IsLetter) && value.Length > 1)
                {
                    wordExists = words.Exists(word => word.Equals(value));
                    if (wordExists) //if the word is in the list already, then only increase
                    //the count of it in the 2nd list
                    {
                        int index = words.FindIndex(word => word.Equals(value));
                        wordCount[index] = wordCount[index] + 1;
                    }
                    else//else add the word to the word list and make count 1
                    {
                        words.Add(value);
                        wordCount.Add(1);
                    }
                }
                //loopCount++;
            }

            //get top ten words in the word count list
            string[] topTen = new string[10];
            int[] maxCounts = {0,0,0,0,0,0,0,0,0,0};
            loopCount = 0;
            foreach (string word in words)
            {
                int maxCountLoop = 0;
                bool alreadyEntered = false;
                foreach(int max in maxCounts){
                    if (wordCount[loopCount] > max && alreadyEntered == false)
                    {
                        maxCounts[maxCountLoop] = loopCount;
                        alreadyEntered = true;
                    }
                    maxCountLoop++;
                }
                
                loopCount++;
            }

            for (int i = 0; i < 10; ++i)
            {
                topTen[i] = words[maxCounts[i]];
            }
            return topTen;
        }

    }
}
