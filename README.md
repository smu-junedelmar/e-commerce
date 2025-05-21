# 🧩 Microservices E-commerce System

This repository consists of three core microservices built using **Node.js** and **Express**, designed following the **SOLID principles** and integrating key technologies like **MongoDB**, **Redis**, **RabbitMQ**, and **Swagger**.

---

## 🧱 Services Overview

### 1. 🛍 Product Catalog Service

- **Tech**: Express, MongoDB, RabbitMQ, Swagger
- **Function**: Manages product inventory (CRUD + stock updates)
- **Events**: Listens for `OrderPlaced` to decrement stock
- **Docs**: Swagger at `/api-docs`

### 2. 🧾 Order Service

- **Tech**: Express, MongoDB, RabbitMQ, Swagger
- **Function**: Persists order data from cart checkout
- **Events**: Publishes `OrderPlaced` after successful creation
- **Docs**: Swagger at `/api-docs`

### 3. 🛒 Cart Service

- **Tech**: Express, Redis, Axios, Swagger
- **Function**: Temporarily stores user cart, validates stock, sends to Order Service at checkout
- **Docs**: Swagger at `/api-docs`

---

## 📦 Architecture

```text
User → Cart Service → Product Catalog (for stock check)
                ↓
         → Order Service ←→ RabbitMQ → Product Service (stock adjustment)
```

---

## 🚀 Quick Start

### 1. Clone Repos
```bash
git clone <repo-url>
cd <repo-folder>
```

### 2. Install Dependencies
```bash
npm install
```

### 3. Setup Redis, MongoDB, RabbitMQ

Ensure the following are running:
- Redis on `localhost:6379`
- MongoDB on `localhost:27017`
- RabbitMQ on `amqp://localhost` (default guest:guest)

### 4. Start Services
```bash
# Each service has its own server.js
npm start
```

---

## 🔄 Event Flow

1. Cart sends order to Order API at checkout.
2. Order API saves order and publishes `OrderPlaced` event.
3. Product Service listens and updates stock accordingly.

---

## 📝 Swagger API Docs

Each service provides Swagger UI at:

- Product: `http://localhost:3000/api-docs`
- Order: `http://localhost:4000/api-docs`
- Cart: `http://localhost:5003/api-docs`

---

## ⚙️ Configuration

Use `.env` files or config modules per service.

Example:

```
REDIS_HOST=localhost
MONGO_URI=mongodb://localhost:27017
RABBITMQ_URI=amqp://guest:guest@localhost
PRODUCT_API=http://localhost:3000/api/products
ORDER_API=http://localhost:3001/api/orders
```

---

## 📬 Contributing

Fork this repo and contribute improvements, fixes, or enhancements.

---

## 📄 License

MIT © 2025