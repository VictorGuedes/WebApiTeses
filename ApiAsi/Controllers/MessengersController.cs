using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
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
    public class MessengersController : ApiController
    {
        private BancoContext db = new BancoContext();

        // GET: api/Messengers
        public IQueryable<Messenger> GetMessenger()
        {
            return db.Messenger;
        }

        // GET: api/Messengers/5
        [ResponseType(typeof(Messenger))]
        public async Task<IHttpActionResult> GetMessenger(int id)
        {
            Messenger messenger = await db.Messenger.FindAsync(id);
            
            if (messenger == null)
            {
                return NotFound();
            }

            return Ok(messenger);
        }

        [Route("api/Messenger/{idUser}")]
        [HttpGet]
        public IHttpActionResult GetAllChatsUser(string idUser)
        {
            var q = from propostaSubmetida in db.PropostaSubmetida
                        join proposta in db.Proposta on propostaSubmetida.id_proposta_submetida equals proposta.fk_propostasubmetida
                        join messenger in db.Messenger on proposta.id_proposta equals messenger.fk_proposta
                        join userX in db.User on idUser equals userX.Id
                        select new
                        {
                            messenger.id_messsenger,
                            propostaSubmetida.titulo,
                            proposta.Aluno.nome,
                            userX.Aluno,
                            userX.Professor
                        };

            if (q == null)
            {
                return NotFound();
            }

            return Ok(q);

        }

        // PUT: api/Messengers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutMessenger(int id, Messenger messenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != messenger.id_messsenger)
            {
                return BadRequest();
            }

            db.Entry(messenger).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessengerExists(id))
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

        // POST: api/Messengers
        [ResponseType(typeof(Messenger))]
        public async Task<IHttpActionResult> PostMessenger(Messenger messenger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Messenger.Add(messenger);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = messenger.id_messsenger }, messenger);
        }

        // DELETE: api/Messengers/5
        [ResponseType(typeof(Messenger))]
        public async Task<IHttpActionResult> DeleteMessenger(int id)
        {
            Messenger messenger = await db.Messenger.FindAsync(id);
            if (messenger == null)
            {
                return NotFound();
            }

            db.Messenger.Remove(messenger);
            await db.SaveChangesAsync();

            return Ok(messenger);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MessengerExists(int id)
        {
            return db.Messenger.Count(e => e.id_messsenger == id) > 0;
        }
    }
}