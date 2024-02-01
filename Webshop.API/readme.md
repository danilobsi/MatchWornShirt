# MatchWornShirt

# Coding assessment: CheckoutAPI
This is the MatchWornShirt's webshop CheckoutAPI. 

This API is responsible for the folowing actions:
1. Get a list of all products;
2. Get 1 specific product;
3. Place a product in a shopping cart;
4. Get the shopping cart summary and conditionally apply any discounts to the order total depending on the items in the cart.

Our product assortment includes the following:
1. Kylian Mbappé's T-shirt - $100.99
2. Olivier Giroud's T-shirt - $200.49
3. Bart van Hintum's T-shirt - $110.99
4. Thom van Bergen's T-shirt - $160.99

MatchWornShirt offers 3 discount rules:
- If a customer gets more than 2 Kylian Mbappé's T-shirts, they get 1 free for each 2 in the cart;
- If a customer gets more than 2 Bart van Hintum's T-shirts, they get 20% off on all Bart van Hintum's T-shirts in the cart;
- If a customer gets an Olivier Giroud's T-shirt and a Thom van Bergen's T-shirt, they get $5 off the order total.

IMPORTANT! More than 1 rule can apply to the cart.

## Assessment details
The solution includes the following:
- In-memory data persistence.  (like **EF Core in-memory provider** or **Dapper**);
- Async coding;
- Separating Controller, Service and Repository layers;
- Unit tests;
- SwaggerUI documentation.

## Test cases

```
cart 1: [2x "Kylian Mbappé's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $362.97
cart 2: [5x "Kylian Mbappé's T-shirt", 1x "Thom van Bergen's T-shirt", 1x "Bart van Hintum's T-shirt"] -> $574.95
cart 3: [2x "Olivier Giroud's T-shirt", 8x "Bart van Hintum's T-shirt"] -> $1111.32
cart 4: [1x "Kylian Mbappé's T-shirt", 1x "Bart van Hintum's T-shirt", 1x "Olivier Giroud's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $568.46
cart 5: [3x "Kylian Mbappé's T-shirt", 2x "Olivier Giroud's T-shirt", 1x "Thom van Bergen's T-shirt"] -> $758.95
```