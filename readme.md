## 1. Major changes
#### 1.1 SetCulture()
**60431d5:** The application now properly switches between languages, and passes the appropriate test.
```diff
        modified:   P2FixAnAppDotNetCode/Models/Services/LanguageService.cs
        
        public string SetCulture(string language)
        {
-           string culture = "";

-           // TODO complete the code 
            // Default language is "en", french is "fr" and spanish is "es".
+           string culture =
+               language == "French" ? "fr" :
+               language == "Spanish" ? "es" :
+               "en";

            return culture;
        }
```

#### 1.2 AddItem()
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Cart.cs
```

**Question:** What the shell is a "cart line"?
**Answer:** The Cart Line class represents a line in the shopping cart. It represents something that a visitor has added to their cart, along with the quantity of the item that was added to the cart. It also represents the position of the line relative to other lines in the cart (for controlling the order the lines appear when the lines are displayed).

(From https://doc.sitecore.com/developers/90/sitecore-experience-commerce/en/cart-domain-model.html -- based on the custom CartLine implementation in this solution, this seems accurate enough for an at least preliminary understanding).

## 2. Minor changes
#### 2.1 FIX/TYPO
**f99ae77**: The order checkout page now correctly displays "Address", rather than "Adress".
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Views\Order\Index.cshtml

-11 <h3>@Localizer["Adress"]</h3>
+11 <h3>@Localizer["Address"]</h3>
``` 

**Note:** After this change, the relevant header was no longer being changed upon setting the language to French. This was fixed in #51fc70b, see below.

**51fc70b**: Update language resources to reflect earlier typo correction (see #f99ae77)
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Resources\Views\Order\Index.en.resx

-120  <data name="Adress" xml:space="preserve">
-121    <value>Adress</value>
-122  </data>
+120  <data name="Address" xml:space="preserve">
+121    <value>Address</value>
+122  </data>
``` 

```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Resources\Views\Order\Index.fr.resx

- 120  <data name="Adress" xml:space="preserve">
- 121    <value>Adresse</value>
- 122  </data>
+ 120  <data name="Address" xml:space="preserve">
+ 121    <value>Adresse</value>
+ 122  </data>
```

**Note:** Unfamiliarity with MVC application architecture led to some initial confusion, but this was fairly easily solved by poking around until I got the gist of the language selection control flow.

## 3. Trivial changes
#### 3.1 FIX/TYPO: Cart.cs
**f5339c4:**
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Cart.cs

- 12      /// Read-only property for dispaly only
+ 12      /// Read-only property for display only
```

#### 3.2 FIX/TYPO: ProductServices.cs
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Services\ProductService.cs
- 30    /// Get a product form the inventory by its id
+ 30    /// Get a product from the inventory by its id  
```

#### 3.3 FIX/TYPO: ProductServices.cs
```diff
        modified:   DotNetEnglishP2\P2FixAnAppDotNetCode\Models\Services\ProductService.cs
- 20    /// Get all product from the inventory
+ 20    /// Get all products from the inventory
```