using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OverviewOfBTKSigCamps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (var item in Enum.GetNames(typeof(SignatureCampaign.CampTypeEnum)))
            {
                cmbxType.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(SignatureCampaign.EscrowEnum)))
            {
                cmbxEscrow.Items.Add(item);
            }
            foreach (var item in Enum.GetNames(typeof(SignatureCampaign.Abbreviations)))
            {
                cmbxAbbrev.Items.Add(item);
            }
        }


        private void EnableButton()
        {
            List<TextBox> tbxRates = new List<TextBox>(new TextBox[] { txtRateLegendary, txtRateHero, txtRateSr, txtRateFull, txtRateMem, txtRateJr, txtRateNewb });
            btnMakeBB.IsEnabled = true;
            foreach (var item in tbxRates)
            {
                if (item != null && item.Background == Brushes.OrangeRed)
                {
                    btnMakeBB.IsEnabled = false;
                }
            }
            if (btnMakeBB.IsEnabled && cmbxAbbrev.SelectedItem == null || cmbxType.SelectedItem == null || cmbxEscrow.SelectedItem == null)
            {
                btnMakeBB.IsEnabled = false;
            }
        }
        private void cmbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cbx = (ComboBox)sender;
            if (cbx.SelectedItem != null)
            {
                EnableButton();
            }
        }
        private void txtRate_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tbx = (TextBox)sender;
            if (tbx.Text != null)
            {
                decimal d;
                if (decimal.TryParse(tbx.Text, out d))
                {
                    tbx.Background = Brushes.White;
                    EnableButton();
                }
                else
                {
                    tbx.Background = Brushes.OrangeRed;
                    EnableButton();
                }
            }
        }

        private void btnMakeBB_Click(object sender, RoutedEventArgs e)
        {
            SignatureCampaign mySig = new SignatureCampaign();
            mySig.Abbrev = (string)cmbxAbbrev.SelectedItem;
            mySig.Name = txtName.Text;
            mySig.Link = txtLink.Text;
            mySig.CampaignType = (string)cmbxType.SelectedItem;
            mySig.LegendaryRate = decimal.Parse(txtRateLegendary.Text);
            mySig.HeroRate = decimal.Parse(txtRateHero.Text);
            mySig.SrRate = decimal.Parse(txtRateSr.Text);
            mySig.FullRate = decimal.Parse(txtRateFull.Text);
            mySig.MemberRate = decimal.Parse(txtRateMem.Text);
            mySig.JrRate = decimal.Parse(txtRateJr.Text);
            mySig.NewbRate = decimal.Parse(txtRateNewb.Text);
            mySig.MinPost = txtMin.Text;
            mySig.MaxPost = txtMax.Text;
            mySig.Escrow = (string)cmbxEscrow.SelectedItem;

            List<SignatureCampaign> allSigs = new List<SignatureCampaign>();
            allSigs.Add(mySig);

            txtResult.Text = CustomBBCode.MakeTable(allSigs);
        }
    }
}
