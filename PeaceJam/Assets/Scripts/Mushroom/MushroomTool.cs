using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MushroomTool : MonoBehaviour
{
    [SerializeField] float spawnLength;
    [SerializeField] Vector2 leanDirA;
    [SerializeField] Vector2 leanDirB;
    [SerializeField] Vector2 tiltStrengthRange;

    [SerializeField] int spawnCount;

    [SerializeField] List<Mushroom> mushrooms;

    public void ResetMushrooms()
    {
        mushrooms.Clear(); 

        for (int i = 0; i < spawnCount; i++)
        {
            mushrooms.Add(
                new Mushroom(
                    Vector3.up * UnityEngine.Random.Range(-spawnLength * 0.5f, spawnLength * 0.5f), 
                    Vector3.up)
                );
        }
    }

    [Serializable]
    private class Mushroom
    {
        [SerializeField] public Vector3 pos;
        [SerializeField] public Vector3 up;

        public Mushroom(Vector3 pos, Vector3 up)
        {
            this.pos = pos;
            this.up = up;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.transform.position - this.transform.up * spawnLength * 0.5f, this.transform.position + this.transform.up * spawnLength * 0.5f);

        if (mushrooms == null)
            return;

        float lineLength = 0.3f;

        foreach (Mushroom m in mushrooms)
        {
            Vector3 pos = this.transform.TransformPoint(m.pos);

            Gizmos.color = Color.white;
            GizmosPlus.DrawWirePlaneNoX(pos, this.transform.TransformDirection(m.up), Vector3.one * 0.5f);

            Vector3 dirA = this.transform.TransformDirection(new Vector3(leanDirA.x, 0.0f, leanDirA.y));
            Vector3 dirB = this.transform.TransformDirection(new Vector3(leanDirB.x, 0.0f, leanDirB.y));

            Gizmos.color = Color.red;
            GizmosPlus.DrawWireArrow(pos, dirA, lineLength, 0.05f);
            Gizmos.color = Color.blue;
            GizmosPlus.DrawWireArrow(pos, dirB, lineLength, 0.05f);

            Vector3 mid = (dirA + dirB) / 2.0f;
            Gizmos.color = Color.green;
            GizmosPlus.DrawWireArrow(pos, mid, lineLength * 0.5f, 0.05f);

            // Draw lean direction 
        }

    }
}
