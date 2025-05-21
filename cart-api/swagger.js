const swaggerJsdoc = require('swagger-jsdoc');

const options = {
  definition: {
    openapi: '3.0.0',
    info: {
      title: 'Cart Service API',
      version: '1.0.0',
      description: 'API documentation for Cart Service',
    },
    servers: [
      { url: 'http://localhost:5003/api' }
    ],
  },
  apis: ['./routes/*.js'], // <-- files containing annotations
};

const swaggerSpec = swaggerJsdoc(options);

module.exports = swaggerSpec;
