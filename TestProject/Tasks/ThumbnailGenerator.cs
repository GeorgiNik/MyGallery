using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace TestProject.Tasks
{   
    /// <summary>
    /// Task that generates thumbnails
    /// </summary>
   
    public class ThumbnailGenerator : ITask
    {

        private string _Name;

        private Execution _Status;

        private Size GetThumbnailSize()
        {
            //Gets the thumbnail height and width from config settings
            return new Size(Int32.Parse(ConfigurationManager.AppSettings["thumbnailWidth"]),
            Int32.Parse(ConfigurationManager.AppSettings["thumbnailHeight"]));
            //return new Size(200,
            //200);

        }

        private void MakeThumbnail(List<Photo> imagesToResize)
        {

            Parallel.ForEach(imagesToResize, image =>
            {

                Size thumbnailSize = GetThumbnailSize();
                
                Provider.GenerateAndInsertThumbnail(image, thumbnailSize);

            });
        }

        public void Run()
        {
            MakeThumbnail(Provider.PhotosWithoutThumb());
        }

        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

        Execution ITask.Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }



    }
}