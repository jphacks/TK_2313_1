using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;
using static OVRSpace;
using static OVRSpatialAnchor;

public class WorldLockedObjectController : MonoBehaviour
{
    public static WorldLockedObjectController Instance { get; private set; }
    [SerializeField]
    OVRSpatialAnchor anchorPrefab;
    private List<OVRSpatialAnchor> Anchors = new List<OVRSpatialAnchor>();

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void LoadAllAnchors()
    {
        //OVRSpatialAnchor.LoadUnboundAnchors(new OVRSpatialAnchor.LoadOptions { StorageLocation = StorageLocation.Local, Uuids = temp }, OnUnboundAnchorsLoaded);
    }

    public async void LoadAllObjects()
    {
    }

    public async void AddObject(GameObject obj)
    {
    }

    void OnUnboundAnchorsLoaded(UnboundAnchor[] unboundAnchors)
    {
        foreach (UnboundAnchor unboundAnchor in unboundAnchors)
        {
            unboundAnchor.Localize(OnUnboundAnchorLocalized);
        }
    }

    void OnUnboundAnchorLocalized(UnboundAnchor unboundAnchor, bool success)
    {
        if (success)
        {
            var pose = unboundAnchor.Pose;
            var spatialAnchor = Instantiate(anchorPrefab, pose.position, pose.rotation);


            unboundAnchor.BindTo(spatialAnchor);
            var anchorView = spatialAnchor.gameObject.GetComponent<AnchorView>();
            anchorView.Uuid = spatialAnchor.Uuid.ToString();
            anchorView.binded = true;
        }
    }
}
