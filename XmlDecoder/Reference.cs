namespace Saturn72.XmlTextDecoder
{
    public class Reference
    {
        public Reference()
        {
        }

        public Reference(string name, string htmlCharacter, string utfCode, string decimalCode)
        {
            Name = name;
            HtmlCharacter = htmlCharacter;
            UtfCode = utfCode;
            DecimalCode = DecimalCode;
        }

        public string Name { get; set; }

        public string DecimalCode { get; set; }

        public string UtfCode { get; set; }

        public string HtmlCharacter { get; set; }
    }
}
