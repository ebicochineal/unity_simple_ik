﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBones : MonoBehaviour {
    public bool draw = true;
    void OnDrawGizmos() {
        if (this.draw) { this.DrawChildBone(this.transform); }
    }
    
    void OnDrawGizmosSelected () {
        this.DrawChildBone(this.transform);
    }
    
    void DrawChildBone (Transform t) {
        Gizmos.color = Color.green;
        for (int i = 0; i < t.childCount; ++i) {
            this.DrawBone(t.position, t.GetChild(i).position, 0.1f);
            this.DrawChildBone (t.GetChild(i));
        }
    }
    
    void DrawBone (Vector3 a, Vector3 b, float size) {
        Gizmos.DrawLine(a, b);
        Gizmos.DrawWireCube(a, new Vector3(size, size, size));
        Gizmos.DrawWireCube(b, new Vector3(size, size, size));
    }
}


