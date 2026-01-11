using UnityEditor;

namespace LumosLib.Firebase
{
    public static class EditorAssetMenu
    {
        #region >--------------------------------------------------- SO

        
        [MenuItem("Assets/Create/Prefab/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            LumosLib.EditorAssetMenu.CreatePrefab<FirebaseManager>();
        }
        
        #endregion
    }
}