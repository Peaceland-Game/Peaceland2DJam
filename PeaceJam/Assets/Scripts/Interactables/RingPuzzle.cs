using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzle : Interactable
{
    [SerializeField] Delay ringPuzzleManager;
    [SerializeField] GameObject ringPuzzleObj;
    [SerializeField] float walkawayRange;
    private Transform player;

    private void Start()
    {
        ringPuzzleObj.SetActive(false);
    }

    private void Update()
    {
        if(player != null)
        {
            if(Vector3.Distance(this.transform.position, player.transform.position) > walkawayRange)
            {
                print("test");
                ringPuzzleManager.canRun = false;
            }
        }

        if(ringPuzzleManager.isComplete)
        {
            // Close game open door 

            ringPuzzleObj.SetActive(false);
        }
    }

    public override void Interact(Transform source)
    {
        if (ringPuzzleManager.isComplete)
            return;

        player = source;

        ringPuzzleObj.SetActive(true);
        ringPuzzleManager.canRun = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, walkawayRange);
    }
}
