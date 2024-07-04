using ShoeStore.Domain.Common;


namespace ShoeStore.Domain.Entities.Comment
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int? ProductId { get; set; }
        public int? BlogId { get; set; }
        public string MessageTitle { get; set; }
        public string MessageBody { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSeen { get; set; }
    }
}
