# Product Search Specification

## Feature Description

Customers can search active products by product name or description.

The search feature is available from the navbar search box and displays
matching products on the Products page.

---

## User Story

As a customer, I want to search products by name or description so that I can
quickly find products I am interested in.

---

## API Contract

### Endpoint

```text
GET /api/products/search?query={searchQuery}
```

### Query Parameter

| Name    | Type   | Required | Rules                  |
| ------- | ------ | -------: | ---------------------- |
| `query` | string |       No | Maximum 100 characters |

---

## Search Rules

1. Search only active products.
2. Search product `Name`.
3. Search product `Description`.
4. Ignore leading and trailing spaces in the query.
5. Return matching products ordered by name.
6. If no query is provided, return all active products.
7. The search endpoint is public and does not require login.

---

## Successful Response

### Request

```text
GET /api/products/search?query=phone
```

### Response: `200 OK`

```json
[
  {
    "productId": 1,
    "name": "Samsung Galaxy S24",
    "description": "Android smartphone with a high-resolution display",
    "price": 799.99,
    "imageUrl": "https://example.com/product-image.jpg",
    "isActive": true,
    "categoryId": 101,
    "availableQuantity": 10
  }
]
```

---

## Validation Error Response

### Scenario

The query contains more than 100 characters.

### Response: `400 Bad Request`

```text
Search query cannot exceed 100 characters.
```

---

## Frontend Contract

### Search Input

The search input appears in the application navbar.

### Search Flow

```text
Customer enters search text
    ↓
Customer presses Enter
    ↓
React redirects to:
/products?search={searchQuery}
    ↓
Products page calls:
/api/products/search?query={searchQuery}
    ↓
Matching products are displayed
```

### Example

```text
Search input: laptop
URL: /products?search=laptop
API: GET /api/products/search?query=laptop
```

---

## Error Handling

- If Product Service is unavailable, show a toast notification.
- If the API returns an error, display the safe error message from the global API error handler.
- The page must not crash if no products are returned.

---

## Acceptance Criteria

- Customer can enter text in the navbar search field.
- Search redirects to the Products page.
- Products page displays matching active products.
- Search checks product name and description.
- Search supports empty query by returning all active products.
- Query longer than 100 characters returns `400 Bad Request`.
- Search errors are handled without crashing the frontend.
