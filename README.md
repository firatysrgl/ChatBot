🤖 C# AI Chatbot Asistanı

Bu proje, C# Windows Forms kullanılarak geliştirilmiş, OpenAI (GPT-3.5) altyapısını kullanan akıllı bir masaüstü sohbet uygulamasıdır. Kullanıcı ile doğal dilde sohbet edebilir ve konuşma geçmişini hafızasında tutarak bağlamı (context) kaybetmeden cevaplar üretir.



🚀 Özellikler

Yapay Zeka Entegrasyonu: OpenAI API kullanılarak gerçek zamanlı ve akıllı cevaplar.



Hafıza (Context) Yönetimi: Bot, önceki mesajları hatırlar ve ona göre cevap verir (Örn: İsminizi söyledikten sonra hatırlaması).



Asenkron Yapı: Async/Await mimarisi sayesinde cevap beklenirken arayüz donmaz.



Görsel Arayüz: Kullanıcı ve Bot mesajları farklı renklerle (Mavi/Yeşil) ayrılarak okunabilirlik artırılmıştır.



Bağımsız Çalışma: Newtonsoft.Json gibi harici kütüphanelere ihtiyaç duymadan, manuel JSON işleme (parsing) algoritmaları ile geliştirilmiştir.



🛠 Kullanılan Teknolojiler

Dil: C#



Arayüz: Windows Forms (.NET)



API: OpenAI GPT-3.5 Turbo



İletişim: HttpClient (REST API)



⚙️ Kurulum ve Çalıştırma



* Projeyi kendi bilgisayarınızda çalıştırmak için aşağıdaki adımları izleyin:



* Projeyi Visual Studio ile açın.



* Form1.cs dosyasını görüntüleyin.



* Kodun en üst kısmındaki ApiKey değişkenini bulun:



ÖNEMLİ NOT :



* private static readonly string ApiKey = "BURAYA\_SK\_ILE\_BASLAYAN\_KEY\_GELECEK";

Kendi OpenAI API anahtarınızı tırnak içine yapıştırın.



* Start (Başlat) tuşuna basarak uygulamayı çalıştırın.



🧠 Nasıl Çalışır? (Teknik Detay)

İstek (Request): Kullanıcı butona bastığında, girilen metin ve önceki konuşma geçmişi bir JSON formatına dönüştürülür.



API Bağlantısı: System.Net.Http kütüphanesi ile OpenAI sunucularına bir POST isteği gönderilir.



Cevap (Response): Sunucudan dönen JSON verisi, harici bir paket kullanılmadan String manipülasyonu ile parçalanır ve sadece mesaj içeriği ayıklanır.



Görüntüleme: Gelen cevap RichTextBox üzerine renkli formatta yazdırılır ve hafıza listesine eklenir.

📷 Ara Yüz Ekranı 

![Ara Yüz Ekranı](https://github.com/firatysrgl/ChatBot/blob/main/screenshot/ss.png)



👤 Geliştirici



Fırat Yunus Yaşaroğlu



📧 Email: firat9041@gmail.com



🔗 GitHub: https://github.com/firatysrgl



🔗 LinkedIn: https://www.linkedin.com/in/firat-yunus-yasaroglu/

