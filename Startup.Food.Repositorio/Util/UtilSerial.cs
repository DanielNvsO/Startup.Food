using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Globalization;
using System.Threading;

namespace Startup.Food.Repositorio.Util
{
    public class UtilSerial
    {
        public static string Serialize<T>(T dataToSerialize)
        {
            try
            {
                CultureInfo n = new CultureInfo("pt-br");
                Thread.CurrentThread.CurrentCulture = n;
                Thread.CurrentThread.CurrentUICulture = n;

                var serializer = new XmlSerializer(typeof(T));
                var stringwriter = new System.IO.StringWriter();

                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var xmlWriter = XmlWriter.Create(stringwriter, new XmlWriterSettings() { OmitXmlDeclaration = true });

                serializer.Serialize(xmlWriter, dataToSerialize, ns);

                return stringwriter.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static T Deserialize<T>(string xmlText)
        {
            try
            {
                CultureInfo n = new CultureInfo("pt-br");
                Thread.CurrentThread.CurrentCulture = n;
                Thread.CurrentThread.CurrentUICulture = n;

                var stringReader = new System.IO.StringReader(xmlText);
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stringReader);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
