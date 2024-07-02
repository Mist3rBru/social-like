using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeSocialBack.Application.Dto
{
    public class ComentarioDto
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataEdicao { get; set; }
        public int QuantidadeLikes { get; set; }
        public int QuantidadeComentarios{ get; set; }
    }
}