using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using allSpice.Models;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using recipes.Services;

namespace recipe.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly RecipesService _rs;
        public RecipesController(RecipesService rs)
        {
            _rs = rs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Recipe>> Get()
        {
            try
            {
                var recipe = _rs.Get();
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Recipe>> Create([FromBody] Recipe newRecipe)
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                newRecipe.CreatorId = userInfo.Id;
                Recipe recipe = _rs.Create(newRecipe);
                return Ok(recipe);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}