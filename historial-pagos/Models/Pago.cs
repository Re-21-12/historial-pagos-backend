using System.ComponentModel.DataAnnotations.Schema;

namespace historial_pagos.Models
{
    //[Table("Pagos")]
    public class Pago
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public string Fecha { get; set; }
    }
}
