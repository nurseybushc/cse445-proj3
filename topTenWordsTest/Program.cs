using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topTenWordsTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing Started at: " + DateTime.Now);
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            //Web2String.ServiceClient proxy = new Web2String.ServiceClient();

            string websiteAddress = "http://www.example.com";
            string[] topTen;
            topTen = proxy.topTen(websiteAddress);

            //string[] wholeWebsiteParsed = wholeWebsite.Split(' ');
            foreach (string word in topTen)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("Processing Finished at: " + DateTime.Now);

            ServiceReference2.Service1Client proxy2 = new ServiceReference2.Service1Client();
            string test = "hello, i am the dude is the .... my bad <help>";
            string wordsFiltered = proxy2.WordFilter(test);

            Console.WriteLine("Unfiltered string:");
            Console.WriteLine(test);
            Console.WriteLine("Filtered string:");
            Console.WriteLine(wordsFiltered);
            Console.ReadLine();
        }
    }
}
