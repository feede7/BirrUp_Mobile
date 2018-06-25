using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppBaseJSON
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            //btnGetUsuario.Clicked += btnGetUsuario_Click;

        }

        private async void BtnGetUsuario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(edtAlgo.Text))
                ((Core)BindingContext).GetUsuario();
        }
    }
}
