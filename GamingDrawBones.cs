using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingDrawBones : MonoBehaviour {
    public bool draw = true;
    int time = 0;
    int bone_depth = 0;
    
    void OnDrawGizmos () {
        this.time += 1;
        this.bone_depth = 0;
        if (this.draw) { this.DrawChildBone(this.transform, 0); }
    }
    
    void DrawChildBone (Transform t, int depth) {
        Gizmos.color = GamingColor.ValueToColor(this.time*8 + depth * 128);
        for (int i = 0; i < t.childCount; ++i) {
            this.DrawBone(t.position, t.GetChild(i).position, 0.1f);
        }
        for (int i = 0; i < t.childCount; ++i) {
            this.DrawChildBone (t.GetChild(i), depth+1);
        }
    }
    
    void DrawBone (Vector3 a, Vector3 b, float size) {
        Gizmos.DrawLine(a, b);
        Gizmos.DrawWireCube(a, new Vector3(size, size, size));
        Gizmos.DrawWireCube(b, new Vector3(size, size, size));
    }
}
