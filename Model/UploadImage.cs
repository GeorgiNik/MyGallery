using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace Model
{
    /// <summary>
    /// Model with information for image that must be uploaded
    /// </summary>

    [Serializable]
    [DataContract]
    
    public class UploadImage
    {
        [DataMember]
        public string filename { get; set; }
        [DataMember]
        public int albumID { get; set; }

        [DataMember]
        public string userName { get; set; }

        [DataMember]
        public byte[] image { get; set; }

        [DataMember]
        public string imageDescrp { get; set; }

        [DataMember]
        public string ext { get; set; }

        [DataMember]
        public string contenttype { get; set; }

        [DataMember]
        public Size sizeOfThumnail { get; set; } 

    }
}
