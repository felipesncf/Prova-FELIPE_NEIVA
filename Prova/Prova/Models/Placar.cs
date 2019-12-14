using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class Placar
    {
        public int Id { get; set; }
        public Jogador Jogador { get; set; }

        [Display(Name ="Jogador")]
        public int JogadorId { get; set; }
        [Display(Name = "Pontuação")]
        [Range(1, 100, ErrorMessage = "Insira uma pontuação entre 1 e 100")]
        public int Total { get; set; }

        [Display(Name = "Data da pontuação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public DateTime Data { get; set; }

        public Placar()
        {
        }

        public Placar(int id, int jogadorId, Jogador jogador, int total, DateTime data)
        {
            Id = id;
            JogadorId = jogadorId;
            Jogador = jogador;
            Total = total;
            Data = data;
        }

        public static implicit operator Placar(List<Placar> v)
        {
            throw new NotImplementedException();
        }
    }
}
