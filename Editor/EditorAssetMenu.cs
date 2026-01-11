using UnityEditor;

namespace Lumos.Firebase
{
    public static class EditorAssetMenu
    {
        #region >--------------------------------------------------- SO

        
        [MenuItem("Assets/Create/Prefab/Manager/Firebase", false, int.MinValue)]
        public static void CreateFirebaseManager()
        {
            Lumos.EditorAssetMenu.CreatePrefab<FirebaseManager>();
        }
        
        #endregion
    }
}