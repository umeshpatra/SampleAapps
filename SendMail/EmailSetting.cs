using System;
using System.Collections.Generic;
using System.Text;

namespace SendMail
{

    public class EmailSetting
    {
        public string body { get; set; }
        public string emailFromAddress { get; set; }
        public string emailToAddress { get; set; }
        public string enableSSL { get; set; }
        public string password { get; set; }
        public string portNumber { get; set; }
        public string smtpAddress { get; set; }
        public string subject { get; set; }
    }

}
