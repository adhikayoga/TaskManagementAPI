# Task Management API

REST API sederhana untuk manajemen tugas (Task Management) yang dibuat menggunakan **ASP.NET Core Web API**, **Entity Framework Core**, dan **SQL Server** sebagai database.

Project ini dibuat sebagai tugas UAS Mata Kuliah Pemrograman Web API.

---

# Fitur

- CRUD Category
- CRUD Status
- CRUD Task
- Relasi antar tabel menggunakan Entity Framework Core
- Soft Delete pada Task dan Category
- Swagger Documentation
- SQL Server Database
- REST API

---

# Teknologi

- ASP.NET Core 9 Web API
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- Visual Studio Code
- Git & GitHub

---

# Struktur Database

## Category

| Field | Tipe |
|-------|------|
| Id | int |
| Name | string |
| IsDeleted | bool |

---

## Status

| Field | Tipe |
|-------|------|
| Id | int |
| Name | string |

---

## Task

| Field | Tipe |
|-------|------|
| Id | int |
| Title | string |
| Description | string |
| CreatedAt | DateTime |
| DueDate | DateTime? |
| IsDeleted | bool |
| CategoryId | int |
| StatusId | int |

---

# Relasi

Category

```
1 ---- *
Task
```

Status

```
1 ---- *
Task
```

---

# Cara Menjalankan Project

## 1. Clone Repository

```bash
git clone https://github.com/adhikayoga/TaskManagementAPI.git
```

Masuk ke folder project

```bash
cd TaskManagementAPI
```

---

## 2. Konfigurasi Database

Project menggunakan SQL Server lokal.

Ubah connection string pada file

```
appsettings.json
```

Contoh

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=TaskManagementDB;User Id=sa;Password=Password123!;TrustServerCertificate=True;"
  }
}
```

Sesuaikan dengan SQL Server yang digunakan.

---

## 3. Restore Package

```bash
dotnet restore
```

---

## 4. Jalankan Migration

```bash
dotnet ef database update
```

---

## 5. Jalankan Project

```bash
dotnet run
```

Swagger akan tersedia pada

```
http://localhost:5267/swagger
```

*(Port dapat berbeda tergantung konfigurasi.)*

---

# Contoh Endpoint

## Category

```
GET    /api/Category
GET    /api/Category/{id}
POST   /api/Category
PUT    /api/Category/{id}
DELETE /api/Category/{id}
```

---

## Status

```
GET    /api/Status
GET    /api/Status/{id}
POST   /api/Status
PUT    /api/Status/{id}
DELETE /api/Status/{id}
```

---

## Task

```
GET    /api/Task
GET    /api/Task/{id}
POST   /api/Task
PUT    /api/Task/{id}
DELETE /api/Task/{id}
```

---

# Soft Delete

Project menggunakan mekanisme **Soft Delete**.

Saat data dihapus:

- Data tidak benar-benar dihapus dari database
- Field `IsDeleted` akan berubah menjadi `true`
- Data otomatis tidak muncul pada endpoint GET karena menggunakan Global Query Filter Entity Framework Core.

---

# Swagger

Swagger digunakan untuk melakukan pengujian endpoint REST API.

Contoh:

- GET
- POST
- PUT
- DELETE

langsung dari browser tanpa menggunakan Postman.

---

# Docker SQL Server (Opsional)

Apabila tidak memiliki SQL Server lokal, database dapat dijalankan menggunakan Docker.

```bash
docker run -e "ACCEPT_EULA=Y" \
-e "SA_PASSWORD=Password123!" \
-p 1433:1433 \
--name sqlserver \
-d mcr.microsoft.com/mssql/server:2022-latest
```

Setelah container berjalan, gunakan connection string berikut:

```text
Server=localhost,1433;
Database=TaskManagementDB;
User Id=sa;
Password=Password123!;
TrustServerCertificate=True;
```

Kemudian jalankan migration:

```bash
dotnet ef database update
```

---

# Author

I Putu Adhika Yoga Kertayasa
240010106

Sistem Komputer
