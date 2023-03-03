using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;
using System.Text;

namespace MovieStoreWebApi.Chiper
{
    public class Chipers
    {
        private readonly IDataProtectionProvider _dataProtectionProvider;
        private readonly string _key;
        public Chipers(IDataProtectionProvider dataProtectionProvider, string key)
        {
            _dataProtectionProvider = dataProtectionProvider;
            _key = key;
        }
        public string Encrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(_key);
            return protector.Protect(input);
        }

        public string Decrypt(string input)
        {
            var protector = _dataProtectionProvider.CreateProtector(_key);
            return protector.Unprotect(input);
        }
    }
}
