using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Api.Domain.Security
{
    public class SigningConfigurations
    {
        /*
          /A Propriedade Key, é uma instancia da classe SecurityKey 
          (namespace Microsoft.IdentityModel.Tokens) 
          irá armazenar a chave de criptografia utilizada na criação de Tokens
        */
        public SecurityKey Key { get; }
        /*
          Receberá um objeto baseado em uma classe SigningCredentials.
          Esta Referencia conterá a chave de criptografia e o Algoritmo de 
          segurança empregados na geração de Assinaturas digitais para os tokens
         */
        public SigningCredentials SigningCredentials { get; }


        /*
          O Construtor responsável para inicialização das propriedades key e 
          SigningCredentials
          Este elemento fará uso para isto dos tipos RSACryptoServiceProvider
         */
        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            SigningCredentials = new SigningCredentials(
                Key, SecurityAlgorithms.RsaSha256Signature);

        }
    }
}
