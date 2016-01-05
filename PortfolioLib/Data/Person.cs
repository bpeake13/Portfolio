using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PortfolioLib.Data
{
    public abstract class Person
    {
        public static Person GetPerson(string name)
        {
            string personPath = string.Format("Content/Contacts/{0}/_{0}.json", name.Replace(' ', '_'));
            FileInfo personFile = new FileInfo(personPath);

            if (!personFile.Exists)
                return new DefaultPerson(name);

            DataContractJsonSerializer parser = new DataContractJsonSerializer(typeof(Contact));

            try
            {
                using (FileStream stream = personFile.OpenRead())
                {
                    Contact contact = (Contact)parser.ReadObject(stream);
                    return contact;
                }
            }
            catch
            {
                return new DefaultPerson(name);
            }
        }

        public abstract string GetName();

        public abstract string GetIconUrl();

        public abstract string GetPortfolioUrl();

        public abstract string GetNote();
    }
}

