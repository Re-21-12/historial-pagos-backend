using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace historial_pagos.Models
{
    public class Pago
    {
        [Key]  // Define que es la clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Activa el autoincremento
        public int Id
        {
            get; set;
        }
        [Required]
        public string Titulo
        {
            get; set;
        }
        public string Descripcion
        {
            get; set;
        }
        [Required]

        public decimal Cantidad
        {
            get; set;
        }
        [Required]
        public string Fecha
        {
            get; set;
        }
    }
}