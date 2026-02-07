using Cysharp.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

namespace LumosLib.Firebase
{
    [CreateAssetMenu(menuName = "[ LumosLib ]/Scriptable Objects/Auth Provider/Firebase/Anonymous", fileName = "Firebase_AnonymousAuthProvider")]
    public class AnonymousAuthProvider : BaseAuthProvider
    {
        protected override async UniTask<FirebaseUser> GetSignInUserAsync()
        {
            var result = await Manager.Auth.SignInAnonymouslyAsync();
            return result.User;
        }
    }
}