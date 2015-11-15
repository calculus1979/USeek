using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USeek.UI.ContactUs;

namespace USeek.Verifiers.ContactUs
{
    public class ContactUsVerifier : IVerify
    {
        private ContactUsPage   page;
        private List<string>    expectedErrorMessages;

        public ContactUsVerifier(ContactUsPage page, ContactUsParams p)
        {
            this.page                   = page;
            this.expectedErrorMessages  = p.ErrorMessages;
        }

        public void Verify()
        {
            List<string> actualErrorMessages = page.ErrorMessages;

            Assert.AreEqual(expectedErrorMessages.Count, actualErrorMessages.Count);
            Assert.IsTrue(expectedErrorMessages.All(e => actualErrorMessages.Contains(e)));
        }
    }
}
