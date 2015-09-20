using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Model
{
    /// <summary>
    /// Model of all albums
    /// </summary>

    [Serializable]
    [DataContract]
    public class Album
    {
        [DataMember]
        public Nullable<int> AlbumID { get; set; }
        [DataMember]
        public string AlbumName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime DateCreated { get; set; }
        [DataMember]
        public bool IsPublished { get; set; }
        [DataMember]
        public string UserName { get; set; }
        

    }
}
