using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using UnityEngine;

namespace LumosLib.Firebase
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Firebase/Auth Service/Email", fileName = "EmailAuthService")]
    public class EmailAuthService : BaseAuthService
    {
        [field: SerializeField] public string Email { get; private set; }
        [field: SerializeField] public string Password { get; private set; }
        
        [SerializeField] private bool _useAutoSignUp;

        private AuthResult _authResult;

        public override async UniTask SignInAsync()
        {
            try
            {
                _authResult = await _manager.Auth.SignInWithEmailAndPasswordAsync(Email, Password);
            }
            catch (FirebaseException e)
            {
                if (_useAutoSignUp)
                {
                    try
                    {
                        await SignUpAsync();
                    }
                    catch (FirebaseException signUpError)
                    {
                        DebugUtil.LogError($"SignUp : {signUpError.Message}", "Fail");
                        return;
                    }
                }
            }
        
            DebugUtil.Log("SignIn", "Success");
            _manager.SetUser(_authResult.User);
        }

        public override async UniTask SignUpAsync()
        {
            _authResult = await _manager.Auth.CreateUserWithEmailAndPasswordAsync(Email, Password);
        }
        
        public override UniTask SignOutAsync()
        {
            _manager.Auth.SignOut();
            return UniTask.CompletedTask;
        }
    }
}