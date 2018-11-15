using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WallManager : MonoBehaviour {

    [SerializeField]
    private GameObject wallSegmentPrefab;

    public int wallSegmentsPerFace =5;
    public int wallFaces = 4;
    public float spacing=5;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            BuildWall();
        }
    }


    public void BuildWall() {

        // For each wall face -> Do
            // create parent GameObject for wall face
        // For each wall Segment -> Do
            // Instantiate segments for wall face and set to parent
            // move the block to it's position on the wall face
        for(int f=0; f<wallFaces; f++) {
            GameObject wall = new GameObject("wallFace_" + f);
            for(int s=0; s<wallSegmentsPerFace; s++) {
                GameObject segment = Instantiate(wallSegmentPrefab);
                segment.transform.SetParent(wall.transform);
                Vector3 offset = new Vector3(segment.transform.position.x, segment.transform.position.y, segment.transform.position.z+(spacing*s));
                segment.transform.position = offset;
            }
            Vector3 wallOffset = new Vector3(wall.transform.position.x, wall.transform.position.y, wall.transform.position.z + (f));
            wall.transform.position = wallOffset;
            wall.transform.Rotate(new Vector3(0, 90 * f, 0));
        }
    
    }

}
