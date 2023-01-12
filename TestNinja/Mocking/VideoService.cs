using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //as we have an interface, we can just use this instead of newing up 
        private IFileReader _fileReader;
        private IVideoRepository _repository;

        public VideoService(IFileReader fileReader = null, IVideoRepository repository = null)
        {
            //the part with adding fileReader here is called constructor injection
            _fileReader = fileReader ?? new FileReader(); //means if fileReader is not null, use that, otherwise new up
            _repository = repository ?? new VideoRepository();
        }

        public string ReadVideoTitle()
        {
            //As a first step here, we wanted to refactor our code
            //to do that, we 1st created FileReader.cs, which is responsible for reading the code
            //this was done in order to remove the dependency in the code
            //now, once we had done that, we still could not use it in the unit tests for mocking, 
            //which is why we needed to create the interface 
            var str = _fileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();

            var videos = _repository.GetUNprocessedVideos();
            foreach (var v in videos)
                videoIds.Add(v.Id);

            return String.Join(",", videoIds);   
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}