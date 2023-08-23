using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Krevechous.NewRecycleSystem;
using System.Security.Principal;
using Codice.Client.Common;

[CustomEditor(typeof(RecycleablePool))]
public class TubesEditmodePlacer : Editor {
   
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RecycleablePool pool = (RecycleablePool)target;

        if (GUILayout.Button("Place with distance")) {
            for (int i = 1; i < pool.transform.childCount; i++) {
                var child = pool.transform.GetChild(i);
                var prevChild = pool.transform.GetChild(i - 1);
                child.transform.position = new Vector3(prevChild.position.x + TubesRecycleable.distanceBetweenTubes, 0, 0);
            }
        }
    }

}
