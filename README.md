# POSTerminal
A point-of-sale scanning system class library. Accepts a list of products then calculates the total price for an order based on per-unit or volume prices as applicable.

Available products include:
| Product | Scannable ID | Single Price | Bulk Price  |
|---------|--------------|--------------|-------------|
| apple   | A            | $1.25        | 3 for $3.00 |
| banana  | B            | $4.25        |             |
| candy   | C            | $1.00        | 6 for $5.00 |
| date    | D            | $0.75        |             |


## Documentation

> ### POSModel

* Product
* ScannedProduct
* CalculationReques


> ### PointOfSaleTerminal Class
* PointOfSaleTerminal()
    ```C#
    const _posTerminal = new PointOfSaleTerminal();
    ```
**Fields**
* Product products
* RequestHandler requests

**methods**
* setPricing(Product)

    sets product model
    ```C#
    terminal.SetPricing(product);
    ```
* scanProduct(string)

    scans a single product or bulk products
    ```C#
    terminal.Scan('A');
    terminal.Scan('ABCDABA');
    ```
    
* SetCalculationRequest(RequestHandler)

    handels calcultion request 
    ```C#
    SetCalculationRequest(request)
    ```

* calculateTotal()
    
    returns the total cost of all scanned products
    ```C#
    terminal.CalculateTotal();
    ```

> ### Test
* TestCases 
```C#
  _posTerminal.Scan("ABCDABA");
  Assert.AreEqual(13.25, _posTerminal.CalculateTotal());
```
* ExceptionTest

<br>
