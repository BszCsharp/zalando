using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class landzano2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            String fname = Server.MapPath("App_Data/Angebote.txt");
            StreamReader reader = File.OpenText(fname);
            while(!reader.EndOfStream)
            {
                CheckBoxListAngebote.Items.Add(reader.ReadLine());
            }
            reader.Close();

        }
    }
    protected void Link_Command(object sender, CommandEventArgs e)
    {
        String viewName = "View" + e.CommandName;
        View v = MultiViewLandzano.FindControl(viewName) as View; // sicheres Casten
        if (v != null)
        {
            MultiViewLandzano.SetActiveView(v);
        }

    }
    protected void LinkButtonReady_Click(object sender, EventArgs e)
    {
        List<String> liSelect = new List<string>();
        foreach(ListItem li in CheckBoxListAngebote.Items)
        {
            if(li.Selected)
            {
                liSelect.Add(li.Text);
            }
        }
        if(liSelect.Count > 0)
        {
            RepeaterSelList.DataSource = liSelect;
            RepeaterSelList.DataBind();
            //this.LabelMeldung.Text = "Sie werden benachrichtigt: " + this.TextBoxEmail.Text;

            User u = Session["User"] as User;
            this.LabelMeldung.Text = "Sie werden benachrichtigt: " + u.Email;
            MultiViewLandzano.SetActiveView(this.ViewSend);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        User u = new User { Email = TextBoxEmail.Text, Kennwort = TextBoxKennwort.Text };
        Session.Add("User", u);
    }
}