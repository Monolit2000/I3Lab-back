using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace I3Lab.Doctors.Domain.Doctors
{
    public class Email
    {
        public string Value { get; }

        private Email(string value)
        => Value = value;
        

        public static Email Create(string value)
        {
            return new Email(value);
        }
    }
}
