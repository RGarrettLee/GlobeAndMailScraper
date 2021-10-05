using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Globe_n_Mail_Article_Grabber {
    class Program {

        static void Main(string[] args) {
            StreamWriter sw = new StreamWriter("scraped article.txt");
            string link = "";
            string node = "c-article-body__text";

            Console.Title = "Globe and Mail Article Grabber";
            Console.WriteLine("=========================================================");
            Console.WriteLine("Retrieves Articles from The Globe and Mail");
            Console.WriteLine("ALL ARTCILE LINKS WORK. EVEN SUBSCRIBER LOCKED ONES");
            Console.WriteLine("=========================================================");
            Console.Write("\nArticle Link: ");
            link = Console.ReadLine();

            HtmlWeb web = new HtmlWeb();

            GetLink:

            try {
                HtmlDocument doc = web.Load(link);

                var HeaderNames = doc.DocumentNode.SelectNodes($"//p[@class='{node}']").ToList();

                foreach (var item in HeaderNames) {
                    sw.WriteLine(item.InnerText);
                }

                sw.Close();
                Process.Start("scraped article.txt");

            } catch {
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("Retrieves Articles from The Globe and Mail");
                Console.WriteLine("ALL ARTCILE LINKS WORK. EVEN SUBSCRIBER LOCKED ONES");
                Console.WriteLine("=========================================================");
                Console.WriteLine("\nYou have entered an invalid link");
                Console.Write("\nArticle Link: ");
                link = Console.ReadLine();
                goto GetLink;
            }
        }
    }
}
