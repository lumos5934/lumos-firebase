using UnityEditor;

namespace LLib.Firebase.Editor
{
    public static class EditorCreateAssetMenu
    {
        [MenuItem("Assets/Create/[ LumosLib ]/Prefabs/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            LLib.Editor.EditorCreateAssetMenu.CreatePrefab<FirebaseManager>();
        }
    }
}