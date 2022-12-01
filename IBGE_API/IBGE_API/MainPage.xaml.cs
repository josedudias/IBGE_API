using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using IBGE_API.Models;
using System.Collections.ObjectModel;

namespace IBGE_API {
    public partial class MainPage : ContentPage {

        private const string Url = "https://servicodados.ibge.gov.br/api/v1/localidades/estados";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Estados> _estados;
        private ObservableCollection<UnidadesFederativas> _cidades;

        public MainPage()
        {
            InitializeComponent();
        }

        async override protected void OnAppearing()
        {
            base.OnAppearing();
            string rescontent = await _client.GetStringAsync(Url);
            List<Estados> estados = JsonConvert.DeserializeObject<List<Estados>>(rescontent);
            _estados = new ObservableCollection<Estados>(estados);

            foreach (var item in estados)
            {
                pkEstados.Items.Add(item.Sigla);
            }
            
            base.OnAppearing();
        }

        private async void PickerSelect(object sender, EventArgs e)
        {
            var selecao = pkEstados.Items[pkEstados.SelectedIndex];
            var UrlUF = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/" + selecao + "/municipios";
            string rescontent = await _client.GetStringAsync(UrlUF);
            List<UnidadesFederativas> cidades = JsonConvert.DeserializeObject<List<UnidadesFederativas>>(rescontent);
            _cidades = new ObservableCollection<UnidadesFederativas>(cidades);

            foreach (var item in cidades)
            {
                pkUnidadesFederativas.Items.Add(item.nome);
            }

            base.OnAppearing();
        }
    }
}
