using System;
using System.Collections.Generic;
using System.Text;

namespace AppBaseJSON
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Edad { get; set; }
        public string Sexo { get; set; }
        public string Correo { get; set; }

        public Usuario()
        {
            //Because labels bind to these values, set them to an empty string to 
            //ensure that the label appears on all platforms by default. 
            this.Nombre = " ";
            this.Apellido = " ";
            this.Edad = " ";
            this.Sexo = " ";
            this.Correo = " ";
        }
    }
}
