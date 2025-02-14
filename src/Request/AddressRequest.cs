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

using IP_Address_Lookup.src.Objects;
using ProxyCheck.Util;

namespace IP_Address_Lookup.src.Request
{
    internal class AddressRequest : BaseRequest
    {
        // Cached Public IP Address
        private string? Address { get; set; }

        public async Task<string?> GetPublicIP()
        {
            try
            {
                return (!string.IsNullOrEmpty(Address) ? Address : await _client.GetStringAsync(Constant.IpifyAPI));
            }
            catch (Exception e)
            {
                Utils.MessageBox(e.Message, "Ops! Não foi possível obter o IP da máquina.");
                return null;
            }
        }

        public async Task<string?> GetProxyCheckJson(string address, string token)
        {
            try
            {
                return await _client.GetStringAsync(string.Format(Constant.ProxyCheckAPI, address, token));
            }
            catch (Exception e)
            {
                Utils.MessageBox($"Ops! Não foi possível solicitar as informações do IP: {address}", e.Message);
                return null;
            }
        }
    }
}