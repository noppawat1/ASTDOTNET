# ASTDOTNET Web API (.NET 8)

โปรเจคนี้เป็น Web API ที่พัฒนาด้วย **.NET 8 และ C#**
ออกแบบตามแนวคิด **Clean Code: A Handbook of Agile Software Craftsmanship**
และมีการทำ **Authorization, External API Integration และ Unit Test**

---

## 🔧 Technology Stack
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- JWT Bearer Authentication
- Swagger (OpenAPI)
- xUnit + Moq (Unit Test)

---

## 🧱 Architecture (N-Tier)
- Controller Layer
- Business Logic Layer
- Repository Layer
- Model (Request / Response)
- Unit Test Project แยกต่างหาก

---

## 🚀 Features

### 1. Product API
- GET Products
- ใช้ JWT Authorization
- ดึงข้อมูล Category ผ่าน Foreign Key และใช้ linq include ข้อมูลเพิ่มเติม

---

### 2. Process API
- รับ input เป็น string (คั่นด้วย comma)
- ใช้ JWT Authorization
- ดึงเฉพาะค่าที่ซ้ำ
- แยกตัวอักษรก่อนตัวเลข
- เรียงจากน้อยไปมาก



### 3. External API Integration
- ใช้ JWT Authorization
- เรียก Free API: และดึงเอา Response มาจาก free api