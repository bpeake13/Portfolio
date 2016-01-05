using System;
using System.IO;
using System.Runtime.Serialization;

namespace PortfolioLib.Data
{
	[DataContract]      
	public class ProjectInfo
	{
        [DataContract]
        public enum RepoType
        {
            None = 0,
            GitHub,
            SourceForge
        }

        public string ProjectName
        {
            get{ return projectName; }
            set{ projectName = value; }
        }

        public string SafeName
        {
            get{ return projectName.Replace(" ", ""); }
        }

        public string ShortDescription
        {
            get{ return shortDescription; }
            set{ shortDescription = value; }
        }

        public string Role
        {
            get{ return roleDescription; }
            set{ roleDescription = value; }
        }

        public DateTime StartDate
        {
            get{ return projectStartDate; }
            set{ projectStartDate = value; }
        }

        public DateTime EndDate
        {
            get{ return projectEndDate; }
            set{ projectEndDate = value; }
        }

        public string RepoUrl
        {
            get{ return repoUrl; }
            set{ repoUrl = value; }
        }

        public RepoType RepoUrlType
        {
            get{ return repoType; }
            set{ repoType = value; }
        }

        public string BannerLocation
        {
            get{ return Path.Combine(dataLocationPathPrefix, SafeName, bannerLocation).Replace('\\', '/'); }
            set{ bannerLocation = StripPrefix(value); }
        }

        public string[] Credits
        {
            get{ return credits; }
            set{ credits = value; }
        }

        public string[] Tools
        {
            get{ return tools; }
            set{ tools = value; }
        }

        public string DownloadLocation
        {
            get
            { 
                return string.IsNullOrEmpty(downloadLocation) ? null : Path.Combine(dataLocationPathPrefix, SafeName, downloadLocation).Replace('\\', '/');
            }
            set{ downloadLocation = StripPrefix(value); }
        }

        public ProjectTypeInfo.ProjectType ProjectType
        {
            get{ return projectType; }
            set{ projectType = value; }
        }

        public ProjectTypeInfo TypeInfo
        {
            get{ return typeInfo; }
            set{ typeInfo = value; }
        }

        public string ProjectUrlBase
        {
            get{ return string.Format("/Content/Projects/{0}", SafeName); }
        }

		public ProjectInfo ()
		{
		}

        private string StripPrefix(string path)
        {
            return path.StartsWith(dataLocationPathPrefix) ? path.Remove(0, dataLocationPathPrefix.Length) : path;
        }

		// The name of the game
        [DataMember(IsRequired = true)]
        private string projectName;

		// The description of the game
        [DataMember(IsRequired = true)]
        private string shortDescription;

		// The date that work started on this project
        private DateTime projectStartDate;

        [DataMember(Name = "projectStartDate", IsRequired = true)]
        private string serializedProjectStartDate
        {
            get { return projectStartDate.ToString("MM-dd-yyyy"); }
            set { projectStartDate = DateTime.Parse(value); }
        }

		// The date work stopped on this project
        private DateTime projectEndDate;

        [DataMember(Name = "projectEndDate")]
        private string serializedProjectEndDate
        {
            get { return projectEndDate.ToString("MM-dd-yyyy"); }
            set { projectEndDate = DateTime.Parse(value); }
        }

        [DataMember(IsRequired = true)]
        string roleDescription;

		[DataMember]
        private string repoUrl;

        private RepoType repoType;

        [DataMember(Name = "repoType", IsRequired = true)]
        private string serializedRepoType
        {
            get{ return repoType.ToString(); }
            set{ repoType = (RepoType)Enum.Parse(typeof(RepoType), value); }
        }

        [DataMember(IsRequired = true)]
        private string bannerLocation;

        [DataMember]
        private string downloadLocation;

        [DataMember]
        private string[] credits = new string[0];

        [DataMember]
        private string[] tools = new string[0];

        private ProjectTypeInfo.ProjectType projectType;

        [DataMember(Name = "projectType", IsRequired = true)]
        private string serializedProjectType
        {
            get{ return projectType.ToString(); }
            set{ projectType = (ProjectTypeInfo.ProjectType)Enum.Parse(typeof(ProjectTypeInfo.ProjectType), value); }
        }

        [DataMember]
        private ProjectTypeInfo typeInfo
        {
            get{ return internalTypeInfo; }
            set
            {
                internalTypeInfo = value;
                internalTypeInfo.Parent = this;
            }
        }

        private ProjectTypeInfo internalTypeInfo;

        private const string dataLocationPathPrefix = "Content/Projects/";
	}
}

