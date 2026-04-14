# 🚗 Rentaly - Full Stack Araç Kiralama Sistemi (N-Tier Architecture)

Rentaly, kurumsal bir araç kiralama şirketinin tüm operasyonel ihtiyaçlarını karşılamak üzere **ASP.NET Core 8.0** ile geliştirilmiş, yüksek performanslı ve güvenli bir web platformudur. Proje; sürdürülebilir yazılım mimarisi, **Repository & Unit of Work** tasarım desenleri ve profesyonel UI/UX yaklaşımı ile inşa edilmiştir.

---

## 🏗 Mimari Yapı ve Katmanlar

Proje, sorumlulukların ayrıştırılması ve kodun test edilebilirliği için 5 ana katmana bölünmüştür:

1.  **Rentaly.WebUI:** Sunum katmanı; Admin Area, Controller'lar ve modern kullanıcı arayüzü.
2.  **Rentaly.BusinessLayer:** İş mantığının (Business Logic) yürütüldüğü, Manager sınıflarının bulunduğu merkez.
3.  **Rentaly.DataAccessLayer:** EF Core süreçleri, Migrations ve Repository implementasyonları.
4.  **Rentaly.EntityLayer:** Veritabanı tablolarına karşılık gelen somut (Concrete) sınıflar.
5.  **Rentaly.DtoLayer:** Güvenli veri transfer nesneleri (DTOs).

---

## 🛠 Kullanılan Teknolojiler & Stack

* **Backend:** .NET 8.0 (ASP.NET Core MVC)
* **Veritabanı:** MSSQL & Entity Framework Core (Code-First)
* **E-Posta:** MailKit & MimeKit (SMTP Entegrasyonu)
* **Araçlar:** AutoMapper, FluentValidation, X.PagedList

---

## 💻 Admin Paneli & Yönetim Modülleri

Sistem, tamamen dinamik bir Admin Sayfası üzerinden yönetilmektedir.

### 🏎 Araç ve Filo Yönetimi
* **Araç & Marka Yönetimi:** Tüm araç filosunun, markaların ve hiyerarşik yapıdaki modellerin tam kontrolü.
* **Kategorizasyon:** Araçların segmentlerine (Ekonomik, Lüks, SUV vb.) göre ayrıştırılması.

![AdminCar1](https://github.com/user-attachments/assets/455a02b3-70a0-4be4-aad9-7c3404523a84)
![AdminBrand1](https://github.com/user-attachments/assets/2ce60984-9b75-49f3-a9d1-a08a60b4e8de)
![AdminCategory1](https://github.com/user-attachments/assets/edb230af-3a2f-4bc0-b6f0-42bf68ecb4a1)

### 👥 Müşteri ve Rezervasyon Sistemi
* **Müşteri Kaydı:** Ehliyet detayları ve müşteri verilerinin merkezi takibi.
![AdminCustomer1](https://github.com/user-attachments/assets/127f94d2-a583-4178-9185-92a5689478d4)

* **Akıllı Rezervasyon:** Kullanıcı rezervasyon yaptığında sistem otomatik olarak **8 haneli benzersiz bir indirim kodu** üretir.
* **İndirim Kuponu Mekanizması:** Rezervasyon aşamasında kullanılabilen, kullanıcıya özel **İndirim Kodu** desteği.
![AdminRezerve1](https://github.com/user-attachments/assets/f50ff99c-47d4-4e74-b106-e92330fe9d5c)

### 🏆 Kurumsal İçerik ve Destek Yönetimi
* **Ödüller & Referanslar:** Kurumsal başarıların ve müşteri geri bildirimlerinin yönetimi.
![AdminAward1](https://github.com/user-attachments/assets/d7f6e5d2-47c0-4d9f-92b7-039b5c129f05)
![AdminTestimonial1](https://github.com/user-attachments/assets/82ce7863-69fc-431f-9a55-004c1d42b223)

* **Destek & İletişim:** S.S.S (FAQ), Bülten aboneleri, Şube lokasyonları ve servis hizmetlerinin yönetimi.
![AdminFAQ](https://github.com/user-attachments/assets/09ab4966-b5e5-4ac8-bbc2-5b50fa595c61)
![AdminNewsLatter1](https://github.com/user-attachments/assets/1f5c8263-cb29-4e4b-89d5-b605449dc39d)
![AdminService1](https://github.com/user-attachments/assets/a61b5e50-44ef-49a2-b904-7d09cffed88f)
![AdminŞube1](https://github.com/user-attachments/assets/0d67cadc-bdf2-421b-93e5-faf90dc19e84)

---

## 🌐 Kullanıcı Arayüzü (UI) ve Sayfalar

### 🏠 Ana Sayfa Yapısı
Modern ve kullanıcı odaklı ana sayfa tasarımı; ViewComponent yapısı kullanılarak dinamik olarak yönetilen bölümlerden oluşur.
![Default1](https://github.com/user-attachments/assets/01287737-f722-471b-b113-989f7e4b879a)
![Default2](https://github.com/user-attachments/assets/1cfcd32a-94b2-4b31-ba23-29f1f0282037)
![Default9](https://github.com/user-attachments/assets/7293c207-0624-4890-9841-cb9075c1e320)

### 🚗 Araba Listeleme ve Detay Sayfası
Kullanıcıların araçları marka ve segment bazlı inceleyebildiği, **X.PagedList** ile optimize edilmiş akıcı listeleme sayfasıdır.
![Car1](https://github.com/user-attachments/assets/f670ffbd-71b2-4c62-ad7c-43d7e057aa79)
![Car4](https://github.com/user-attachments/assets/a23c9e38-9645-442c-8553-c080b6f1ab3a)

### 📰 Haberler ve Bülten (Newsletter)
Kurumsal güncellemelerin ve otomobil dünyasından haberlerin paylaşıldığı dinamik blog sayfasıdır.
![NewsLatter1](https://github.com/user-attachments/assets/add78c40-7b32-48a7-94d8-fcf5572cf173)

---

## 🚀 Öne Çıkan Profesyonel Özellikler

### ✅ Otomatik Rezervasyon Onayı
Rezervasyon tamamlandığı anda **MailKit** aracılığıyla kullanıcıya şık bir onay maili gönderilir. Bu mail içerisinde rezervasyon detayları, **8 haneli özel indirim kodu** ve kiralama bilgileri yer alır.
![Email](https://github.com/user-attachments/assets/2afa2c12-668b-46f9-a403-ee1d60d2f483)

### ✅ Özel Hata Yönetimi (404)
Yanlış URL yönlendirmelerinde kullanıcıyı karşılayan, Rentaly temasına uygun profesyonel tasarım hata sayfası.
![ErrprPage](https://github.com/user-attachments/assets/0e08b766-8443-4731-a431-f05d176e80f5)

### ✅ Gelişmiş Mimari Desenler
Veri erişiminin standartlaştırılması için **Repository Pattern**, işlemlerin tek bir transaction üzerinden güvenle yürütülmesi için **Unit of Work** kullanılmıştır.
