using System.ComponentModel.DataAnnotations;

namespace ProyectoLibreria.Models.Entidades
{
    public class Autor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm tt}")]
        public DateTime Birthdate { get; set; }
    }
}
