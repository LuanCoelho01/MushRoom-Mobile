using MushRoom.Models;

namespace MushRoom.Views;

public partial class NovoFornecedor : ContentPage
{
	public NovoFornecedor()
	{
		InitializeComponent();
	}


    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Fornecedor f = new Fornecedor
            {
                NomeFornecedor = txt_fornecedor.Text,
                NomeProduto = txt_produto.Text,
                CNPJ = txt_cnpj.Text,
                Telefone = txt_telefone.Text
            };

            await App.Db.Insert(f);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}