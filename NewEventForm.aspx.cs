using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventCalendar
{
    public partial class NewEventForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Calendar1.Visible = true;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();

            Calendar1.Visible = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DateTime date = Convert.ToDateTime(TextBox1.Text);
            string description = TextBox2.Text;
            if (date == null || description == null)
            {
                Label3.ForeColor = System.Drawing.Color.Red;
                Label3.Text = "You must complete all Fields before Saving.";
            }
            else { 
                int rowsAffected = SqlConn.executeRow("Insert Into Events Values('"+date+"','"+description+"')");
                if (rowsAffected > 0)
                {
                    Label3.ForeColor = System.Drawing.Color.Green;
                    Label3.Text = "New Event has been added to Event Calendar.";
                }
                else
                {
                    Label3.ForeColor = System.Drawing.Color.Red;
                    Label3.Text = "Unable to Insert New Record.";
                }
                TextBox1.Text = null;
                TextBox2.Text = null;
                //Calendar1.SelectedDates.Clear();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Label3.Text = null;
            Response.Redirect("Calendar.aspx");
        }
    }
}