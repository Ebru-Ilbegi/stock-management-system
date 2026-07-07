# 📦 Stock Management System / Stok Yönetim Sistemi

### English

This project is a comprehensive, enterprise-level Stock Management System developed using ASP.NET MVC and N-Tier Architecture. Built from scratch during an IT department internship at a municipality, the system provides a secure, scalable, and real-world solution for inventory, warehouse, and user management.

The architecture strictly follows the **Generic Repository Pattern** and incorporates professional development practices such as **Dependency Injection**, **Soft Deletion**, and **Fluent Validation**.

**✨ Key Features & Technical Highlights**
* **N-Tier Architecture & Generic Repository:** Clean separation of concerns (Data Access, Business, Entity, and UI layers) ensuring high maintainability and code reusability.
* **Entity Framework Code First Migrations:** Database schema generated and managed entirely through C# classes and migrations.
* **Role-Based Authorization & Security:** Comprehensive access control using `FormsAuthentication` and Session management. Features strict Backend authorization and Frontend UI restrictions (hiding sensitive buttons from non-admin users).
* **Soft Delete Implementation:** Preserves historical data integrity by logically disabling records (`ItemStatus = false`) instead of permanently deleting them from the database.
* **Data Validation:** Server-side validation rules implemented using the **Fluent Validation** library to ensure data consistency and security.
* **Data Visualization:** Interactive dashboards integrating **Google Charts** (Pie and Stacked Bar charts) for real-time inventory and category analysis.
* **Asynchronous UI (Modals/Popups):** Enhanced user experience by performing CRUD operations via popups without reloading the page.
* **Dynamic Search & Pagination:** High-performance, server-side search and pagination using `PagedList` to efficiently handle large datasets.
* **Messaging Module:** Built-in internal communication system featuring inbox/outbox functionalities.
* **Custom Error Handling:** Professionally designed custom error pages (e.g., 404, 403) for better user routing and system reliability.
* **Modern UI/UX:** Fully responsive and professional interface powered by **AdminLTE 3.0.4** and Bootstrap.

**🛠️ Tech Stack**
* **Backend:** C#, ASP.NET MVC, LINQ
* **Database:** MSSQL, Entity Framework (Code First)
* **Architecture:** N-Tier, Generic Repository Pattern, Dependency Injection
* **Frontend:** HTML5, CSS3, Bootstrap, AdminLTE 3.0.4, jQuery/AJAX
* **Libraries:** Fluent Validation, Google Charts, PagedList.MVC

**🚀 Setup & Installation**
1. Clone the repository to your local machine.
2. Open the `.sln` file in Visual Studio.
3. Update the Connection String in `Web.config` to point to your local MSSQL server.
4. Open the Package Manager Console and run `Update-Database` to generate the tables.
5. Build and run the project.

🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️🕹️

### Türkçe

Bu proje, ASP.NET MVC ve N-Katmanlı Mimari kullanılarak geliştirilmiş kurumsal seviyede kapsamlı bir Stok Yönetim Sistemi'dir. Bir belediyenin Bilgi İşlem departmanındaki staj sürecinde sıfırdan tasarlanan bu sistem; envanter, depo ve kullanıcı yönetimi için güvenli, ölçeklenebilir ve gerçek dünya ihtiyaçlarına uygun bir çözüm sunar.

Sistem mimarisi **Generic Repository (Genel Depo)** tasarım desenine sıkı sıkıya bağlı kalınarak inşa edilmiş olup; **Bağımlılık Enjeksiyonu (Dependency Injection)**, **Mantıksal Silme (Soft Delete)** ve **Fluent Validation** gibi profesyonel yazılım geliştirme pratiklerini barındırmaktadır.

**✨ Temel Özellikler ve Teknik Detaylar**
* **N-Katmanlı Mimari ve Generic Repository:** Veri Erişimi (DAL), İş (Business), Varlık (Entity) ve Arayüz (UI) katmanlarının birbirinden bağımsız çalışmasıyla yüksek sürdürülebilirlik ve temiz kod yapısı.
* **Entity Framework Code First:** Veri tabanı tablolarının ve ilişkilerinin C# sınıfları üzerinden kodlanarak Migration işlemleriyle yönetilmesi.
* **Rol Tabanlı Yetkilendirme ve Güvenlik:** `FormsAuthentication` ve Session (Oturum) yönetimi ile kimlik doğrulama. Hem Backend (sunucu) tarafında yetki kontrolü hem de Frontend (arayüz) tarafında yetkisiz kullanıcılardan işlem butonlarının gizlenmesi.
* **Soft Delete (Mantıksal Silme):** Veri bütünlüğünü ve geçmiş kayıtları korumak amacıyla verilerin SQL'den kalıcı olarak silinmesi yerine pasife çekilmesi (`Status = false`).
* **Veri Doğrulama (Validation):** Güvenilir ve tutarlı veri akışı sağlamak için **Fluent Validation** kütüphanesi ile sunucu taraflı katı doğrulama kuralları.
* **Veri Görselleştirme:** Stok ve kategori dağılımlarını analiz etmek amacıyla sisteme entegre edilmiş dinamik **Google Charts** (Pasta ve Sütun grafikleri).
* **Asenkron Arayüz (Popup/Modal):** Sayfa yenilenmesine gerek kalmadan CRUD işlemlerinin hızlı ve kullanıcı dostu pencereler üzerinden yapılması.
* **Dinamik Arama ve Sayfalama (Pagination):** Büyük veri setlerinin arayüzü yormaması için `PagedList` kütüphanesi ile optimize edilmiş sunucu taraflı sayfalama ve arama altyapısı.
* **Mesajlaşma Modülü:** Gelen ve giden kutusu barındıran, doğrulama kurallarıyla desteklenmiş iç iletişim sistemi.
* **Özelleştirilmiş Hata Yönetimi:** Beklenmeyen durumlarda kullanıcıyı doğru yönlendirmek için özel tasarlanmış 403 ve 404 hata (Error) sayfaları.
* **Modern UI/UX:** **AdminLTE 3.0.4** teması ve Bootstrap ile güçlendirilmiş, tamamen mobil uyumlu (responsive) profesyonel arayüz tasarımı.

**🛠️ Kullanılan Teknolojiler**
* **Backend:** C#, ASP.NET MVC, LINQ
* **Veri Tabanı:** MSSQL, Entity Framework (Code First)
* **Mimari:** N-Katmanlı Mimari, Generic Repository Deseni, Dependency Injection
* **Frontend:** HTML5, CSS3, Bootstrap, AdminLTE 3.0.4, jQuery/AJAX
* **Kütüphaneler:** Fluent Validation, Google Charts, PagedList.MVC

**🚀 Kurulum Adımları**
1. Repoyu bilgisayarınıza klonlayın.
2. Visual Studio üzerinden `.sln` dosyasını açın.
3. Kendi MSSQL sunucunuza bağlanmak için `Web.config` dosyasındaki veritabanı bağlantı yolunu (Connection String) güncelleyin.
4. Veri tabanını oluşturmak için Package Manager Console üzerinden `Update-Database` komutunu çalıştırın.
5. Projeyi derleyip (Build) başlatın.
