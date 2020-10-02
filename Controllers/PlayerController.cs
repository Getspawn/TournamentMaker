using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TournamentMaker.Contexts;
using TournamentMaker.Entities;

namespace TournamentMaker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly AppDbContext context;

        public PlayerController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/Player
        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return context.Player.ToList();
        }

        // GET: api/Player/5
        [HttpGet("{id}", Name = "Get")]
        public Player Get(string id)
        {
            var player = context.Player.FirstOrDefault(x => x.PlayerId == id);

            return player;
        }

        // POST: api/Player
        [HttpPost]
        public ActionResult Post([FromBody] Player player)
        {
            try
            {
                context.Player.Add(player);
                context.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT: api/Player/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Player player)
        {
            if (player.PlayerId == id)
            {
                context.Entry(player).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var player = context.Player.FirstOrDefault(x => x.PlayerId == id);

            if (player != null)
            {
                context.Player.Remove(player);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
