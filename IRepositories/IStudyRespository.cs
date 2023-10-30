using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.Domain;

namespace WebAPI.IRepositories
{
    public interface IStudyRespository
    {
        Task<List<Study>> GetAllStudy();
        Task<Study?> GetFilteredStudyByStudyID(string id);
        Task<Study> AddStudy(Study Study);
        Task<Study> UpdateStudy(Study study);
        Task<bool> DeleteStudy(string id);
    }
}
