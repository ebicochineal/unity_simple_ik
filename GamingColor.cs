using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamingColor {
    static public Color ValueToColor (int t) {
        int m = (t / 256) % 6;
        int n = t % 256;
        int r = GamingColor.C(n, m);
        int g = GamingColor.C(n, (m+4)%6);
        int b = GamingColor.C(n, (m+2)%6);
        
        return new Color(r/256f, g/256f, b/256f);
    }
    static private int C (int n, int m) {
        if (m == 0 || m == 5) {
            return 255;
        } else if (m == 2 || m == 3) {
            return 0;
        } else if (m == 4) {
            return n;
        } else {
            return 255-n;
        }
    }
}
