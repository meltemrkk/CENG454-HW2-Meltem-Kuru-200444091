using UnityEngine;

public class LandingAreaController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;

    private void OnTriggerEnter(Collider other)
    {
        // Uçak iniþ pistine girdiðinde yöneticiye inmek istediðini söyle
        if (other.CompareTag("Player"))
        {
            if (examManager != null)
            {
                examManager.LandAircraft();
            }
        }
    }
}