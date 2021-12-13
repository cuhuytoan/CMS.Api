using CMS.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CMS.Services.RepositoriesBase
{
    public interface IRepositoryWrapper
    {
        ISettingRepository Setting { get; }

        IArticleRepository Article { get; }
        
        IArticleCommentRepository ArticleComment { get; }

        IArticleCategoryRepository ArticleCategory { get; }

        IArticleBlockRepository ArticleBlock { get; }

        IArticleBlockArticleRepository ArticleBlockArticle { get; }

        IAspNetUserProfilesRepository AspNetUserProfiles { get; }

        IAspNetRolesRepository AspNetRoles { get; }

        IAspNetUserRolesRepository AspNetUserRoles { get; }
    }
}