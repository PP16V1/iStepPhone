using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace iStepPhone.Menu.Tools
{
    public static class Serializator
    {
        public static void SerializSettings(string[] saveSettings)
        {
            var xDoc = XDocument.Load(@"C:\iStepPhone\code\iStepPhone\Menu\cmn\UserSettings.xml");
            XElement root = xDoc.Element("userSettings");

            root.ReplaceAll(
                new XElement("settings",
                    new XElement("foreground", saveSettings[0]),
                    new XElement("background", saveSettings[1]),
                    new XElement("selectedRow", saveSettings[2])
                 )
            );
            xDoc.Save(@"C:\iStepPhone\code\iStepPhone\Menu\cmn\UserSettings.xml");
        }
    }
}
