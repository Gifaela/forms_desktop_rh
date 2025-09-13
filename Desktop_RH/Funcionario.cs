using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumindo_WebApi_Funcionario
{
    public class Funcionario
    {

        public string myName { get; set; }
        public int myCpf { get; set; }
        public string myemail { get; set; }
        public string mybirthdate { get; set; }
        public string myferias { get; set; }
        public int myPhone { get; set; }

        public double MySalario { get; set; }


        public string MyCargo { get; set; }


    }
}


