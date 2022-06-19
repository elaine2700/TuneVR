using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Selector : MonoBehaviour
{
    XRRayInteractor rayInteractor;

    // Start is called before the first frame update
    void Start()
    {
        rayInteractor = GetComponentInParent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        // todo finish this rayInteractor.TryGetCurrent3DRaycastHit()
    }
}
