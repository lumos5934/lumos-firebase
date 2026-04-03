using UnityEditor;

namespace LLib.Firebase.Editor
{
    public static class EditorCreateAssetMenu
    {
        [MenuItem("Assets/Create/[ LLib ]/Prefabs/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            LLib.Editor.EditorCreateAssetMenu.CreatePrefab<FirebaseManager>();
        }
    }
}