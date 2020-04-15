using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    // class SystemDateTime implementa interface IDateTime
    public class SystemDateTime : IDateTime
    {

        // temos de implementar método defenido pela interface
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
