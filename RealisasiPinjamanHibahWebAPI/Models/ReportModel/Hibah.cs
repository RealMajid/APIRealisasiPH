using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealisasiPinjamanHibahWebAPI.Models.ReportModel
{
    public class Hibah
    {
        public string Kementerian { get; set; }
        public string Register { get; set; }
        public string NamaProyek { get; set; }
        public double PaguDIPA { get; set; }
        public double Realisasi { get; set; }
    }
}