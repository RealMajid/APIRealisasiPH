using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealisasiPinjamanHibahWebAPI.Models.ReportModel
{
    public class PinjamanLuarNegeriPipeline
    {
        public string Kementerian { get; set; }
        public string Register { get; set; }
        public double PaguPLN { get; set; }
        public double RMPPLN { get; set; }
    }
}