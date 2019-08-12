using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contentful.Core;
using Contentful.Core.Models;
using Contentful.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;



namespace RazorPagesMovie.Pages
{

    public class Blog
    {
        public Contentful.Core.Models.SystemProperties Sys { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public Contentful.Core.Models.Document Text { get; set; }


        public List<Asset> Image { get; set; }

    }

    public class IndexModel : PageModel
    {
        private IContentfulClient client;
        IConfiguration configuration;

        public Blog Blog { get; set; }

        public IndexModel(IConfiguration configuration, IContentfulClient client, IOptions<ContentfulOptions> contentfulOptions)
        {
            this.client = client;
            this.configuration = configuration;
        }
        public async Task OnGetAsync()
        {
            var entries = await client.GetEntriesByType<Blog>("blog");
            this.Blog = entries.First();
        }

        private class Debugger
        {
        }
    }
}
