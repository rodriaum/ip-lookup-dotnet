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

namespace ProxyCheck.Objects
{
    public class AddressInfoResponse
    {
        public string? ASN { get; set; }
        public string? Range { get; set; }
        public string? Provider { get; set; }
        public string? Organisation { get; set; }
        public string? Continent { get; set; }
        public string? ContinentCode { get; set; }
        public string? ISOCode { get; set; }
        public string? Region { get; set; }
        public string? RegionCode { get; set; }
        public string? Timezone { get; set; }
        public string? City { get; set; }
        public long? Latitude { get; set; }
        public long? Longitude { get; set; }
        public Currecy? Currecy { get; set; }
        public string? Proxy { get; set; }
        public string? Type { get; set; }
    }
}