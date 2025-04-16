// Responsável por armazenar as informações dos hóspedes
// Namespace: é uma maneira de organizar o código em grupos, como pastas,para facilitar a leitura e manutenção
// API.Models: indica que este código faz parte do projeto de uma API e está relacionado a modelos de dados

namespace API.Models{
    public class Hospede{
        // {get; set; } -> Propriedade para armazenar os dados do hóspede
        // O get serve para 'ler' os dados e o set para 'escrever' os dados
        public int Id { get; set; } 
        public string Nome { get; set; } 
        public string Cpf { get; set; } 
        public string Telefone { get; set; } 
    }
}
