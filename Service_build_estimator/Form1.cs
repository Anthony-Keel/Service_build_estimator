using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Service_build_estimator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double airFeet = 0.0, UGFeet = 0.0, trenchFeet = 0.0, boreFeet = 0.0, roadCross = 0.0,
            wireCost = 0.0, UGCost = 0.0, trenchCost = 0.0,boreCost=0.0, poleCost = 0.0, permitCost = 0, 
            constCost = 0.0, subTotal = 0.0,saleTax = 0.0, GrandTotal = 0.0, poleCount = 1.0, meterPole = 0, 
            subTotalTaxable = 0.0, fastTrackFee = 0.0;
        bool FastTrackClicked = false;
        const double POLE_WIRE_LENGTH = 249.00;
        const double AIR_WIRE_RATE = 3.25;
        const double UG_WIRE_RATE = 3.75;
        const double TRENCH_WIRE_RATE = 9.50;
        const double TRENCH_FEE = 250.00;
        const double BORE_WIRE_RATE = 17.00;
        const double BORE_FEE = 3000.00;
        const double ROAD_CROSSING_FEE = 800.00;
        const double ROAD_PERMIT = 1400.00;
        const double METER_POLE_FEE = 475.00;
        const double FAST_TRACK_FEE= 2500.00;
        const double UTILITY_POLE = 430.00;
        const double SALES_TAX = 0.0755;

        string errorMessage = "invalid Data Input";

        private void CalculateBtn_Click(object sender, EventArgs e)
        {
            BindFromUI();

            wireCost = (airFeet * AIR_WIRE_RATE) + (UGFeet * UG_WIRE_RATE);
            if (airFeet > POLE_WIRE_LENGTH)
            {
                poleCount = (airFeet / 250.00);
                meterPole = 1.0;
            }
            else
            {
                poleCount = 1.0;
                meterPole = 1.0;
            }

            trenchCost = trenchFeet * TRENCH_WIRE_RATE + TRENCH_FEE;
            boreCost = boreFeet * BORE_WIRE_RATE + BORE_FEE;
            constCost = fastTrackFee + (meterPole*METER_POLE_FEE) + trenchCost + boreCost;
            poleCost = (poleCount * UTILITY_POLE);  
            subTotalTaxable = (wireCost + UGCost);
            saleTax = subTotalTaxable * SALES_TAX;
            subTotal = subTotalTaxable + roadCross + constCost;

            GrandTotal = subTotal + saleTax;
            BindToUI();
        }

        private void RoadPermitBtn_Click(object sender, EventArgs e)
        {
            permitCost += ROAD_PERMIT;
        }

        private void ExtraMeterBtn_Click(object sender, EventArgs e)
        {
            meterPole += 1;
        }

        private void FastTrackBtn_Click(object sender, EventArgs e)
        {
            if (!FastTrackClicked)
            {
                fastTrackFee += FAST_TRACK_FEE;
                FastTrackClicked = true;
            }
            else
            {
                //do nothing
            }
        }


        private void BindToUI()
        {
          
            poleCountDataLbl.Text = poleCount.ToString("n0");
            wireTotalLbl.Text = wireCost.ToString("n2");
            poleTotalLbl.Text = poleCost.ToString("n2");
            permitTotalLbl.Text = permitCost.ToString("n2");
            constTotalLbl.Text = constCost.ToString("n2");
            subtotalDataLbl.Text = subTotal.ToString("n2");
            taxTotalLbl.Text = saleTax.ToString("n2");
            grandTotalDataLbl.Text =  GrandTotal.ToString("c2");
            
        }

        private void ResetUIValues()
        {
            airFeet = 0.0;
            UGFeet = 0.0;
            trenchFeet = 0.0;
            boreFeet = 0.0;
            roadCross = 0.0;
            wireCost = 0.0;
            poleCost = 0.0;
            permitCost = 0.0;
            constCost = 0.0;
            subTotal = 0.0;
            saleTax = 0.0;
            GrandTotal = 0.0;
            poleCount = 1.0;
            airFeetTxtBx.Text ="0";
            UGFeetTxtBx.Text = "0";
            boreFeetTxtBx.Text = "0";
            RoadCrossTxtBx.Text = "0";
            TrenchFeetTxtbx.Text = "0";
            airFeetErrorLbl.Text = string.Empty;
            UGErrorLbl.Text = string.Empty;
            boreFeetErrorLbl.Text = string.Empty;
            trenchFeetErrorLbl.Text = string.Empty;
            roadCrossingErrorLbl.Text = string.Empty;
            errrorMessageLbl.Text = string.Empty;

        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ResetUIValues();
            BindToUI();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetUIValues();
            BindToUI();
            
        }

        private void BindFromUI()
        {


            if (!double.TryParse(airFeetTxtBx.Text, out airFeet))
            {
                airFeetErrorLbl.ForeColor = Color.Red;
                airFeetErrorLbl.Text = "*";
                airFeetTxtBx.Focus();
                errrorMessageLbl.Text = errorMessage;
                errrorMessageLbl.ForeColor = Color.Red;
            }
            else
            {
                //empty else
            }
            if (!double.TryParse(UGFeetTxtBx.Text, out UGFeet))
            {
                boreFeetErrorLbl.ForeColor = Color.Red;
                boreFeetErrorLbl.Text = "*";
                boreFeetTxtBx.Focus();
                errrorMessageLbl.Text = errorMessage;
                errrorMessageLbl.ForeColor = Color.Red;
            }
            else 
            {
            
            }
            if(!double.TryParse(TrenchFeetTxtbx.Text, out trenchFeet))
            {
                trenchFeetErrorLbl.ForeColor = Color.Red;
                trenchFeetErrorLbl.Text = "*";
                TrenchFeetTxtbx.Focus();
                errrorMessageLbl.Text = errorMessage;
                errrorMessageLbl.ForeColor = Color.Red;
            }
            else
            {
                //empty else
            }
            if (!double.TryParse(boreFeetTxtBx.Text, out boreFeet))
            {
                boreFeetErrorLbl.ForeColor = Color.Red;
                boreFeetErrorLbl.Text = "*";
                boreFeetTxtBx.Focus();
                errrorMessageLbl.Text = errorMessage;
                errrorMessageLbl.ForeColor = Color.Red;
            }
            else
            {
                //empty else
            }

            if (!double.TryParse(RoadCrossTxtBx.Text, out roadCross))
            {
                roadCrossingErrorLbl.Text = "*";
                roadCrossingErrorLbl.ForeColor = Color.Red;
                RoadCrossTxtBx.Focus();
                errrorMessageLbl.Text = errorMessage;
                errrorMessageLbl.ForeColor = Color.Red;
            }
            else
            {
                //empty else
            }



        }

       
    }
}
