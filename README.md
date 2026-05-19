# ASTDOTNET Web API (.NET 8)

โปรเจคนี้เป็น Web API ที่พัฒนาด้วย **.NET 8 และ C#**
ออกแบบตามแนวคิด **Clean Code: A Handbook of Agile Software Craftsmanship**
และมีการทำ **Authorization, External API Integration และ Unit Test**
## 🔐 Authentication & API Testing via Swagger

สามารถทดสอบการใช้งาน API ผ่าน Swagger ได้ โดยจะต้องทำการสร้าง Token ก่อน  
เนื่องจาก API ถูกป้องกันด้วยระบบ Authorization (JWT Bearer)

### ขั้นตอนการทดสอบผ่าน Swagger
1. เรียกใช้งาน API สำหรับสร้าง Token (Auth API)
   - curl -X POST https://localhost:5001/api/auth/token \
   - -H "Content-Type: application/json"
3. คัดลอก Token ที่ได้รับ
4. เปิดหน้า Swagger
5. คลิกที่ไอคอนรูปแม่กุญแจ (Authorize) ด้านบนขวา
6. ใส่ค่า Token ในรูปแบบ
7. กด Authorize เพื่อปลดล็อกการใช้งาน API ที่มีการกำหนด `[Authorize]`
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
curl -X GET https://localhost:5001/api/product \
  -H "Authorization: Bearer {your_token}"
- GET Products
- ใช้ JWT Authorization
- ดึงข้อมูล Category ผ่าน Foreign Key และใช้ linq include ข้อมูลเพิ่มเติม
- ใช้ฐานข้อมูล Local SQL Server Express สำหรับจัดเก็บและดึงข้อมูล

---

### 2. Process API
curl -X POST https://localhost:5001/api/process \
  -H "Authorization: Bearer {your_token}" \
  -H "Content-Type: application/json" \
  -d "string,string,1,2,1,3,5,4,2,4"
- รับ input เป็น string (คั่นด้วย comma)
- ใช้ JWT Authorization
- ดึงเฉพาะค่าที่ซ้ำ
- แยกตัวอักษรก่อนตัวเลข
- เรียงจากน้อยไปมาก



### 3. External API Integration
curl -X GET https://localhost:5001/api/externalapi/todo \
  -H "Authorization: Bearer {your_token}"
- ใช้ JWT Authorization
- เรียก Free API: และดึงเอา Response มาจาก free api