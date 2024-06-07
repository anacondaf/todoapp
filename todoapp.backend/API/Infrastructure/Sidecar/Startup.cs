using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sidecar.KeyVault;

namespace Infrastructure.Sidecar.KeyVault;

public static class SidecarExtensions
{
    public static IServiceCollection UseKVConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var keyVaultSettings = configuration.GetSection(nameof(KeyVaultSettings)).Get<KeyVaultSettings>();

        if (keyVaultSettings != null && !string.IsNullOrEmpty(keyVaultSettings.Uri))
        {
            if (!string.IsNullOrEmpty(keyVaultSettings.ClientId) && !string.IsNullOrEmpty(keyVaultSettings.ClientSecret))
            {
                ClientSecretCredential clientCred = new ClientSecretCredential(keyVaultSettings.TenantId, keyVaultSettings.ClientId, keyVaultSettings.ClientSecret);

                var client = new SecretClient(new Uri(keyVaultSettings.Uri), clientCred);
                services.AddSingleton(client);
            }
        }

        return services;
    }
}
