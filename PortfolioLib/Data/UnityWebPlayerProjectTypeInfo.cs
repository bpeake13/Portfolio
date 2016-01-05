using System;
using System.Runtime.Serialization;

namespace PortfolioLib.Data
{
    [DataContract]
    public class UnityWebPlayerProjectTypeInfo : ProjectTypeInfo
    {
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }

        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }

        public UnityWebPlayerProjectTypeInfo()
        {
        }

        [DataMember]
        private int width = 900;

        [DataMember]
        private int height = 600;
    }
}

