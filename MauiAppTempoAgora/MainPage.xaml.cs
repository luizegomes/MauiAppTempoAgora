using MauiAppTempoAgora.Models;
using MauiAppTempoAgora.Services;
using System.Threading.Tasks;

namespace MauiAppTempoAgora
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txt_cidade.Text))
                {
                    Tempo? t = await DataService.GetPrevisao(txt_cidade.Text);

                    if (t != null)
                    {
                        string dados_previsao = "";

                        dados_previsao = $"Latitude: {t.lat}\n" +
                                         $"Longitude: {t.lon}\n" +
                                         $"Temperatura mínima: {t.temp_min}\n" +
                                         $"Temperatura máxima: {t.temp_max}\n" +
                                         $"Visibilidade: {t.visibility}\n" +
                                         $"Velocidade do vento: {t.speed}\n" +
                                         $"Condição: {t.main}\n" +
                                         $"Descrição: {t.description}\n" +
                                         $"Nascer do sol: {t.sunrise}\n" +
                                         $"Pôr do sol: {t.sunset}";

                        lbl_res.Text = dados_previsao;

                    } else
                    {
                        lbl_res.Text = "Sem dados de previsão";
                    }

                } else
                {
                    lbl_res.Text = "Preencha a cidade ";
                }

            } catch (Exception ex)
            {
                await DisplayAlert("Ops", ex.Message, "OK");
            }
        }
    }

}
