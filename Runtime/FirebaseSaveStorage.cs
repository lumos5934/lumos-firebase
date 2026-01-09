using Cysharp.Threading.Tasks;
using UnityEngine;

namespace LumosLib.Firebase
{
    public class FirebaseSaveStorage : BaseSaveStorage
    {
        public override UniTask SaveAsync<T>(T data)
        {
            
            return default;
        }

        public override UniTask<T> LoadAsync<T>()
        {
            return default;
        }
    }
}

