using System;
using System.Runtime.Serialization;

namespace PortfolioLib.Data
{
    [DataContract]
    public class StandardProjectTypeInfo : ProjectTypeInfo
    {
        public int GetSourceCount()
        {
            return gallerySources.Length;
        }

        public string GetSource(int index)
        {
            string rawSource = gallerySources[index];

            if (rawSource.StartsWith("/"))
                return Parent.ProjectUrlBase + rawSource;
            else
                return rawSource;
        }

        [DataMember(IsRequired = true)]
        private string[] gallerySources = new string[0];
    }
}

