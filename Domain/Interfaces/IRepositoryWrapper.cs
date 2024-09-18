using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IMaterialRepository Material { get; }
        IAuthorRepository Author { get; }
        IAuthorStatusRepository AuthorStatus { get; }
        ICategoryRepository Category { get; }
        IChatRepository Chat { get; }
        IChatUserRepository ChatUser { get; }
        ICommentRepository Comment { get; }
        ICommentRateRepository CommentRate { get; }
        IFileRepository File { get; }
        IGroupMaterialRepository GroupMaterial { get; }
        IMaterialFileRepository MaterialFile { get; }
        IMaterialsUserStatusRepository MaterialsUserStatus { get; }
        IMessageUserRepository MessageUser { get; }
        IPaymentRepository Payment { get;  }
        IPaymentUserRepository PaymentUser { get; }
        IRateRepository Rate { get; }
        void Save();
    }
}
