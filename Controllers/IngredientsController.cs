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
        public IngredientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAllIngredient")]
        public IHttpActionResult GetAlIngredient()
        {
            var IngredientsList = _unitOfWork.Ingredients.GetAlIngredient();
            if (IngredientsList.Count() == 0)
                return NotFound();

            return Ok(IngredientsList);
        }

        [HttpGet]
        [Route("GetIngredient/{id:int}", Name = "GetIngredientById")]
        public IHttpActionResult GetIngredient(int id)
        {
            var ingredient = _unitOfWork.Ingredients.GetIngredient(id);

            if (ingredient == null)
                return NotFound();

            return Ok(ingredient);
        }

        [HttpPost]
        //[Authorize(Roles ="Admin")]
        [Route("AddNewIngredient")]
        public IHttpActionResult AddNewIngredient(Ingredient ingredient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            
            _unitOfWork.Ingredients.AddNewIngredient(ingredient);
            try
            {
                _unitOfWork.Complete();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
               
            }
           
            return Created(new Uri(Request.RequestUri + "/" + ingredient.Id), ingredient);
        }

        [HttpPut]
        [Route("UpdateIngredient/{id:int}")]
        public IHttpActionResult UpdateIngredient(int id, Ingredient ingredient)
        {
            var ingredientInDb = _unitOfWork.Ingredients.GetIngredient(id);
            if (ingredientInDb == null)
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

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
