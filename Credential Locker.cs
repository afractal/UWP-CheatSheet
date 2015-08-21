// Encrypted. roamed storage for PasswordCredential objects

private void SaveCredential(string username, string password)
{
    PasswordVault vault = new PasswordVault();
    PasswordCredential cred = 
    new PasswordCredential("MyAppResource", username, password);
    vaulr.Add(cred);
}

private IReadOnlyList<PasswordCredential> RetrieveCredential(string resource)
{
    PasswordVault vault = new PasswordVault();
    return vault.FindAllByResource(resource);
}
