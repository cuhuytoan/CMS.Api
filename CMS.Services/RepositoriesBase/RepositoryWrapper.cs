using CMS.Data.ModelEntity;
using CMS.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IDbContextFactory<CmsContext> _cmsContext { get; set; }
     
        private ISettingRepository _setting;
        private IArticleRepository _article;
        private IArticleCommentRepository _articleComment;
        private IArticleCategoryRepository _articleCategory;
        private IArticleBlockRepository _articleBlock;
        private IArticleBlockArticleRepository _articleBlockArticle;
        private IAspNetUserProfilesRepository _aspNetUserProfiles;
        private IAspNetRolesRepository _aspNetRoles;
        private IAspNetUserRolesRepository _aspNetUserRoles;
        public RepositoryWrapper(IDbContextFactory<CmsContext> CmsContext)
        {
            _cmsContext = CmsContext;           
        }
        public IAspNetUserRolesRepository AspNetUserRoles
        {
            get
            {
                if (_aspNetUserRoles == null)
                {
                    _aspNetUserRoles = new AspNetUserRolesRepository(_cmsContext.CreateDbContext());
                }

                return _aspNetUserRoles;
            }
        }
        public IAspNetRolesRepository AspNetRoles
        {
            get
            {
                if (_aspNetRoles == null)
                {
                    _aspNetRoles = new AspNetRolesRepository(_cmsContext.CreateDbContext());
                }

                return _aspNetRoles;
            }
        }
        public IAspNetUserProfilesRepository AspNetUserProfiles
        {
            get
            {
                if (_aspNetUserProfiles == null)
                {
                    _aspNetUserProfiles = new AspNetUserProfilesRepository(_cmsContext.CreateDbContext());
                }

                return _aspNetUserProfiles;
            }
        }
        public ISettingRepository Setting
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new SettingRepository(_cmsContext.CreateDbContext());
                }

                return _setting;
            }
        }

        public IArticleRepository Article
        {
            get
            {
                if (_article == null)
                {
                    _article = new ArticleRepository(_cmsContext.CreateDbContext());
                }

                return _article;
            }
        }
        public IArticleCommentRepository ArticleComment
        {
            get
            {
                if (_articleComment == null)
                {
                    _articleComment = new ArticleCommentRepository(_cmsContext.CreateDbContext());
                }

                return _articleComment;
            }
        }
        public IArticleCategoryRepository ArticleCategory
        {
            get
            {
                if (_articleCategory == null)
                {
                    _articleCategory = new ArticleCategoryRepository(_cmsContext.CreateDbContext());
                }

                return _articleCategory;
            }
        }
        public IArticleBlockRepository ArticleBlock
        {
            get
            {
                if (_articleBlock == null)
                {
                    _articleBlock = new ArticleBlockRepository(_cmsContext.CreateDbContext());
                }

                return _articleBlock;
            }
        }
        public IArticleBlockArticleRepository ArticleBlockArticle
        {
            get
            {
                if (_articleBlockArticle == null)
                {
                    _articleBlockArticle = new ArticleBlockArticleRepository(_cmsContext.CreateDbContext());
                }

                return _articleBlockArticle;
            }
        }

        
    }
}