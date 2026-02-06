using Cysharp.Threading.Tasks;
using Firebase.Firestore;
using UnityEngine;

namespace LumosLib.Firebase
{
    [CreateAssetMenu(fileName = "Firestore_DataSource", menuName = "[ LumosLib ]/SO/Data Source/Firestore")]
    public class FirestoreDataSource : BaseDataSource
    {
        private FirebaseManager Manager
        {
            get
            {
                if (_manager == null)
                {
                    _manager = GlobalService.Get<IFirebaseManager>() as FirebaseManager;
                }
                
                return _manager;
            }
        }
        private FirebaseManager _manager;
       
        
        public override async UniTask WriteAsync<T>(T data)
        {
            if (Manager.User == null) return;

            await Manager.DB
                .Collection("users")
                .Document(Manager.User.UserId)
                .SetAsync(data);
        }

        public override async UniTask<T> ReadAsync<T>()
        {
            if (Manager.User == null) return default;

            DocumentSnapshot snapshot = await Manager.DB
                .Collection("users")
                .Document(Manager.User.UserId)
                .GetSnapshotAsync();

            if (!snapshot.Exists)
                return default;

            T data = snapshot.ConvertTo<T>();
            return data;
        }
    }
}

