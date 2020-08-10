using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AdditiveReferencePoseToolWindow : EditorWindow
{
    [SerializeField] private List<AnimationClip> targetClipList = new List<AnimationClip>(64);

    [SerializeField] private AnimationClip referenceClip = null;

    [SerializeField] private float poseTime = 0.0f;

    private Editor editor;

    [MenuItem("Additive Reference Pose Tool/Tool Window")]
    public static void Init()
    {
        EditorWindow.GetWindow(typeof(AdditiveReferencePoseToolWindow), false);
    }

    void OnEnable()
    {
        editor = Editor.CreateEditor(this);
    }
    
    void OnGUI()
    {
        editor.OnInspectorGUI();
    }

    private void SetAdditiveReferencePose()
    {
        foreach (var targetClip in targetClipList) {
            AnimationUtility.SetAdditiveReferencePose(targetClip, referenceClip, poseTime);
        }
    }

    private void ResetAdditiveReferencePose()
    {
        foreach (var targetClip in targetClipList) {
            AnimationUtility.SetAdditiveReferencePose(targetClip, null, 0.0f);
        }
    }

    [CustomEditor(typeof(AdditiveReferencePoseToolWindow), true)]
    private class WindowEditor : Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            var window = target as AdditiveReferencePoseToolWindow;

            // 各種ボタンの追加

            if (GUILayout.Button("Set Additive Reference Pose")) {
                window.SetAdditiveReferencePose();
                AssetDatabase.SaveAssets();
                Debug.Log("Completed: Set Additive Reference Pose");
            }

            if (GUILayout.Button("Reset Additive Reference Pose")) {
                window.ResetAdditiveReferencePose();
                AssetDatabase.SaveAssets();
                Debug.Log("Completed: Reset Additive Reference Pose");
            }
        }
    }
}