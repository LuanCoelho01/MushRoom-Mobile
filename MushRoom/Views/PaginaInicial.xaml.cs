using System.Collections.ObjectModel;
using MushRoom.Models;

namespace MushRoom.Views;

public partial class PaginaInicial : ContentPage
{
    ObservableCollection<Fornecedor> lista = new ObservableCollection<Fornecedor>();

    public PaginaInicial()
	{
		InitializeComponent();

        string? usuario_logado = null;
        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_boasvindas.Text = $"Bem-vindo(a), {usuario_logado}";
        });

        lst_produtos.ItemsSource = lista;
    }


    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();

            List<Fornecedor> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }

}