using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LumosLib.Firebase
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Firebase/Auth Service/Anonymous", fileName = "AnonymousAuthService")]
    public class AnonymousAuthService : BaseAuthService
    {
        public override async UniTask SignInAsync()
        {
            var result = await _manager.Auth.SignInAnonymouslyAsync();
            
            _manager.SetUser(result.User);
        }

        public override UniTask SignUpAsync()
        {
            return UniTask.CompletedTask;
        }

        public override UniTask SignOutAsync()
        {
            _manager.Auth.SignOut();
            return UniTask.CompletedTask;
        }
    }
}