using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using UnityEngine;

namespace LumosLib.Firebase
{
    public class FirebaseManager : MonoBehaviour, IPreInitializable
    {
        #region >--------------------------------------------------- PROPERTIES

        
        public FirebaseUser User { get; private set; }
        public FirebaseAuth Auth { get; private set; }
        public FirebaseFirestore DB { get; private set; }
        

        #endregion
        #region >--------------------------------------------------- FIELD
        
        
        [SerializeField] private BaseAuthProvider[] firebaseAuthProvider;
        
        
        #endregion
        #region >--------------------------------------------------- INIT
     
        
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

            GlobalService.Register(this);
            return await UniTask.FromResult(true);
        }
        
        
        #endregion
        #region >--------------------------------------------------- GET & SET


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
        

        #endregion
        #region >--------------------------------------------------- SIGN


        
        /*private async UniTask GoogleAutoSignIn(string webClientId)
        {
            var configuration = new GoogleSignInConfiguration
            {
                WebClientId = webClientId,
                RequestEmail = true,
                RequestIdToken = true
            };
            GoogleSignIn.Configuration = configuration;

            try
            {
                var googleUser = await GoogleSignIn.DefaultInstance.SignIn();
                if (googleUser == null)
                {
                    
                    DebugUtil.LogError("SignIn : Google User is null", "Fail");
                    return;
                }

                string idToken = googleUser.IdToken;
                var credential = GoogleAuthProvider.GetCredential(idToken, null);
                User = await Auth.SignInWithCredentialAsync(credential);
            }
            catch (Exception e)
            {
                DebugUtil.LogError("SignIn :" + e.Message, "Fail");
                GoogleSignIn.DefaultInstance.SignOut();
                return;
            }
            
            DebugUtil.Log("SignIn", "Success");
        }*/
        
        
        #endregion
    }
}

