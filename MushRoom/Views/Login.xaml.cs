using MushRoom.Models;

namespace MushRoom.Views;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}


	private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "Luan",
					Senha = "1010"
				},
				new DadosUsuario() {

					Usuario = "Pedro",
					Senha = "2424"
				}

			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text,
			};

			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario &&
			   dados_digitados.Senha == i.Senha))) 
			{
				await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
				App.Current.MainPage = new AppShell();



			}
			else
			{
				throw new Exception("Usuário ou senha incorretos");
			}

		}
		catch (Exception ex)
		{
			await DisplayAlert("Ops!", ex.Message, "OK");
		}
    }


	
}