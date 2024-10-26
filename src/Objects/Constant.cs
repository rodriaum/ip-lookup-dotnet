﻿/*
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

namespace IP_Address_Lookup.src.Objects
{
    internal class Constant
    {
        public static readonly string PROXY_CHECK_V2_API = "https://proxycheck.io/v2/{0}?key={1}?vpn=1&asn=1";
        public static readonly string IPIFY_API = "https://api.ipify.org/";
    }
}