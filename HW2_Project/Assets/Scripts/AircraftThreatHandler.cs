using UnityEngine;
using UnityEngine.SceneManagement; // Ceza olarak sahneyi yeniden baþlatmak için gerekli

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private AudioSource hitAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        // Çarpan obje "Missile" etiketine sahipse
        if (other.CompareTag("Missile"))
        {
            if (hitAudioSource != null)
            {
                hitAudioSource.Play();
            }

            // Füze uçaðý vurdu: Basit ve hatasýz ceza olarak bölümü baþtan baþlat
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}