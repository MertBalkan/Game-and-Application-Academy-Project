using AcademyProject.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace AcademyProject.DataEditorWindow
{
    /// <summary>
    /// Academy tool, this tool is still on Development. 
    /// </summary>
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
            DamageDataCreator();
        }

        private void ItemDataCreator()
        { 
            GUILayout.Label("Item Data Scriptable Object");
               
            if (GUILayout.Button("Create New Item Data", GUILayout.Width(200)))
            {  
                ItemDataSO asset = ScriptableObject.CreateInstance<ItemDataSO>();

                string name = UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/[GameFolders]/ScriptableData/ItemData/NewScriptableObject.asset");
                AssetDatabase.CreateAsset(asset, name);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = asset;
            }
            
        }

        private void DamageDataCreator()
        {
            GUILayout.Label("Damageable Data Scriptable Object");
               
            if (GUILayout.Button("Create New Damageable Data", GUILayout.Width(200)))
            {  
                DamageDataSO asset = ScriptableObject.CreateInstance<DamageDataSO>();

                string name = UnityEditor.AssetDatabase.GenerateUniqueAssetPath("Assets/[GameFolders]/ScriptableData/DamageableData/NewScriptableObject.asset");
                AssetDatabase.CreateAsset(asset, name);
                AssetDatabase.SaveAssets();

                EditorUtility.FocusProjectWindow();

                Selection.activeObject = asset;
            }

        }
    }
    
}