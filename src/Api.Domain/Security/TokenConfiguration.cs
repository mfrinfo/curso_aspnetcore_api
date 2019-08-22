using System;

namespace Api.Domain.Security {
    public class TokenConfiguration {
        public string Audience { get; set; } //publico
        public string Issuer { get; set; } //Emissor
        public int Seconds { get; set; } = 600;
    }
}
