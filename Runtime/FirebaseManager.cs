using System;
using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using UnityEngine;

namespace LumosLib.Firebase
{
    public class FirebaseManager : MonoBehaviour, IFirebaseManager, IPreInitializable
    {
        [SerializeField] private BaseAuthProvider[] firebaseAuthProvider;
        
        public FirebaseUser User { get; private set; }
        public FirebaseAuth Auth { get; private set; }
        public FirebaseFirestore DB { get; private set; }
        
        public Type RegisterType => typeof(FirebaseManager);


        private void Awake()
        {
            Services.Register<IFirebaseManager>(this);
        }


        public async UniTask<bool> InitAsync(PreInitContext ctx)
        {
            var status = await FirebaseApp.CheckAndFixDependenciesAsync();
            if (status != DependencyStatus.Available)
            {
                Debug.LogError($"Firebase dependency error: {status}");
                return false;
            }
            
            Auth = FirebaseAuth.DefaultInstance;
            DB = FirebaseFirestore.DefaultInstance;

            return true;
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

