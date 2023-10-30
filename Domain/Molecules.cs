using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.DTO.Domain
{
    public class Molecules
    {
        [Key]
        public Guid IdMolecules { get; set; }

        [Required(ErrorMessage = " Molecules Name cannot be null")]
        [StringLength(50)]
        public string MoleculesName { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = " Molecules Description cannot be null")]
        public string MolDescription { get; set; }

        public int IsActive { get; set; }

        [StringLength(10)]
        public string? State { get; set; }
    }
}
