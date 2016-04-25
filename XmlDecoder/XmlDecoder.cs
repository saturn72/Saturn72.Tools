using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace Saturn72.XmlTextDecoder
{
    public class XmlDecoder
    {
        private static IEnumerable<Reference> _defaultReferences;

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

            var references = GetAllReferences(referencesFile);
            foreach (var r in references)
            {
                result = ReplaceXmlReference(result, r);
            }

            return result;
        }

        public static IEnumerable<Reference> DefaultReferences { get { return _defaultReferences ?? (_defaultReferences = LoadDefaultReferences()); } }

        private static string ReplaceXmlReference(string source, Reference reference)
        {
            var targetArray = new[] { reference.DecimalCode, reference.Name, reference.UtfCode };

            foreach (var t in targetArray)
            {
                if (!string.IsNullOrEmpty(t) && !string.IsNullOrWhiteSpace(t))
                    source = source.Replace(t, reference.HtmlCharacter);
            }
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

            foreach (var sr in specialReferences)
                source = ReplaceXmlReference(source, sr);
            return source;
        }

        private static IEnumerable<Reference> GetAllReferences(string referencesFile)
        {
            return File.Exists(referencesFile) ?
                LoadReferencesFromFile(referencesFile) :
                DefaultReferences;
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

        private static IEnumerable<Reference> LoadDefaultReferences()
        {
            return new[]
            {
new Reference("![CDATA[","","",""),
new Reference("]]","","",""),
new Reference("&quot;","\"","U+0022","&#34;"),
new Reference("&amp;","&","U + 0026","&#38;"),
new Reference("&apos;","'","U+0027","&#39;"),
new Reference("&lt;","<","U + 003C","&#60;"),
new Reference("&gt;",">","U + 003E","&#62;"),
new Reference("&nbsp;","","U + 00A0","&#160;"),
new Reference("&iexcl;","¡","U + 00A1","&#161;"),
new Reference("&cent;","¢","U + 00A2","&#162;"),
new Reference("&pound;","£","U + 00A3","&#163;"),
new Reference("&curren;","¤","U + 00A4","&#164;"),
new Reference("&yen;","¥","U + 00A5","&#165;"),
new Reference("&brvbar;","¦","U + 00A6","&#166;"),
new Reference("&sect;","§","U + 00A7","&#167;"),
new Reference("&uml;","¨","U + 00A8","&#168;"),
new Reference("&copy;","©","U + 00A9","&#169;"),
new Reference("&ordf;","ª","U + 00AA","&#170;"),
new Reference("&laquo;","«","U + 00AB","&#171;"),
new Reference("&not;","¬","U + 00AC","&#172;"),
new Reference("&shy;","","U + 00AD","&#173;"),
new Reference("&reg;","®","U + 00AE","&#174;"),
new Reference("&macr;","¯","U + 00AF","&#175;"),
new Reference("&deg;","°","U + 00B0","&#176;"),
new Reference("&plusmn;","±","U + 00B1","&#177;"),
new Reference("&sup2;","²","U + 00B2","&#178;"),
new Reference("&sup3;","³","U + 00B3","&#179;"),
new Reference("&acute;","´","U + 00B4","&#180;"),
new Reference("&micro;","µ","U + 00B5","&#181;"),
new Reference("&para;","¶","U + 00B6","&#182;"),
new Reference("&middot;","·","U + 00B7","&#183;"),
new Reference("&cedil;","¸","U + 00B8","&#184;"),
new Reference("&sup1;","¹","U + 00B9","&#185;"),
new Reference("&ordm;","º","U + 00BA","&#186;"),
new Reference("&raquo;","»","U + 00BB","&#187;"),
new Reference("&frac14;","¼","U + 00BC","&#188;"),
new Reference("&frac12;","½","U + 00BD","&#189;"),
new Reference("&frac34;","¾","U + 00BE","&#190;"),
new Reference("&iquest;","¿","U + 00BF","&#191;"),
new Reference("&Agrave;","À","U + 00C0","&#192;"),
new Reference("&Aacute;","Á","U + 00C1","&#193;"),
new Reference("&Acirc;","Â","U + 00C2","&#194;"),
new Reference("&Atilde;","Ã","U + 00C3","&#195;"),
new Reference("&Auml;","Ä","U + 00C4","&#196;"),
new Reference("&Aring;","Å","U + 00C5","&#197;"),
new Reference("&AElig;","Æ","U + 00C6","&#198;"),
new Reference("&Ccedil;","Ç","U + 00C7","&#199;"),
new Reference("&Egrave;","È","U + 00C8","&#200;"),
new Reference("&Eacute;","É","U + 00C9","&#201;"),
new Reference("&Ecirc;","Ê","U + 00CA","&#202;"),
new Reference("&Euml;","Ë","U + 00CB","&#203;"),
new Reference("&Igrave;","Ì","U + 00CC","&#204;"),
new Reference("&Iacute;","Í","U + 00CD","&#205;"),
new Reference("&Icirc;","Î","U + 00CE","&#206;"),
new Reference("&Iuml;","Ï","U + 00CF","&#207;"),
new Reference("&ETH;","Ð","U + 00D0","&#208;"),
new Reference("&Ntilde;","Ñ","U + 00D1","&#209;"),
new Reference("&Ograve;","Ò","U + 00D2","&#210;"),
new Reference("&Oacute;","Ó","U + 00D3","&#211;"),
new Reference("&Ocirc;","Ô","U + 00D4","&#212;"),
new Reference("&Otilde;","Õ","U + 00D5","&#213;"),
new Reference("&Ouml;","Ö","U + 00D6","&#214;"),
new Reference("&times;","×","U + 00D7","&#215;"),
new Reference("&Oslash;","Ø","U + 00D8","&#216;"),
new Reference("&Ugrave;","Ù","U + 00D9","&#217;"),
new Reference("&Uacute;","Ú","U + 00DA","&#218;"),
new Reference("&Uuml;","Ü","U + 00DC","&#220;"),
new Reference("&THORN;","Þ","U + 00DE","&#222;"),
new Reference("&szlig;","ß","U + 00DF","&#223;"),
new Reference("&agrave;","à","U + 00E0","&#224;"),
new Reference("&aacute;","á","U + 00E1","&#225;"),
new Reference("&acirc;","â","U + 00E2","&#226;"),
new Reference("&atilde;","ã","U + 00E3","&#227;"),
new Reference("&auml;","ä","U + 00E4","&#228;"),
new Reference("&aring;","å","U + 00E5","&#229;"),
new Reference("&aelig;","æ","U + 00E6","&#230;"),
new Reference("&ccedil;","ç","U + 00E7","&#231;"),
new Reference("&egrave;","è","U + 00E8","&#232;"),
new Reference("&eacute;","é","U + 00E9","&#233;"),
new Reference("&ecirc;","ê","U + 00EA","&#234;"),
new Reference("&euml;","ë","U + 00EB","&#235;"),
new Reference("&igrave;","ì","U + 00EC","&#236;"),
new Reference("&iacute;","í","U + 00ED","&#237;"),
new Reference("&icirc;","î","U + 00EE","&#238;"),
new Reference("&iuml;","ï","U + 00EF","&#239;"),
new Reference("&eth;","ð","U + 00F0","&#240;"),
new Reference("&ntilde;","ñ","U + 00F1","&#241;"),
new Reference("&ograve;","ò","U + 00F2","&#242;"),
new Reference("&oacute;","ó","U + 00F3","&#243;"),
new Reference("&ocirc;","ô","U + 00F4","&#244;"),
new Reference("&otilde;","õ","U + 00F5","&#245;"),
new Reference("&ouml;","ö","U + 00F6","&#246;"),
new Reference("&divide;","÷","U + 00F7","&#247;"),
new Reference("&oslash;","ø","U + 00F8","&#248;"),
new Reference("&ugrave;","ù","U + 00F9","&#249;"),
new Reference("&uacute;","ú","U + 00FA","&#250;"),
new Reference("&ucirc;","û","U + 00FB","&#251;"),
new Reference("&uuml;","ü","U + 00FC","&#252;"),
new Reference("&yacute;","ý","U + 00FD","&#253;"),
new Reference("&thorn;","þ","U + 00FE","&#254;"),
new Reference("&yuml;","ÿ","U + 00FF","&#255;"),
new Reference("&OElig;","Œ","U + 0152","&#338;"),
new Reference("&oelig;","œ","U + 0153","&#339;"),
new Reference("&Scaron;","Š","U + 0160","&#352;"),
new Reference("&scaron;","š","U + 0161","&#353;"),
new Reference("&Yuml;","Ÿ","U + 0178","&#376;"),
new Reference("&fnof;","ƒ","U + 0192","&#402;"),
new Reference("&circ;","ˆ","U + 02C6","&#710;"),
new Reference("&tilde;","˜","U + 02DC","&#732;"),
new Reference("&Alpha;","Α","U + 0391","&#913;"),
new Reference("&Beta;","Β","U + 0392","&#914;"),
new Reference("&Gamma;","Γ","U + 0393","&#915;"),
new Reference("&Delta;","Δ","U + 0394","&#916;"),
new Reference("&Epsilon;","Ε","U + 0395","&#917;"),
new Reference("&Zeta;","Ζ","U + 0396","&#918;"),
new Reference("&Eta;","Η","U + 0397","&#919;"),
new Reference("&Theta;","Θ","U + 0398","&#920;"),
new Reference("&Iota;","Ι","U + 0399","&#921;"),
new Reference("&Kappa;","Κ","U + 039A","&#922;"),
new Reference("&Lambda;","Λ","U + 039B","&#923;"),
new Reference("&Mu;","Μ","U + 039C","&#924;"),
new Reference("&Nu;","Ν","U + 039D","&#925;"),
new Reference("&Xi;","Ξ","U + 039E","&#926;"),
new Reference("&Omicron;","Ο","U + 039F","&#927;"),
new Reference("&Pi;","Π","U + 03A0","&#928;"),
new Reference("&Rho;","Ρ","U + 03A1","&#929;"),
new Reference("&Sigma;","Σ","U + 03A3","&#931;"),
new Reference("&Tau;","Τ","U + 03A4","&#932;"),
new Reference("&Upsilon;","Υ","U + 03A5","&#933;"),
new Reference("&Phi;","Φ","U + 03A6","&#934;"),
new Reference("&Chi;","Χ","U + 03A7","&#935;"),
new Reference("&Psi;","Ψ","U + 03A8","&#936;"),
new Reference("&Omega;","Ω","U + 03A9","&#937;"),
new Reference("&alpha;","α","U + 03B1","&#945;"),
new Reference("&beta;","β","U + 03B2","&#946;"),
new Reference("&gamma;","γ","U + 03B3","&#947;"),
new Reference("&delta;","δ","U + 03B4","&#948;"),
new Reference("&epsilon;","ε","U + 03B5","&#949;"),
new Reference("&zeta;","ζ","U + 03B6","&#950;"),
new Reference("&eta;","η","U + 03B7","&#951;"),
new Reference("&theta;","θ","U + 03B8","&#952;"),
new Reference("&iota;","ι","U + 03B9","&#953;"),
new Reference("&kappa;","κ","U + 03BA","&#954;"),
new Reference("&lambda;","λ","U + 03BB","&#955;"),
new Reference("&mu;","μ","U + 03BC","&#956;"),
new Reference("&nu;","ν","U + 03BD","&#957;"),
new Reference("&xi;","ξ","U + 03BE","&#958;"),
new Reference("&omicron;","ο","U + 03BF","&#959;"),
new Reference("&pi;","π","U + 03C0","&#960;"),
new Reference("&rho;","ρ","U + 03C1","&#961;"),
new Reference("&sigmaf;","ς","U + 03C2","&#962;"),
new Reference("&sigma;","σ","U + 03C3","&#963;"),
new Reference("&tau;","τ","U + 03C4","&#964;"),
new Reference("&upsilon;","υ","U + 03C5","&#965;"),
new Reference("&phi;","φ","U + 03C6","&#966;"),
new Reference("&chi;","χ","U + 03C7","&#967;"),
new Reference("&psi;","ψ","U + 03C8","&#968;"),
new Reference("&omega;","ω","U + 03C9","&#969;"),
new Reference("&thetasym;","ϑ","U + 03D1","&#977;"),
new Reference("&upsih;","ϒ","U + 03D2","&#978;"),
new Reference("&piv;","ϖ","U + 03D6","&#982;"),
new Reference("&ensp;","","U + 2002","&#8194;"),
new Reference("&emsp;","","U + 2003","&#8195;"),
new Reference("&thinsp;","","U + 2009","&#8201;"),
new Reference("&zwnj;","","U + 200C","&#8204;"),
new Reference("&zwj;","","U + 200D","&#8205;"),
new Reference("&lrm;","","U + 200E","&#8206;"),
new Reference("&rlm;","","U + 200F","&#8207;"),
new Reference("&ndash;","–","U + 2013","&#8211;"),
new Reference("&mdash;","—","U + 2014","&#8212;"),
new Reference("&lsquo;","‘","U + 2018","&#8216;"),
new Reference("&rsquo;","’","U + 2019","&#8217;"),
new Reference("&sbquo;","‚","U + 201A","&#8218;"),
new Reference("&ldquo;","“","U + 201C","&#8220;"),
new Reference("&rdquo;","”","U + 201D","&#8221;"),
new Reference("&bdquo;","„","U + 201E","&#8222;"),
new Reference("&dagger;","†","U + 2020","&#8224;"),
new Reference("&Dagger;","‡","U + 2021","&#8225;"),
new Reference("&bull;","•","U + 2022","&#8226;"),
new Reference("&hellip;","…","U + 2026","&#8230;"),
new Reference("&permil;","‰","U + 2030","&#8240;"),
new Reference("&prime;","′","U + 2032","&#8242;"),
new Reference("&Prime;","″","U + 2033","&#8243;"),
new Reference("&lsaquo;","‹","U + 2039","&#8249;"),
new Reference("&rsaquo;","›","U + 203A","&#8250;"),
new Reference("&oline;","‾","U + 203E","&#8254;"),
new Reference("&frasl;","⁄","U + 2044","&#8260;"),
new Reference("&euro;","€","U + 20AC","&#8364;"),
new Reference("&image;","ℑ","U + 2111","&#8465;"),
new Reference("&weierp;","℘","U + 2118","&#8472;"),
new Reference("&real;","ℜ","U + 211C","&#8476;"),
new Reference("&trade;","™","U + 2122","&#8482;"),
new Reference("&alefsym;","ℵ","U + 2135","&#8501;"),
new Reference("&larr;","←","U + 2190","&#8592;"),
new Reference("&uarr;","↑","U + 2191","&#8593;"),
new Reference("&rarr;","→","U + 2192","&#8594;"),
new Reference("&darr;","↓","U + 2193","&#8595;"),
new Reference("&harr;","↔","U + 2194","&#8596;"),
new Reference("&crarr;","↵","U + 21B5","&#8629;"),
new Reference("&lArr;","⇐","U + 21D0","&#8656;"),
new Reference("&uArr;","⇑","U + 21D1","&#8657;"),
new Reference("&rArr;","⇒","U + 21D2","&#8658;"),
new Reference("&dArr;","⇓","U + 21D3","&#8659;"),
new Reference("&hArr;","⇔","U + 21D4","&#8660;"),
new Reference("&forall;","∀","U + 2200","&#8704;"),
new Reference("&part;","∂","U + 2202","&#8706;"),
new Reference("&exist;","∃","U + 2203","&#8707;"),
new Reference("&empty;","∅","U + 2205","&#8709;"),
new Reference("&nabla;","∇","U + 2207","&#8711;"),
new Reference("&isin;","∈","U + 2208","&#8712;"),
new Reference("&notin;","∉","U + 2209","&#8713;"),
new Reference("&ni;","∋","U + 220B","&#8715;"),
new Reference("&prod;","∏","U + 220F","&#8719;"),
new Reference("&sum;","∑","U + 2211","&#8721;"),
new Reference("&minus;","−","U + 2212","&#8722;"),
new Reference("&lowast;","∗","U + 2217","&#8727;"),
new Reference("&radic;","√","U + 221A","&#8730;"),
new Reference("&prop;","∝","U + 221D","&#8733;"),
new Reference("&infin;","∞","U + 221E","&#8734;"),
new Reference("&ang;","∠","U + 2220","&#8736;"),
new Reference("&and;","∧","U + 2227","&#8743;"),
new Reference("&or;","∨","U + 2228","&#8744;"),
new Reference("&cap;","∩","U + 2229","&#8745;"),
new Reference("&cup;","∪","U + 222A","&#8746;"),
new Reference("&int;","∫","U + 222B","&#8747;"),
new Reference("&there4;","∴","U + 2234","&#8756;"),
new Reference("&sim;","∼","U + 223C","&#8764;"),
new Reference("&cong;","≅","U + 2245","&#8773;"),
new Reference("&asymp;","≈","U + 2248","&#8776;"),
new Reference("&ne;","≠","U + 2260","&#8800;"),
new Reference("&equiv;","≡","U + 2261","&#8801;"),
new Reference("&le;","≤","U + 2264","&#8804;"),
new Reference("&ge;","≥","U + 2265","&#8805;"),
new Reference("&sub;","⊂","U + 2282","&#8834;"),
new Reference("&sup;","⊃","U + 2283","&#8835;"),
new Reference("&nsub;","⊄","U + 2284","&#8836;"),
new Reference("&sube;","⊆","U + 2286","&#8838;"),
new Reference("&supe;","⊇","U + 2287","&#8839;"),
new Reference("&oplus;","⊕","U + 2295","&#8853;"),
new Reference("&otimes;","⊗","U + 2297","&#8855;"),
new Reference("&perp;","⊥","U + 22A5","&#8869;"),
new Reference("&sdot;","⋅","U + 22C5","&#8901;"),
new Reference("&lceil;","⌈","U + 2308","&#8968;"),
new Reference("&rceil;","⌉","U + 2309","&#8969;"),
new Reference("&lfloor;","⌊","U + 230A","&#8970;"),
new Reference("&rfloor;","⌋","U + 230B","&#8971;"),
new Reference("&lang;","〈","U + 2329","&#9001;"),
new Reference("&rang;","〉","U + 232A","&#9002;"),
new Reference("&loz;","◊","U + 25CA","&#9674;"),
new Reference("&spades;","♠","U + 2660","&#9824;"),
new Reference("&clubs;","♣","U + 2663","&#9827;"),
new Reference("&hearts;","♥","U + 2665","&#9829;"),
new Reference("&diams;","♦","U + 2666","&#9830;"),
            };
        }
    }
}
