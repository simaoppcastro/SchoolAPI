using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IDateTime
    {
        // interface define um contracto
        // tem que ter isto (caracteristicas)

        DateTime Now { get; }
    }
}
