using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class VaultManager : MonoBehaviour {
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int gold = 0;
    
    private readonly string _salt = "Secret_Naxhi_Key_2026";

    public string ComputeSecureHash(string rawData) {
        using (SHA512 sha512Hash = SHA512.Create()) {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(rawData + _salt);
            byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    public void SaveVault() {
        string data = $"{playerLevel}:{gold}"; 
        string integrityHash = ComputeSecureHash(data);

        PlayerPrefs.SetString("VaultData", data);
        PlayerPrefs.SetString("VaultHash", integrityHash);
        PlayerPrefs.Save();
        Debug.Log("Datos protegidos guardados.");
    }

    public void LoadVault() {
        string storedData = PlayerPrefs.GetString("VaultData");
        string storedHash = PlayerPrefs.GetString("VaultHash");

            if (ComputeSecureHash(storedData) != storedHash) {
            Debug.LogError("DETECCIÓN DE FRAUDE: El archivo de guardado ha sido alterado.");
            return;
        }

        Debug.Log("Carga segura completada.");
    }
}
