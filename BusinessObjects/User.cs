using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusinessObjects
{
    /// <summary>
    /// Zusammenfassungsbeschreibung für User
    /// </summary>
    public class User
    {
        public User()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public Int32 Id { get; set; }
        public String Email { get; set; }
        public String Kennwort { get; set; }
    }
}