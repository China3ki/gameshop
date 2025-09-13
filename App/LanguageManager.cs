using GameShop.Views.NormalViews;
using System.Diagnostics;
using System.Xml;

namespace GameShop.App
{
    static class LanguageManager
    {
        static public Language Language = Language.Polski;
        /// <summary>
        /// Retrieves a list of strings based on the specified view type and data type.
        /// </summary>
        /// <param name="viewType">The type of view that determines the XML path to query.</param>
        /// <param name="dataType">The type of data to retrieve, which influences the XML path.</param>
        /// <returns>A list of strings extracted from the XML file based on the specified parameters.</returns>
        /// <exception cref="Exception">Thrown if the XML file cannot be loaded.</exception>
        /// <exception cref="NotImplementedException">Thrown if the specified XML path does not return any nodes.</exception>
        static public List<string> GetData(ViewType viewType, DataType dataType)
        {
            string language = Language == Language.Polski ? "polski.xml" : "angielski.xml";
            string fileLocation = $"..\\..\\..\\Language\\{language}";
            XmlNodeList? nodeList;
            List<string> list;
            string path = GetPath(viewType, dataType);

            XmlDocument langDoc = new();
            try
            {
                langDoc.Load(fileLocation);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            nodeList = langDoc.SelectNodes(path);
            if (nodeList != null) list = nodeList.Cast<XmlNode>().Select(n => n.InnerText).ToList(); // Do naprawy
            else throw new NotImplementedException();
            Debug.WriteLine(list[1]);
            return list;
        }
        /// <summary>
        /// Generates a relative path string based on the specified view type and data type.
        /// </summary>
        /// <param name="viewType">The type of view for which the path is being generated. Must be a valid <see cref="ViewType"/>.</param>
        /// <param name="dataType">The type of data for which the path is being generated. Must be a valid <see cref="DataType"/>.</param>
        /// <returns>A relative path string corresponding to the specified <paramref name="viewType"/> and <paramref
        /// name="dataType"/>.</returns>
        /// <exception cref="NotImplementedException">Thrown if the combination of <paramref name="viewType"/> and <paramref name="dataType"/> is not supported.</exception>
        static private string GetPath(ViewType viewType, DataType dataType)
        {
            if (dataType == DataType.OptionList)
            {
                return viewType switch
                {
                    ViewType.Start => "gameshop/start/optionlist",
                    _ => throw new NotImplementedException()
                };
            }
            else if (dataType == DataType.InfoList)
            {
                return viewType switch
                {
                    ViewType.Start => "gameshop/start/infolist",
                    _ => throw new NotImplementedException()
                };
            }
            else throw new NotImplementedException();
        }
    }
}
