using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnchorGenerator : MonoBehaviour
{
    OVRSceneManager sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.Find("OVRSceneManager").GetComponent<OVRSceneManager>();
        sceneManager.SceneModelLoadedSuccessfully += OnSceneLoaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSceneLoaded()
    {

    }
}
