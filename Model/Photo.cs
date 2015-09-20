﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Model
{
    /// <summary>
    /// Model of all photos
    /// </summary>

    [Serializable]
    [DataContract]
    public class Photo
    {
        [DataMember]
       public Nullable<int> AlbumID {get;set;}
        [DataMember]
       public Nullable<int> PhotoID { get; set; }
        [DataMember]
       public string Name { get; set; }
        [DataMember]
       public string ContentType { get; set; }
        [DataMember]
       public string Description { get; set; }
        [DataMember]
       public byte[] PhotoByte { get; set; }
        [DataMember]
       public byte[] Thumbnail { get; set; }
        [DataMember]
       public DateTime DateCreated { get; set; }
        [DataMember]
       public string UserName { get; set; }

    }
}
