using AutoMapper;
using ngCookingWebApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ngCookingWebApi.Models;
using ngCookingWebApi.Dtos;
namespace ngCookingWebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetCommentByRecette/{idRecette:int}")]
        public IHttpActionResult GetCommentByRecette(int idRecette)
        {
            var commentList = _unitOfWork.Comments.GetCommentByRecette(idRecette);

            if (commentList.Count() == 0)
                return NotFound();

            var commentDtoList = commentList.Select(c => _mapper.Map<CommentDto>(c));

            return Ok(commentDtoList);

        }

        [HttpGet]
        [Route("GetMarktByRecette/{idRecette:int}")]
        public IHttpActionResult GetMarktByRecette(int idRecette)
        {
            var commentList = _unitOfWork.Comments.GetCommentByRecette(idRecette);

            if (commentList.Count() == 0)
                return NotFound();

            return Ok(_unitOfWork.Comments.GetMarkByRecette(idRecette));
        }

        [HttpPost]
        [Route("AddCommentToRecette/{idRecette}")]
        public IHttpActionResult AddCommentToRecette(int idRecette, CommentDto commentDto)
        {
            var recette = _unitOfWork.Recettes.GetRecette(idRecette);

            if (recette == null)
                return BadRequest(string.Format("There is no recette with the Id {0}", idRecette));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = _mapper.Map<Comment>(commentDto);

            _unitOfWork.Comments.AddCommentToRecette(comment);

            try
            {
                _unitOfWork.Complete();

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

            _mapper.Map(comment, commentDto);

            return Created(new Uri(Request.RequestUri + "/" + commentDto.Id), commentDto);
        }

    }
}
