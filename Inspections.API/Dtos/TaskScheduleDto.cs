using System;
using System.Collections.Generic;

namespace Inspections.API.Dtos
{
    public partial class TaskScheduleDto
    {
        public int TsTaskCode { get; set; }
        public short? TsTaskCategory { get; set; }
        public string TsTaskDescription { get; set; }
        public string TsShortTaskDescription { get; set; }
    }
}
