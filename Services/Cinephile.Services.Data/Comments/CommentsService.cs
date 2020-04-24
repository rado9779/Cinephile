namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Comments;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsRepository;

        public CommentsService(IDeletableEntityRepository<Comment> commentsRepository)
        {
            this.commentsRepository = commentsRepository;
        }

        public T GetById<T>(int id)
        {
            var comment = this.commentsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return comment;
        }

        public async Task Create(int postId, string userId, string content)
        {
            var comment = new Comment()
            {
                PostId = postId,
                UserId = userId,
                Content = content,
            };

            await this.commentsRepository.AddAsync(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Comment> query = this.commentsRepository
                .All();

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task Edit(CommentEditModel input)
        {
            var comment = this.commentsRepository
                 .All()
                 .FirstOrDefault(x => x.Id == input.Id);

            comment.Content = input.Content;
            comment.ModifiedOn = DateTime.UtcNow;

            this.commentsRepository.Update(comment);
            await this.commentsRepository.SaveChangesAsync();
        }

        public async Task Delete(CommentEditModel input)
        {
            var comment = this.commentsRepository
                 .All()
                 .FirstOrDefault(x => x.Id == input.Id);

            comment.IsDeleted = true;
            comment.DeletedOn = DateTime.UtcNow;

            this.commentsRepository.Update(comment);
            await this.commentsRepository.SaveChangesAsync();
        }
    }
}
