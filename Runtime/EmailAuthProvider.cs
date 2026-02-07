using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine;

namespace LumosLib.Firebase
{
    [CreateAssetMenu(menuName = "[ LumosLib ]/Scriptable Objects/Auth Provider/Firebase/Email", fileName = "Firebase_EmailAuthProvider")]
    public class EmailAuthProvider : BaseAuthProvider
    {
        [field: SerializeField] public string Email { get; private set; }
        [field: SerializeField] public string Password { get; private set; }
        
        [SerializeField] private bool _useAutoSignUp;


        protected override async UniTask<FirebaseUser> GetSignInUserAsync()
        {
            FirebaseUser user = null;
            
            try
            {
                var result = await Manager.Auth.SignInWithEmailAndPasswordAsync(Email, Password);
                user = result.User;
            }
            catch (FirebaseException e)
            {
                if (_useAutoSignUp)
                {
                    try
                    {
                        user = await SignUpAsync();
                    }
                    catch (FirebaseException signUpError)
                    {
                        DebugUtil.LogError($"SignUp : {signUpError.Message}", "Fail");
                        return user;
                    }
                }
            }
        
            return user;
        }

        public async UniTask<FirebaseUser> SignUpAsync()
        {
            var result = await Manager.Auth.CreateUserWithEmailAndPasswordAsync(Email, Password);
            return result.User;
        }
    }
}