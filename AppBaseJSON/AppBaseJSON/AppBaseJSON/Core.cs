using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Threading.Tasks;
using AppBaseJSON;
using System.ComponentModel;


namespace AppBaseJSON
{
    public class Core : INotifyPropertyChanged
    {
        private string _Algo;
        public string Algo
        {
            get
            { return _Algo; }
            set
            { _Algo = value; }
        }

        public string ErrorMessage { get; set; }
        private Usuario usuario = new Usuario();

        public async void GetUsuario()
        {
            usuario = await GetUsuario(Algo, ErrorMessage);

            OnPropertyChanged("Nombre");
            OnPropertyChanged("Apellido");
            OnPropertyChanged("Edad");
            OnPropertyChanged("Sexo");
            OnPropertyChanged("Correo");
        }

        public string Nombre
        {
            get
            {
                return usuario.Nombre;
            }
            set
            {
                usuario.Nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Apellido
        {
            get
            {
                return usuario.Apellido;
            }
            set
            {
                usuario.Apellido = value;
                OnPropertyChanged("Apellido");
            }
        }
        public string Edad
        {
            get
            {
                return usuario.Edad;
            }
            set
            {
                usuario.Edad = value;
                OnPropertyChanged("Edad");
            }
        }
        public string Sexo
        {
            get
            {
                return usuario.Sexo;
            }
            set
            {
                usuario.Sexo = value;
                OnPropertyChanged("Sexo");
            }
        }
        public string Correo
        {
            get
            {
                return usuario.Correo;
            }
            set
            {
                usuario.Correo = value;
                OnPropertyChanged("Correo");
            }
        }

        private static async Task<Usuario> GetUsuario(string pZipCode, string pErrorMessage)
        {
 /*           //Sign up for a free API key at http://openweathermap.org/appid 
            string key = "YOUR KEY HERE";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + pZipCode + ",us&appid=" + key + "&units=imperial";

            //Make sure developers running this sample replaced the API key
            if (key != "YOUR API KEY HERE")
            {
                throw new ArgumentException("You must obtain an API key from openweathermap.org/appid and save it in the 'key' variable.");
            }

            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {*/
                Usuario usuario = new Usuario();
            usuario.Nombre = "Pepe";// (string)results["name"];
            usuario.Apellido = "Sanches";// (string)results["main"]["temp"] + " F";
            usuario.Edad = "29";// (string)results["wind"]["speed"] + " mph";
            usuario.Sexo = "Nene";// (string)results["main"]["humidity"] + " %";
            usuario.Correo = "pepesanches@gmail.com";// (string)results["weather"][0]["main"];

            return usuario;
 /*           }
            else
            {
                return null;
            }*/
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var changed = PropertyChanged;
            if (changed != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }



 
    }
}
