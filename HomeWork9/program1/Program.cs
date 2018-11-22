using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace program1
{
    class Program
    {
        private Hashtable urls = new Hashtable();
        private int count = 0;
        static void Main(string[] args)
        {
            Program myCrawler = new Program();
            string startUr1 = "http://www.cnblogs.com/dstang2000/";
            if (args.Length >= 1) startUr1 = args[0];
            myCrawler.urls.Add(startUr1, false);
            Action[] actions = { new Action(myCrawler.Crawl), myCrawler.Crawl };
            Parallel.Invoke(actions);
            Console.WriteLine("主函数所在的线程" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }
        private void Crawl()
        {
            Console.WriteLine("开始爬行了...");
            while (true)
            {
                string current = null;
                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]) continue;
                    current = url;

                }
                if (current == null || count > 10) break;
                Console.WriteLine("爬行" + current + "页面!");
                string html = Download(current);
                urls[current] = true;
                count++;
                Parse(html);
                Console.WriteLine("子函数所在的线程" + Thread.CurrentThread.ManagedThreadId);
            }
            Console.WriteLine("爬行结束");
        }
        public string Download(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;
                string html = webClient.DownloadString(url);
                string fileName = count.ToString();
                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "";
            }
        }
        public void Parse(string html)
        {
            string strRef = @"(href|HREF)[]*=[]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '#', ' ', '>');
                if (strRef.Length == 0) continue;
                if (urls[strRef] == null) urls[strRef] = false;

            }
        }
    }
}
