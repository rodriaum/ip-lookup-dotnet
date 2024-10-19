using IP_Address_Lookup.src.Objects;

namespace IP_Address_Lookup.src.Request
{
    internal class AddressRequest : BaseRequest
    {
        public async Task<string?> GetPublicIP()
        {
            try
            {
                return await _client.GetStringAsync(Constant.IPIFY_API);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ops!");
                return null;
            }
        }
    }
}