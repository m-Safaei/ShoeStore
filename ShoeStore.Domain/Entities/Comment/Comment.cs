﻿using ShoeStore.Domain.Common;


namespace ShoeStore.Domain.Entities.Comment
{
    internal class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public int? BlogId { get; set; }
        public string MessageTitle { get; set; }
        public string Message { get; set; }
        public bool IsDelete { get; set; }
        public bool IsSeen { get; set; }
    }
}
