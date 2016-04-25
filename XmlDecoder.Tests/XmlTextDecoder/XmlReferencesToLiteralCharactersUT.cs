using NUnit.Framework;
using Saturn72.XmlTextDecoder;

namespace AutomationToolbox.Tests.XmlTextDecoder
{
    [TestFixture]
    public class XmlReferencesToLiteralCharactersUT
    {
        [Test]
        public void CanReplaceAllXmlReferences()
        {

            var expectedValue = "\n    \"\n    &\n    '\n    <\n    >\n    \n    ¡\n    ¢\n    £\n¤\n    ¥\n    ¦\n    §\n    ¨\n    ©\n    ª\n    «\n    ¬\n    \n    ®\n¯\n    °\n    ±\n    ²\n    ³\n    ´\n    µ\n    ¶\n    ·\n    ¸\n¹\n    º\n    »\n    ¼\n    ½\n    ¾\n    ¿\n    À\n    Á\n    Â\nÃ\n    Ä\n    Å\n    Æ\n    Ç\n    È\n    É\n    Ê\n    Ë\n    Ì\nÍ\n    Î\n    Ï\n    Ð\n    Ñ\n    Ò\n    Ó\n    Ô\n    Õ\n    Ö\n×\n    Ø\n    Ù\n    Ú\n    Ü\n    Þ\n    ß\n    à\n    á\n    â\nã\n    ä\n    å\n    æ\n    ç\n    è\n    é\n    ê\n    ë\n    ì\ní\n    î\n    ï\n    ð\n    ñ\n    ò\n    ó\n    ô\n    õ\n    ö\n÷\n    ø\n    ù\n    ú\n    û\n    ü\n    ý\n    þ\n    ÿ\n    Œ\nœ\n    Š\n    š\n    Ÿ\n    ƒ\n    ˆ\n    ˜\n    Α\n    Β\n    Γ\nΔ\n    Ε\n    Ζ\n    Η\n    Θ\n    Ι\n    Κ\n    Λ\n    Μ\n    Ν\nΞ\n    Ο\n    Π\n    Ρ\n    Σ\n    Τ\n    Υ\n    Φ\n    Χ\n    Ψ\nΩ\n    α\n    β\n    γ\n    δ\n    ε\n    ζ\n    η\n    θ\n    ι\nκ\n    λ\n    μ\n    ν\n    ξ\n    ο\n    π\n    ρ\n    ς\n    σ\nτ\n    υ\n    φ\n    χ\n    ψ\n    ω\n    ϑ\n    ϒ\n    ϖ\n    \n\n    \n    \n    \n    \n    \n    –\n    —\n    ‘\n’\n    ‚\n    “\n    ”\n    „\n    †\n    ‡\n    •\n    …\n    ‰\n    ′\n″\n    ‹\n    ›\n    ‾\n    ⁄\n    €\n    ℑ\n    ℘\n    ℜ\n    ™\nℵ\n    ←\n    ↑\n    →\n    ↓\n    ↔\n    ↵\n    ⇐\n    ⇑\n    ⇒\n    ⇓\n⇔\n    ∀\n    ∂\n    ∃\n    ∅\n    ∇\n    ∈\n    ∉\n    ∋\n    ∏\n    ∑\n    −\n∗\n    √\n    ∝\n    ∞\n    ∠\n    ∧\n    ∨\n    ∩\n    ∪\n    ∫\n    ∴\n    ∼\n≅\n    ≈\n    ≠\n    ≡\n    ≤\n    ≥\n    ⊂\n    ⊃\n    ⊄\n    ⊆\n    ⊇\n⊕\n    ⊗\n    ⊥\n    ⋅\n    ⌈\n    ⌉\n    ⌊\n    ⌋\n    〈\n    〉\n◊\n    ♠\n    ♣\n    ♥\n    ♦\n    ";

            var source =
                "![CDATA[\n    &quot;\n    &amp;\n    &apos;\n    &lt;\n    &gt;\n    &nbsp;\n    &iexcl;\n    &cent;\n    &pound;\n" +
                "&curren;\n    &yen;\n    &brvbar;\n    &sect;\n    &uml;\n    &copy;\n    &ordf;\n    &laquo;\n    &not;\n    &shy;\n    &reg;\n" +
                "&macr;\n    &deg;\n    &plusmn;\n    &sup2;\n    &sup3;\n    &acute;\n    &micro;\n    &para;\n    &middot;\n    &cedil;\n" +
                "&sup1;\n    &ordm;\n    &raquo;\n    &frac14;\n    &frac12;\n    &frac34;\n    &iquest;\n    &Agrave;\n    &Aacute;\n    &Acirc;\n" +
"&Atilde;\n    &Auml;\n    &Aring;\n    &AElig;\n    &Ccedil;\n    &Egrave;\n    &Eacute;\n    &Ecirc;\n    &Euml;\n    &Igrave;\n" +
"&Iacute;\n    &Icirc;\n    &Iuml;\n    &ETH;\n    &Ntilde;\n    &Ograve;\n    &Oacute;\n    &Ocirc;\n    &Otilde;\n    &Ouml;\n" +
"&times;\n    &Oslash;\n    &Ugrave;\n    &Uacute;\n    &Uuml;\n    &THORN;\n    &szlig;\n    &agrave;\n    &aacute;\n    &acirc;\n" +
"&atilde;\n    &auml;\n    &aring;\n    &aelig;\n    &ccedil;\n    &egrave;\n    &eacute;\n    &ecirc;\n    &euml;\n    &igrave;\n" +
"&iacute;\n    &icirc;\n    &iuml;\n    &eth;\n    &ntilde;\n    &ograve;\n    &oacute;\n    &ocirc;\n    &otilde;\n    &ouml;\n" +
"&divide;\n    &oslash;\n    &ugrave;\n    &uacute;\n    &ucirc;\n    &uuml;\n    &yacute;\n    &thorn;\n    &yuml;\n    &OElig;\n" +
"&oelig;\n    &Scaron;\n    &scaron;\n    &Yuml;\n    &fnof;\n    &circ;\n    &tilde;\n    &Alpha;\n    &Beta;\n    &Gamma;\n" +
"&Delta;\n    &Epsilon;\n    &Zeta;\n    &Eta;\n    &Theta;\n    &Iota;\n    &Kappa;\n    &Lambda;\n    &Mu;\n    &Nu;\n" +
"&Xi;\n    &Omicron;\n    &Pi;\n    &Rho;\n    &Sigma;\n    &Tau;\n    &Upsilon;\n    &Phi;\n    &Chi;\n    &Psi;\n" +
"&Omega;\n    &alpha;\n    &beta;\n    &gamma;\n    &delta;\n    &epsilon;\n    &zeta;\n    &eta;\n    &theta;\n    &iota;\n" +
"&kappa;\n    &lambda;\n    &mu;\n    &nu;\n    &xi;\n    &omicron;\n    &pi;\n    &rho;\n    &sigmaf;\n    &sigma;\n" +
"&tau;\n    &upsilon;\n    &phi;\n    &chi;\n    &psi;\n    &omega;\n    &thetasym;\n    &upsih;\n    &piv;\n    &ensp;\n" +
"&emsp;\n    &thinsp;\n    &zwnj;\n    &zwj;\n    &lrm;\n    &rlm;\n    &ndash;\n    &mdash;\n    &lsquo;\n" +
"&rsquo;\n    &sbquo;\n    &ldquo;\n    &rdquo;\n    &bdquo;\n    &dagger;\n    &Dagger;\n    &bull;\n    &hellip;\n    &permil;\n    &prime;\n" +
"&Prime;\n    &lsaquo;\n    &rsaquo;\n    &oline;\n    &frasl;\n    &euro;\n    &image;\n    &weierp;\n    &real;\n    &trade;\n" +
"&alefsym;\n    &larr;\n    &uarr;\n    &rarr;\n    &darr;\n    &harr;\n    &crarr;\n    &lArr;\n    &uArr;\n    &rArr;\n    &dArr;\n" +
"&hArr;\n    &forall;\n    &part;\n    &exist;\n    &empty;\n    &nabla;\n    &isin;\n    &notin;\n    &ni;\n    &prod;\n    &sum;\n    &minus;\n" +
"&lowast;\n    &radic;\n    &prop;\n    &infin;\n    &ang;\n    &and;\n    &or;\n    &cap;\n    &cup;\n    &int;\n    &there4;\n    &sim;\n" +
"&cong;\n    &asymp;\n    &ne;\n    &equiv;\n    &le;\n    &ge;\n    &sub;\n    &sup;\n    &nsub;\n    &sube;\n    &supe;\n" +
"&oplus;\n    &otimes;\n    &perp;\n    &sdot;\n    &lceil;\n    &rceil;\n    &lfloor;\n    &rfloor;\n    &lang;\n    &rang;\n" +
"&loz;\n    &spades;\n    &clubs;\n    &hearts;\n    &diams;\n    ]]";

            var actualValue = XmlDecoder.ReplaceAllXmlReferences(source, null);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}