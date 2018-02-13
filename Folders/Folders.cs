using System;
using System.Collections.Generic;
using System.Xml;

/**
 * Implement a function FolderNames, which accepts a string containing an XML file that specifies folder 
 * structure and returns all folder names that start with startingLetter. The XML format is given in the example below.
 **/

namespace Folders
{
    public class Folders
    {
        public static List<string> folderNames = new List<string>();

        public static IEnumerable<string> FolderNames(string xml, char startingLetter)
        {
            string name = string.Empty;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlElement root = xmlDoc.DocumentElement;
            if (root.Name.ToLower() == "folder" && root.Attributes[0].Value.ToLower().StartsWith("u"))
            {
                folderNames.Add(root.Attributes[0].Value);
            }

            XmlNodeList nodes = root.SelectNodes("folder");

            object[] array = new String[10];
            array[0] = 10;

            foreach (XmlNode node in nodes)
            {
                if(node.ChildNodes.Count > 0)
                {
                    FolderNames(node.InnerXml, startingLetter);
                }

                var temp = node.Attributes[0].Value;
                if (temp.ToLower().StartsWith("u"))
                {
                    folderNames.Add(temp);
                }
            }

            return folderNames;
        }

        public static void Main(string[] args)
        {
            string xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<folder name=\"c\">" +
                    "<folder name=\"program files\">" +
                        "<folder name=\"Uninstall information\">" +
                            "<folder name=\"ugly god\">" +
                                "<folder name=\"not so ugly god\" />" +
                            "</folder>" +
                        "</folder>" +
                    "</folder>" +
                    "<folder name=\"users\" />" +
                "</folder>";

            foreach (string name in Folders.FolderNames(xml, 'u'))
                Console.WriteLine(name);
        }
    }
}