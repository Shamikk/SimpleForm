using System.Collections.Generic;

namespace SimpleForm.BLL
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
        public string Email { get; set; }

        public IEnumerable<Form> FormsSent { get; set; }
    }
}
