using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyEffect;
    [SerializeField] AudioClip destroySound;
    [SerializeField] float timeToDestroy = 1f;

    public void DestroyObject(bool hitByPlayer)
    {
        Destroy(gameObject, timeToDestroy);
        if (hitByPlayer)
        {
            // show effect
            // play sound
        }
    }
}
