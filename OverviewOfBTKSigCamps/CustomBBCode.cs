using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverviewOfBTKSigCamps
{
    public class CustomBBCode
    {
        private static string AddBBCode(string textWithNoBBCode, string BBCode)
        {
            return string.Format("[{0}]{1}[/{0}]", BBCode, textWithNoBBCode);
        }
        private static string AddBBCode(string textWithNoBBCode, string BBCode, string additional)
        {
            return string.Format("[{0}={1}]{2}[/{0}]", BBCode, additional, textWithNoBBCode);
        }
        private static string AddBold(string textToBold)
        {
            return AddBBCode(textToBold, "b");
        }
        private static string AddItalic(string textToBold)
        {
            return AddBBCode(textToBold, "i");
        }
        private static string AddUderline(string textToBold)
        {
            return AddBBCode(textToBold, "u");
        }
        private static string AddStrikeThrough(string textToBold)
        {
            return AddBBCode(textToBold, "s");
        }
        private static string AddURL(string textToBold, string urlText)
        {
            return AddBBCode(textToBold, "url", urlText);
        }
        private static string AddColor(string textToBold, string colorName)
        {
            return AddBBCode(textToBold, "color", colorName);
        }


        public static string MakeTable(List<SignatureCampaign> sigList)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("[table]");
            foreach (var item in sigList)
            {
                result.AppendLine(MakeTableRow(item));
            }
            result.Append("[/table]");
            return result.ToString();
        }
        private static string AddSeperator()
        {
            return "[td]|[/td]";
        }
        private static string MakeTableCell(string s)
        {
            return string.Format("[td]{0}[/td]{1}", s, AddSeperator());
        }
        public static string MakeTableRow(SignatureCampaign sig)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("[tr]");

            result.AppendLine(MakeTableCell(ChageAbbrevString(sig.Abbrev.ToString())));
            result.AppendLine(MakeTableCell(AddURL(sig.Name, sig.Link)));
            result.AppendLine(MakeTableCell(sig.CampaignType));
            result.AppendLine(MakeTableCell(sig.LegendaryRate.ToString()));
            result.AppendLine(MakeTableCell(sig.HeroRate.ToString()));
            result.AppendLine(MakeTableCell(sig.SrRate.ToString()));
            result.AppendLine(MakeTableCell(sig.FullRate.ToString()));
            result.AppendLine(MakeTableCell(sig.MemberRate.ToString()));
            result.AppendLine(MakeTableCell(sig.JrRate.ToString()));
            result.AppendLine(MakeTableCell(sig.NewbRate.ToString()));
            result.AppendLine(MakeTableCell(sig.MinPost));
            result.AppendLine(MakeTableCell(sig.MaxPost));
            result.AppendLine(MakeTableCell(ChangeEscrowString(sig.Escrow)));

            result.Append("[/tr]");
            return result.ToString();
        }
        private static string ChageAbbrevString(string Abbreviation)
        {
            if (Abbreviation == SignatureCampaign.Abbreviations.CFNP.ToString())
            {
                return AddStrikeThrough(AddColor(Abbreviation, ChooseColorForAbbreviation(Abbreviation)));
            }
            else
            {
                return AddColor(Abbreviation, ChooseColorForAbbreviation(Abbreviation));
            }
        }
        private static string ChooseColorForAbbreviation(string Abbreviation)
        {
            string color = "black";
            if (Abbreviation == SignatureCampaign.Abbreviations.A.ToString() || Abbreviation == SignatureCampaign.Abbreviations.CFNP.ToString())
            {
                color = "green";
            }
            else if (Abbreviation == SignatureCampaign.Abbreviations.PNYC.ToString() || Abbreviation == SignatureCampaign.Abbreviations.FLUX.ToString())
            {
                color = "orange";
            }
            return color;
        }
        private static string ChooseColorForEscrow(string EscrowType)
        {
            string color = "black";
            if (EscrowType == SignatureCampaign.EscrowEnum.Yes.ToString())
            {
                color = "green";
            }
            else if (EscrowType == SignatureCampaign.EscrowEnum.YesNo.ToString())
            {
                color = "orange";
            }
            return color;
        }
        private static string ChangeEscrowString(string EscrowType)
        {
            if (EscrowType != SignatureCampaign.EscrowEnum.No.ToString())
            {
                return AddColor(EscrowType, ChooseColorForEscrow(EscrowType));
            }
            else
            {
                return EscrowType;
            }
        }
    }
}
