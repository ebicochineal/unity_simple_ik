using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisIK : MonoBehaviour {
    public bool drawchain = true;
    public bool reset = true;
    public Transform target;
    [Range(1, 1024)] public int iteration = 64;
    [Range(1, 64)] public int chain = 1;
    [Range(0f, 1f)] public float breakdist = 0.05f;
    List<Quaternion> rotations = new List<Quaternion>();
    List<Axis> axiss = new List<Axis>();
    
    void Start () {
        Transform t = this.transform;
        for (int i = 0; i < this.chain; ++i) {
            t = t.parent;
            this.rotations.Add(t.localRotation);
            
            AxisJoint j = t.GetComponent<AxisJoint>();
            if (j != null) {
                this.axiss.Add(j.axis);
            } else {
                this.axiss.Add(Axis.ALL);
            }
        }
    }
    
    void LateUpdate () {
        if (this.reset) { this.ResetLocalRotations(); }
        
        float n = (1f / this.chain) * 0.25f;
        for (int i = 0; i < this.iteration; ++i) {
            Transform t = this.transform;
            if (Vector3.Distance(this.target.position, this.transform.position) < this.breakdist) { return; }
            for (int j = 0; j < this.chain; ++j) {
                t = t.parent;
                float p = n * (j+1);
                if (this.axiss[j] == Axis.ALL) {
                    Vector3 a = this.target.position - t.position;
                    Vector3 b = this.transform.position - t.position;
                    t.localRotation *= Quaternion.AngleAxis(-Vector3.Angle(a, b) * p, t.InverseTransformDirection(Vector3.Cross(a, b)));
                } else if (this.axiss[j] != Axis.LOCK) {
                    Vector3 a =  t.InverseTransformPoint(this.target.position);
                    Vector3 b =  t.InverseTransformPoint(this.transform.position);
                    Vector3 o =  t.InverseTransformPoint(t.position);
                    if (this.axiss[j] == Axis.X) {
                        a = new Vector3(0f, a.y, a.z);
                        b = new Vector3(0f, b.y, b.z);
                        o = new Vector3(0f, o.y, o.z);
                    } else if (this.axiss[j] == Axis.Y) {
                        a = new Vector3(a.x, 0f, a.z);
                        b = new Vector3(b.x, 0f, b.z);
                        o = new Vector3(o.x, 0f, o.z);
                    } else if (this.axiss[j] == Axis.Z) {
                        a = new Vector3(a.x, a.y, 0f);
                        b = new Vector3(b.x, b.y, 0f);
                        o = new Vector3(o.x, o.y, 0f);
                    }
                    t.localRotation *= Quaternion.AngleAxis(-Vector3.Angle(a, b) * p, Vector3.Cross(a, b));
                }
            }
        }
    }
    
    void ResetLocalRotations () {
        Transform t = this.transform;
        for (int i = 0; i < this.chain; ++i) {
            t = t.parent;
            t.localRotation = this.rotations[i];
        }
    }
    
    void OnDrawGizmos () {
        if (this.drawchain) {
            Transform t = this.transform;
            Vector3 a = t.position;
            for (int i = 0; i < this.chain; ++i) {
                if (t.parent == null) {
                    this.chain = i;
                    break;
                }
                t = t.parent;
            }
            
            Vector3 b = t.position;
            Gizmos.color = Color.white;
            Gizmos.DrawLine(a, b);
            // Vector3 d = b - a;
            // for (int i = 0; i < 20; i++) {
            //     Vector3 p = a + d*(i*0.05f);
            //     Gizmos.DrawWireCube(p, new Vector3(0.05f, 0.05f, 0.05f));
            // }
        }
    }
}