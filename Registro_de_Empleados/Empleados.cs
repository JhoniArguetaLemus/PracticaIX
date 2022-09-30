using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro_de_Empleados
{
    class Empleados
    {

        private int id;
        private string nombre;
        private string dui;
        private double salario;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Dui
        {
            get { return dui; }
            set { dui = value; }
        }
        public double Salario
        {
            get { return salario; }
            set { salario = value; }
        }

        public double AFP(double Salario)
        {
            double CalcAFP = Salario * 0.0625;

            return CalcAFP;
        }

        public double ISSS(double salario)
        {
            double ISSS = salario * 0.03;
            return ISSS;
        }

        public double salarioNeto(double salario)
        {
            double salarioNeto = salario - AFP(salario) - ISSS(salario);

            return salarioNeto;
        }
    }
}
