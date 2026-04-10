using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class VaultManager : MonoBehaviour
{
    
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int gold = 0;

   
    private readonly string _salt = "Secret_Naxhi_Key_2026";

   
    private const string VAULT_DATA_KEY = "VaultData";
    private const string VAULT_HASH_KEY = "VaultHash";

  
    public string ComputeSecureHash(string rawData)
    {
        using (SHA512 sha512 = SHA512.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(rawData + _salt);
            byte[] hashBytes = sha512.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }

    public void SaveVault()
    {
        string data = $"{playerLevel}:{gold}";
        string hash = ComputeSecureHash(data);

        PlayerPrefs.SetString(VAULT_DATA_KEY, data);
        PlayerPrefs.SetString(VAULT_HASH_KEY, hash);
        PlayerPrefs.Save();

        Debug.Log("Vault guardado con integridad.");
    }

    
    public void LoadVault()
    {
        if (!PlayerPrefs.HasKey(VAULT_DATA_KEY) || !PlayerPrefs.HasKey(VAULT_HASH_KEY))
        {
            throw new Exception("Error de seguridad: no existen datos del Vault.");
        }

        string storedData = PlayerPrefs.GetString(VAULT_DATA_KEY);
        string storedHash = PlayerPrefs.GetString(VAULT_HASH_KEY);

        string computedHash = ComputeSecureHash(storedData);

        if (computedHash != storedHash)
        {
            throw new Exception("Error de seguridad: los datos del Vault han sido manipulados.");
        }

        string[] parts = storedData.Split(':');

        if (parts.Length == 2)
        {
            playerLevel = int.Parse(parts[0]);
            gold = int.Parse(parts[1]);
        }

        Debug.Log("Carga segura completada.");
    }
}