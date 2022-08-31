namespace ExperianCode.Models
{
    public class PhotoAlbum
    {
        public int PhotoId { get; set; }
        public string PhotoTitle { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoThumbnailUrl { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int UserId { get; set; }
    }
}
