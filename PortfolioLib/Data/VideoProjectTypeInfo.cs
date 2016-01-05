using System;
using System.Runtime.Serialization;

namespace PortfolioLib.Data
{
    [DataContract]
    public class VideoProjectTypeInfo : ProjectTypeInfo
    {
        public string SourceUrl
        {
            get{ return sourceUrl; }
            set{ sourceUrl = value; }
        }

        public VideoProjectTypeInfo()
            :base()
        {
        }

        [DataMember(IsRequired = true)]
        private string sourceUrl;
    }
}

