using System;
using System.Net.Http;
using CsQuery;

namespace MiniCrawler
{
    class Program
    {
        private const string MicrosoftGithubRepoUrl = "https://github.com/Microsoft";

        static void Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                var repositoryPage = httpClient.GetAsync(MicrosoftGithubRepoUrl).Result;
                var pageContent = repositoryPage.Content.ReadAsStringAsync().Result;

                var pageDom = CQ.Create(pageContent);
                var repositoryLinks = pageDom.Select("h3.repo-list-name a");

                foreach (var repositoryLink in repositoryLinks)
                {
                    Console.WriteLine(repositoryLink.InnerText.Trim());
                }
            }

            Console.ReadKey();
        }
    }
}
