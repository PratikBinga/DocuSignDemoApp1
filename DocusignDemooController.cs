using DocuSign.eSign.Api;
using DocuSign.eSign.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace DocuSignDemo.Controllers
{
    public class DocusignDemooController : ApiController
    {
        public void Post(HttpRequestMessage request)
        {
            string directorypath = HttpContext.Current.Server.MapPath("~/App_Data/" + "Files/");
            if (!Directory.Exists(directorypath))
            {
                Directory.CreateDirectory(directorypath);
            }
            StringBuilder sb = new StringBuilder();

            sb.Append("log something");


            // flush every 20 seconds as you do it
            File.AppendAllText(directorypath + "log.txt", sb.ToString());
          



            // to check the xml data pushed by docusign to our listener.
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(request.Content.ReadAsStreamAsync().Result);
            sb.Append(xmldoc.InnerXml);
            File.AppendAllText(directorypath + "XMLlog.txt", sb.ToString());
            sb.Clear();

            //    var mgr = new XmlNamespaceManager(xmldoc.NameTable);
            //    mgr.AddNamespace("a", "http://www.docusign.net/API/3.0");

            //    XmlNode envelopeStatus = xmldoc.SelectSingleNode("//a:EnvelopeStatus", mgr);
            //    XmlNode envelopeId = envelopeStatus.SelectSingleNode("//a:EnvelopeID", mgr);
            //    XmlNode status = envelopeStatus.SelectSingleNode("./a:Status", mgr);
            //    string envId = envelopeId.ToString();
            //    if (envelopeId != null)
            //    {
            //        //System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/Documents/" +
            //        //    envelopeId.InnerText + "_" + status.InnerText + "_" + Guid.NewGuid() + ".xml"), xmldoc.OuterXml);
            //    }

            //    // Loop through the DocumentPDFs element, storing each signed document.

            //    XmlNode docs = xmldoc.SelectSingleNode("//a:DocumentPDFs", mgr);
            //    foreach (XmlNode doc in docs.ChildNodes)
            //    {
            //        string documentName = doc.ChildNodes[0].InnerText; // pdf.SelectSingleNode("//a:Name", mgr).InnerText;
            //        string documentId = doc.ChildNodes[2].InnerText; // pdf.SelectSingleNode("//a:DocumentID", mgr).InnerText;
            //        string byteStr = doc.ChildNodes[1].InnerText; // pdf.SelectSingleNode("//a:PDFBytes", mgr).InnerText;

            //        System.IO.File.WriteAllText(HttpContext.Current.Server.MapPath("~/Documents/" + envelopeId.InnerText + "_" + documentId + "_" + documentName), byteStr);
            //    }

            //    if (status.InnerText == "Completed")
            //    {
            //        // purge the envelope if status is completed.
            //        EnvelopesApi obj = new EnvelopesApi();
            //        DocuSign.eSign.Model.Envelope item = new DocuSign.eSign.Model.Envelope();
            //        item.PurgeState = "documents_and_metadata_queued";
            //        item.EnvelopeId = envId;
            //        EnvelopeUpdateSummary envelopeUpdateSummary = obj.Update("7360016", item.EnvelopeId, null, null);


            //    }
        }
        }
    }

