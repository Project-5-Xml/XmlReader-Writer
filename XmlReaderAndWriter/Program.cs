using System;
using System.Xml;

namespace XmlReaderAndWriter
{
	class Program
	{
        static void CreateXMLFileContainsTeamMembersInfo()
        {
            XmlDocument xmldoc = new XmlDocument();

            XmlElement root = xmldoc.CreateElement("team");
            xmldoc.AppendChild(root);

            XmlElement element1 = xmldoc.CreateElement("member");
            root.AppendChild(element1);

            XmlElement element2 = xmldoc.CreateElement("id");
            XmlText text2 = xmldoc.CreateTextNode("");
            element1.AppendChild(element2).AppendChild(text2);
          

            XmlElement element3 = xmldoc.CreateElement("name");
            XmlText text3 = xmldoc.CreateTextNode("");
            element1.AppendChild(element3).AppendChild(text3);


            XmlElement element4 = xmldoc.CreateElement("major");
            XmlText text4 = xmldoc.CreateTextNode("");
            element1.AppendChild(element4).AppendChild(text4);

            XmlElement element5 = xmldoc.CreateElement("email");
            XmlText text5 = xmldoc.CreateTextNode("");
            element1.AppendChild(element5).AppendChild(text5);
            
            
            xmldoc.Save(@"/XmlReaderAndWriter/Project5.xml");
            Console.WriteLine(xmldoc.InnerXml);
        }
        static void Main(string[] args)
		{

            CreateXMLFileContainsTeamMembersInfo();
            
        }
	}
}
