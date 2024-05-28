using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CamFocusAndDialogue : Interactable
{
    private List<string> allText;

    [Tooltip("Text that the player doesn't directly respond to.")]
    [SerializeField] List<string> myLines;
    [Tooltip("Text that the player directly responds to.")]
    [SerializeField] List<string> myQuestions;

    [Tooltip("Text that the player responds with.")]
    [SerializeField] List<string> playerLines;

    [SerializeField] GameObject dialogueObject;
    [SerializeField] TextMeshPro myText;
    [SerializeField] TextMeshPro playerTextOp1;
    [SerializeField] TextMeshPro playerTextOp2;

    [Tooltip("If player walks away duringa conversation at the given distance, dialgoue will close")]
    [SerializeField] float endDialogueRange;

    [Tooltip("Unfocuses from this interactable if player goes out of range")]
    [SerializeField] CinemachineVirtualCamera cam;

    [SerializeField][Range(0.0f, 1.0f)] float showTextThreshold;
    [Space]
    [SerializeField] Transform dialogueTrans;
    [SerializeField] float dialogueIncreaseRate;
    [SerializeField] float dialogueDecreaseRate;
    [SerializeField] Vector3 dialogueStartScale;
    [SerializeField] Vector3 dialogueTargetScale;
    [SerializeField] AnimationCurve dialogueCurveScaleX;
    [SerializeField] AnimationCurve dialogueCurveScaleY;

    private CameraManager manager;
    private bool focused;

    private int currentText = 0;
    private float dialogueLerp;

    private Transform listener;

    private NPCState state;

    private void Start()
    {
        currentText = 0;
        dialogueLerp = 0.0f;
    }

    public override void Interact(Transform source)
    {
        if(state != NPCState.TALKING && state != NPCState.END_CONVO)
        {
            //print("test");
            if (manager == null)
                return;

            Debug.Log("Current cam is: " + cam);

            manager.SwapCamera(cam);
            focused = true;

            Debug.Log("Current cam is: " + cam);

            this.listener = source;

            //base.Interact(source);

            // Startup dialogue 
            state = NPCState.TALKING;

            Debug.Log("Conversation started");
        }
    }

    private void Update()
    {
        DialogueStateMachine(); // Logic
        DialogueVisual();       // Dialogue box visual 
    }

    private void DialogueStateMachine()
    {
        switch (state)
        {
            case NPCState.IDLE: // Wait for interact call 
                break;
            case NPCState.TALKING:
                DialogueLogic();
                break;
            case NPCState.END_CONVO:
                EndConversation();
                break;
        }
    }

    /// <summary>
    /// Manages what is happening during a conversation 
    /// </summary>
    private void DialogueLogic()
    {
        // Make sure player is within distance
        if (listener)
        {
            if (Vector3.Distance(listener.transform.position, this.transform.position) >= endDialogueRange && focused)
            {
                ResetDialogueText();
                state = NPCState.END_CONVO;
                manager.SwapToMainCam();
                focused = false;
            }
        }

        if (dialogueLerp < showTextThreshold)
            return;

        myText.text = myLines[currentText];

        if (Input.GetMouseButtonDown(0))
        {
            // Close dialogue if end reached
            if (currentText + 1 >= myLines.Count)
            {
                Debug.Log("Conversation ended");
                ResetDialogueText();
                state = NPCState.END_CONVO;
                manager.SwapToMainCam();
                focused = false;

                return;
            }

            currentText++;
        }
    }

    /// <summary>
    /// Ends conversation and does not allow to start a new dialogue until close
    /// dialogue box has gone past threshold 
    /// </summary>
    private void EndConversation()
    {
        if (dialogueLerp <= showTextThreshold)
        {
            state = NPCState.IDLE;
            print("Hello");
        }
    }

    private void ResetDialogueText()
    {
        currentText = 0;
    }

    /// <summary>
    /// Animates the dialogue box 
    /// </summary>
    private void DialogueVisual()
    {
        if (state != NPCState.TALKING)
        {
            dialogueLerp = Mathf.Clamp01(dialogueLerp - dialogueDecreaseRate * Time.deltaTime);
            myText.text = "";
        }
        else
        {
            dialogueLerp = Mathf.Clamp01(dialogueLerp + dialogueIncreaseRate * Time.deltaTime);
        }

        float scaleX = Mathf.LerpUnclamped(dialogueStartScale.x, dialogueTargetScale.x, dialogueCurveScaleX.Evaluate(dialogueLerp));
        float scaleY = Mathf.LerpUnclamped(dialogueStartScale.y, dialogueTargetScale.y, dialogueCurveScaleY.Evaluate(dialogueLerp));
        dialogueTrans.localScale = new Vector3(scaleX, scaleY, 1.0f);
    }

    public void ResetThisFocus()
    {
        manager.SwapToMainCam();
    }

    private void OrganizeLines()
    {

    }

    private void Awake()
    {
        manager = GameObject.FindObjectOfType<CameraManager>();
        if (manager == null)
            Debug.LogError("Camera manager not in scene");

        if (cam == null)
            Debug.LogError("Cam not attached to this script");

        focused = false;
    }

    private enum NPCState
    {
        IDLE,
        TALKING,
        WAITING_FOR_RESPONSE,
        END_CONVO
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(this.transform.position, endDialogueRange);
    }
}
