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
            
            var listaChatAluno = (from messenger in db.Messenger
                    from proposta in db.Proposta
                    from propostaSubmetida in db.PropostaSubmetida
                    from user in db.User
                    from aluno in db.Aluno
                    where messenger.fk_proposta == proposta.id_proposta
                    where proposta.fk_propostasubmetida == propostaSubmetida.id_proposta_submetida
                    where proposta.fk_aluno == aluno.numero_mecanografico
                    where aluno.fk_user_login == idUser
                    select new
                    {
                        messenger.id_messsenger,
                        propostaSubmetida.titulo,
                        proposta.Aluno.nome

                    }).Distinct().ToList();

            if (listaChatAluno.Count == 0)
            {
                var listaChatOrientador = (from messenger in db.Messenger
                                           from proposta in db.Proposta
                                           from propostaSubmetida in db.PropostaSubmetida
                                           from user in db.User
                                           from professor in db.Professor
                                           from professorValido in db.ProfessorValido
                                           where messenger.fk_proposta == proposta.id_proposta
                                           where proposta.fk_propostasubmetida == propostaSubmetida.id_proposta_submetida
                                           where propostaSubmetida.orientador == professorValido.id_atribuicao
                                           where professorValido.fk_professor == professor.numero_meca
                                           where professor.fk_user == idUser
                                           select new
                                           {
                                               messenger.id_messsenger,
                                               propostaSubmetida.titulo,
                                               proposta.Aluno.nome
                                           }).Distinct().ToList();

                var listaChatCoorientador = (from messenger in db.Messenger
                                            from proposta in db.Proposta
                                            from propostaSubmetida in db.PropostaSubmetida
                                            from user in db.User
                                            from professor in db.Professor
                                            from professorValido in db.ProfessorValido
                                            from coordientador in db.Coorientador
                                            where messenger.fk_proposta == proposta.id_proposta
                                            where proposta.fk_propostasubmetida == propostaSubmetida.id_proposta_submetida
                                            where professorValido.id_atribuicao == coordientador.fk_professor_professor_val
                                            where coordientador.fk_proposta_submetida == propostaSubmetida.id_proposta_submetida
                                            where professorValido.fk_professor == professor.numero_meca
                                            where professor.fk_user == idUser 
                                            select new
                                            {
                                                messenger.id_messsenger,
                                                propostaSubmetida.titulo,
                                                proposta.Aluno.nome
                                            }).Distinct().ToList();

                listaChatOrientador.AddRange(listaChatCoorientador);
                return Ok(listaChatOrientador);
            }
            else
            {
                return Ok(listaChatAluno);
            }
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