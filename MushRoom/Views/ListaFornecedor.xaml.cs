using System.Collections.ObjectModel;
using MushRoom.Models;

namespace MushRoom.Views;

public partial class ListaFornecedor : ContentPage
{

	ObservableCollection<Fornecedor> lista = new ObservableCollection<Fornecedor>();

	public ListaFornecedor()
	{
		InitializeComponent();

		lst_fornecedores.ItemsSource = lista;
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

  //  private void ToolbarItem_Clicked(object sender, EventArgs e)
  //  {
		//try
		//{
		//	Navigation.PushAsync(new Views.NovoFornecedor());
		//}
		//catch (Exception ex)
		//{
		//	DisplayAlert("Ops!", ex.Message, "OK");
		//}
  //  }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
		try
		{
			string q = e.NewTextValue;

			lista.Clear();

			List<Fornecedor> tmp = await App.Db.Search(q);

			tmp.ForEach(i => lista.Add(i));
		}
		catch (Exception ex)
		{
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			MenuItem selecionado = sender as MenuItem;

			Fornecedor f = selecionado.BindingContext as Fornecedor;

			bool confirm = await DisplayAlert("Tem Certeza?", $"Remover {f.NomeFornecedor}", "Sim", "Não");

			if (confirm)
			{
				await App.Db.Delete(f.Id);
				lista.Remove(f);
			}
		}
		catch (Exception ex)
		{
            await DisplayAlert("Ops!", ex.Message, "OK");
        }
    }

    private void lst_fornecedores_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		try
		{
			Fornecedor f = e.SelectedItem as Fornecedor;

			Navigation.PushAsync(new Views.EditarFornecedor
			{
				BindingContext = f
			});

		}
		catch (Exception ex)
		{
            DisplayAlert("Ops!", ex.Message, "OK");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Navigation.PushAsync(new Views.NovoFornecedor());
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops!", ex.Message, "OK");
        }
    }
}