using System;
using System.Runtime.Serialization;
using System.IO;

namespace PortfolioLib.Data
{
    [DataContract]
    public class Contact : Person
    {
        private Contact()
        {
        }

        #region Overrides

        public override string GetName()
        {
            return name;
        }

        public override string GetIconUrl()
        {
            string contactDirectory = string.Format("Content/Contacts/{0}", name.Replace(' ', '_'));
            string iconPath = Path.Combine(contactDirectory, "icon.png");

            FileInfo iconFile = new FileInfo(iconPath);
            if (!iconFile.Exists)
                iconPath = "Content/Contacts/DefaultIcon.png";

            return "/" + iconPath;
        }

        public override string GetPortfolioUrl()
        {
            return url;
        }

        public override string GetNote()
        {
            return note;
        }

        #endregion

        [DataMember(IsRequired = true)]
        private string name = null;

        [DataMember]
        private string url = null;

        [DataMember]
        private string note = "";
    }
}

