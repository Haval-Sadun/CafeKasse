using CafeKasse.MAUI.Interfaces;
using System.Net.Security;
using Xamarin.Android.Net;

namespace CafeKasse.MAUI.Platforms.Android
{
    public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new AndroidMessageHandler
            {

                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                    cert?.Issuer == "CN=localhost" || errors == SslPolicyErrors.None
            };

    }
}
