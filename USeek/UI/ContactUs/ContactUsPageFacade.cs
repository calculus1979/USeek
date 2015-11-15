using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USeek.UI.ContactUs
{
    public partial class ContactUsPage
    {
        public ContactUsPage SetFields(ContactUsParams p)
        {
            FirstName       = p.FirstName;
            LastName        = p.LastName;
            EmailAddress    = p.EmailAddress;
            Subject         = p.Subject;
            Message         = p.Message;

            return this;
        }
    }
}
