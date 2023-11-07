using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnchorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject anchorPrefab;

    private SpatialAnchorManager anchorManager;

    private bool isAnchorGenerating = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anchorManager = GameObject.Find("SpatialAnchorManager").GetComponent<SpatialAnchorManager>();
        if(anchorManager != null) Debug.Log("test test test");
    }

    // Update is called once per frame
    void Update()
    {
        if (anchorManager.isSceneLoaded && !isAnchorGenerating)
        {
            isAnchorGenerating = true;
            OnSceneLoaded();
        }
    }

    void OnSceneLoaded()
    {
        Debug.Log($"[Anchor loaded] {gameObject.GetComponent<OVRSemanticClassification>().Labels[0]}");
        var anchor = Instantiate(anchorPrefab);
        anchor.transform.position = gameObject.transform.position;
        StartCoroutine(generateAnchor(anchor.GetComponent<OVRSpatialAnchor>()));
    }

    IEnumerator generateAnchor(OVRSpatialAnchor anchor)
    {

        while (!anchor.Created)
        {
            Debug.Log("test 2");
            yield return new WaitForSeconds(1f);
        }
        
        anchor.Save(new OVRSpatialAnchor.SaveOptions{Storage = OVRSpace.StorageLocation.Local});
        Debug.Log($"[Anchor info] Uuid:{anchor.Uuid}, Name:{gameObject.GetComponent<OVRSemanticClassification>().Labels[0]}");
        anchorManager.anchorUuids.Add(anchor.Uuid.ToString());
        PlayerPerfsUtil.SaveList<string>("AnchorUuids", anchorManager.anchorUuids);
        
        yield break;
    }
}
