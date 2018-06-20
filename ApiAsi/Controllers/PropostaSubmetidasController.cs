using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ApiAsi.Models;

namespace ApiAsi.Controllers
{
    [Authorize]
    public class PropostaSubmetidasController : ApiController
    {
        private BancoContext db = new BancoContext();

        // GET: api/PropostaSubmetidas
        public IQueryable<PropostaSubmetida> GetPropostaSubmetida()
        {
            return db.PropostaSubmetida;
        }

        // GET: api/PropostaSubmetidas/5
        [ResponseType(typeof(PropostaSubmetida))]
        public async Task<IHttpActionResult> GetPropostaSubmetida(int id)
        {
            PropostaSubmetida propostaSubmetida = await db.PropostaSubmetida.FindAsync(id);
            if (propostaSubmetida == null)
            {
                return NotFound();
            }

            return Ok(propostaSubmetida);
        }

        // PUT: api/PropostaSubmetidas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPropostaSubmetida(int id, PropostaSubmetida propostaSubmetida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != propostaSubmetida.id_proposta_submetida)
            {
                return BadRequest();
            }

            db.Entry(propostaSubmetida).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropostaSubmetidaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PropostaSubmetidas
        [ResponseType(typeof(PropostaSubmetida))]
        public async Task<IHttpActionResult> PostPropostaSubmetida(PropostaSubmetida propostaSubmetida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PropostaSubmetida.Add(propostaSubmetida);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = propostaSubmetida.id_proposta_submetida }, propostaSubmetida);
        }

        // DELETE: api/PropostaSubmetidas/5
        [ResponseType(typeof(PropostaSubmetida))]
        public async Task<IHttpActionResult> DeletePropostaSubmetida(int id)
        {
            PropostaSubmetida propostaSubmetida = await db.PropostaSubmetida.FindAsync(id);
            if (propostaSubmetida == null)
            {
                return NotFound();
            }

            db.PropostaSubmetida.Remove(propostaSubmetida);
            await db.SaveChangesAsync();

            return Ok(propostaSubmetida);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropostaSubmetidaExists(int id)
        {
            return db.PropostaSubmetida.Count(e => e.id_proposta_submetida == id) > 0;
        }
    }
}