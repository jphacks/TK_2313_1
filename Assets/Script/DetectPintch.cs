using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPintch : MonoBehaviour
{
    [SerializeField]
    MicController micController;

    private OVRHand hand; 


    bool isRecording = false;
    // Start is called before the first frame update
    void Start()
    {
        hand = GetComponent<OVRHand>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hand.GetFingerIsPinching(OVRHand.HandFinger.Thumb) && !isRecording)
        {
            Debug.Log("Pintching");
            StartCoroutine(waiting());
            micController.StartMicRec();
        }
    }

    IEnumerator waiting()
    {
        isRecording = true;

        yield return new WaitForSeconds(15);

        isRecording = false;

        yield break;
    }
}
