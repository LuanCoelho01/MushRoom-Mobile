using MushRoom.Models;

namespace MushRoom.Views;

public partial class EditarFornecedor : ContentPage
{
	public EditarFornecedor()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            //Fornecedor fornecedor_anexado = BindingContext as Fornecedor;

            Fornecedor fornecedor_anexado = BindingContext as Fornecedor;

            Fornecedor f = new Fornecedor
            {
                Id = fornecedor_anexado.Id,
                NomeFornecedor = txt_fornecedor.Text,
                NomeProduto = txt_produto.Text,
                CNPJ = txt_cnpj.Text,
                Telefone = txt_telefone.Text
            };

            await App.Db.Update(f);
            await DisplayAlert("Sucesso!", "Registro Alterado", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}