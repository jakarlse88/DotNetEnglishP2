## 1. Major changes
#### 1.1 SetCulture()
_60431d5:_ The application now properly switches between languages. and passes the relevant unit test.

```
        modified:
        P2FixAnAppDotNetCode/Models/Services/LanguageService.cs
```
#### 1.2 GetAllProducts()
_17132b7:_ Changed the return type of GetAllProducts() from Product[] to List<Product> and propagated the change throughout the application. The relevant test now passes.   

```
        modified: 
        P2FixAnAppDotNetCode.Tests/ProductServiceTests.cs
        P2FixAnAppDotNetCode/Controllers/ProductController.cs
        P2FixAnAppDotNetCode/Models/Repositories/IProductRepository.cs
        P2FixAnAppDotNetCode/Models/Repositories/ProductRepository.cs
        P2FixAnAppDotNetCode/Models/Services/IProductService.cs
        P2FixAnAppDotNetCode/Models/Services/ProductService.cs
```

#### 1.3 GetProductById()
_3627abd:_ Implemented GetProductById().

```
        modified:    P2FixAnAppDotNetCode\Models\Services\ProductService.cs
```

#### 1.4 AddItem()
_06ed3ba:_ Added necessary class members and properties; changed GetCartLineList() to correct erronuous behaviour; implemented FindProductInCartLines(), and AddItem().
```diff
        modified: P2FixAnAppDotNetCode/Models/Cart.cs
```

## 2. Minor changes
#### 2.1 FIX/TYPO
_f99ae77_: The order checkout page now correctly displays "Address", rather than "Adress".
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Views\Order\Index.cshtml
``` 

_Note:_ After this change, the relevant header was no longer being changed upon setting the language to French. This was fixed in #_51fc70b_, see below.

_51fc70b_: Update language resources to reflect earlier typo correction (see #f99ae77)
```diff
        modified:
        DotNetEnglishP2\P2FixAnAppDotNetCode\Resources\Views\Order\Index.en.resx
        DotNetEnglishP2\P2FixAnAppDotNetCode\Resources\Views\Order\Index.fr.resx
```

_Note:_ Unfamiliarity with MVC application architecture led to some initial confusion, but this was fairly easily solved by poking around until I got the gist of the language selection control flow.

## 3. Trivial changes
#### 3.1 FIX/TYPO: Cart.cs
_f5339c4:_ Correct a comment typo. 
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Cart.cs
```

#### 3.2 FIX/TYPO: ProductServices.cs
_982354c:_ Correct a comment typo.
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Services\ProductService.cs
```

#### 3.3 FIX/TYPO: ProductServices.cs
_982354c:_ Correct a comment typo.
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Services\ProductService.cs
```