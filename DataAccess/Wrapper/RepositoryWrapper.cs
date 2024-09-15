﻿using DataAccess.Interfaces;
using DataAccess.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MnogoLibContext _repoContext;

        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_repoContext);
                }
                return _user;
            }
        }

        private IMaterialRepository _material;

        public IMaterialRepository Material
        {
            get
            {
                if (_material == null)
                {
                    _material = new MaterialRepository(_repoContext);
                }
                return _material;
            }
        }

        private IAuthorRepository _author;

        public IAuthorRepository Author
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_repoContext);
                }
                return _author;
            }
        }

        private IAuthorStatusRepository _authorStatus;

        public IAuthorStatusRepository AuthorStatus
        {
            get
            {
                if (_authorStatus == null)
                {
                    _authorStatus = new AuthorStatusRepository(_repoContext);
                }
                return _authorStatus;
            }
        }

        private ICategoryRepository _category;

        public ICategoryRepository Category
        {
            get
            {
                if (_category == null)
                {
                    _category = new CategoryRepository(_repoContext);
                }
                return _category;
            }
        }

        private IChatRepository _chat;

        public IChatRepository Chat
        {
            get
            {
                if (_chat == null)
                {
                    _chat = new ChatRepository(_repoContext);
                }
                return _chat;
            }
        }

        private IChatUserRepository _chatUser;

        public IChatUserRepository ChatUser
        {
            get
            {
                if (_chatUser == null)
                {
                    _chatUser = new ChatUserRepository(_repoContext);
                }
                return _chatUser;
            }
        }

        private ICommentRepository _comment;

        public ICommentRepository Comment
        {
            get
            {
                if (_comment == null)
                {
                    _comment = new CommentRepository(_repoContext);
                }
                return _comment;
            }
        }


        private ICommentRateRepository _commentRate;

        public ICommentRateRepository CommentRate
        {
            get
            {
                if (_commentRate == null)
                {
                    _commentRate = new CommentRateRepository(_repoContext);
                }
                return _commentRate;
            }
        }

        private IFileRepository _file;

        public IFileRepository File
        {
            get
            {
                if (_file == null)
                {
                    _file = new FileRepository(_repoContext);
                }
                return _file;
            }
        }

        private IGroupMaterialRepository _groupMaterial;

        public IGroupMaterialRepository GroupMaterial
        {
            get
            {
                if (_groupMaterial == null)
                {
                    _groupMaterial = new GroupMaterialRepository(_repoContext);
                }
                return _groupMaterial;
            }
        }

        public RepositoryWrapper(MnogoLibContext repoContext)
        {
            _repoContext = repoContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
