namespace ApiAsi.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BancoContext : DbContext
    {
        public BancoContext()
            : base("name=BancoContext")
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AnexoAvaliacao> AnexoAvaliacao { get; set; }
        public virtual DbSet<AnexoMensagem> AnexoMensagem { get; set; }
        public virtual DbSet<AnexoRevisaoRelatorio> AnexoRevisaoRelatorio { get; set; }
        public virtual DbSet<AnexoSubmissaoRelatorio> AnexoSubmissaoRelatorio { get; set; }
        public virtual DbSet<Avaliacao> Avaliacao { get; set; }
        public virtual DbSet<CandidaturaAluno> CandidaturaAluno { get; set; }
        public virtual DbSet<Categoriaprofessor> Categoriaprofessor { get; set; }
        public virtual DbSet<ConfirmacaoReuniao> ConfirmacaoReuniao { get; set; }
        public virtual DbSet<Coorientador> Coorientador { get; set; }
        public virtual DbSet<Curso> Curso { get; set; }
        public virtual DbSet<Departamento> Departamento { get; set; }
        public virtual DbSet<Diretor> Diretor { get; set; }
        public virtual DbSet<Escola> Escola { get; set; }
        public virtual DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
        public virtual DbSet<Mensagem> Mensagem { get; set; }
        public virtual DbSet<Messenger> Messenger { get; set; }
        public virtual DbSet<PeriodoCandidatura> PeriodoCandidatura { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProfessorValido> ProfessorValido { get; set; }
        public virtual DbSet<Proposta> Proposta { get; set; }
        public virtual DbSet<PropostaSubmetida> PropostaSubmetida { get; set; }
        public virtual DbSet<ResultadosAvaliacao> ResultadosAvaliacao { get; set; }
        public virtual DbSet<Reuniao> Reuniao { get; set; }
        public virtual DbSet<RevisaoRelatorio> RevisaoRelatorio { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SubmissaoAvaliacao> SubmissaoAvaliacao { get; set; }
        public virtual DbSet<SubmissaoRelatorio> SubmissaoRelatorio { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserClaim> UserClaim { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Administrador>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.curriculo)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.numero_mecanografico)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.sinc_code_ext)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.CandidaturaAluno)
                .WithRequired(e => e.Aluno)
                .HasForeignKey(e => e.fk_aluno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Proposta)
                .WithRequired(e => e.Aluno)
                .HasForeignKey(e => e.fk_aluno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.ResultadosAvaliacao)
                .WithRequired(e => e.Aluno)
                .HasForeignKey(e => e.fk_aluno)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AnexoAvaliacao>()
                .Property(e => e.path_anexo)
                .IsUnicode(false);

            modelBuilder.Entity<AnexoMensagem>()
                .Property(e => e.path_anexo)
                .IsUnicode(false);

            modelBuilder.Entity<AnexoRevisaoRelatorio>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<AnexoSubmissaoRelatorio>()
                .Property(e => e.path)
                .IsUnicode(false);

            modelBuilder.Entity<Avaliacao>()
                .Property(e => e.epoca)
                .IsUnicode(false);

            modelBuilder.Entity<Avaliacao>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Avaliacao>()
                .HasMany(e => e.ResultadosAvaliacao)
                .WithRequired(e => e.Avaliacao)
                .HasForeignKey(e => e.fk_avaliacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Avaliacao>()
                .HasMany(e => e.SubmissaoAvaliacao)
                .WithRequired(e => e.Avaliacao)
                .HasForeignKey(e => e.fk_avaliacao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CandidaturaAluno>()
                .Property(e => e.fk_aluno)
                .IsUnicode(false);

            modelBuilder.Entity<Categoriaprofessor>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Categoriaprofessor>()
                .HasMany(e => e.Professor)
                .WithRequired(e => e.Categoriaprofessor)
                .HasForeignKey(e => e.fk_categoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Aluno)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.fk_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.Diretor)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.fk_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.ProfessorValido)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.fk_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Curso>()
                .HasMany(e => e.PropostaSubmetida)
                .WithRequired(e => e.Curso)
                .HasForeignKey(e => e.fk_curso)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .Property(e => e.sinc_code_ext)
                .IsUnicode(false);

            modelBuilder.Entity<Departamento>()
                .HasMany(e => e.Professor)
                .WithRequired(e => e.Departamento)
                .HasForeignKey(e => e.fk_departamento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Diretor>()
                .Property(e => e.fk_professor)
                .IsUnicode(false);

            modelBuilder.Entity<Escola>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Escola>()
                .Property(e => e.sinc_code_ext)
                .IsUnicode(false);

            modelBuilder.Entity<Escola>()
                .HasMany(e => e.Departamento)
                .WithRequired(e => e.Escola)
                .HasForeignKey(e => e.fk_escola)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InstituicaoEnsino>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<InstituicaoEnsino>()
                .Property(e => e.sinc_code_ext)
                .IsUnicode(false);

            modelBuilder.Entity<InstituicaoEnsino>()
                .HasMany(e => e.Escola)
                .WithRequired(e => e.InstituicaoEnsino)
                .HasForeignKey(e => e.fk_id_instituto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Mensagem>()
                .Property(e => e.mensagem1)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagem>()
                .HasMany(e => e.AnexoMensagem)
                .WithRequired(e => e.Mensagem)
                .HasForeignKey(e => e.fk_mensagem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PeriodoCandidatura>()
                .HasMany(e => e.CandidaturaAluno)
                .WithRequired(e => e.PeriodoCandidatura)
                .HasForeignKey(e => e.fk_periodocandidatura)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Professor>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Professor>()
                .Property(e => e.numero_meca)
                .IsUnicode(false);

            modelBuilder.Entity<Professor>()
                .Property(e => e.curriculo_vitae)
                .IsUnicode(false);

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.Diretor)
                .WithRequired(e => e.Professor)
                .HasForeignKey(e => e.fk_professor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Professor>()
                .HasMany(e => e.ProfessorValido)
                .WithRequired(e => e.Professor)
                .HasForeignKey(e => e.fk_professor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfessorValido>()
                .Property(e => e.fk_professor)
                .IsUnicode(false);

            modelBuilder.Entity<ProfessorValido>()
                .HasMany(e => e.Coorientador)
                .WithRequired(e => e.ProfessorValido)
                .HasForeignKey(e => e.fk_professor_professor_val)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProfessorValido>()
                .HasMany(e => e.PropostaSubmetida)
                .WithRequired(e => e.ProfessorValido)
                .HasForeignKey(e => e.orientador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .Property(e => e.fk_aluno)
                .IsUnicode(false);

            modelBuilder.Entity<Proposta>()
                .HasMany(e => e.Messenger)
                .WithRequired(e => e.Proposta)
                .HasForeignKey(e => e.fk_proposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasMany(e => e.Reuniao)
                .WithRequired(e => e.Proposta)
                .HasForeignKey(e => e.fk_proposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Proposta>()
                .HasMany(e => e.SubmissaoRelatorio)
                .WithRequired(e => e.Proposta)
                .HasForeignKey(e => e.fk_proposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.palavras_chaves)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.objetivo)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.descricao_adicional)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.metodologia)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .Property(e => e.recursos_necessarios)
                .IsUnicode(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .HasMany(e => e.CandidaturaAluno)
                .WithRequired(e => e.PropostaSubmetida)
                .HasForeignKey(e => e.fk_proposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .HasMany(e => e.Coorientador)
                .WithRequired(e => e.PropostaSubmetida)
                .HasForeignKey(e => e.fk_proposta_submetida)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropostaSubmetida>()
                .HasMany(e => e.Proposta)
                .WithRequired(e => e.PropostaSubmetida)
                .HasForeignKey(e => e.fk_propostasubmetida)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ResultadosAvaliacao>()
                .Property(e => e.fk_aluno)
                .IsUnicode(false);

            modelBuilder.Entity<Reuniao>()
                .Property(e => e.texto_adicional)
                .IsUnicode(false);

            modelBuilder.Entity<Reuniao>()
                .HasMany(e => e.ConfirmacaoReuniao)
                .WithRequired(e => e.Reuniao)
                .HasForeignKey(e => e.fk_reuniao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RevisaoRelatorio>()
                .HasMany(e => e.AnexoRevisaoRelatorio)
                .WithRequired(e => e.RevisaoRelatorio)
                .HasForeignKey(e => e.fk_revisao_relatorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithMany(e => e.Role)
                .Map(m => m.ToTable("UserRole").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<SubmissaoAvaliacao>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<SubmissaoAvaliacao>()
                .HasMany(e => e.AnexoAvaliacao)
                .WithRequired(e => e.SubmissaoAvaliacao)
                .HasForeignKey(e => e.fk_submissao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubmissaoRelatorio>()
                .HasMany(e => e.AnexoSubmissaoRelatorio)
                .WithRequired(e => e.SubmissaoRelatorio)
                .HasForeignKey(e => e.fk_submissaorelatorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubmissaoRelatorio>()
                .HasMany(e => e.RevisaoRelatorio)
                .WithRequired(e => e.SubmissaoRelatorio)
                .HasForeignKey(e => e.fk_submissaorelatorio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Administrador)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Aluno)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Avaliacao)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_criador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.ConfirmacaoReuniao)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Mensagem)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PeriodoCandidatura)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_criador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Professor)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.PropostaSubmetida)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reuniao)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RevisaoRelatorio)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_criador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SubmissaoAvaliacao)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_criador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SubmissaoRelatorio)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.fk_user_criador)
                .WillCascadeOnDelete(false);
        }
    }
}
