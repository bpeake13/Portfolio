using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Portfolio.Controllers
{
    public class FilesController : Controller
    {
        public FileResult Index(string fileId)
        {
            string decodedId = Server.UrlDecode(fileId);

            string[] decodedParts = decodedId.Split('/');
            foreach (string part in decodedParts)
            {
                if(part.StartsWith("_"))
                    throw new HttpException(404, "The file was not found.");
            }

            string filePath = Server.MapPath(string.Format("~/{0}", decodedId));

            if (string.IsNullOrWhiteSpace(filePath))
                throw new HttpException(404, "The file was not found.");

            string contentPath = Server.MapPath("~/Content/");
            if (!filePath.StartsWith(contentPath))
                throw new HttpException(404, "The file was not found.");

            FileInfo file = new FileInfo(filePath);
            if(!file.Exists)
                throw new HttpException(404, "The file was not found.");

            HttpContext.Response.Buffer = false;

            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, file.Name);
        }
    }
}
