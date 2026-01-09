using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LumosLib.Firebase
{
    public abstract class BaseAuthService : ScriptableObject
    {
        protected FirebaseManager _manager;
        
        public virtual void Init(FirebaseManager manager)
        {
            _manager = manager;
        }
        public abstract UniTask SignInAsync();
        public abstract UniTask SignUpAsync();
        public abstract UniTask SignOutAsync();
    }
}