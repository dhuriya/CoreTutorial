using Microsoft.AspNetCore.DataProtection;
namespace CoreActionResult;

public class MyCookieService
{
    private readonly IDataProtector _protector;
    public MyCookieService(IDataProtectionProvider dataProtectionProvider)
    {
        _protector = dataProtectionProvider.CreateProtector("SampleMVCWeb.CookieProtection");
    }
    // Method to encrypt (protect) the cookie value.
    public string Protect(string cookieValue)
    {
        try
        {
            return _protector.Protect(cookieValue);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while encrypting the cookie value.", ex);
        }
    }
    // Method to decrypt (unprotect) the encrypted cookie value.
    public string Unprotect(string protectedCookieValue)
    {
        try
        {
            return _protector.Unprotect(protectedCookieValue);
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while encrypting the cookie value.", ex);
        }
    }
}
