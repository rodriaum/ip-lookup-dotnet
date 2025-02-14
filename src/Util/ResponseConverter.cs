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

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using ProxyCheck.Objects;

namespace ProxyCheck.Util
{
    public class ResponseConverter : JsonConverter<AddressResponse>
    {
        public override AddressResponse? ReadJson(JsonReader reader, Type objectType, AddressResponse? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);

            if (obj == null)
            {
                Utils.MessageBox("Não foi possível ler um objeto JSON.");
                return null;
            }

            JToken? status = obj["status"];

            if (status == null)
            {
                Utils.MessageBox("Não foi possível ler um token JSON.");
                return null;
            }

            var response = new AddressResponse
            {
                Status = Utils.GetStatusByName(status.ToString()).GetValueOrDefault(),
                Proxies = new Dictionary<string, AddressInfoResponse>()
            };

            foreach (var property in obj.Properties())
            {
                if (property.Name != "status")
                {
                    JToken? token = property.Value;

                    if (token == null)
                    {
                        Utils.MessageBox("Não foi possível obter o token JSON.");
                        continue;
                    }

                    AddressInfoResponse? info = null;

                    try
                    {
                        info = token.ToObject<AddressInfoResponse>();
                    }
                    catch (Exception ex)
                    {
                        Utils.MessageBox("Não foi possível converter para um objeto JSON.", ex.Message);
                        continue;
                    }

                    response.Proxies[property.Name] = info;
                }
            }

            return response;
        }

        public override void WriteJson(JsonWriter writer, AddressResponse value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}