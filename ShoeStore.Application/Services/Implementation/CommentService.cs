﻿using ShoeStore.Application.Services.Interface;
using ShoeStore.Domain.DTOs.SiteSide.Comment;
using ShoeStore.Domain.Entities.Comment;
using ShoeStore.Domain.IRepositories;

namespace ShoeStore.Application.Services.Implementation
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void AddComment(CommentDTO comment)
        {
            Comment newComment = new Comment()
            {
                UserId = comment.UserId,
                MessageTitle = comment.MessageTitle,
                MessageBody = comment.MessageBody,
                IsDelete = false,
                IsSeen = false
            };

            _commentRepository.AddComment(newComment);
        }

        public async Task<List<Comment>> GetListOfProductComments(CancellationToken cancellation)
        {
            return await _commentRepository.GetListOfProductComments(cancellation);
        }

        public async Task<List<Comment>> GetListOfBlogComments()
        {
            return await _commentRepository.GetListOfBlogComments();
        }

    }
}
