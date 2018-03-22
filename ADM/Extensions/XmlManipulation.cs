
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ADM
{
    /// <summary>
    /// Represents xml manipulation extensions
    /// </summary>
    public static class XmlManipulation
    {
        public static int counter;
        public static bool isDuplicate;
        public static IEnumerable<XElement> query;
        public static string subfolders;

        /// <summary>
        /// Finds and replaces duplicate attributes. Creates new xml file to Xmls folder
        /// </summary>
        /// <param name="xDocument"></param>
        /// <param name="attribute"></param>
        /// <param name="descendants"></param>
        /// <param name="newPath"></param>
        /// <param name="newAttributeValue"></param>
        public static void CorrectElementAttribute(this XDocument xDocument, string attribute, string descendants,
            string newFileName, string newAttributeValue = "")
        {
            string subfolders = @"Content\Xmls\"; // XMLs main folder
            string newFilePath = AppDomain.CurrentDomain.BaseDirectory + subfolders + newFileName;

            query = from c in xDocument.Descendants(descendants)
                    select c;

            //if attribute doesn't exist, add new attribute with value "0"
            foreach (var xElement in query)
            {
                if (xElement.Attribute(attribute) == null)
                {
                    xElement.SetAttributeValue(attribute, "0");
                }
            }

            //bool for checking if dublicate attribute values
            isDuplicate = xDocument.Descendants(descendants).Attributes(attribute).
                 GroupBy(node => node.Value).Any(grp => grp.Count() > 1);

            counter = 0;

            //if dublicate attribute values, replace attribute values. Save new XML file
            if (isDuplicate)
            {
                foreach (XElement product in query)
                {
                    counter++;
                    if (counter < 10)
                    {
                        product.Attribute(attribute).Value = $"{newAttributeValue + "0" + counter}";
                    }
                    else
                    {
                        product.Attribute(attribute).Value = $"{newAttributeValue + counter}";
                    }
                }
                xDocument.Save(newFilePath);
            }
            else
            {
                xDocument.Save(newFilePath);
            }
        }
    }
}