using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialBack.Domain.Entities
{

    public class Comentario
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public int QuantidadeLikes { get; set; }

        public Comentario()
        {
            this.Id = Guid.NewGuid();
            this.IdUsuario = Guid.NewGuid();
            this.Conteudo = "Programar é legal!!";
            this.DataCriacao = DateTime.Now;
            this.DataEdicao = DateTime.Now;
            this.QuantidadeLikes = 0;
        }

        public Comentario(Guid IdUsuario, string Conteudo) { 
            this.Id = Guid.NewGuid();
            this.IdUsuario = IdUsuario;
            this.Conteudo = Conteudo;
            this.DataCriacao = DateTime.Now;
            this.DataEdicao = DateTime.Now;
            this.QuantidadeLikes = 0;
        }

        public Comentario(Guid Id, Guid IdUsuario, string Conteudo, DateTime DataCriacao, DateTime DataEdicao, int QuantidadeLikes)
        {
            this.Id = Id;
            this.IdUsuario = IdUsuario;
            this.Conteudo = Conteudo;
            this.DataCriacao = DataCriacao;
            this.DataEdicao = DataEdicao;
            this.QuantidadeLikes = QuantidadeLikes;
        }
    }
}
