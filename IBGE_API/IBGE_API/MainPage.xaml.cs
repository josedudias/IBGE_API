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
        public MainPage()
        {
            InitializeComponent();
            OnLoad();
        }

        private const string Url = "https://servicodados.ibge.gov.br/api/v1/" + 
            "localidades/estados";
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Estados> _estados;

        private async void OnLoad()
        {
            string Estados = await _client.GetStringAsync(Url);
            List<Estados> posts = JsonConvert.DeserializeObject<List<Estados>>(Estados);
            _estados = new ObservableCollection<Estados>(posts);
            lvEstados.ItemsSource = _estados;
        }

        private void PickerSelect(object sender, EventArgs e)
        {
            var selecao = pkEstados.Items[pkEstados.SelectedIndex];

            
        }
    }
}
