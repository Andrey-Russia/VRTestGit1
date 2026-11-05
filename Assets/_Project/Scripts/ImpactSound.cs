using UnityEngine;

public sealed class ImpactSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] impactClips;
    [SerializeField] private float _minimumImpactSpeed = 0.7f;
    [SerializeField] private float _maximumImpactSpeed = 5f;
    [SerializeField] private float _minimumVolume = 0.15f;
    [SerializeField] private float _maximumVolume = 0.85f;
    [SerializeField] private float _cooldown = 0.12f;
    [SerializeField] private AudioSource _source;

    private AudioSource _audioSource;
    private float _lastImpactTime = float.NegativeInfinity;

    private void Awake()
    {
        _audioSource = _source; ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        float impactSpeed = collision.relativeVelocity.magnitude;

        if (impactClips == null || impactClips.Length == 0 || impactSpeed < _minimumImpactSpeed || Time.time - _lastImpactTime < _cooldown)
            return;

        AudioClip clip = impactClips[Random.Range(0, impactClips.Length)];
        float maximumSpeed = Mathf.Max(_maximumImpactSpeed, _minimumImpactSpeed + 0.01f);
        float intensity = Mathf.InverseLerp(_minimumImpactSpeed, maximumSpeed, impactSpeed);
        float volume = Mathf.Lerp(_minimumVolume, _maximumVolume, intensity);

        _audioSource.PlayOneShot(clip, volume);
        _lastImpactTime = Time.time;
    }
}