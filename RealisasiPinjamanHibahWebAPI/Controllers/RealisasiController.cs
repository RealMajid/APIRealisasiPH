using RealisasiPinjamanHibahDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RealisasiPinjamanHibahWebAPI.Controllers
{
    public class RealisasiController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> Get()
        {
            IEnumerable<VW_REALISASI_DITPH> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.VW_REALISASI_DITPH.ToList());

                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result.OrderByDescending(res => res.TANGGAL).Take(10));
            }
        }
    }
}
