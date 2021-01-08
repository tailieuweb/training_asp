using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDW2Project.FetchModel
{
    public class PostPersonalImageModel
    {
        public string UserId { set; get; }
        public IFormFile File { set; get; }
    }
}
