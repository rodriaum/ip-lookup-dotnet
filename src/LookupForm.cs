/*
 * MIT License
 * 
 * This software is provided under the MIT License, a permissive license that allows for the use, copying, modification, 
 * merging, publishing, distribution, sublicensing, and sale of copies of the software, as long as the original 
 * permission and disclaimer are included in all copies or substantial portions of the software.
 * 
 * For more details about the MIT License and its terms, please refer to:
 * https://github.com/rodriaum/IP-Address-Lookup?tab=MIT-1-ov-file#readme
 * 
 * This project is an IP address lookup system developed in C#.
 * 
 * Copyright (c) 2024 Rodrigo Ferreira
 */

using IP_Address_Lookup.src.Request;
using IP_Address_Lookup.src.Request.Response.Info;
using Newtonsoft.Json;
using ProxyCheck.Objects;
using ProxyCheck.Util;
using System.Text.RegularExpressions;

namespace IP_Address_Lookup
{
    public partial class LookupForm : Form
    {
        public LookupForm()
        {
            InitializeComponent();
        }

        private void LookupForm_Load(object sender, EventArgs e)
        {
            DotNetEnv.Env.Load();
        }

        private async void AddressTextBox_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resultCustomListBox.Items.Clear();
                resultCustomListBox.Items.Add("A pegar o endereço IP...");

                string? address = await GetAddressAsync();
                if (address == null) return;

                resultCustomListBox.Items.Add("Endereço IP: " + address);

                string? token = GetApiToken();
                if (token == null) return;

                var response = await GetAddressInfoAsync(address, token);
                if (response == null) return;

                DisplayAddressInfo(response);

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private async Task<string?> GetAddressAsync()
        {
            string? address = addressTextBox.Text
                .Replace("\n", ""); // TextBox Multiline

            if (string.IsNullOrWhiteSpace(address))
            {
                AddressRequest request = new AddressRequest();
                address = await request.GetPublicIP();
            }

            // If it is still null, it returns nothing.
            if (address == null) return null;

            if (!Regex.IsMatch(address, @"^(?:\d{1,3}\.){3}\d{1,3}$"))
            {
                MessageBox.Show("O endereço deve estar no formato correto (ex: 192.168.1.1)");
                return null;
            }

            // As it is a Multiline TextBox, when you press enter the line will break
            // and the old IP will remain on top, which is why we clear the TextBox.
            addressTextBox.Clear();

            return address;
        }

        private string? GetApiToken()
        {
            string? token = DotNetEnv.Env.GetString("PROXY_CHECK_API_KEY", "lqs0xz-6208u4-012607-446xw2");

            if (string.IsNullOrEmpty(token))
            {
                resultCustomListBox.Items.Add("Não foi possível obter o token da API ProxyCheck.");
            }

            return token;
        }

        private async Task<AddressResponse?> GetAddressInfoAsync(string address, string token)
        {
            AddressRequest request = new AddressRequest();

            var json = await request.GetProxyCheckJson(address, token);

            if (json == null)
            {
                resultCustomListBox.Items.Add("Não foi possível pegar o resultado da resposta da API.");
                return null;
            }

            resultCustomListBox.Items.Add("A iniciar pedido de informações ao endereço IP...");

            return JsonConvert.DeserializeObject<AddressResponse>(json, new ResponseConverter());
        }

        private void DisplayAddressInfo(AddressResponse response)
        {
            resultCustomListBox.Items.Add("Pedido retornado com sucesso.");
            resultCustomListBox.Items.Clear();

            Dictionary<string, AddressInfoResponse>? proxies = response.Proxies;

            if (proxies == null)
            {
                resultCustomListBox.Items.Add("Não foi possível pegar as informações dos proxies.");
                return;
            }

            AddressInfoResponse? proxy = proxies.Values.FirstOrDefault();

            if (proxy == null)
            {
                resultCustomListBox.Items.Add("Não foi possível pegar as informações do proxy.");
                return;
            }

            statusLabel.Text = response.Status.ToString();

            foreach (var property in Utils.GetProperties(proxy))
            {
                resultCustomListBox.Items.Add($"{property.Key}: {property.Value}");
            }
        }
    }
}