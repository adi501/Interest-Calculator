namespace InterestCalculator;

public partial class MainPage : ContentPage
{
    //decimal bill;
    //int tip;
    //int noPersons = 1;

    public MainPage()
    {
        InitializeComponent();
        List<String> Names = new List<string>();
        Names.Add("Rupees");
        Names.Add("Percentage(%)");
        pickerInterestType.ItemsSource = Names;
        pickerInterestType.SelectedItem = "Rupees";
    }

    private void ExtryAmount_TextChanged(object sender, TextChangedEventArgs e)
    {

    }

    private void Date_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (Date.IsChecked == true)
        {
            Datespanel.IsVisible = true;
            Durationpanel.IsVisible = false;
        }
        else
        if (Duration.IsChecked == true)
        {
            Datespanel.IsVisible = false;
            Durationpanel.IsVisible = true;
        }
    }

    private void btnCalculat_Clicked(object sender, EventArgs e)
    {
        try
        {
            int year;
            double amount, rate=0, interest, total_amt;
            amount = Convert.ToDouble(ExtryAmount.Text.Trim());
           // year = Convert.ToInt16(Extryyears.Text.Trim());

            if(pickerInterestType.SelectedItem.ToString()== "Rupees")
            {
                rate = Convert.ToDouble(ExtryInterestRate.Text.Trim());
            }
            else
                if (pickerInterestType.SelectedItem.ToString() == "Percentage(%)")
            {
                rate = Convert.ToDouble(ExtryInterestRate.Text.Trim())/12;
            }

            
            //interest = amount * year * rate / 100;
            //total_amt = amount + interest;

            int noOfDays = 0;
            if (Date.IsChecked == true)
            {
                 noOfDays = (ToDate.Date).Subtract(FromDate.Date).Days;
            }
            else
                 if (Duration.IsChecked == true)
            {
                DateTime firstdate = DateTime.Now.AddYears(-(Convert.ToInt32(Extryyears.Text)));
                firstdate= firstdate.AddMonths(-(Convert.ToInt32(ExtryMonths.Text)));
                firstdate = firstdate.AddDays(-(Convert.ToInt32(ExtryDays.Text)));
                DateTime todaydate = DateTime.Now;
                noOfDays = todaydate.Subtract(firstdate).Days;

            }

            interest = (((amount * rate / 100) / 30) * noOfDays);
            total_amt = amount + interest;


            lblTotalTime.Text = "Total Days is: " + noOfDays;
            lblInterestAmount.Text = "Interest amount is : " + (int)interest;
            lblPrincipleAmount.Text = "Principle amount is : " + amount;
            lblTotalAmount.Text = "Total amount is : " + (int)total_amt;
            outputPanel.IsVisible = true;
        }
        catch (Exception ex)
        {

        }
    }

    private void btnClear_Clicked(object sender, EventArgs e)
    {

    }

    //private void txtBill_Completed(object sender, EventArgs e)
    //{
    //    bill = decimal.Parse(txtBill.Text);
    //    CalculateTotal();
    //}

    //private void CalculateTotal()
    //{
    //    var totalTip = (bill * tip) / 100;
    //    var tipByPerson = (totalTip / noPersons);
    //    lblTipbyPerson.Text = $"{tipByPerson:C}";

    //    var subTotal = (bill / noPersons);
    //    lblSubtotal.Text = $"{subTotal:C}";

    //    var totalByPerson = (bill + totalTip) / noPersons;
    //    lblTotal.Text = $"{totalByPerson:C}";
    //}

    //private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    //{
    //    tip = (int)sldTip.Value;
    //    lblTip.Text = $"Tip:{tip}%";
    //    CalculateTotal();
    //}

    //private void Button_Clicked(object sender, EventArgs e)
    //{
    //    if (sender is Button)
    //    {
    //        var btn = (Button)sender;
    //        var percentage = int.Parse(btn.Text.Replace("%", ""));
    //        sldTip.Value = percentage;
    //    }
    //}

    //private void btnMinus_Clicked(object sender, EventArgs e)
    //{
    //    if (noPersons > 1)
    //    {
    //        noPersons--;
    //    }
    //    lblNoPersons.Text = noPersons.ToString();
    //    CalculateTotal();
    //}

    //private void btnPlus_Clicked(object sender, EventArgs e)
    //{
    //    noPersons++;
    //    lblNoPersons.Text = noPersons.ToString();
    //    CalculateTotal();
    //}
}

