using UnityEngine;

public class MissileLauncher : MonoBehaviour
{
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchPoint;
    [SerializeField] private AudioSource launchAudioSource;

    private GameObject activeMissile;

    public void Launch(Transform target)
    {
        if (activeMissile == null)
        {
            activeMissile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
            if (launchAudioSource != null) launchAudioSource.Play();
        }
    }

    public void DestroyActiveMissile()
    {
        if (activeMissile != null)
        {
            Destroy(activeMissile);
            activeMissile = null;
        }
    }
}