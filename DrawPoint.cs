using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPoint : MonoBehaviour {
    public bool draw = true;
    [Range(0f, 8f)] public float size = 0.25f;
    void OnDrawGizmos () {
        Gizmos.color = Color.white;
        if (this.draw) { Gizmos.DrawWireCube(this.transform.position, new Vector3(this.size, this.size, this.size)); }
    }
    void OnDrawGizmosSelected () {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(this.transform.position, new Vector3(this.size, this.size, this.size));
    }
}