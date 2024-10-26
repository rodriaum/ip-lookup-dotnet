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
 * This project is an IP address lookup system developed in C#. Contributions are welcome!
 * 
 * Copyright (c) 2024 Rodrigo Ferreira
 */

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

        public async Task<string?> GetProxyCheckJson(string address, string token)
        {
            try
            {
                return await _client.GetStringAsync(string.Format(Constant.PROXY_CHECK_V2_API, address, token));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ops!");
                return null;
            }
        }
    }
}