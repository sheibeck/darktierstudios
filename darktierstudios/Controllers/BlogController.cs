using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace darktierstudios.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        //[OutputCache(Duration = 86400, VaryByParam = "none")] // cache for 24 hours
        public ActionResult Index()
        {
            string url = "https://sterlingheibeck.wordpress.com/feed";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            var blogItemList = new List<BlogItem>();
            foreach(var post in feed.Items)
            {
                var blogPost = new BlogItem()
                {
                    Authors = "Sterling Heibeck",
                    Image = post.ElementExtensions.Where(p => p.OuterName == "thumbnail").First().GetObject<XElement>().Attribute("url").Value,
                    Title = post.Title.Text,
                    Uri = post.Links[0].Uri.AbsoluteUri,
                    Summary = post.Summary.Text,
                    PublishDate = post.PublishDate.LocalDateTime.ToShortDateString()
                };
                
                blogItemList.Add(blogPost);
            }

            ViewBag.BlogPosts = blogItemList;

            return View();
        }
    }

    public class BlogItem
    {
        public string Authors { get; set;}
        public string Title { get;  set;}
        public string Image { get; set; }
        public string Uri { get; set; }
        public string Summary { get; set; }
        public string PublishDate { get; set; }

    }
}