using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inspections.API.Dtos
{
    public partial class BillToClientDto
    {
        public short BtcBilltoClientId { get; set; }
        public string BtcBillToClientName { get; set; }
        public string BtcBillToClientShortName { get; set; }
    }
}
