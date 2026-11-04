using Microsoft.EntityFrameworkCore;
namespace MenuGHF.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        [Precision(10, 2)]
        public decimal Preco { get; set; }
    }
}
