using UnityEngine;
using TMPro;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

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
            if (warningText != null)
                warningText.SetActive(true);

            activeCountdown = StartCoroutine(CountdownAndLaunch(other.transform));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (warningText != null)
                warningText.SetActive(false);

            if (activeCountdown != null)
            {
                StopCoroutine(activeCountdown);
                activeCountdown = null;
            }

            if (missileLauncher != null)
            {
                missileLauncher.DestroyActiveMissile();
            }
        }
    }

    private IEnumerator CountdownAndLaunch(Transform target)
    {
        yield return new WaitForSeconds(missileDelay);

        if (missileLauncher != null)
        {
            missileLauncher.Launch(target);
        }
    }
}