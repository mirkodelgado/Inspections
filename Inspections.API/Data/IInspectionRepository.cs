using System.Collections.Generic;
using System.Threading.Tasks;
using Inspections.API.Helpers;
using Inspections.API.Models;

namespace Inspections.API.Data
{
    public interface IInspectionRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();

         Task<InspectionM> GetInspectionM(string id);

         Task<PagedList<InspectionM>> GetInspectionMs(UserParams userParams);

         Task<PagedList<InspectionM>> GetInspectionM2s(UserParams userParams, string startdate, string enddate);

         Task<PagedList<InspectionM>> GetInspectionM2s(UserParams userParams, string unitid);

         Task<IEnumerable<InspectionResult>> GetInspectionDetails(short billToCid, string id);

         Task<InspectionPictures> GetInspectionPictures(string id);

         //Task<Photo> GetPhoto(int id);
         //Task<Photo> GetMainPhotoForUser(int userId);
    }
}