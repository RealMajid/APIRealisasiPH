using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealisasiPinjamanHibahWebAPI.Models.ReportModel
{
    public class PinjamanLuarNegeri
    {
        public string Kementerian { get; set; }
        public string Register { get; set; }
        public string NamaProyek { get; set; }
        public double NilaiPaguPLN { get; set; }
        public double NilaiPaguRMP { get; set; }
        public double NilaiRealisasiPLN { get; set; }
        public double NilaiRealisasiRMP { get; set; }
    }
}