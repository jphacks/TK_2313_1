using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using static OVRSpace;
using static OVRSpatialAnchor;

public class SpatialAnchorManager : MonoBehaviour
{
    [SerializeField]
    OVRSpatialAnchor anchorPrefab;
    [SerializeField]
    public List<string> anchorUuids;

    // Start is called before the first frame update
    void Start()
    {
        anchorUuids = PlayerPerfsUtil.LoadList<string>("AnchorUuids");

        List<Guid> temp = new List<Guid>();
        foreach (string uuid in anchorUuids)
        {
            temp.Add(Guid.Parse(uuid));
        }

        Debug.Log("[Anchor test] Anchor Loading");
        OVRSpatialAnchor.LoadUnboundAnchors(new OVRSpatialAnchor.LoadOptions { StorageLocation = StorageLocation.Local, Uuids = temp }, OnUnboundAnchorsLoaded);
    }

    void OnUnboundAnchorsLoaded(UnboundAnchor[] unboundAnchors)
    {
        foreach (UnboundAnchor unboundAnchor in unboundAnchors)
        {
            unboundAnchor.Localize(OnUnboundAnchorLocalized, 100.0);
        }
        Debug.Log("[Anchor test] Anchor Localized");
    }

    void OnUnboundAnchorLocalized(UnboundAnchor unboundAnchor, bool success)
    {
        if (success)
        {
            var pose = unboundAnchor.Pose;
            var spatialAnchor = Instantiate(anchorPrefab, pose.position, pose.rotation);
            //spatialAnchor.GetComponent<TextMeshProUGUI>().text = unboundAnchor.Uuid.ToString();
            unboundAnchor.BindTo(spatialAnchor);
            Debug.Log("[Anchor test] Anchor binded");
        }
    }
}
