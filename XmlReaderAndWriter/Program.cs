using System;
using System.Xml;

namespace XmlReaderAndWriter
{
	public class Read
    {
		int tab = 0;
        public void ReadXMLFile(string path)
        {
            XmlDocument xmldoc = new();
            xmldoc.Load(@path);
			XMLNodes( xmldoc.ChildNodes );
        }
		private void XMLNodes( XmlNodeList nodes )
        {
			tab++;

            foreach( XmlNode node in nodes )
            {
				if(node.Name[0] != '#')
                Console.WriteLine( tabs() + node.Name + ":"  + (isHeader(node)? null : node.InnerText));
                XMLNodes( node.ChildNodes );
				tab--;
            }
        }
		private bool isHeader(XmlNode node){
			return node.Name == "member" || node.Name == "team";
		}
		private string tabs(){
			return new String('\t', tab);
		}
    }

	class Write{
		public  void CreateXMLFileContainsTeamMembersInfo()
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
            
            
            xmldoc.Save(@"D:/DotNet/XmlReaderAndWriter/Project5.xml");
            // Console.WriteLine(xmldoc.InnerXml);
        }
	}
	class Program
	{
		static void Main(string[] args)
		{
			Write writeXML = new();
            writeXML.CreateXMLFileContainsTeamMembersInfo();

			Read readXML = new();
			readXML.ReadXMLFile("../Project5.xml");
		}
	}
}
