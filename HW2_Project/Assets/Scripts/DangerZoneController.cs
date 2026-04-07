using UnityEngine;
using TMPro;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    // YENÝ EKLENEN: Sýnav yöneticimiz
    [SerializeField] private FlightExamManager examManager;

    private Coroutine activeCountdown;

    private void Start()
    {
        if (warningText != null)
            warningText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (warningText != null) warningText.SetActive(true);

            // YENÝ EKLENEN: Yöneticiye haber ver
            if (examManager != null) examManager.EnterDangerZone();

            activeCountdown = StartCoroutine(CountdownAndLaunch(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (warningText != null) warningText.SetActive(false);

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            if (missileLauncher != null) missileLauncher.DestroyActiveMissile();

            // YENÝ EKLENEN: Yöneticiye füzeyi atlattýðýmýzý haber ver
            if (examManager != null) examManager.ExitDangerZone();
        }
    }

    private IEnumerator CountdownAndLaunch(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);
        if (missileLauncher != null) missileLauncher.Launch(target);
    }
}