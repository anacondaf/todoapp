namespace Sidecar.KeyVault;

public class KeyVaultSettings
{
    public string KeyVaultName { get; set; } = default!;
    public string Uri { get; set; } = default!;
    public string ClientId { get; set; } = default!;
    public string ClientSecret { get; set; } = default!;
    public string TenantId { get; set; } = default!;
}
