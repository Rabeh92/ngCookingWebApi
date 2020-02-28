using ngCookingWebApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ngCookingWebApi.Models;
using ngCookingWebApi.Dtos;
namespace ngCookingWebApi.Controllers
{
    [RoutePrefix("api")]
    public class RecettesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RecettesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllRecette")]
        public IHttpActionResult GetAllRecette()
        {
            var recetteList = _unitOfWork.Recettes.GetAllRecette();
            if (recetteList.Count() == 0)
                return NotFound();

            return Ok(recetteList.Select(r => _mapper.Map<Recette, RecetteDto>(r)));
        }

        [HttpGet]
        [Route("GetRecette")]
        public IHttpActionResult GetRecette(int id)
        {
            var recette = _unitOfWork.Recettes.GetRecette(id);
            if (recette == null)
                return NotFound();

            var recetteDto = _mapper.Map<Recette, RecetteDto>(recette);
            return Ok(recetteDto);
        }

        [HttpPost]
        [Authorize(Roles = "Cuisinier")]
        [Route("AddNewRecette")]
        public IHttpActionResult AddNewRecette(RecetteDto recetteDto)
        {
            if (recetteDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recette = _mapper.Map<RecetteDto, Recette>(recetteDto);
            _unitOfWork.Recettes.AddNewRecette(recette);
            try
            {
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            _mapper.Map(recette, recetteDto);

            return Created(new Uri(Request.RequestUri + "/" + recetteDto.Id), recetteDto);
        }

        [HttpPut]
        [Authorize(Roles = "Cuisinier")]
        [Route("UpdateRecette/{id:int}")]
        public IHttpActionResult UpdateRecette(int id, RecetteDto recetteDto)
        {
            var recetteInDb = _unitOfWork.Recettes.GetRecette(id);
            if (recetteInDb == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var recette = _mapper.Map<Recette>(recetteDto);
            _unitOfWork.Recettes.UpdateRecette(recetteInDb, recette);
            try
            {
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }
            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        [Route("DeleteRecette")]
        public IHttpActionResult DeleteRecette(int id)
        {
            var recetteInDb = _unitOfWork.Recettes.GetRecette(id);

            if (recetteInDb == null)
                return NotFound();

            _unitOfWork.Recettes.DeleteRecette(recetteInDb);

            try
            {
                _unitOfWork.Complete();
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(id);
        }
        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
        }
    }
}
