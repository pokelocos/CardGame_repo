using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace TurnSystem
{
    [CustomEditor(typeof(TurnManager))]
    public class TurnManagerEditor : Editor
    {
        TurnManager turnManager;
        //SerializedObject obj;

        void OnEnable()
        {
            this.turnManager = (TurnManager)target;

            if (turnManager != null && turnManager.phases == null)
            {
                turnManager.phases = new List<PhaseTurn>();
            }
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUI.BeginChangeCheck();

            if (turnManager == null)
            {
                return;
            }

            EditorGUILayout.LabelField("Turn N°: ", turnManager.turnCount.ToString());

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add Phase"))
            {
                turnManager.AddPhase();
                turnManager.actualPhase = turnManager.phases.Count - 1;
            }

            if (GUILayout.Button("Remove Phase"))
            {
                turnManager.RemovePhase(turnManager.actualPhase);
            }
            EditorGUILayout.EndHorizontal();

            if (turnManager.phases.Count > 1)
            {
                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("<"))
                {
                    turnManager.actualPhase = Mathf.Clamp(turnManager.actualPhase - 1, 0, turnManager.phases.Count - 1);
                }

                if (GUILayout.Button(">"))
                {
                    turnManager.actualPhase = Mathf.Clamp(turnManager.actualPhase + 1, 0, turnManager.phases.Count - 1);
                }
                turnManager.actualPhase = EditorGUILayout.IntSlider(turnManager.actualPhase, 0, turnManager.phases.Count - 1);
                EditorGUILayout.EndHorizontal();
            }

            if (turnManager.phases.Count > 0)
            {
                turnManager.phases[turnManager.actualPhase].name = EditorGUILayout.TextField("Name: ", turnManager.phases[turnManager.actualPhase].name);
                     
                var obj = new SerializedObject(turnManager.phases[turnManager.actualPhase]);
                EditorGUILayout.PropertyField(obj.FindProperty("OnStart"));                
                EditorGUILayout.PropertyField(obj.FindProperty("OnUpdate"));
                EditorGUILayout.PropertyField(obj.FindProperty("OnEnd"));
                obj.ApplyModifiedProperties();
            }


            if (GUI.changed)
            {
                EditorUtility.SetDirty(turnManager);

            }
            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
            {
                // Do something when the property changes 
            }

        }

        public void OnSceneGUI()
        {

        }
    }
}