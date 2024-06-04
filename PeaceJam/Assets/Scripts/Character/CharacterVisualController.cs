using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterVisualController : MonoBehaviour
{

    [Header("Debug")]
    [SerializeField] Renderer renderer;
    [SerializeField] float speed;
    [SerializeField] AnimationCurve curve;

    [Header("Overall Visuals")]
    [SerializeField] EmotionalState emotionalState;

    [Header("Eyes")]
    [SerializeField] List<Renderer> eyes;

    private Material[] materials;

    private int activeCoroutines = 0;

    private void Start()
    {
        materials = renderer.materials;
    }

    // Update is called once per frame
    void Update()
    {
        DebugLogic();
        EyeLogic();
    }

    private void EyeLogic()
    {
        switch (emotionalState)
        {
            case EmotionalState.CONTENT:
                break;
            case EmotionalState.SLEEPY:
                break;
            case EmotionalState.STUNNED:
                break;
            case EmotionalState.ANGRY:
                break;
            case EmotionalState.PLEASE:
                break;
            case EmotionalState.JOYFUL:
                break;
        }
    }

    private enum EmotionalState
    { 
        CONTENT,
        SLEEPY,
        STUNNED,
        ANGRY,
        PLEASE,
        JOYFUL
    }


    #region Debug

    private void DebugLogic()
    {
        if (activeCoroutines > 0)
            return;

        bool shouldTransition = Input.GetKeyDown(KeyCode.T);

        if (shouldTransition)
        {
            foreach (Material mat in materials)
            {
                StartCoroutine(Transition(mat));
                activeCoroutines++;
            }
        }
    }

    private IEnumerator Transition(Material mat)
    {
        float lerp = mat.GetFloat("_NoiseType");
        print(lerp);
        if(lerp <= .001f)
        {
            while (lerp <= 1.0f)
            {
                mat.SetFloat("_NoiseType", curve.Evaluate(Mathf.PingPong(lerp, 1.0f)));

                lerp += speed * Time.deltaTime;
                yield return null;
            }
        }
        else
        {
            while (lerp >= 0.0f)
            {
                mat.SetFloat("_NoiseType", curve.Evaluate(Mathf.PingPong(lerp, 1.0f)));

                lerp -= speed * Time.deltaTime;
                yield return null;
            }
        }

        activeCoroutines--;
    }

    #endregion
}
