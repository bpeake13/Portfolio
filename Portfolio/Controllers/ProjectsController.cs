using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.Serialization;

using PortfolioLib.Data;
using System.Runtime.Serialization.Json;

namespace Portfolio.Controllers
{
    public class ProjectsController : Controller
    {
        public ActionResult Index()
        {
            DirectoryInfo projectDirectory = new DirectoryInfo(Server.MapPath("~/Content/Projects"));
            if (!projectDirectory.Exists)
                throw new HttpException(204, "No games directory found");

            DirectoryInfo[] projectFolders = projectDirectory.GetDirectories();

            DataContractJsonSerializer parser = new DataContractJsonSerializer(typeof(ProjectInfo));
            List<ProjectInfo> projects = new List<ProjectInfo>();
            foreach (DirectoryInfo projectFolder in projectFolders)
            {
                // ignore folders that cannot be reached by the web browser
                if (projectFolder.Name.StartsWith("_"))
                    continue;

                string infoFilePath = Path.Combine(projectFolder.FullName, "_metaInfo.json");

                FileInfo metaFile = new FileInfo(infoFilePath);
                if (!metaFile.Exists)
                    continue;

                using (FileStream fs = metaFile.OpenRead())
                {
                    try
                    {
                        ProjectInfo game = parser.ReadObject(fs) as ProjectInfo;
                        if (game != null && game.SafeName == projectFolder.Name)
                            projects.Add(game);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.Message);
                    }
                }
            }

            projects.Sort(new Comparison<ProjectInfo>((x, y) => {
                return -x.StartDate.CompareTo(y.StartDate);
            }));

            ViewData["ProjectList"] = projects;

            return View();
        }

        public ActionResult Project(string projectSafeName)
        {
            DirectoryInfo projectDirectory = new DirectoryInfo(Server.MapPath("~/Content/Projects/" + projectSafeName));
            if (!projectDirectory.Exists)
                throw new HttpException(404, "Project does not exist.");

            FileInfo metaFile = new FileInfo(Path.Combine(projectDirectory.FullName, "_metaInfo.json"));
            if (!metaFile.Exists)
                throw new HttpException(404, "Project does not exist.");

            DataContractJsonSerializer parser = new DataContractJsonSerializer(typeof(ProjectInfo));
            using (FileStream fs = metaFile.OpenRead())
            {
                ProjectInfo project;
                try
                {
                    project = parser.ReadObject(fs) as ProjectInfo;
                }
                catch
                {
                    throw new HttpException(404, "Project does not exist.");
                }

                if (project == null || project.SafeName != projectDirectory.Name)
                    throw new HttpException(404, "Project does not exist.");

                ViewData["Project"] = project;
                return View(project.ProjectType.ToString() + "ProjectPage");
            }
        }
    }
}
