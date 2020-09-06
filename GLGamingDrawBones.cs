using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GLGamingDrawBones : MonoBehaviour {
    struct Line {
        public Vector3 a, b;
        public Color color;
        public Line (Vector3 a, Vector3 b, Color color) {
            this.a = a;
            this.b = b;
            this.color = color;
        }
    }
    static Material lineMaterial;
    
    public bool draw = true;
    int time = 0;
    int bone_depth = 0;
    List<Line> lines;
    
    void Update () {
        this.time += 1;
        this.bone_depth = 0;
        this.lines = new List<Line>();
        this.DrawChildBone(this.transform, 0);
    }
    
    void DrawChildBone (Transform t, int depth) {
        for (int i = 0; i < t.childCount; ++i) {
            this.lines.Add(new Line(t.position, t.GetChild(i).position, GamingColor.ValueToColor(this.time*8 + depth * 128)));
        }
        for (int i = 0; i < t.childCount; ++i) {
            this.DrawChildBone (t.GetChild(i), depth+1);
        }
    }
    
    static void CreateLineMaterial() {
        if (!lineMaterial) {
            Shader shader = Shader.Find("Hidden/Internal-Colored");
            lineMaterial = new Material(shader);
            lineMaterial.SetOverrideTag("Queue", "Overlay");
            lineMaterial.SetOverrideTag("RenderType", "Overlay");
            lineMaterial.SetFloat("_ZTest", (float)UnityEngine.Rendering.CompareFunction.Always);
        }
    }
    
    public void OnRenderObject() {
        if (!this.draw) { return; }
        CreateLineMaterial();
        lineMaterial.SetPass(0);
        GL.PushMatrix();
        if (this.lines != null) {
            foreach (var i in this.lines) {
                GL.Begin(GL.LINES);
                GL.Color(i.color);
                GL.Vertex(i.a);
                GL.Vertex(i.b);
                GL.End();
            }
        }
        GL.PopMatrix();
    }
}
