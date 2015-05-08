using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XsltTransformer
{
    class Program
    {
        public static void Main(string[] args)
        {
            args = new string[2];
            args[0] = @"C:\temp\ToDELETE\single_item.xml";
            args[1] = @"C:\Dev\Saturn72.Tools\XsltTransformer\bin\Debug\xsl.xsl";
                    
            if (args.Length == 2)
            {

                Transform(args[0], args[1]);


            }
            else
            {

                PrintUsage();

            }


        }

        public static void Transform(string sXmlPath, string sXslPath)
        {

            try
            {

                //load the Xml doc
                XPathDocument myXPathDoc = new XPathDocument(sXmlPath);

                XslTransform myXslTrans = new XslTransform();

                //load the Xsl 
                myXslTrans.Load(sXslPath);

                //create the output stream
                XmlTextWriter myWriter = new XmlTextWriter
                    ("result.xml", null);

                //do the actual transform of Xml
                myXslTrans.Transform(myXPathDoc, null, myWriter);

                myWriter.Close();


            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: {0}", e.ToString());
            }

        }


        public static void PrintUsage()
        {

            Console.WriteLine("Usage: XmlTransformUtil.exe <xml path> <xsl path>");
        }
    }
}