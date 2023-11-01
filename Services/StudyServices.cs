using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DTO.Domain;
using WebAPI.IRepositories;
using WebAPI.IServices;

namespace WebAPI.Services
{
    public class StudyServices : IStudyServices
    {
        private readonly IStudyRespository _repo;
        public StudyServices(IStudyRespository repo)
        {
            _repo = repo;
        }

        public async Task<Study> AddStudy(Study obj)
        {
            Study? checkDataTitleExist = await _repo.GetFilteredStudyByStudyID(obj.Id.ToString());

            if (checkDataTitleExist == null)
            {
                Study std = new Study()
                {
                    Id = new Guid(),
                    StudyId = obj.StudyId,
                    VersionID = obj.VersionID,
                    ProtocolCode = obj.ProtocolCode,
                    ProtocolTitle = obj.ProtocolTitle,
                    MoleculesID = obj.MoleculesID,
                    StatusStudyID = obj.StatusStudyID,
                    IsActive = obj.IsActive,
                    IsDeleted = obj.IsDeleted,
                    CreatedBy = obj.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = obj.UpdatedBy,
                    UpdatedDate = DateTime.Now,
                    State = obj.State                 
                };

                await _repo.AddStudy(std);

                checkDataTitleExist = std;
            }
            else
            {
                return null;
            }

            return checkDataTitleExist;
        }

        public async Task<bool> DeleteStudy(string id)
        {
            if (await _repo.GetFilteredStudyByStudyID(id) != null)
                return await _repo.DeleteStudy(id);

            return false;
        }

        public async Task<List<Study>> GetAllStudy()
        {
            var result = await _repo.GetAllStudy();
            return result;
        }

        public async Task<Study?> GetFilteredStudyByStudID(string id)
        {
            return await _repo.GetFilteredStudyByStudyID(id);
        }

        public async Task<Study> UpdateStudy(Study obj)
        {
            Study? checkDataExist = await _repo.GetFilteredStudyByStudyID(obj.Id.ToString());

            if (checkDataExist != null)
            {
                checkDataExist.Id = obj.Id;
                checkDataExist.StudyId = obj.StudyId;
                checkDataExist.VersionID = obj.VersionID;
                checkDataExist.ProtocolCode = obj.ProtocolCode;
                checkDataExist.ProtocolTitle = obj.ProtocolTitle;
                checkDataExist.MoleculesID = obj.MoleculesID;
                checkDataExist.StatusStudyID = obj.StatusStudyID;
                checkDataExist.IsActive = obj.IsActive;
                checkDataExist.IsDeleted = obj.IsDeleted;
                checkDataExist.CreatedBy = obj.CreatedBy;
                checkDataExist.CreatedDate = obj.CreatedDate;
                checkDataExist.UpdatedBy = obj.UpdatedBy;
                checkDataExist.UpdatedDate = DateTime.Now;
                checkDataExist.State = obj.State;
                
                await _repo.UpdateStudy(checkDataExist);
            }
            else
            {
                return null;
            }

            return checkDataExist;
        }
    }
}
