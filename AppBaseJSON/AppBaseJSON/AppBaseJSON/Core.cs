using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppBaseJSON;
using System.ComponentModel;
using Microsoft.CSharp;


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
            try
            {
                usuario = await GetUsuario(Algo);//, ErrorMessage);

                OnPropertyChanged("Nombre");
                OnPropertyChanged("Apellido");
                OnPropertyChanged("Edad");
                OnPropertyChanged("Sexo");
                OnPropertyChanged("Correo");
            }
            catch
            {

            }

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

        private static async Task<Usuario> GetUsuario(string pAlgo)//, string pErrorMessage)
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
                       */

            string queryString = "http://192.168.0.16:3000/user?" + "age=" + pAlgo;
            dynamic results = await DataService.getDataFromService(queryString).ConfigureAwait(false);

            Console.WriteLine("Pedido");

            if (results["user"] != null)
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = (string)results["user"]["first_name"];
                usuario.Apellido = (string)results["user"]["last_name"];// (string)results["main"]["temp"] + " F";
                usuario.Edad = (string)results["user"]["age"]; // (string)results["wind"]["speed"] + " mph";
                usuario.Sexo = (string)results["user"]["sex"]; // (string)results["main"]["humidity"] + " %";
                usuario.Correo = (string)results["user"]["email"]; // (string)results["weather"][0]["main"];

                return usuario;
            }
            else
            {
                return null;
            }
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
