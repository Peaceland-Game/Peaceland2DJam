using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] string interactAxis = "Fire1";
    [SerializeField] float checkRadius;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] bool showGizmos;

    private bool holdInteract; 

    // Update is called once per frame
    void Update()
    {
        bool isInteract = Input.GetAxisRaw(interactAxis) > 0.0f;

        if (isInteract && !holdInteract)
        {
            // Test for interactables 
            Collider[] colliders = Physics.OverlapSphere(this.transform.position, checkRadius, interactableLayer);

            if (colliders.Length == 0)
                return;

            // Only interact with first collider 
            Interactable interactable = colliders[0].GetComponent<Interactable>();

            if (interactable != null)
                interactable.Interact(this.transform);
        }

        holdInteract = isInteract;
    }

    private void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.DrawWireSphere(this.transform.position, checkRadius);
        }
    }
}
