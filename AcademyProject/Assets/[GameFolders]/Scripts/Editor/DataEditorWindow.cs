using System;
using AcademyProject.ScriptableObjects;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;

namespace AcademyProject.DataEditorWindow
{
    public class DataEditorWindow : EditorWindow
    {
        private static float editorHeight;
        private static float editorWidth;

        private void OnEnable()
        {
            editorHeight = 200;
            editorWidth = 200;
        }

        [MenuItem("Academy Project Tools/Data Editor Tool")]
        public static void OpenWindow()
        {
            DataEditorWindow window = (DataEditorWindow)GetWindow(typeof(DataEditorWindow));
            window.minSize = new Vector2(editorWidth, editorHeight);
            window.maxSize = new Vector2(editorWidth + 150, editorHeight + 150);
            window.Show();
        }

        private void OnGUI()
        {
            ItemDataCreator();
        }

        private void ItemDataCreator()
        { 
            GUILayout.Label("Item Data Scriptable Object");
               
            if (GUILayout.Button("Create New Item Data", GUILayout.Width(200)))
            {  
                ItemDataSO asset = ScriptableObject.CreateInstance<ItemDataSO>();

                string name = UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/[GameFolders]/ScriptableData/NewScriptableObject.asset");
                AssetDatabase.CreateAsset(asset, name);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = asset;
            }
            
        }
    }
    
}