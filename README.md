# BackendTask
---

## 🚀 Özellikler
- Ürün ekleme (POST)
- Ürün listeleme (GET)
- Ürün detay (GET by Id)
- Ürün silme (DELETE)
- Ürün güncelleme (Update)
- Global Exception Middleware ile hata yönetimi

---

## 🛠️ Teknolojiler
- ASP.NET Core 6+ Web API
- Entity Framework Core
- MSSQL
- C#


---

## 📂 Katmanlar
- ProductApi.API → Controller ve Middleware katmanı  
- ProductApi.Application → Servisler, DTO’lar, interface’ler  
- ProductApi.Domain → Entity modelleri  
- ProductApi.Infrastructure → Repository ve DbContext  

---

## 🔧 Veritabanı Bağlantısı
Bu projede connection string doğrudan `ProductContext` içerisine yazılmıştır.  


