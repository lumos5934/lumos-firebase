using System;
using Cysharp.Threading.Tasks;
using Firebase.Auth;
using UnityEngine;

namespace LumosLib.Firebase
{
    public abstract class BaseAuthProvider : ScriptableObject
    {
        protected FirebaseManager Manager
        {
            get
            {
                if (_manager == null)
                {
                    _manager = GlobalService.Get<FirebaseManager>();
                }
                
                return _manager;
            }
        }
        private FirebaseManager _manager;

        public async UniTask<FirebaseUser> SignInAsync()
        {
            try
            {
                var user = await GetSignInUserAsync();
            
                Manager.SetUser(user);
                DebugUtil.Log("SignIn", "Success");
                return user;
            }
            catch (Exception e)
            {
                DebugUtil.LogError($"SignIn : {e.Message}", "Fail");
                throw;
            }
      
        }

        protected abstract UniTask<FirebaseUser> GetSignInUserAsync();
    }
}