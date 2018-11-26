using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHubExplorer.Models
{
    public class SearchResultGrid
    {
        public string FullName { get; set; }
        public string URL { get; set; }
        public string Stars { get; set; }
        public string OpenIssues { get; set; }
        public string Language { get; set; }
    }
}
