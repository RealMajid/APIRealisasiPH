using AutoMapper;
using Microsoft.Reporting.WebForms;
using RealisasiPinjamanHibahDataAccess;
using RealisasiPinjamanHibahWebAPI.Models.ReportModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace RealisasiPinjamanHibahWebAPI.Controllers
{
    public class RptController : Controller
    {
        public async Task<ActionResult> GetPLN(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("PLN", tanggal).ToList());

                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPLN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<PinjamanLuarNegeri>>(result);

                resultPLN.OrderBy(val => val.Register);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(PinjamanLuarNegeri).Name);
                PropertyInfo[] props = typeof(PinjamanLuarNegeri).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (PinjamanLuarNegeri item in resultPLN)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptPLN.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetHibah(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("HIBAH", tanggal).ToList());
                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultHibah = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<Hibah>>(result);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(Hibah).Name);
                PropertyInfo[] props = typeof(Hibah).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (Hibah item in resultHibah)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptHibah.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetPDN(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("PDN", tanggal).ToList());
                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPDN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<PinjamanDalamNegeri>>(result);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(PinjamanDalamNegeri).Name);
                PropertyInfo[] props = typeof(PinjamanDalamNegeri).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (PinjamanDalamNegeri item in resultPDN)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptPinjamanDalamNegeri.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetAll(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result;
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result2;
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result> result3;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("PLN", tanggal).ToList());
                result2 = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("HIBAH", tanggal).ToList());
                result3 = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_ONGOING_2("PDN", tanggal).ToList());

                if (result == null || result2 == null || result3 == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPLN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<PinjamanLuarNegeri>>(result);
                var resultHibah = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<Hibah>>(result2);
                var resultPDN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_ONGOING_2_Result>, IEnumerable<PinjamanDalamNegeri>>(result3);

                ReportDataSource rds1 = getRds<PinjamanLuarNegeri>(resultPLN, "DataSet1");
                ReportDataSource rds2 = getRds<PinjamanDalamNegeri>(resultPDN, "DataSet2");
                ReportDataSource rds3 = getRds<Hibah>(resultHibah, "DataSet3");

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptAll.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds1);
                viewer.LocalReport.DataSources.Add(rds2);
                viewer.LocalReport.DataSources.Add(rds3);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetPipelinePLN(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("PLN", tanggal).ToList());
                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPLNPipeline = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<PinjamanLuarNegeriPipeline>>(result);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(PinjamanLuarNegeriPipeline).Name);
                PropertyInfo[] props = typeof(PinjamanLuarNegeriPipeline).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (PinjamanLuarNegeriPipeline item in resultPLNPipeline)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptPinjamanLuarNegeriPipeline.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetPipelineHibah(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("HIBAH", tanggal).ToList());
                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultHibahPipeline = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<HibahPipeline>>(result);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(HibahPipeline).Name);
                PropertyInfo[] props = typeof(HibahPipeline).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (HibahPipeline item in resultHibahPipeline)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptHibahPipeline.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetPipelinePDN(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("PDN", tanggal).ToList());
                if (result == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPDNPipeline = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<PinjamanDalamNegeriPipeline>>(result);

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                DataTable dt = new DataTable(typeof(PinjamanDalamNegeriPipeline).Name);
                PropertyInfo[] props = typeof(PinjamanDalamNegeriPipeline).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (PropertyInfo prop in props)
                {
                    dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                        prop.PropertyType);
                }

                foreach (PinjamanDalamNegeriPipeline item in resultPDNPipeline)
                {
                    var values = new object[props.Length];
                    for (int x = 0; x < props.Length; x++)
                    {
                        values[x] = props[x].GetValue(item, null);
                    }
                    dt.Rows.Add(values);
                }

                ReportDataSource rds = new ReportDataSource("DataSet1", dt);
                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptPinjamanDalamNegeriPipeline.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }

                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public async Task<ActionResult> GetAllPipeline(string tanggal, string format)
        {
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result;
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result2;
            IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result> result3;
            using (PDE2Entities pdeEntitties = new PDE2Entities())
            {
                result = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("PLN", tanggal).ToList());
                result2 = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("HIBAH", tanggal).ToList());
                result3 = await Task.Run(() => pdeEntitties.USP_GET_DITPH_PAGUVSREAL_PIPELINE_2("PDN", tanggal).ToList());

                if (result == null || result2 == null || result3 == null)
                {
                    return Redirect("~/NotfoundPage.html");
                }

                var resultPLN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<PinjamanLuarNegeriPipeline>>(result);
                var resultHibah = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<HibahPipeline>>(result2);
                var resultPDN = Mapper.Map<IEnumerable<USP_GET_DITPH_PAGUVSREAL_PIPELINE_2_Result>, IEnumerable<PinjamanDalamNegeriPipeline>>(result3);

                ReportDataSource rds1 = getRds<PinjamanLuarNegeriPipeline>(resultPLN, "DataSet1");
                ReportDataSource rds2 = getRds<PinjamanDalamNegeriPipeline>(resultPDN, "DataSet2");
                ReportDataSource rds3 = getRds<HibahPipeline>(resultHibah, "DataSet3");

                Warning[] warnings;
                string[] streamIds;
                string mimeType = string.Empty;
                string encoding = string.Empty;
                string extension = string.Empty;

                ReportViewer viewer = new ReportViewer();
                viewer.ProcessingMode = ProcessingMode.Local;
                viewer.LocalReport.ReportPath = "Reports/RptAllPipeline.rdlc";
                viewer.LocalReport.EnableExternalImages = true;
                viewer.LocalReport.DataSources.Add(rds1);
                viewer.LocalReport.DataSources.Add(rds2);
                viewer.LocalReport.DataSources.Add(rds3);
                byte[] bytes = viewer.LocalReport.Render(format, null, out mimeType, out encoding, out extension, out streamIds, out warnings);
                if (format == "PDF")
                {
                    mimeType = "Application/" + format;
                    format = "";
                }
                else
                {
                    Response.AddHeader("content-disposition", "attachment; filename=Laporan_1." + extension);
                }
                Response.Buffer = true;
                Response.Clear();

                Response.ContentType = mimeType;

                Response.BinaryWrite(bytes); // create the file
                Response.Flush();
                Response.End();
                return View();
            }
        }

        public ReportDataSource getRds<T>(IEnumerable<T> list, string dataSetName)
        {
            DataTable dt = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                    prop.PropertyType);
            }

            foreach (T item in list)
            {
                var values = new object[props.Length];
                for (int x = 0; x < props.Length; x++)
                {
                    values[x] = props[x].GetValue(item, null);
                }
                dt.Rows.Add(values);
            }

            ReportDataSource rds = new ReportDataSource(dataSetName, dt);
            return rds;
        }
    }
}
