using System;

namespace PortfolioLib.Data
{
    public class DefaultPerson : Person
    {
        public DefaultPerson(string name)
        {
            this.name = name;
        }
            
        #region Overrides

        public override string GetName()
        {
            return name;
        }

        public override string GetIconUrl()
        {
            return "/Content/Contacts/DefaultIcon.png";
        }

        public override string GetPortfolioUrl()
        {
            return null;
        }

        public override string GetNote()
        {
            return "";
        }

        #endregion

        private string name;
    }
}

