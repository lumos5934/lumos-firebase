### ℹ️의존성
* [ lumos-core ](https://github.com/lumos5934/lumos-core)


<br>
<br>

## ℹ️기능

### FirebaseManager
기본적인 Firebase의 `FirebaseUser`,`FirebaseAuth`,`FirebaseFirestore` 를 래핑하고 사용할 `AuthProvider` 들을 관리하는 컨테이너

<br>
<br>

### AuthProvider
<img width="1906" height="979" alt="image" src="https://github.com/user-attachments/assets/04f16d57-269b-42b4-91dc-e31dd35060af" />

<br>

사용할 계정 인증의 동작을 `GetSignInUserAsync` 매서드에 구현. 

<br>
<br>

### FirestoreDataSource
실제로 값을 읽어올 저장소, Core 라이브러리의 `BaseDataSource` 의 상속을 받아 현재는 Firestore 와의 통신만 구현 


<br>
<br>
