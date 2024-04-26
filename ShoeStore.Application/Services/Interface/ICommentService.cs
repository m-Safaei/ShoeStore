using ShoeStore.Domain.DTOs.SiteSide.Account;
using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Product;
using System.Security.Cryptography;

namespace ShoeStore.Application.Services.Interface
{
    public interface ICommentService
    {
        void AddComment(CommentDTO comment, UserDto user);
        void DeleteComment(CommentDTO comment);

    }
}
