using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormularioCadastroCliente.Models
{
    public class Cliente
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Razão Social")]
        [Column(TypeName = "varchar(100)")]
        public string RazaoSocial { get; set; }
        [Display(Name = "Nome Fantasia")]
        [Column(TypeName = "varchar(100)")]
        public string NomeFantasia { get; set; }
        [Display(Name = "CNPJ")]
        [Column(TypeName = "varchar(18)")]
        public string Cnpj { get; set; }
        [Display(Name = "Data de Abertura da Empresa")]
        [Column(TypeName = "varchar(12)")]
        public string DataAberturaEmpresa { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Display(Name = "UF")]
        [Column(TypeName = "varchar(2)")]
        public string Uf { get; set; }
    }
}
