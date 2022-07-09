using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class Saber : MonoBehaviour
{
    public XRBaseController controller;
    XRRayInteractor rayInteractor;
    ScoreManager scoreManager;
    public float defaultamplitude = 0.2f;
    public float defaultduration = 0.5f;

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
                //if (hitObject.gameObject.layer == LayerMask.NameToLayer(colorLayer))
                //{
                    if (!hitObject.hit)
                    {
                        Debug.Log(hitObject.gameObject.layer);
                        controller.SendHapticImpulse(defaultamplitude,defaultduration);
                        hitObject.DestroyObject();
                        scoreManager.AddScore();
                    }
                        
                //}
            }
        }
    }
}
