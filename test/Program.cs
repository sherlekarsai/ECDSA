using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var signdata = ECDSA128.ECC128.GenerateSignature("20685b5fbfe1898fbb080b0719acc9ed2f365128627f21ffcc1b1ee27471e69e", "ravishpri.txt", "ravishpub.txt");
        }
    }
}
