using IP_Address_Lookup.src.Objects;
using IP_Address_Lookup.src.Request;
using ProxyCheckUtil;
using System.Net;
using System.Reflection;


namespace IP_Address_Lookup
{
    public partial class LookupForm : Form
    {
        public LookupForm()
        {
            InitializeComponent();
        }

        private void LookupForm_Load(object sender, EventArgs e) { }

        private async void AddressTextBox_KeyDownAsync(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Clear the results of the last query.
                resultCustomListBox.Items.Clear();

                // General address request.
                AddressRequest request = new AddressRequest();

                resultCustomListBox.Items.Add("A pegar o endereço IP...");

                string? address = addressTextBox.Text;

                if (string.IsNullOrEmpty(address))
                {
                    address = await request.GetPublicIP();
                }

                if (address == null) return;

                resultCustomListBox.Items.Add("Endereço IP: " + address);

                // The API where the information will be retrieved.
                ProxyCheck proxyCheck = new ProxyCheck(Constant.PROXY_CHECK_KEY);
                if (proxyCheck == null) return;

                resultCustomListBox.Items.Add("A iniciar pedido de informações ao endereço IP...");

                // The result returned in json.
                ProxyCheckResult? result = null;

                try
                {
                     result = await proxyCheck.QueryAsync(address);
                } 
                catch (Exception)
                {
                    resultCustomListBox.Items.Add("O endereço IP mencionado é inválido.");
                }

                if (result == null) return;

                resultCustomListBox.Items.Add("Pedido retornado com sucesso.");

                // Gets the geo informations.
                result.Results.TryGetValue(IPAddress.Parse(address), out ProxyCheckResult.IpResult? info);
                if (info == null) return;


                resultCustomListBox.Items.Add("Está quase...");

                // Clear the results of the last query.
                resultCustomListBox.Items.Clear();

                // Iterate through the properties and prints their names and values.
                foreach (PropertyInfo property in info.GetType().GetProperties())
                {
                    resultCustomListBox.Items.Add($"{property.Name}: {property.GetValue(info)}");
                }

                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}
