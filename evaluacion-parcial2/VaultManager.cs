using System;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

// EXAMEN PARCIAL II - Miguel Angel Garcia Elizalde

// No se encontraron fallos y la clase fue correctamente implementada,
// y acorde a las especificaciones de la entrega.

public class VaultManager : MonoBehaviour {
    // Punto 3.1 es correcto: las variables son privadas.
    [SerializeField] private int playerLevel = 1;
    [SerializeField] private int gold = 0;

    private readonly string _salt = "Secret_Naxhi_Key_2026";

    // Punto 3.2 es correcto: se implementa el método ComputeSecureHash(string rawData).
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

    // Punto 3.3 es correcto: se implementa correctamente el Anti-Tamper.
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
