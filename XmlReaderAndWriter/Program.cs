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
	class Program
	{
		static void Main(string[] args)
		{
			Read readXML = new();
			readXML.ReadXMLFile("../Sample.xml");
		}
	}
}
