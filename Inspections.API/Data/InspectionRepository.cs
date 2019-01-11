using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Inspections.API.Helpers;
using Inspections.API.Models;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Inspections.API.Data
{
    public class InspectionRepository : IInspectionRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;

        public InspectionRepository(DataContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        // public async Task<Photo> GetMainPhotoForUser(int userId)
        // {
        //     return await _context.Photos.Where(u => u.UserId == userId)
        //         .FirstOrDefaultAsync(p => p.IsMain);
        // }

        // public async Task<Photo> GetPhoto(int id)
        // {
        //     var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);

        //     return photo;
        // }

        // public async Task<User> GetUser(int id)
        // {
        //     var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

        //     return user;
        // }


        public async Task<PagedList<InspectionM>> GetInspectionM2s(UserParams userParams, string startDate, string endDate)
        {
            var inspections = _context.InspectionsM.AsQueryable();

            var sDate = DateTime.Parse(startDate);
            var eDate = DateTime.Parse(endDate).AddDays(1);

            inspections = inspections.Where(i => i.ImInspectionDate >= sDate && i.ImInspectionDate <= eDate);

            inspections = inspections.Include(i => i.BillToClient);
            //inspections = inspections.Include(i => i.InspectionD);

            inspections = inspections.OrderByDescending(i => i.ImInspectionDate);

            return await PagedList<InspectionM>.CreateAsync(inspections, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<PagedList<InspectionM>> GetInspectionM2s(UserParams userParams, string unitId)
        {
            var inspections = _context.InspectionsM.AsQueryable();

            inspections = inspections.Where(i => i.ImEquip1Id.Equals(unitId));

            inspections = inspections.Include(i => i.BillToClient);
            //inspections = inspections.Include(i => i.InspectionD);

            inspections = inspections.OrderByDescending(i => i.ImInspectionDate);

            return await PagedList<InspectionM>.CreateAsync(inspections, userParams.PageNumber, userParams.PageSize);
        }


        public async Task<InspectionM> GetInspectionM(string id)
        {
            var inspection = await _context.InspectionsM
                             .Include(i => i.BillToClient)
                             .Include(i => i.Depot)
                             .Include(i => i.EquipmentType)     
                             .FirstOrDefaultAsync(i => i.ImInspectionRefNmbr.Equals(id));

            return inspection;
        }

        public async Task<PagedList<InspectionM>> GetInspectionMs(UserParams userParams)
        {
            var inspections = _context.InspectionsM.AsQueryable();

            if (!String.IsNullOrEmpty(userParams.UnitId))
                //inspections = inspections.Where(i => i.ImEquip1Id.Equals(userParams.UnitId));
                inspections = inspections.Where(i => i.ImEquip1Id.Equals(userParams.UnitId) && i.ImCleanInspection.Equals("0"));

            if (!String.IsNullOrEmpty(userParams.StartDate) && !String.IsNullOrEmpty(userParams.EndDate))
            {
                var startDate = DateTime.Parse(userParams.StartDate);
                var endDate = DateTime.Parse(userParams.EndDate).AddDays(1);

                //inspections = inspections.Where(i => i.ImInspectionDate >= startDate && i.ImInspectionDate <= endDate);
                inspections = inspections.Where(i => i.ImInspectionDate >= startDate && i.ImInspectionDate <= endDate && i.ImCleanInspection.Equals("0"));
            }

            inspections = inspections.Include(i => i.BillToClient);
            inspections = inspections.Include(i => i.Depot);

            switch (userParams.OrderByColumn)
            {
                case "imInspectionDate":
                    if (userParams.OrderByDirection.Equals("asc"))
                        inspections = inspections.OrderBy(i => i.ImInspectionDate);
                    else
                        inspections = inspections.OrderByDescending(i => i.ImInspectionDate);
                    break;

                case "depot.dptName":
                    if (userParams.OrderByDirection.Equals("asc"))
                        inspections = inspections.OrderBy(i => i.Depot.DptName);
                    else
                        inspections = inspections.OrderByDescending(i => i.Depot.DptName);
                    break;

                case "billToClient.btcBillToClientShortName":
                    if (userParams.OrderByDirection.Equals("asc"))
                        inspections = inspections.OrderBy(i => i.BillToClient.BtcBillToClientShortName);
                    else
                        inspections = inspections.OrderByDescending(i => i.BillToClient.BtcBillToClientShortName);
                    break;

                case "imEquip1Id":
                    if (userParams.OrderByDirection.Equals("asc"))
                        inspections = inspections.OrderBy(i => i.ImEquip1Id);
                    else
                        inspections = inspections.OrderByDescending(i => i.ImEquip1Id);
                    break;

                case "imInspectionRefNmbr":
                    if (userParams.OrderByDirection.Equals("asc"))
                        inspections = inspections.OrderBy(i => i.ImInspectionRefNmbr);
                    else
                        inspections = inspections.OrderByDescending(i => i.ImInspectionRefNmbr);
                    break;

                default:
                    inspections = inspections.OrderByDescending(i => i.ImInspectionDate);
                    break;
            }

            return await PagedList<InspectionM>.CreateAsync(inspections, userParams.PageNumber, userParams.PageSize);
        }

        // public async Task<PagedList<User>> GetUsers(UserParams userParams)
        // {
        //     var users = _context.Users.Include(p => p.Photos)
        //         .OrderByDescending(u => u.LastActive).AsQueryable();

        //     users = users.Where(u => u.Id != userParams.UserId);

        //     users = users.Where(u => u.Gender == userParams.Gender);

        //     if (userParams.MinAge != 18 || userParams.MaxAge != 99)
        //     {
        //         var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
        //         var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

        //         users = users.Where(u => u.DateOfBirth >= minDob && u.DateOfBirth <= maxDob);
        //     }

        //     if (!string.IsNullOrEmpty(userParams.OrderBy))
        //     {
        //         switch (userParams.OrderBy)
        //         {
        //             case "created":
        //                 users = users.OrderByDescending(u => u.Created);
        //                 break;
        //             default:
        //                 users = users.OrderByDescending(u => u.LastActive);
        //                 break;
        //         }
        //     }

        //     return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        // }





        public async Task<IEnumerable<InspectionResult>> GetInspectionDetails(short billToCid, string id)
        {
            var query = //from m in _context.InspectionsM

                        //join b in _context.BillToClient
                        //on m.ImBillToCid equals b.BtcBilltoClientId

                        //join dpt in _context.Depot
                        //on new { d1 = (Int16?) m.ImVendorId, d2 = (Int16? ) m.ImDepotId, d3 = (Int16? ) m.ImBillToCid } equals new { d1 = (Int16?) dpt.DptVendorId, d2 = (Int16?) dpt.DptDepotId, d3 = (Int16?) dpt.DptBillToClientId } 

                        //join d in _context.InspectionsD
                        //on m.ImInspectionRefNmbr equals d.IdInspectionRefNmbr

                        from d in _context.InspectionsD

                        join ts in _context.TaskSchedule
                        on d.IdRepairCode equals ts.TsTaskCode

                        join lg in _context.Locations
                        on new { a1 = (Int16?) billToCid, a2 = (Int16?)ts.TsTaskCategory, a3 = d.IdRepairLocation } equals new { a1 = (Int16?)lg.LgBillToCid, a2 = (Int16?)lg.LgRepairCategory, a3 = lg.LgLocationNmbr } 

                        where d.IdInspectionRefNmbr.Equals(id)
                        orderby d.IdLineNmbr
                        //select new InspectionResult (m, b, dpt, d, ts, lg);
                        select new InspectionResult (d, ts, lg);

            // var query = from m in _context.InspectionsM

            //             join b in _context.BillToClient
            //             on m.ImBillToCid equals b.BtcBilltoClientId

            //             join dpt in _context.Depot
            //             on new { d1 = (Int16?) m.ImVendorId, d2 = (Int16? ) m.ImDepotId, d3 = (Int16? ) m.ImBillToCid } equals new { d1 = (Int16?) dpt.DptVendorId, d2 = (Int16?) dpt.DptDepotId, d3 = (Int16?) dpt.DptBillToClientId } 

            //             join d in _context.InspectionsD
            //             on m.ImInspectionRefNmbr equals d.IdInspectionRefNmbr

            //             join ts in _context.TaskSchedule
            //             on d.IdRepairCode equals ts.TsTaskCode

            //             join lg in _context.Locations
            //             on new { a1 = (Int16?)m.ImBillToCid, a2 = (Int16?)ts.TsTaskCategory, a3 = d.IdRepairLocation } equals new { a1 = (Int16?)lg.LgBillToCid, a2 = (Int16?)lg.LgRepairCategory, a3 = lg.LgLocationNmbr } 

            //             where m.ImInspectionRefNmbr.Equals(id)
            //             select new InspectionResult (m, b, dpt, d, ts, lg);


            //var inspection = _context.InspectionsM
            //.Join(_context.InspectionsD, m => m.ImInspectionRefNmbr, d => d.IdInspectionRefNmbr, (m, d) => new { m, d })
            //.Join(_context.TaskSchedule, d => d.d.IdRepairCode, ts => ts.TsTaskCode, ( d, ts ) => new { d, ts })

            ////.Join(_context.Locations, 
            ////      new { a1 = (Int16?) m.ImBillToCid, a2 = (Int16?) ts.TsTaskCategory, a3 = d.IdRepairLocation },
            ////      new { a1 = (Int16?) lg.LgBillToCid, a2 = (Int16?) lg.LgRepairCategory, a3 = lg.LgLocationNmbr },
            ////      ( m, d, ts, lg ) => new { m, d, ts, lg })

            //.Where(r => r.d.m.ImInspectionRefNmbr.Equals(id))
            //.Select(z => new { z.d.m, z.d, z.ts });

            //var inspection = _context.InspectionsM.AsQueryable();
            //inspection = inspection.Join(_context.InspectionsD, m => m.ImInspectionRefNmbr, d => d.IdInspectionRefNmbr, (m, d) => new { m, d })
            //.Where(r => r.m.ImInspectionRefNmbr.Equals(id));

            //var inspection = _context.InspectionsD.AsQueryable();

            //inspection = inspection.Where(i => i.IdInspectionRefNmbr.Equals(id.ToString()));

            ////inspection = inspections.Include(i => i.BillToClient);

            ////inspection = inspections.OrderByDescending(i => i.ImInspectionDate);

            var list = await query.ToListAsync();

            return list;            
        }


        public async Task<InspectionPictures> GetInspectionPictures(string id)
        {
            var inspection = await _context.InspectionsM.FirstOrDefaultAsync(m => m.ImInspectionRefNmbr.Equals(id));

            var pictureInfo = new InspectionPictures();

            pictureInfo.InDate = inspection.ImInspectionDate.ToString("MM/dd/yyyy hh:mm tt");

            IEnumerable<string> urlList = GetPhotoLinks(inspection.ImTimeStamp, inspection.ImInspectionRefNmbr);

            pictureInfo.PictureUrl = urlList.ToArray();

            return pictureInfo;
        }

        /*************************************
         * 
         *************************************/

        protected IEnumerable<String> GetPhotoLinks(DateTime iDate, String InspectionNmbr)
        {
            string Year = iDate.Year.ToString();
            string Month = iDate.Month.ToString().PadLeft(2,'0');
            string Day = iDate.Day.ToString().PadLeft(2,'0');

            var basePath = _config.GetSection("AppSettings:InspectionBasePath").Value;

            String iDirPath = basePath + Year + "\\" + Month + "\\" + Day + "\\" + InspectionNmbr + "\\";

            String[] pFiles = Directory.GetFiles(iDirPath);

            Boolean ListAllocated = false;
            List<String> pLinks = null;

            var urlPath = _config.GetSection("AppSettings:InspectionBaseUrl").Value;

            foreach (String pFile in pFiles)
            {
                String pFile2 = Path.GetFileName(pFile);

                if (ListAllocated == false)
                {
                    pLinks = new List<String>();
                    ListAllocated = true;
                }

                String pUrlPath = urlPath + Year + "/" + Month + "/" + Day + "/" + InspectionNmbr + "/" + pFile2;

                pLinks.Add(pUrlPath);
            }

            return pLinks;
        }




        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}