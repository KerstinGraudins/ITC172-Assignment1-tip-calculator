﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string[] tipPercent = { "Ten Percent", "Fifteen Percent", "Twenty Percent", "Other" };
            TipPercentsButtons.DataSource = tipPercent;
            TipPercentsButtons.DataBind();
        }
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        GetInfo();
    }
    protected void GetInfo()
    {
        Tip tip = new Tip();
        tip.MealAmount = double.Parse(MealTextBox.Text);
        if(OtherTextBox.Text=="")
        {
            tip.TipPercent = 0;
            
            foreach(ListItem item in TipPercentsButtons.Items)
            {
                if(item.Selected)
                if(item.Text.Equals("Ten Percent"))
                {
                    tip.TipPercent = .1;
                }
               else if (item.Text.Equals("Fifteen Percent"))
                {
                    tip.TipPercent = .15;
                }
                else if (item.Text.Equals("Twenty Percent"))
                {
                    tip.TipPercent = .2;
                }
              
            }
        }
        else
        {
            tip.TipPercent = double.Parse(OtherTextBox.Text);
        }
        ResultLabel.Text = tip.MealAmount.ToString("$#,##0.00") + "<br/>" +
            "Tip:" + tip.CalculateTip().ToString("$#,##0.00") + "<br/>" +
            "Tax:" + tip.CalculateTax().ToString("$#,##0.00") + "<br/>" +
            "Total:" + tip.CalculateTotal().ToString("$#,##0.00");
       
    }
}