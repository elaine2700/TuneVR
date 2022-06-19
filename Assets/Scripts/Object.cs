using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyEffect;
    [SerializeField] AudioClip destroySound;
    [SerializeField] float timeToDestroy = 1f;

    public bool hit = false;

    private void Start()
    {
        hit = false;
    }

    public void DestroyObject()
    {
        hit = true;
        GetComponentInChildren<Renderer>().enabled = false;
        Destroy(gameObject, timeToDestroy);
        destroyEffect.Play();
        // play clip sound
    }
}
