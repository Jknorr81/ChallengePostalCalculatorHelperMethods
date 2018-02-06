using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                double width = 0;
                double height = 0;
                double length = 1;

                ViewState.Add("Width", width);
                ViewState.Add("Height", height);
                ViewState.Add("Length", length);
            }
        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            displayResults();
        }

        //helper Methods


        private void convertTextBoxToDouble()
        {

            double width = 0;
            double height = 0;
            double length = 1;

            width = double.Parse(widthTextBox.Text.Trim());
            height = double.Parse(heightTextBox.Text.Trim());
            if (lengthTextBox.Text.Trim().Length == 0)
                length = 1;
            else
                length = double.Parse(lengthTextBox.Text.Trim());

            ViewState["Width"] = width;
            ViewState["Height"] = height;
            ViewState["Length"] = length;

        }

        private bool validateNeededInfo()
        {
            if (!groundRadioButton.Checked && !airRadioButton.Checked && !nextDayRadioButton.Checked)
                return false;
            if (heightTextBox.Text.Trim().Length == 0 || widthTextBox.Text.Trim().Length == 0)
                return false;
            else
                return true;
        }

        private double volumeCalculation()
        {
            double volume = (((double)ViewState["Width"] * (double)ViewState["Height"]) * (double)ViewState["Length"]);
            return volume;
        }

        private double shippingMultiplier()
        {
            double shippingMultiplier = 0;
            if (groundRadioButton.Checked) shippingMultiplier = .15;
            else if (airRadioButton.Checked) shippingMultiplier = .25;
            else if (nextDayRadioButton.Checked) shippingMultiplier = .45;
            return shippingMultiplier;
        }

        private double shippingCost(double volume, double shippingMultiplier)
        {
            double shippingCost = volume * shippingMultiplier;
            return shippingCost;
        }

        private void displayResults()
        {
            if(!validateNeededInfo()) return;
            convertTextBoxToDouble();
            double result = shippingCost(volumeCalculation(), shippingMultiplier());
            resultLabel.Text = string.Format("Your parcel will cost {0:C} to ship", result);
        }
    }
}