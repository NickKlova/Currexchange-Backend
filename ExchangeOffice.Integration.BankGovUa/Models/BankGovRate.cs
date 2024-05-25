﻿using Newtonsoft.Json;

namespace ExchangeOffice.Integration.BankGov.Models
{
    public class BankGovRate
    {
        [JsonProperty("r030")]
        public string? Id { get; set; }
        [JsonProperty("cc")]
        public string? Code { get; set; }
        [JsonProperty("txt")]
        public string? Description { get; set; }
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
    }
}
