using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessObjects;
using DatanTransfer;



public partial class Index : System.Web.UI.Page
{
    DTO dto = new DTO();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            //String fName = Server.MapPath("App_Data/angebote.txt");
            //StreamReader reader =   File.OpenText(fName);
            //while(!reader.EndOfStream)
            //{
            //    String zeile;
            //    zeile = reader.ReadLine();
            //    CheckBoxListAngebote.Items.Add(zeile);
            //}
            //reader.Close();        
            List<Angebot> li = dto.getAllOffers();
            foreach(Angebot a in li)
            {
                CheckBoxListAngebote.Items.Add(a.Anghebotstext);
            }
        }
    }
   
    protected void Link_Command(object sender, CommandEventArgs e)
    {
        String viewName = "View" + e.CommandName;
        View v = MultiViewlandzano.FindControl(viewName) as View;
        if(!v.Equals(null))
        {
            MultiViewlandzano.SetActiveView(v);
            
        }

       
    }
    protected void LinkButtonReady_Click(object sender, EventArgs e)
    {
        List<String> liSelect = new List<string>();
        foreach(ListItem li in CheckBoxListAngebote.Items)
        {
            if (li.Selected) liSelect.Add(li.Text);
                
        }
        if(liSelect.Count > 0)
        {
            RepeaterSelList.DataSource = liSelect;
            RepeaterSelList.DataBind();
            
            this.MultiViewlandzano.SetActiveView(this.ViewSend);
            //String s = (String) Session["User"];
            Object o = Session["User"]; ;
            User u = (User)o;
            if(u != null) this.LabelMeldung.Text = "Sie erhalten eine email an: " +  u.Email;
            else this.LabelMeldung.Text = "Erst registrieren";
            //this.LabelMeldung.Text = "Sie erhalten eine email an: " +  this.TextBoxEmail.Text;
            
        }
    }
    protected void ButtonSpeichern_Click(object sender, EventArgs e)
    {
        String email = this.TextBoxEmail.Text;
         User u = dto.getUserByEmail(email);
         if(u != null)
         {
             if(u.Kennwort.Equals(this.TextBoxKennwort.Text))
             {
                 Session.Add("User", u);
                 LabelMeldungRegister.Text = "Login erfolgreich";
             }
             else LabelMeldungRegister.Text = "Falsches Passwort";
         }
         else
         {
             LabelMeldungRegister.Text = "Unbekannter User. Erst registrieren";
         }
    }
    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        User u = new User();
        u.Email = this.TextBoxEmail.Text;
        u.Kennwort = this.TextBoxKennwort.Text;
        if(dto.getUserByEmail(u.Email) == null)
        {
            dto.SaveNewUser(u);
            Session.Add("User", u);
            LabelMeldungRegister.Text = "Neuer User angelegt";
        }
        else
        {
            LabelMeldungRegister.Text = "User schon vorhanden";
        }

    }
}