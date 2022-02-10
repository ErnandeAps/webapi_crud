using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanSuporte.Aplication.ViewModels
{
   public class ProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório")]
        [MinLength(5)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage ="Obrigatório  o valor")]
        [Range(1,99999.99)]
        [DisplayFormat(DataFormatString ="{0:C2}")]
        public decimal Price { get; set; }



    }
}