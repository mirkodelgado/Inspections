using System.Collections.Generic;

namespace Inspections.API.Models
{
    public class InspectionResult
    {
        //public InspectionM InspectionM { get; set; }
        //public BillToClient BillToClient { get; set; }
        //public Location Depot { get; set; }
        public InspectionD InspectionD { get; set; }
        public TaskSchedule TaskSchedule { get; set; }
        public Locations Locations { get; set; }

        public InspectionResult(InspectionD d, TaskSchedule ts, Locations lg)
        //public InspectionResult(InspectionM m, BillToClient b, Location dpt, InspectionD d, TaskSchedule ts, Locations lg)
        {
            //this.InspectionM = m;
            //this.BillToClient = b;
            //this.Depot = dpt;
            this.InspectionD = d;
            this.TaskSchedule = ts;
            this.Locations = lg;
        }
        
    }
}