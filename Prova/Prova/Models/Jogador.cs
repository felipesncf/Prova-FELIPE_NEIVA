using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prova.Models
{
    public class Jogador
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "O tamanho do {0} deve ser entre {2} e {1}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatório")]
        public int Idade { get; set; }

        public string Nacionalidade { get; set; }

        public Jogador()
        {
        }

        public Jogador(int id, string nome, int idade, string nacionalidade)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Nacionalidade = nacionalidade;
        }
    }
}
