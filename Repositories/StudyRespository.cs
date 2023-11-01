using Microsoft.EntityFrameworkCore;
using ProjectKFWebApi.Domain.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.Domain;
using WebAPI.IRepositories;

namespace WebAPI.Repositories
{
    public class StudyRespository : IStudyRespository
    {
        private readonly ApplicationDBContext _db;

        public StudyRespository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<Study> AddStudy(Study study)
        {
            _db.Study.Add(study);
            await _db.SaveChangesAsync();

            return study;
        }

        public async Task<bool> DeleteStudy(string id)
        {
            _db.Study.RemoveRange(_db.Study.Where(x => x.Id.ToString() == id));
            int rowDel = await _db.SaveChangesAsync();
            return rowDel > 0;
        }

        public async Task<List<Study>> GetAllStudy()
        {
            return await _db.Study.ToListAsync();
        }

        public Task<Study?> GetFilteredStudyByStudyID(string id)
        {
            return _db.Study.Where(x => x.Id.ToString() == id).FirstOrDefaultAsync(); 
        }

        public async Task<Study> UpdateStudy(Study obj)
        {
            await _db.SaveChangesAsync();

            return obj;
        }
    }
}
