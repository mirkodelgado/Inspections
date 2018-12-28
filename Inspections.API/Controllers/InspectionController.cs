using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

using Inspections.API.Data;
using Inspections.API.Helpers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Inspections.API.Dtos;

namespace Inspections.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : ControllerBase
    {

        //private readonly DataContext _context;
        //private readonly IConfiguration _config;

private readonly IInspectionRepository _repo;
        private readonly IMapper _mapper;

        //public InspectionController(DataContext context, IConfiguration config, IMapper mapper)
        public InspectionController(IInspectionRepository repo, IMapper mapper)
        {
            //_context = context;
            //_config = config;

            _repo = repo;
            _mapper = mapper;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("bydate/{startdate}/{enddate}")]
        public async Task<IActionResult> GetByDateRange([FromQuery] UserParams userParams, string startdate, string enddate)
        {
            var inspections = await _repo.GetInspectionM2s(userParams, startdate, enddate);

            var inspectionsToReturn = _mapper.Map<IEnumerable<InspectionForListDto>>(inspections);

            Response.AddPagination(inspections.CurrentPage, inspections.PageSize,
                inspections.TotalCount, inspections.TotalPages);

            return Ok(inspectionsToReturn);
        }

        [HttpGet("byunit/{unitid}")]
        public async Task<IActionResult> GetByUnitId([FromQuery] UserParams userParams, string unitid)
        {
            var inspections = await _repo.GetInspectionM2s(userParams, unitid);

            var inspectionsToReturn = _mapper.Map<IEnumerable<InspectionForListDto>>(inspections);

            Response.AddPagination(inspections.CurrentPage, inspections.PageSize,
                inspections.TotalCount, inspections.TotalPages);

            return Ok(inspectionsToReturn);

        }



        [HttpGet("getinspections")]
        public async Task<IActionResult> GetInspections([FromQuery] UserParams userParams)
        {
            var inspections = await _repo.GetInspectionMs(userParams);

            var inspectionsToReturn = _mapper.Map<IEnumerable<InspectionForListDto>>(inspections);

            Response.AddPagination(inspections.CurrentPage, inspections.PageSize,
                inspections.TotalCount, inspections.TotalPages);

            if (inspectionsToReturn.Count() == 0)
                return BadRequest("Unit " + userParams.UnitId + " could not be found" );

            return Ok(inspectionsToReturn);

            //var inspection = _context.InspectionsM.AsQueryable();

            ////if (String.IsNullOrEmpty(userParams.UnitId))
            //    return BadRequest("Provide Parameter String");

            //inspection = inspection.Where(i => i.ImEquip1Id.Equals(userParams.UnitId));

            //inspection = inspection.Include(i => i.BillToClient);
            //inspection = inspection.Include(i => i.InspectionD);
            //inspection = inspection.Include(g => g.Depot);
            //inspection = inspection.Include(g => g.EquipmentType);
            
            //inspection = inspection.OrderByDescending(i => i.ImInspectionDate);

            //var response = await inspection.ToListAsync();

            //var inspectiond = _context.InspectionsD.AsQueryable();

            //inspectiond = inspectiond.Where(i => i.IdInspectionRefNmbr.Equals(response[0].ImInspectionRefNmbr));

            //inspectiond = inspectiond.OrderBy(i => i.IdLineNmbr);

            //var responsed = await inspectiond.ToListAsync();

            //response[0].InspectionD = responsed;

            //if (response.Count == 0)
             //   return BadRequest("Unit " + userParams.UnitId + " could not be found" );

            //return Ok(response);
        }


        [HttpGet("getpictures/{id}")]

        public async Task<IActionResult> GetPictures(string id)
        {
            var inspectionM = await _repo.GetInspectionM(id);

            var inspectionMToReturn = _mapper.Map<InspectionForListDto>(inspectionM);

            var pictures = await _repo.GetInspectionPictures(id);

            //return Ok(pictures);

            return Ok(new
            {
                inspectionMToReturn,
                pictures
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var inspectionM = await _repo.GetInspectionM(id);

            var inspectionMToReturn = _mapper.Map<InspectionForListDto>(inspectionM);

            var inspection = await _repo.GetInspectionDetails(inspectionMToReturn.BillToClient.BtcBilltoClientId, id);

            var inspectionToReturn = _mapper.Map<IEnumerable<InspectionResultDto>>(inspection);

            var pictures = await _repo.GetInspectionPictures(id);

            //return Ok(inspectionToReturn);

            return Ok(new
            {
                inspectionMToReturn,
                pictures,
                inspectionToReturn
            });

        }
    }
}
