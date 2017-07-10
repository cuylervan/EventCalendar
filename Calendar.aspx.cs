using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventCalendar
{
    public partial class Calendar : System.Web.UI.Page
    {
        private DataTable calEvents;

        protected void Page_Load(object sender, EventArgs e)
        {
            fillCalEventsTable();
        }
        private void fillCalEventsTable()
        {
            DataTable table = new DataTable();
            calEvents = SqlConn.getDataTable("Select EventDate,EventDescription FROM Events");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            DataRow[] rows = calEvents.Select(
                String.Format(
                    "EventDate >= #{0}# AND EventDate < #{1}#",
                    e.Day.Date.ToShortDateString(),
                    e.Day.Date.AddDays(1).ToShortDateString()
                    )
                );
            foreach (DataRow row in rows)
            {
                System.Web.UI.WebControls.Image image;
                image = new System.Web.UI.WebControls.Image();
                image.ToolTip = row["EventDescription"].ToString();
                e.Cell.BackColor = Color.Wheat;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            System.Data.DataView view = calEvents.DefaultView;
            view.RowFilter = String.Format(
                "EventDate >= #{0}# AND EventDate < #{1}#",
                Calendar1.SelectedDate.ToShortDateString(),
                Calendar1.SelectedDate.AddDays(1).ToShortDateString()
                );
            if (view.Count > 0)
            {
                GridView1.Visible = true;
                GridView1.DataSource = view;
                GridView1.DataBind();
            }
            else
            {
                GridView1.Visible = false;
            }
        }

        protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            this.Calendar1.DayRender += new System.Web.UI.WebControls.DayRenderEventHandler(this.Calendar1_DayRender);
            this.Calendar1.SelectionChanged += new System.EventHandler(this.Calendar1_SelectionChanged);
            this.Load += new System.EventHandler(this.Page_Load);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewEventForm.aspx");
        }
    }
}