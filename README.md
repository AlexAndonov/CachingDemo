# CachingDemo

## 📌 About the Project

This project is my first hands-on experience with caching concepts in backend development using ASP.NET Core.

The goal of the project is to understand how caching works in real-world scenarios by experimenting with different caching strategies and measuring their impact on application performance.

The application intentionally contains very simple business logic so the focus can remain on learning and experimenting with caching mechanisms.

Initially, the project explored in-memory caching, but the final implementation uses **Redis distributed caching**.

---

## 🚀 What is Implemented So Far

### ✅ Redis Distributed Caching

- Implemented **Cache Aside Pattern** using Redis
- Added **Redis distributed caching** using `IDistributedCache`
- Introduced **cache abstraction (`ICacheService`)**
- Implemented **RedisCacheService**
- Added **cache invalidation** when modifying data

### ✅ Database Seeding

The database is seeded with **100,000 product records** in order to simulate a larger dataset and better demonstrate the impact of caching.

### ✅ Performance Improvements

Performance was measured using Postman requests.

**Without caching**

~2–3 seconds


**With Redis caching**

~40–400 ms (consistent response time)

---

## 📸 Screenshots

<img width="1920" height="956" alt="Screenshot (52)" src="https://github.com/user-attachments/assets/c5e2291c-1cb4-4723-8cca-d9c4314940a2" />

<img width="1920" height="952" alt="Screenshot (55)" src="https://github.com/user-attachments/assets/0b932129-6604-412d-aecc-9501220203dd" />

---

## 🧠 Future Improvements

As I continue learning about caching, I plan to extend the project with:

- Cache performance benchmarking
- Hybrid caching (Memory + Redis)
- Cache stampede protection
- Pagination-level caching
- Advanced cache invalidation strategies
- Logging and monitoring improvements

---

## 🏗 Architecture

The project follows the **Cache Aside Pattern**.
