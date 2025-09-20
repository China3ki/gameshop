using System.Xml;

namespace GameShop.App.Components
{
    static class LanguageManager
    {
        static public Language Language = Language.Polski;
        /// <summary>
        /// Retrieves a list of strings based on the specified view type and data type.
        /// </summary>
        /// <remarks>This method loads an XML file based on the current language setting and retrieves
        /// data from a specific path determined by the combination of <paramref name="viewType"/> and <paramref
        /// name="dataType"/>. Ensure that the XML file exists at the expected location and contains the required
        /// structure.</remarks>
        /// <param name="viewType">The type of view that determines the XML path to query.</param>
        /// <param name="dataType">The type of data to retrieve, which further refines the XML path.</param>
        /// <returns>A list of strings extracted from the XML file corresponding to the specified view type and data type.</returns>
        /// <exception cref="Exception">Thrown if the XML file cannot be loaded or if the specified XML path does not exist.</exception>
        static public List<string> GetData(ViewType viewType, DataType dataType)
        {
            string language = Language == Language.Polski ? "polski.xml" : "english.xml";
            string fileLocation = $"..\\..\\..\\Language\\{language}";
            XmlNodeList? nodeList;
            List<string> list = [];
            string path = GetPath(viewType, dataType);

            XmlDocument langDoc = new();
            try
            {
                langDoc.Load(fileLocation);
            }
            catch
            {
                throw new Exception("File does not exist!");
            }
            nodeList = langDoc.SelectSingleNode(path)?.ChildNodes;
            if (nodeList != null)
            {
                for(int i = 0; i < nodeList.Count; i++)
                {
                    list.Add(nodeList[i].InnerText);
                }
            }
            else throw new Exception("Node list is empty!");
            return list;
        }
        /// <summary>
        /// Generates a URL path based on the specified view type and data type.
        /// </summary>
        /// <param name="viewType">The type of view for which the path is being generated. Must be a valid <see cref="ViewType"/>.</param>
        /// <param name="dataType">The type of data associated with the view. Must be a valid <see cref="DataType"/>.</param>
        /// <returns>A string representing the URL path corresponding to the specified <paramref name="viewType"/> and <paramref
        /// name="dataType"/>.</returns>
        /// <exception cref="Exception">Thrown if the combination of <paramref name="viewType"/> and <paramref name="dataType"/> does not correspond
        /// to a valid URL path.</exception>
        static private string GetPath(ViewType viewType, DataType dataType)
        {
            if (dataType == DataType.OptionList)
            {
                return viewType switch
                {
                    ViewType.Start => "gameshop/start/optionlist",
                    ViewType.Language => "gameshop/language/optionlist",
                    ViewType.Login => "gameshop/login/optionlist",
                    ViewType.Register => "gameshop/register/optionlist",
                    _ => throw new Exception("Url is not correct!")
                };
            }
            else if (dataType == DataType.InfoList)
            {
                return viewType switch
                {
                    ViewType.Start => "gameshop/start/infolist",
                    ViewType.Language => "gameshop/language/infolist",
                    ViewType.Login => "gameshop/login/infolist",
                    ViewType.Register => "gameshop/register/infolist",
                    ViewType.Outro => "gameshop/outro/infolist",
                    ViewType.Error => "gameshop/error/infolist",
                    ViewType.Validation => "gameshop/validation/infolist",
                    _ => throw new Exception("Url is not correct!")
                };
            }
            else throw new Exception("Data type is not correct!");
        }
    }
}
