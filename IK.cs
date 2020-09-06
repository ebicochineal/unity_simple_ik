using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IK : MonoBehaviour {
    public Transform target;
    [Range(1, 1024)] public int iteration = 64;
    [Range(1, 64)] public int chain = 1;
    List<Quaternion> rotations = new List<Quaternion>();
    
    void Start () {
        Transform t = this.transform;
        for (int i = 0; i < this.chain; ++i) {
            t = t.parent;
            this.rotations.Add(t.localRotation);
        }
    }
    
    void LateUpdate () {
        this.ResetLocalRotations();
        float n = (1f / this.chain) * 0.25f;
        for (int i = 0; i < this.iteration; ++i) {
            Transform t = this.transform;
            for (int j = 0; j < this.chain; ++j) {
                t = t.parent;
                Vector3 a = this.target.position - t.position;
                Vector3 b = this.transform.position - t.position;
                float p = n * (j+1);
                t.localRotation *= Quaternion.AngleAxis(-Vector3.Angle(a, b) * p, t.InverseTransformDirection(Vector3.Cross(a, b)));
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
}