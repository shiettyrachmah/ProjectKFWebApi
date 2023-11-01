using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebAPI.DTO.Domain;
using WebAPI.IServices;

namespace ProjectKFWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudyController : ControllerBase   
    {
        private readonly ILogger<StudyController> _logger;

        private readonly IStudyServices _services;

        public StudyController(ILogger<StudyController> logger, IStudyServices services)
        {
            _services = services;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Study>>> GetData()
        {
            try
            {
                var resultData = await _services.GetAllStudy();
                if (resultData.Count == 0)
                {
                    return NotFound(new { message = "Data Empty" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Study>> GetFilteredStudyByID(string id)
        {
            try
            {
                var resultData = await _services.GetFilteredStudyByStudID(id);
                if (resultData == null)
                {
                    return NotFound(new { message = "Data Not Found" });
                }

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Study>> AddData([FromForm] string jsonData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<Study>(jsonData);

                var resultData = await _services.AddStudy(data);

                if (resultData == null)
                {
                    return NotFound(new { message = "Add Unsuccessfully. ID Study was Exist" });
                }

                return Ok(resultData);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/{id}")]
        public async Task<ActionResult> DelData(string id)
        {
            try
            {
                bool resultData = await _services.DeleteStudy(id);

                if (resultData == false)
                {
                    return NotFound(new { message = "Delete Unsuccessfully. ID Study Not Found" });
                }
                else
                {
                    return Ok(new { message = "Delete Study From Database" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Study>> UpdateData([FromForm] string jsonData)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<Study>(jsonData);
                var resultData = await _services.UpdateStudy(data);
                if (resultData == null)
                    return NotFound(new { message = "Update Unsuccessfully.ID Study was Exist" });

                return Ok(resultData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
