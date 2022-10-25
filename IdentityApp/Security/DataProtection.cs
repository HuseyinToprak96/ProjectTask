using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Web.Security
{
    public class DataProtection
    {
        private readonly IDataProtector _dataProtector;
        public DataProtection(IDataProtectionProvider dataProtectionProvider, string code)
        {
            _dataProtector = dataProtectionProvider.CreateProtector(code);
        }
        public string Encrypt(int Decrypt)
        {
            var timeLimitedDataProtector = _dataProtector.ToTimeLimitedDataProtector();
            return timeLimitedDataProtector.Protect(Decrypt.ToString());
        }
        public int Decrypt(string Encrypt)
        {
            var timeLimitedDataProtector = _dataProtector.ToTimeLimitedDataProtector();
            return int.Parse(timeLimitedDataProtector.Unprotect(Encrypt));
        }
    }
}
