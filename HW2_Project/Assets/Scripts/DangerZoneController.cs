using UnityEngine;
using TMPro; // Yazý kontrolü için bu þart

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private GameObject warningText; // Hazýrladýðýn kýrmýzý yazýyý buraya baðlayacaðýz

    private void Start()
    {
        // Oyun baþýnda yazýnýn kapalý olduðundan emin olalým
        if (warningText != null)
            warningText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eðer giren objenin etiketi "Player" ise yazýyý aç
        if (other.CompareTag("Player"))
        {
            if (warningText != null)
                warningText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eðer çýkan objenin etiketi "Player" ise yazýyý kapat
        if (other.CompareTag("Player"))
        {
            if (warningText != null)
                warningText.SetActive(false);
        }
    }
}