using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace RecEngineApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecEngController : ControllerBase
    {
        public class Recommendation
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public Uri Uri { get; set; }
        }

        private static readonly Recommendation[] Recommendations = new[]
        {
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/malm-chest-of-3-drawers__0750587_PE746787_S5.JPG?f=xxs"), Name = "Malm", Description = "Chest of 3 drawers, grey stained"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/bryggja-chest-of-9-drawers-beige__0778108_PE760067_S5.JPG?f=xxs"), Name = "Bryggia", Description = "Chest of 9 drawers, beige"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/kullen-chest-of-5-drawers__0778067_PE758824_S5.JPG?f=xxs"), Name = "Kullen", Description = "Chest of 5 drawers, white"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/hemnes-chest-of-8-drawers-white-stain__0858919_PE554983_S5.JPG?f=xxs"), Name = "Hemnes", Description = "Chest of 3 drawers, white"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/askvoll-chest-of-3-drawers-white-stained-oak-effect-white__0858963_PE555910_S5.JPG?f=xxs"), Name = "Askvoll", Description = "Chest of 3 drawers, stained oak and white"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/brimnes-chest-of-4-drawers-white-frosted-glass__0500938_PE631496_S5.JPG?f=xxs"), Name = "Brimnes", Description = "Chest of 4 drawers, white, frosted glass"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/nordmela-chest-of-drawers-with-clothes-rail__0857791_PE711622_S5.JPG?f=xxs"), Name = "Nordmela", Description = "Clothes rail, black/blue"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/songesand-chest-of-6-drawers__0857847_PE658942_S5.JPG?f=xxs"), Name = "Songesand", Description = "Chest of 6 drawers, white"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/nordli-chest-of-6-drawers__0857992_PE660401_S5.JPG?f=xxs"), Name = "Nordii", Description = "Chest of 6 drawers, white"},
            new Recommendation { Uri = new Uri("https://www.ikea.com/gb/en/images/products/lote-chest-of-3-drawers-white__0365728_PE549520_S5.JPG?f=xxs"), Name = "Lote", Description = "Chest of 3 drawers, white"},
        };

        private readonly ILogger<RecEngController> _logger;

        public RecEngController(ILogger<RecEngController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Recommendation> Get()
        {
            var rng = new Random();
            var randomStart = rng.Next(0, 5);
            return Recommendations.Skip(randomStart).Take(6).ToArray();
        }

        // GET: api/Default/5
        [HttpGet("image/{id}", Name = "Image")]
        public IActionResult GetImage(int id)
        {
            var rng = new Random();
            var randomStart = rng.Next(0, 5);
            return Redirect(Recommendations[id].Uri.ToString());
        }

        [HttpGet("name/{id}", Name = "Name")]
        public string GetName(int id)
        {
            var rng = new Random();
            var randomStart = rng.Next(0, 5);
            return Recommendations[id].Name;
        }

        [HttpGet("select/{id}", Name = "Select")]
        public IActionResult GetSelect(int id, string url)
        {
            var rng = new Random();
            var randomStart = rng.Next(0, 5);
            Debug.WriteLine($"Select {id}");
            return Redirect(url);
        }


    }
}

