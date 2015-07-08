using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using BusinessObjects;
using System.Web.UI;

namespace DatanTransfer
{
    public class DTO
    {
        // Microsoft.Jet.OLEDB.4.0;Data Source="C:\Users\Reinhold\Documents\Visual Studio 2013\Projects\AufgabeBestellung\DatanTransfer\bin\Debug\zalando.mdb"
        OleDbConnection con = null;

        private bool openConnection()
        {
             Boolean result =  true;
             OleDbConnectionStringBuilder bld = new OleDbConnectionStringBuilder();
             bld.Provider = "Microsoft.Jet.OLEDB.4.0";
             Page p = new Page();
             bld.DataSource =  p.Server.MapPath("App_Data\\landzano.mdb");
             //bld.DataSource = @"C:\Users\Reinhold\Documents\Visual Studio 2013\Projects\AufgabeBestellung\DatanTransfer\bin\Debug\zalando.mdb";
             con = new OleDbConnection(bld.ConnectionString);
            try
            {
               
                con.Open();
            }
            catch 
            {
                result = false;
            }
            
            return result;
        }
        public User getUserByEmail(String email)
        {
            User u = null;;
           
            if(openConnection())
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * From tUser where Email = '" + email + "';";
                OleDbDataReader reader =  cmd.ExecuteReader();
                if(reader.Read())
                {
                    
                    u = new User();
                    u.Id = reader.GetInt32(0);
                    u.Email = reader.GetString(1);
                    u.Kennwort = reader.GetString(2);
                }
                
            }
            con.Close();
            return u;
        }
        public List<Angebot> getAllOffers()
        {
            List<Angebot> li = new List<Angebot>();
            if(openConnection())
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = "Select * from tAngebot";
                OleDbDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    Angebot a = new Angebot();
                    a.Id = reader.GetInt32(0);
                    a.Anghebotstext = reader.GetString(1);
                    li.Add(a);
                }
                reader.Close();
                con.Close();
                
            }
            return li;
        }
        public Boolean SaveNewUser(User u)
        {
            Boolean result = true;
            if(openConnection())
            {
                OleDbCommand cmd = con.CreateCommand();
                cmd.Parameters.AddWithValue("email", u.Email);
                cmd.Parameters.AddWithValue("Pw", u.Kennwort);
                cmd.CommandText = "Insert Into tUser(Email,Passwort) Values(email,Pw)";
                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception)
                {

                    ;
                }
            }
            return result;
        }

    } 
}
