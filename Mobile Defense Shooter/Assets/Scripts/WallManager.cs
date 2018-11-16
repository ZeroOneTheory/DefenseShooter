using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;

public class WallManager : MonoBehaviour {

    public GameObject wallCenter;

    private int wallSegmentCount;
    public List<Transform> wallFaceSegments = new List<Transform>();
    public List<Transform> wallSegments = new List<Transform>();

    private void Awake() {
        foreach(Transform wallFace in wallCenter.transform) {
            wallFaceSegments.Add(wallFace.transform);
            foreach (Transform segment in wallFace) {
                wallSegments.Add(segment.transform);
            }
        }
    }

    public Transform GetNewDestinationTransform() {
        int selection = Random.Range(0, wallSegments.Count - 1);
        return wallSegments[selection].transform;

    }


}
