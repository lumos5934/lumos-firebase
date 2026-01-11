using Firebase.Auth;
using Firebase.Firestore;

namespace LumosLib.Firebase
{
    public interface IFirebaseManager
    {
        public FirebaseUser User { get; }
        public FirebaseAuth Auth { get; }
        public FirebaseFirestore DB { get; }
        public BaseAuthProvider GetAuthProvider<T>() where T : BaseAuthProvider;
    }
}