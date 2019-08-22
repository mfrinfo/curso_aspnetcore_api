using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security {
    public class SigningConfigurations {
        public SecurityKey Key { get; }
        public SigningCredentials SigningCredentials { get; }

        public SigningConfigurations () {
            Key = new SymmetricSecurityKey (
                Encoding.UTF8.GetBytes ("CHAVE_Curso_De_Asp_Net_Core_API")
            );

        }
    }
}
