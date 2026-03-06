# CachingDemo

## 📌 About the Project

This is my first hands-on experience with caching concepts in backend development. The project is mainly a learning playground where I explore how caching works in practice.

At the moment, the application does not contain complex business logic. The main focus is understanding caching mechanisms and gradually improving my knowledge of advanced caching techniques over time.

I plan to continue extending this project as I learn more about caching strategies and distributed caching systems.

## 🚀 What is Implemented So Far

### ✅ In-Memory Caching

- Implemented Cache Aside Pattern using in-memory caching.
- Added cache key management for cleaner design.
- Added cache invalidation logic during product creation.

### ✅ Database Seeding

- Seeded the database with **100,000 product records** for performance testing purposes.

### ✅ Performance Improvement

After introducing caching, the response time was consistently reduced:

- Without caching: ~2–3 seconds  
- With in-memory caching: ~40–100 ms (consistent performance)

Postman screenshots demonstrating the response time differences are included below.

## 📸 Screenshots

<img width="1920" height="956" alt="Screenshot (52)" src="https://github.com/user-attachments/assets/c5e2291c-1cb4-4723-8cca-d9c4314940a2" />
<img width="1920" height="952" alt="Screenshot (55)" src="https://github.com/user-attachments/assets/0b932129-6604-412d-aecc-9501220203dd" />


## 🧠 Future Improvements

As I continue learning, I plan to extend this project with:

- Redis distributed caching  
- Cache performance benchmarking  
- Advanced cache invalidation strategies  
- Cache stampede protection  
- Pagination-level caching  
- Logging and monitoring improvements
