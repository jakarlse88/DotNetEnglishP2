## 1. Major changes
#### 1.1 SetCulture
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