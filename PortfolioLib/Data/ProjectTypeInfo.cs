using System;
using System.Runtime.Serialization;

namespace PortfolioLib.Data
{
    [DataContract]
    [KnownType(typeof(UnityWebPlayerProjectTypeInfo))]
    [KnownType(typeof(VideoProjectTypeInfo))]
    [KnownType(typeof(StandardProjectTypeInfo))]
    public class ProjectTypeInfo
    {
        [DataContract]
        public enum ProjectType
        {
            Standard,
            Video,
            UnityWebPlayer,
            UnityHtml5,
            UnrealHtml5
        }

        public ProjectInfo Parent
        {
            get{ return parent; }
            set{ parent = value; }
        }

        public ProjectTypeInfo()
        {
        }

        private ProjectInfo parent;
    }
}

