# KEBAB
<img src="Assets/Sprites/game logo a1.png" width="250" height="250">
Bu proje, Global Game Jam 2024 kapsamında geliştirilen "KEBAB" adlı 2D platform oyununu içerir. Oyun, Adana'nın leziz mutfaklarından esinlenerek yaratılmış ve eğlenceli bir kaçış deneyimi sunmayı hedeflemektedir.

## Oyun Özellikleri

- **Karakter Değişimi:** Scriptable Object kullanılarak iki farklı karakter oluşturulmuş. Her karakterin hızı, zıplama gücü ve özel yetenekleri bulunmaktadır.
 * Aşağıdaki scriptableobject sınıfı ile birden fazla karakter oluşturarak bu karakterler arasında değişim sağlanıyor!
  ```cs
    [CreateAssetMenu(fileName = "CharacterProperties", menuName = "CharacterProperties", order = 0)]
    public class CharacterProperties : ScriptableObject
  ```
- **Fizik Tabanlı Hareket:** RigidBody kullanılarak karakterlere fizik tabanlı hareket yetenekleri kazandırılmıştır.
  ```cs
          public void CharacterController()
        {
            _horizontalAxis = Input.GetAxis(this.horizontalAxisName) * this.characterManager.characterProperties.speed * Time.deltaTime * speedMultiply + this._speedDecrease;

            this.rb.velocity = new Vector2(_horizontalAxis, this.rb.velocity.y);
        }
  ```
- **Kamera Kontrolleri:** Yumuşak kamera kontrolleri eklenerek oyun içinde akıcı bir görüntüleme deneyimi sağlanmıştır.
- **Dinamik Can Sistemi:** Karakterlerin temas ettiği objeleri algılayan özel bir sınıf kullanılarak can sistemi oluşturulmuştur.
- **Efektler ve Animasyonlar:** Karakter canı azaldığında Adana durumu veya ciğer parçasının havaya uçup düşmesini simüle eden efektler ve animasyonlar eklenmiştir.
- **Arayüz ve Level Yönetimi:** Oyun içi arayüz ve Level Manager sınıfları yazılarak oyunun yönetimi kolaylaştırılmıştır.
- **Kedi Düşman:** Oyuncunun peşinden koşan kedi düşmanını kontrol etmek için özel bir Cat sınıfı eklenmiştir.

## Nasıl Oynanır

- **Karakter Hareketi:** A/D tuşları ile sağa sola hareket edin.
- **Zıplama:** Space tuşu ile karakterinizi zıplatın.
- **Karakter Değiştirme:** R tuşu ile karakterler arasında geçiş yapın.
- **Oyundan Çıkış:** ALT + F4 tuş kombinasyonu ile oyunu kapatabilirsiniz.

## Tasarımlar

<img src="Assets/Sprites/run animation a1.png">
<img src="Assets/Sprites/tezgah a1.png">
<img src="Assets/Sprites/alt üst ates.png">

## Nasıl Başlatılır

1. Repoyu bilgisayarınıza klonlayın.
2. Unity 3D'yi açın ve projeyi yükleyin.
3. "LevelDesıgn" sahnesini açarak oyunu başlatın.


## Geliştiriciler

 Game Developer: Mesut Atakan Temiz

Linkedin: [Mesut Atakan Temiz](https://www.linkedin.com/in/mesut-atakan/)


Game Designer: Halit Can Güneri

Linkedin: [Halitcan Güneri](https://www.linkedin.com/in/halit-can-güneri-6218421b1/)



 Game Arts: Dilara Güncül, Nisa Aracı
   
  Linkedin: [Dilara Güncül](https://www.linkedin.com/in/dilara-güncül-90489024b/)

  Linkedin: [Nisa Aracı](https://www.linkedin.com/in/nisa-aracı-19553725a/)


 Game Music Composer: Zeynep Saraoğlu
 
  Linkedin: [Zeynep Saraoğlu](https://www.linkedin.com/in/zeynep-saraoğlu-17662a22b/)
