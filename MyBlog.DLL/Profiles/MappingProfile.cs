using System.Linq;
using AutoMapper;
using MyBlog.DTO;
using MyBlog.DTO.AddViewDto;
using MyBlog.MODEL;
using MyBlogDTO;

namespace MyBlog.BLL.Profiles
{
    public class MappingProfile:Profile
    {
        public  MappingProfile ()
        {
            CreateMap<AddArticleCategoryDto, ArticleCategory>();

            CreateMap<ArticleCategory, ArticleCategoryDto>().ForMember(m=>m.CategoryId,
                op=>op.MapFrom(m=>m.Id));
         

            CreateMap<Articles, ArticleDto>();

            CreateMap<AddArticleCommentDto, ArticleComment>();

            CreateMap<ArticleComment, ArticleCommentDto>();

            CreateMap<AddArticleDto, Articles>();

            CreateMap<AddLeaveMessageDto, LeaveMessage>();

            CreateMap<ReplyMessageDto, ReplyMessage>();

            CreateMap<ReplyMessage, ReplyMessageDto>();

            CreateMap<LeaveMessage, LeaveMessageDto>();


            //给不同属性赋等同值
            //    .ForMember(op => op.Gender,
            //        ac => ac
            //            .MapFrom(m => $"{(m.Gender == Gender.Male ? '男' : '女')}"))


        }
    }
}