using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverviewOfBTKSigCamps
{
    public class SignatureCampaign
    {
        public enum EscrowEnum
        {
            Yes,
            No,
            YesNo
        }
        public enum CampTypeEnum
        {
            Post_Weekly,
            Post_BiWeekly,
            Post_Monthly,
            Fixed_Weekly,
            Fixed_BiWeekly,
            Fixed_Monthly
        }
        public enum Abbreviations
        {
            A,
            PNYC,
            FLUX,
            CFNP
        }
        public string Abbrev { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string CampaignType { get; set; }
        public decimal LegendaryRate { get; set; }
        public decimal HeroRate { get; set; }
        public decimal SrRate { get; set; }
        public decimal FullRate { get; set; }
        public decimal MemberRate { get; set; }
        public decimal JrRate { get; set; }
        public decimal NewbRate { get; set; }
        public string MinPost { get; set; }
        public string MaxPost { get; set; }
        public string Escrow { get; set; }
    }
}
