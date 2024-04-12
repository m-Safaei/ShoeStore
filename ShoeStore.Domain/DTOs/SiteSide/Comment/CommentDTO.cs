namespace ShoeStore.Domain.DTOs.SiteSide.Comment
{
    public class CommentDTO
    {
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public int? BlogId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSeen { get; set; }
    }
}
