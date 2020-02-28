using ngCookingWebApi.Dtos;
using ngCookingWebApi.Models;
using ngCookingWebApi.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
namespace ngCookingWebApi.Controllers
{
    [RoutePrefix("api")]
    public class IngredientsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public IngredientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAllIngredient")]
        public IHttpActionResult GetAlIngredient()
        {
            var IngredientsList = _unitOfWork.Ingredients.GetAlIngredient();
            if (IngredientsList.Count() == 0)
                return NotFound();

            return Ok(IngredientsList.Select(ing => _mapper.Map<Ingredient, IngredientDto>(ing)));
        }

        [HttpGet]
        [Route("GetIngredient/{id:int}", Name = "GetIngredientById")]
        public IHttpActionResult GetIngredient(int id)
        {
            var ingredient = _unitOfWork.Ingredients.GetIngredient(id);

            if (ingredient == null)
                return NotFound();

            var ingredientDto = _mapper.Map<Ingredient>(ingredient);
            return Ok(ingredientDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("AddNewIngredient")]
        public IHttpActionResult AddNewIngredient(IngredientDto ingredientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = _mapper.Map<IngredientDto, Ingredient>(ingredientDto);
            _unitOfWork.Ingredients.AddNewIngredient(ingredient);
            try
            {
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
            _mapper.Map(ingredient, ingredientDto);
            return Created(new Uri(Request.RequestUri + "/" + ingredientDto.Id), ingredientDto);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        [Route("UpdateIngredient/{id:int}")]
        public IHttpActionResult UpdateIngredient(int id, IngredientDto ingredientDto)
        {
            var ingredientInDb = _unitOfWork.Ingredients.GetIngredient(id);
            if (ingredientInDb == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = _mapper.Map<IngredientDto, Ingredient>(ingredientDto);
            _unitOfWork.Ingredients.UpdateIngredient(ingredientInDb, ingredient);
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
        [Route("DeleteIngredient/ID")]
        public IHttpActionResult DeleteIngredient(int id)
        {
            var ingredientInDb = _unitOfWork.Ingredients.GetIngredient(id);
            if (ingredientInDb == null)
                return NotFound();

            _unitOfWork.Ingredients.DeleteIngredient(ingredientInDb);
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

        //protected override void Dispose(bool disposing)
        //{
        //    _unitOfWork.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}
