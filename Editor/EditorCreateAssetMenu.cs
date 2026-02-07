using UnityEditor;

namespace LumosLib.Firebase.Editor
{
    public static class EditorCreateAssetMenu
    {
        #region >--------------------------------------------------- SO

        
        [MenuItem("Assets/Create/[ LumosLib ]/Prefabs/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            LumosLib.Editor.EditorCreateAssetMenu.CreatePrefab<FirebaseManager>();
        }
        
        #endregion
    }
}