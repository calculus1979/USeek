using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USeek.UI.ContactUs
{
    public struct ContactUsParams
    {
        public string       FirstName       { get; set; }
        public string       LastName        { get; set; }
        public string       EmailAddress    { get; set; }
        public string       Subject         { get; set; }
        public string       Message         { get; set; }

        public List<string> ErrorMessages   { get; set; }
    }
}
