<pre>
19:26:21.209 > Client app started...
19:26:21.659 > Request all products
<span style="color:green;">GET http://localhost:5000/api/products</span>
GET http://localhost:5000/api/products
19:26:25.806 > 

[
  {
    "Id": 1,
    "Name": "First product"
  },
  {
    "Id": 2,
    "Name": "Second product"
  },
  {
    "Id": 3,
    "Name": "Third product"
  },
  {
    "Id": 4,
    "Name": "4th product"
  },
  {
    "Id": 5,
    "Name": "5th product"
  }
]
19:26:25.806 > Request all orders
GET http://localhost:5000/api/orders
19:26:26.046 > 

[
  {
    "Id": "379676e5-393d-4f1f-bc29-abfca5832ec0",
    "OrderItems": []
  },
  {
    "Id": "0c96ed4b-de49-4fc5-9bab-0bbdf49ee31b",
    "OrderItems": []
  }
]
19:26:26.046 > Request nonexistent order
GET http://localhost:5000/api/orders/00000000-0000-0000-0000-000000000000
19:26:27.152 > Error retrieving response. Code: 404. Content: 
19:26:27.152 > 

19:26:27.152 > Create 3 orders
POST http://localhost:5000/api/orders/
19:26:27.371 > 

{
  "Id": "417f6337-febd-4854-9adf-713d9834cc1d",
  "OrderItems": []
}
POST http://localhost:5000/api/orders/
19:26:27.474 > 

{
  "Id": "6442992c-5af3-4df5-8cf4-208cfa6597de",
  "OrderItems": []
}
POST http://localhost:5000/api/orders/
19:26:27.575 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": []
}
19:26:27.576 > Request all orders
GET http://localhost:5000/api/orders
19:26:27.706 > 

[
  {
    "Id": "379676e5-393d-4f1f-bc29-abfca5832ec0",
    "OrderItems": []
  },
  {
    "Id": "0c96ed4b-de49-4fc5-9bab-0bbdf49ee31b",
    "OrderItems": []
  },
  {
    "Id": "417f6337-febd-4854-9adf-713d9834cc1d",
    "OrderItems": []
  },
  {
    "Id": "6442992c-5af3-4df5-8cf4-208cfa6597de",
    "OrderItems": []
  },
  {
    "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
    "OrderItems": []
  }
]
19:26:27.706 > Add product #3 to order
POST http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/3
19:26:27.810 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": [
    {
      "Product": {
        "Id": 3,
        "Name": "Third product"
      },
      "Quantity": 1
    }
  ]
}
19:26:27.810 > Add product #2 to order
POST http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/2
19:26:27.858 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": [
    {
      "Product": {
        "Id": 3,
        "Name": "Third product"
      },
      "Quantity": 1
    },
    {
      "Product": {
        "Id": 2,
        "Name": "Second product"
      },
      "Quantity": 1
    }
  ]
}
19:26:27.858 > Set product #2 quantity to 43
PUT http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/2/quantity/43
19:26:27.947 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": [
    {
      "Product": {
        "Id": 3,
        "Name": "Third product"
      },
      "Quantity": 1
    },
    {
      "Product": {
        "Id": 2,
        "Name": "Second product"
      },
      "Quantity": 43
    }
  ]
}
19:26:27.947 > Set product #5 quantity to 17
PUT http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/5/quantity/17
19:26:28.017 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": [
    {
      "Product": {
        "Id": 3,
        "Name": "Third product"
      },
      "Quantity": 1
    },
    {
      "Product": {
        "Id": 2,
        "Name": "Second product"
      },
      "Quantity": 43
    },
    {
      "Product": {
        "Id": 5,
        "Name": "5th product"
      },
      "Quantity": 17
    }
  ]
}
19:26:28.017 > Set non existant order some existant product quantity
PUT http://localhost:5000/api/orders/00000000-0000-0000-0000-000000000000/product/1/quantity/1
19:26:28.493 > Error retrieving response. Code: 404. Content: "Order not found"
19:26:28.493 > 

19:26:28.493 > Set non existant product with id=77 quantity to 3
PUT http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/77/quantity/3
19:26:29.017 > Error retrieving response. Code: 404. Content: "Product not found"
19:26:29.017 > 

19:26:29.017 > Set product quantity to 0 (remove from order)
PUT http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/product/2/quantity/0
19:26:29.091 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": [
    {
      "Product": {
        "Id": 3,
        "Name": "Third product"
      },
      "Quantity": 1
    },
    {
      "Product": {
        "Id": 5,
        "Name": "5th product"
      },
      "Quantity": 17
    }
  ]
}
19:26:29.091 > Clear order
PUT http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301/clear
19:26:29.189 > 

{
  "Id": "6376f62e-7df4-42b7-a3f3-eb0bf1a8c301",
  "OrderItems": []
}
19:26:29.189 > Delete order
DELETE http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301
19:26:29.343 > 

19:26:29.343 > Delete nonexistant order
DELETE http://localhost:5000/api/orders/6376f62e-7df4-42b7-a3f3-eb0bf1a8c301
19:26:29.842 > Error retrieving response. Code: 404. Content: "Order not found"
19:26:29.850 > 

19:26:29.850 > Request all orders
GET http://localhost:5000/api/orders
19:26:29.950 > 

[
  {
    "Id": "379676e5-393d-4f1f-bc29-abfca5832ec0",
    "OrderItems": []
  },
  {
    "Id": "0c96ed4b-de49-4fc5-9bab-0bbdf49ee31b",
    "OrderItems": []
  },
  {
    "Id": "417f6337-febd-4854-9adf-713d9834cc1d",
    "OrderItems": []
  },
  {
    "Id": "6442992c-5af3-4df5-8cf4-208cfa6597de",
    "OrderItems": []
  }
]

</pre>
