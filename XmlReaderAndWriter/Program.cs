using System;
using System.Xml;
using System.Collections.Generic;
using System.Threading;

namespace XmlReaderAndWriter
{
	public class Read
    {
		int tab = 0;
        public void ReadXMLFile(string path)
        {
            XmlDocument xmldoc = new();
            xmldoc.Load(path);
			XMLNodes( xmldoc.ChildNodes );
        }
		private void XMLNodes( XmlNodeList nodes )
        {
			tab++;

            foreach( XmlNode node in nodes )
            {
				if(node.Name[0] != '#')
                Console.WriteLine( tabs() + node.Name + ":"  + (isMainTag(node)? null : node.InnerText));
                XMLNodes( node.ChildNodes );
				tab--;
            }
        }
		private bool isMainTag(XmlNode node){
			return node.Name == "member" || node.Name == "team";
		}
		private string tabs(){
			return new String('\t', tab);
		}
    }

	class Write{
		public void CreateXMLFile(XmlDocument xmldoc, XmlElement root, List<TeamMember> members)
        {

            foreach (var member in members)
            {

                XmlElement header = xmldoc.CreateElement("member");
                root.AppendChild(header);

                XmlElement id = xmldoc.CreateElement("id");
                XmlText idText = xmldoc.CreateTextNode(member.Id);
                header.AppendChild(id).AppendChild(idText);

                XmlElement name = xmldoc.CreateElement("name");
                XmlText nameText = xmldoc.CreateTextNode(member.Name);
                header.AppendChild(name).AppendChild(nameText);

                XmlElement major = xmldoc.CreateElement("major");
                XmlText majorText = xmldoc.CreateTextNode(member.Major);
                header.AppendChild(major).AppendChild(majorText);

                XmlElement email = xmldoc.CreateElement("email");
                XmlText emailText = xmldoc.CreateTextNode(member.Email);
                header.AppendChild(email).AppendChild(emailText);

            }
            
        }
	}

    class TeamMember
    {

        public string Id;
        public string Name;
        public string Major;
        public string Email;

        public TeamMember(string id, string name, string major, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Major = major;
            this.Email = email;
        }

    }

	class Program
	{
		static void Main(string[] args)
		{
            List<TeamMember> teamMembersInfo = new List<TeamMember>() {
            new TeamMember("1001","Afra Allahyani", "BS.CS","afra.allahyani@tuwaiq.edu.sa"),
            new TeamMember("1002","Faisal Alsagri","BS.SWE", "faisal.alsagri@tuwaiq.edu.sa"),
            new TeamMember("1003","Arwa Wan La", "MS.IT", "arwa.wan.la@tuwaiq.edu.sa"),
            new TeamMember("1004", "Turki Alqurashi", "BS.CS", "turki.alqurashi@tuwaiq.edu.sa"),
            new TeamMember("1005", "Abdulrahman Aljafar", "BS.CS", "abdulrahman.aljafar@tuwaiq.edu.sa")

            };

            XmlDocument xmldoc = new XmlDocument();
            XmlElement root = xmldoc.CreateElement("team");
            xmldoc.AppendChild(root);

            Write writeXML = new();

            Thread writeThread = new Thread(() => writeXML.CreateXMLFile(xmldoc, root, teamMembersInfo));

            writeThread.Start();
            writeThread.Join();

            xmldoc.Save(@"Team.xml");

            Read readXML = new();

            Thread readThread = new Thread(() => readXML.ReadXMLFile(@"Team.xml"));

            readThread.Start();
        }
	}
}
