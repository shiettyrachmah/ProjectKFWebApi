using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.Domain;

namespace WebAPI.DTO.Domain
{
    public class Study
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = " Study Id cannot be null")]
        [StringLength(10)]
        public string StudyId { get; set; }

        [Required(ErrorMessage = " Version Id cannot be null")]
        public int VersionID { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = " Protocol Title cannot be null")]
        public string ProtocolTitle { get; set; }

        [Required(ErrorMessage = "Protocol Code cannot be null")]
        [StringLength(25)]
        public string ProtocolCode { get; set; }

        [Required(ErrorMessage = "Molecules ID cannot be null")]
        public Guid MoleculesID { get; set; }

        [Required(ErrorMessage = "Status Study ID cannot be null")]
        public int StatusStudyID { get; set; }

        [Required(ErrorMessage = "IsActive cannot be null")]
        public int IsActive { get; set; }

        [Required(ErrorMessage = " Protocol Title cannot be null")]
        public int IsDeleted { get; set; }

        [StringLength(200)]
        public string CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        [StringLength(200)]
        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [StringLength(10)]
        public string? State { get; set; }
    }
}
