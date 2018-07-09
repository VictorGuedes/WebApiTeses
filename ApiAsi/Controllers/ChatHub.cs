using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAsi.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;


namespace ApiAsi.Controllers
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public class InfoUser
        {
            public string id_session { get; set; }
            public string nome_user { get; set; }
        }

        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

        private static Dictionary<int, List<InfoUser>> dict = new Dictionary<int, List<InfoUser>>();

        private BancoContext db = new BancoContext();
        private ApplicationDbContext d = new ApplicationDbContext();

        public void Connect()
        {
            var id = Context.ConnectionId;
            //var user = Context.User.Identity.Name;
            var user = "aluno@hotmail.com";
            var usr = d.Users.Where(u => u.Email == user).FirstOrDefault();
            Aluno al = db.Aluno.Where(a => a.fk_user_login == usr.Id).FirstOrDefault();

            if (al != null)
            {
                InfoUser us = new InfoUser();
                us.id_session = id;
                us.nome_user = user;
                var proposta = db.Proposta.Where(p => p.fk_aluno == al.numero_mecanografico).FirstOrDefault();
                var m = db.Messenger.Where(m1 => m1.fk_proposta == proposta.id_proposta).FirstOrDefault();
                var nr = dict.ContainsKey(m.id_messsenger);
                if (nr == true)
                {
                    dict[m.id_messsenger].Add(us);
                }
                else
                {
                    List<InfoUser> lt = new List<InfoUser>();
                    lt.Add(us);
                    dict.Add(m.id_messsenger, lt);
                }
            }
            else
            {

                Professor p = db.Professor.Where(pr => pr.fk_user == usr.Id).FirstOrDefault();
                ProfessorValido pv = db.ProfessorValido.Where(prv => prv.date_inicio < DateTime.Now && prv.date_fim > DateTime.Now && prv.fk_professor == p.numero_meca).FirstOrDefault();
                List<Messenger> tp = new List<Messenger>();
                //procura messenger orientadores

                string sql = "Select  t1.* from Messenger as t1 inner join Proposta as t2 on t1.fk_proposta =  t2.id_proposta inner join PropostaSubmetida as t3 on" +
                    " t2.fk_propostasubmetida = t3.id_proposta_submetida Where t3.orientador=" + pv.id_atribuicao;
                tp = db.Messenger.SqlQuery(sql).ToList();

                sql = "Select  t1.* from Messenger as t1 inner join Proposta as t2 on t1.fk_proposta =  t2.id_proposta inner join PropostaSubmetida as t3 on" +
                    " t2.fk_propostasubmetida = t3.id_proposta_submetida inner join Coorientador  as t4 on t3.id_proposta_submetida =  t4.fk_proposta_submetida" +
                    " Where t4.fk_professor_professor_val=" + pv.id_atribuicao;

                tp.AddRange(db.Messenger.SqlQuery(sql).ToList());

                InfoUser us = new InfoUser();
                us.id_session = id;
                us.nome_user = user;
                foreach (var v in tp)
                {
                    var nr = dict.ContainsKey(v.id_messsenger);
                    if (nr == true)
                    {
                        dict[v.id_messsenger].Add(us);
                    }
                    else
                    {
                        List<InfoUser> lt = new List<InfoUser>();
                        lt.Add(us);
                        dict.Add(v.id_messsenger, lt);
                    }
                }
            }

            Clients.Caller.onConnected(id, dict);
        }


        public void SendMessage(string chat, string message, string time)
        {
            var list = chat.Split('-');
            var l = dict[int.Parse(list[0])];
            //var user = Context.User.Identity.Name;
            var user = "aluno@hotmail.com";
            Mensagem msg = new Mensagem();
            msg.mensagem1 = message;
            msg.fk_messenger = int.Parse(list[0]);
            var usr = d.Users.Where(u => u.Email == user).FirstOrDefault();
            msg.fk_user = usr.Id;
            msg.data_receive = DateTime.Now;
            db.Mensagem.Add(msg);
            db.SaveChanges();

            foreach (var val in l)
                //hubContext.Clients.Client(val.id_session).message(int.Parse(list[0]), user, message, time);
                hubContext.Clients.Client(val.id_session).message(message, time);

        }


        public override Task OnDisconnected(bool stopCalled)
        {
            // var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            // if (item != null)
            // {
            ///  ConnectedUsers.Remove(item);

            //   var id = Context.ConnectionId;
            //   Clients.All.onUserDisconnected(id, item.UserName);

            //  }
            return base.OnDisconnected(stopCalled);
        }

    }
}



