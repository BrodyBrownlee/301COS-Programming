using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Enemy))]
public class enemyRangeEditor : Editor
{
    public void OnSceneGUI()
    {
        Enemy enemyScript = (Enemy)target;

        if(enemyScript == null )
        {
            return;
        }

        float attackRange = enemyScript.attackRange;
        var t = target as Enemy;
        var tr = t.transform;
        var pos = tr.position;

        Handles.color = Color.red;
        Handles.DrawWireDisc(pos, tr.forward, attackRange);
    }
}
