using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using UnityEngine;

namespace LumosLib.Firebase
{
    public class FirebaseManager : MonoBehaviour, IPreInitializable, IFirebaseManager
    {
        [SerializeField] private BaseAuthProvider[] firebaseAuthProvider;
        
        public FirebaseUser User { get; private set; }
        public FirebaseAuth Auth { get; private set; }
        public FirebaseFirestore DB { get; private set; }
        
        
        public async UniTask<bool> InitAsync()
        {
            var status = await FirebaseApp.CheckAndFixDependenciesAsync();
            if (status != DependencyStatus.Available)
            {
                Debug.LogError($"Firebase dependency error: {status}");
                return await UniTask.FromResult(false);
            }
            
            Auth = FirebaseAuth.DefaultInstance;
            DB = FirebaseFirestore.DefaultInstance;

            GlobalService.Register((IFirebaseManager)this);
            return await UniTask.FromResult(true);
        }

        public BaseAuthProvider GetAuthProvider<T>() where T : BaseAuthProvider
        {
            foreach (var provider in firebaseAuthProvider)
            {
                if (provider is T t)
                {
                    return t;
                }
            }

            return null;
        }

        public void SetUser(FirebaseUser user)
        {
            User = user;
        }
    }
}

