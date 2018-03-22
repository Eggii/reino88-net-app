
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace ADM
{
    /// <summary>
    /// Main page, output for products
    /// </summary>
    public partial class ListView : System.Web.UI.Page
    {
        //Input XML file names
        private readonly string listXmlFileName = @"List.xml";
        private readonly string detailXmlFileName = "Detail.xml";

        //Corrected XML file names
        public static readonly string CorrectedListXmlFileName = "Corrected_List.xml";
        public static readonly string CorrectedDetailXmlFileName = "Corrected_Detail.xml";
        public static string xmlsFolder = "Content/Xmls/"; //Xmls folder
        public static readonly string appDomain = AppDomain.CurrentDomain.BaseDirectory;

        public const string NEWID = "PROD"; //Default value for new id if needed
        public XDocument _xDocument;

        protected void Page_Load(object sender, EventArgs e)
        {
            //For correcting xml files
            string attribute = "id";
            string descendant = "Product";

            //Load XMLs
            _xDocument = XDocument.Load(appDomain + xmlsFolder + listXmlFileName);

            //if dublicate ids, correct and save new XML
            _xDocument.CorrectElementAttribute(attribute, descendant, CorrectedListXmlFileName, NEWID);

            //Load Detail.xml
            _xDocument = XDocument.Load(appDomain + xmlsFolder + detailXmlFileName);

            //if dublicate ids, correct and save new XML
            _xDocument.CorrectElementAttribute(attribute, descendant, CorrectedDetailXmlFileName, NEWID);


            if (!Page.IsPostBack)
            {
                Repeater1.DataSource = GetProductListData();
                Repeater1.DataBind();
            }

            //Add client-side attribute to DDLSortProducts for sorting products in ListView.aspx
            DDLSortProducts.Attributes.Add("onchange", "return SortProducts();");
        }

        /// <summary>
        /// Get elements from Corrected_List.xml
        /// </summary>
        /// <returns></returns>
        private List<ProductList> GetProductListData()
        {
            _xDocument = XDocument.Load(listXmlFileName);

            ProductList productList = new ProductList();
            List<ProductList> productLists = (from product in _xDocument.Descendants("Product")
                                              select new ProductList
                                              {
                                                  ProductListParameter1 = (string)product.Element("Title") ?? "No Title",
                                                  ProductListParameter2 = (string)product.Element("Description") ?? "No Description",
                                                  ProductListParameter3 = (string)product.Element("Image") ?? "no-image-available.jpg",

                                                  ProductListParameter4 = (string)product.Element("Price") != null ? Convert.ToDecimal((string)product.Element("Price"),
                                                  CultureInfo.InvariantCulture.NumberFormat).ToString("n2") : "0",

                                                  ProductListParameter5 = (string)product.Element("Sorting") ?? "0",
                                                  ProductListParameter6 = (string)product.Attribute("id") ?? "0",
                                              }).ToList();
            return productLists;
        }

        protected void BtnMoreDetails_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("DetailView.aspx?id=" + e.CommandArgument.ToString());
        }
    }
}