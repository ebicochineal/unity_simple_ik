using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxisJoint : MonoBehaviour {
    public Axis axis;
    
    void OnDrawGizmos () {
        Vector3 a = this.transform.position;
        Vector3 size = Vector3.one * 0.05f;
        
        if (this.axis == Axis.X) {
            Gizmos.color = Color.red;
            for (int i = 0; i < 10; i++) {
                Vector3 b = this.transform.TransformPoint(Vector3.right*(i*0.05f));
                Gizmos.DrawWireCube(b, size);
            }
        }
        if (this.axis == Axis.Y) {
            Gizmos.color = Color.green;
            for (int i = 0; i < 10; i++) {
                Vector3 b = this.transform.TransformPoint(Vector3.up*(i*0.05f));
                Gizmos.DrawWireCube(b, size);
            }
        }
        if (this.axis == Axis.Z) {
            Gizmos.color = Color.blue;
            for (int i = 0; i < 10; i++) {
                Vector3 b = this.transform.TransformPoint(Vector3.forward*(i*0.05f));
                Gizmos.DrawWireCube(b, size);
            }
        }
    }
}
