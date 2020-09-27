## Unity Simple IK (Inverse Kinematics)  
---
#### IK  
動かしたい子ボーンに追加して使う  
target このオブジェクトの方にボーンを伸ばす  
chain 影響範囲  
iteration 反復回数  

---
#### AxisIK
動かせる軸を制限できるIK  
AxisJointボーンに追加すると軸を制限できる  

---
## 表示して確認したりするための物

#### DrawPoint
IKターゲットなどに追加すれば小さなキューブを表示できる  

#### DrawBones
ルートボーンに追加すれば線を表示できる  

#### GamingDrawBones
ゲーミングな感じのDrawBones  
再生中とエディタのカメラを動かしたときのみ光る  

#### GLGamingDrawBones
ゲーミングな感じのDrawBonesをGizmoではなくGLで描画するので実行形式ファイルにした時も表示できる  

#### GamingColor
GamingDrawBonesで使う  