﻿using Domain.Entites;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class User
    {
        public User()
        {
            ChatDeletedByNavigations = new HashSet<Chat>();
            ChatIdOwnerNavigations = new HashSet<Chat>();
            ChatLastUpdateByNavigations = new HashSet<Chat>();
            ChatUserCreatedByNavigations = new HashSet<ChatUser>();
            ChatUserDeletedByNavigations = new HashSet<ChatUser>();
            ChatUserIdUserNavigations = new HashSet<ChatUser>();
            CommentRates = new HashSet<CommentRate>();
            Comments = new HashSet<Comment>();
            FileCreatedByNavigations = new HashSet<File>();
            FileDeletedByNavigations = new HashSet<File>();
            FileLastUpdateByNavigations = new HashSet<File>();
            MaterialCreatedByNavigations = new HashSet<Material>();
            MaterialDeletedByNavigations = new HashSet<Material>();
            MaterialLastUpdateByNavigations = new HashSet<Material>();
            MaterialsUserStatuses = new HashSet<MaterialsUserStatus>();
            MessagesUserDeletedByNavigations = new HashSet<MessagesUser>();
            MessagesUserIdUserNavigations = new HashSet<MessagesUser>();
            PaymentUsers = new HashSet<PaymentUser>();
            Rates = new HashSet<Rate>();
        }

        public int IdUser { get; set; }
        public string EmailUser { get; set; } = null!;
        public string PasswordUser { get; set; } = null!;
        public string NicknameUser { get; set; } = null!;
        public int IdRole { get; set; } = 1;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public int LastUpdateBy { get; set; }
        public DateTime LastUpdateTime { get; set; } = DateTime.Now;
        public int? DeletedBy { get; set; }
        public DateTime? DeletedTime { get; set; }


        //Поля для JWT

        public bool AcceptTerms { get; set; }
        //public Role Role {get; set;}
        public string? VerificationToken { get; set; }
        public DateTime? Verified { get; set; }
        public bool IsVerified => Verified.HasValue || PasswordReset.HasValue;
        public string? ResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }
        public DateTime? PasswordReset { get; set; }
        //public DateTime Created {get; set;}
        public DateTime? Updated { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }

        public virtual Role? IdRoleNavigation { get; set; } = null!;
        public virtual ICollection<Chat>? ChatDeletedByNavigations { get; set; }
        public virtual ICollection<Chat>? ChatIdOwnerNavigations { get; set; }
        public virtual ICollection<Chat>? ChatLastUpdateByNavigations { get; set; }
        public virtual ICollection<ChatUser>? ChatUserCreatedByNavigations { get; set; }
        public virtual ICollection<ChatUser>? ChatUserDeletedByNavigations { get; set; }
        public virtual ICollection<ChatUser>? ChatUserIdUserNavigations { get; set; }
        public virtual ICollection<CommentRate>? CommentRates { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<File>? FileCreatedByNavigations { get; set; }
        public virtual ICollection<File>? FileDeletedByNavigations { get; set; }
        public virtual ICollection<File>? FileLastUpdateByNavigations { get; set; }
        public virtual ICollection<Material>? MaterialCreatedByNavigations { get; set; }
        public virtual ICollection<Material>? MaterialDeletedByNavigations { get; set; }
        public virtual ICollection<Material>? MaterialLastUpdateByNavigations { get; set; }
        public virtual ICollection<MaterialsUserStatus>? MaterialsUserStatuses { get; set; }
        public virtual ICollection<MessagesUser>? MessagesUserDeletedByNavigations { get; set; }
        public virtual ICollection<MessagesUser>? MessagesUserIdUserNavigations { get; set; }
        public virtual ICollection<PaymentUser>? PaymentUsers { get; set; }
        public virtual ICollection<Rate>? Rates { get; set; }
    }
}