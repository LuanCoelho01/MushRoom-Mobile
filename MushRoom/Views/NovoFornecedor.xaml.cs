using MushRoom.Models;
using System.Globalization;

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



    private void txt_cnpj_TextChanged(object sender, TextChangedEventArgs e)
    {

        var entry = sender as Entry;

        // Remove caracteres não numéricos
        string text = e.NewTextValue?.Replace(".", "").Replace("-", "").Replace("/", "");

        if (string.IsNullOrEmpty(text))
            return;

        // Limitar ao tamanho máximo de um CNPJ (14 caracteres)
        if (text.Length > 14)
            text = text.Substring(0, 14);

        // Aplicar a máscara CNPJ (##.###.###/####-##)
        if (text.Length >= 3 && text.Length <= 5)
            text = $"{text.Substring(0, 2)}.{text.Substring(2)}";
        else if (text.Length >= 6 && text.Length <= 8)
            text = $"{text.Substring(0, 2)}.{text.Substring(2, 3)}.{text.Substring(5)}";
        else if (text.Length >= 9 && text.Length <= 12)
            text = $"{text.Substring(0, 2)}.{text.Substring(2, 3)}.{text.Substring(5, 3)}/{text.Substring(8)}";
        else if (text.Length >= 13)
            text = $"{text.Substring(0, 2)}.{text.Substring(2, 3)}.{text.Substring(5, 3)}/{text.Substring(8, 4)}-{text.Substring(12)}";

        // Atualiza o texto do Entry sem disparar eventos infinitos
        entry.Text = text;

    }

    private void txt_telefone_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = sender as Entry;

        // Remove caracteres não numéricos
        string text = e.NewTextValue?.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

        if (string.IsNullOrEmpty(text))
            return;

        // Limita o texto a no máximo 11 caracteres (DDD + número)
        if (text.Length > 11)
            text = text.Substring(0, 11);

        // Aplica a máscara (##) #####-####
        if (text.Length <= 2)
            text = $"({text}";
        else if (text.Length <= 7)
            text = $"({text.Substring(0, 2)}) {text.Substring(2)}";
        else
            text = $"({text.Substring(0, 2)}) {text.Substring(2, 5)}-{text.Substring(7)}";

        // Atualiza o texto sem disparar novamente o evento
        entry.Text = text;
    }
}


