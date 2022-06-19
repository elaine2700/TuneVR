using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Saber : MonoBehaviour
{
    [SerializeField] string colorLayer;

    XRRayInteractor rayInteractor;
    ScoreManager scoreManager;

    void Start()
    {
        rayInteractor = GetComponentInParent<XRRayInteractor>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        bool rayCastDown = rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit raycastHit);
        if (rayCastDown)
        {
            raycastHit.collider.TryGetComponent<Object>(out var hitObject);
            if (hitObject != null)
            {
                if (hitObject.gameObject.layer == LayerMask.NameToLayer(colorLayer))
                {
                    if (!hitObject.hit)
                    {
                        Debug.Log(hitObject.gameObject.layer);
                        hitObject.DestroyObject();
                        scoreManager.AddScore();
                    }
                        
                }
            }
        }
    }
}
