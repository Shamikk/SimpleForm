﻿using System.Collections.Generic;

namespace SimpleForm.BLL
{
    public class Form
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string RecipientsAddresses { get; set; }
        public User Sender { get; set; }
    }
}
