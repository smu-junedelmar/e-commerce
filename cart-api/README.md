# 🛒 Cart Service API

This Cart Service is part of a microservices-based e-commerce system. It temporarily holds users' cart data in **Redis**, verifies product availability via the **Product Catalog Service**, and places orders by sending data to the **Order Service**.

---

## 📦 Features

- Add product to cart (validates stock with Product Catalog)
- View user cart
- Remove product from cart
- Checkout (converts cart into an order via Order Service)
- Uses Redis to store cart data efficiently
- Follows SOLID design principles

---

## 📁 Project Structure

```
cart-service/
├── controllers/
│   └── cartController.js
├── routes/
│   └── cartRoutes.js
├── services/
│   └── cartService.js
├── config/
│   └── redisClient.js
├── swagger/
│   └── swaggerSpec.js
├── app.js
├── server.js
└── README.md
```

---

## ⚙️ Prerequisites

- Node.js (v16+ recommended)
- Redis instance (local or cloud)
- Product Catalog Service running
- Order Service running

---

## 🔐 Redis Configuration

Update your `config/redisClient.js` to connect with credentials:

```js
const redis = require('redis');

const redisClient = redis.createClient({
  socket: {
    host: 'localhost',
    port: 6379
  },
  username: 'default', // optional if ACL enabled
  password: 'yourpassword' // if set in Redis config
});

module.exports = { redisClient };
```

To test connection:

```bash
redis-cli -h <host> -p 6379 -a <password>
```

---

## 🚀 Getting Started

### 1. Install dependencies

```bash
npm install
```

### 2. Start the server

```bash
npm start
```

Server runs at `http://localhost:3002`

---

## 🛠️ API Endpoints

Base URL: `/api/cart`

### `POST /`
Add item to cart

```json
{
  "userId": "user123",
  "productId": "prod123",
  "quantity": 2
}
```

### `GET /:userId`
Retrieve cart contents for a user.

### `DELETE /`
Remove an item from cart.

```json
{
  "userId": "user123",
  "productId": "prod123"
}
```

### `POST /checkout`
Send cart data to Order API and clear cart.

```json
{
  "userId": "user123"
}
```

---

## 📝 Swagger Docs

Visit: `http://localhost:3002/api-docs`

---

## 🔗 External Dependencies

- **Product Catalog API**: Verifies stock
- **Order API**: Receives checked-out cart

---

## 📦 Environment Variables

If you prefer, use `.env`:

```
REDIS_HOST=localhost
REDIS_PORT=6379
REDIS_USER=default
REDIS_PASS=yourpassword
PRODUCT_API=http://localhost:3000/api/products
ORDER_API=http://localhost:3001/api/orders
```

---

## 📌 Notes

- Cart data is stored as Redis hash: `cart:<userId>`
- No product metadata is stored in Redis
- Checkout clears the cart after successful order creation

---

## 🧪 Testing

You can use Postman or Swagger UI to test endpoints.

---

## 🧱 Built With

- Express.js
- Redis
- Axios
- Swagger (OpenAPI)

---

## 📬 Contributing

Feel free to fork and submit PRs if you'd like to improve the service or add features.

---

## 🛡 License

MIT © 2025