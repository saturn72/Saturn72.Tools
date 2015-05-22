using Saturn72.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Saturn72.XmlTextDecoder
{
    public class XmlDecoderWorker
    {
        public static void RemoveHexCharacters(string source, string destination, bool overwrite = true)
        {
            if (!File.Exists(source) || (!overwrite && File.Exists(destination)))
                return;

            var hexCharactersRegEx = new Regex("[^\u0009\u000a\u000d\u0020-\ud7ff\ue000-\ufffd]|([\ud800-\udbff](?![\udc00-\udfff]))|((?<![\ud800-\udbff])[\udc00-\udfff])");

            using (var streamReader = new StreamReader(source))
            using (var streamWriter = new StreamWriter(destination))
            {
                var currentLine = streamReader.ReadLine();
                while (currentLine != null)
                {
                    streamWriter.WriteLine(hexCharactersRegEx.Replace(currentLine, string.Empty));
                    currentLine = streamReader.ReadLine();
                }
            }

        }
        public static string ReplaceAllXmlReferences(string source)
        {
            var filePath = ConfigurationManager.AppSettings["XmlReferenceDictionary"]
                ?? Path.Combine(Directory.GetCurrentDirectory(), "dictionary.csv");

            return ReplaceAllXmlReferences(source, filePath);
        }

        public static string ReplaceAllXmlReferences(string source, string referencesFile)
        {
            var result = source;

            LoadReferencesFromFile(referencesFile)
               .ForEachItem(reference => result = ReplaceXmlReference(result, reference));

            return result;
        }

        private static string ReplaceXmlReference(string source, Reference reference)
        {
            new[] { reference.DecimalCode, reference.Name, reference.UtfCode }
                .ForEachItem(x =>
            {
                if (x.HasValue())
                    source = source.Replace(x, reference.HtmlCharacter);
            });

            return source;
        }

        private static string ReplaceSpecialReferences(string source)
        {
            var specialReferences = new Reference[]{
               new Reference {Name="&quot;" ,HtmlCharacter=@"""" ,DecimalCode="&#34;" },
            new Reference {Name="&amp;"  ,HtmlCharacter="amp",DecimalCode="&#38;" },
                new Reference {Name="&lt;"  ,HtmlCharacter="<",DecimalCode="&#60;" },
                new Reference {Name="![CDATA["  ,HtmlCharacter="",DecimalCode="" },
                new Reference {Name="]]"  ,HtmlCharacter="",DecimalCode="" },
            };

            specialReferences.ForEachItem(
                sr => source = ReplaceXmlReference(source, sr));
            return source;
        }

        private static IEnumerable<Reference> LoadReferencesFromFile(string filePath)
        {
            var result = new List<Reference>();

            using (var streamReader = new StreamReader(filePath))
            {

                string line = string.Empty;
                streamReader.ReadLine();
                while ((line = streamReader.ReadLine()) != null)
                {
                    var lineAsArray = line.Split(',');
                    result.Add(new Reference
                    {
                        Name = lineAsArray[0].Trim(),
                        HtmlCharacter = lineAsArray[1].Trim(),
                        UtfCode = lineAsArray[2].Trim(),
                        DecimalCode = lineAsArray[3].Trim(),
                    });
                }
                streamReader.Dispose();
            }
            return result;
        }
    }
}
