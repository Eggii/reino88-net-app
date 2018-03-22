using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Web.UI;
using System.Web.Script.Services;
using System.Globalization;

namespace ADM
{
    /// <summary>
    /// Output class for product details
    /// </summary>
    public partial class DetailView : System.Web.UI.Page
    {
        public static XDocument xdocList;
        public static XDocument xdocDetail;

        /// <summary>
        /// Load product list details from Corrected_Detail.xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repeater1.DataSource = GetDetails();
                Repeater1.DataBind();

                //if DetailView.aspx have no querystring, then broken Detail view
                if (Request.QueryString["id"] == null)
                {
                    Response.Redirect("ListView.aspx");
                }
            }
        }

        /// <summary>
        /// Get data from Corrected_List.xml and Corrected_Detail.xml 
        /// </summary>
        /// <returns></returns>
        public List<DetailList> GetDetails()
        {
            xdocList = XDocument.Load(ListView.appDomain + ListView.xmlsFolder + ListView.CorrectedListXmlFileName);
            xdocDetail = XDocument.Load(ListView.appDomain + ListView.xmlsFolder + ListView.CorrectedDetailXmlFileName);

            List<DetailList> detailLists = (from detail in xdocDetail.Descendants("Product")
                                            join product in xdocList.Descendants("Product")
                                            on (string)detail.Attribute("id") equals (string)product.Attribute("id") into specsList
                                            from specs in specsList
                                            where (string)detail.Attribute("id") == Request["id"]

                                            select new DetailList
                                            {
                                                Detail1 = (string)detail.Attribute("id") ?? "No id",
                                                Detail2 = (string)detail.Element("Title") ?? "No Title",
                                                Detail3 = (string)detail.Element("Description") ?? "No description",
                                                Detail4 = (string)detail.Element("Image") ?? "no-image-available.jpg",
                                                Detail5 = (string)detail.Element("Availability"),

                                                Detail6 = (string)specs.Element("Price") != null ? Convert.ToDecimal((string)specs.Element("Price"),
                                                CultureInfo.InvariantCulture.NumberFormat).ToString("n2") : "0",

                                                Detail7 = (string)detail.Element("Specs") != null ?
                                                detail.Element("Specs").Elements("Spec").Select(x => (string)x).ToList() : new List<string>(),

                                            }).ToList();
            return detailLists;
        }

        /// <summary>
        /// Get Availability from Corrected_Detail.xml and convert to JSON
        /// </summary>
        /// <returns></returns>
        [System.Web.Services.WebMethod]
        [ScriptMethod(UseHttpGet = true)]
        public static string GetAvailability()
        {
            xdocDetail = XDocument.Load(ListView.appDomain + ListView.xmlsFolder + ListView.CorrectedDetailXmlFileName);

            List<DetailList> availabilityList = (from detail in xdocDetail.Descendants("Product")
                                                 select new DetailList
                                                 {
                                                     Detail6 = (string)detail.Element("Availability") ?? "Unknown",
                                                 }).ToList();

            return JsonConvert.SerializeObject(availabilityList.Select(x => x.Detail6));
        }
    }
}
