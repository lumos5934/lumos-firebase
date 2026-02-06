using UnityEditor;

namespace LumosLib.Firebase.Editor
{
    public static class EditorAssetMenu
    {
        #region >--------------------------------------------------- SO

        
        [MenuItem("Assets/Create/[ LumosLib ]/Prefab/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            LumosLib.Editor.EditorAssetMenu.CreatePrefab<FirebaseManager>();
        }
        
        #endregion
    }
}