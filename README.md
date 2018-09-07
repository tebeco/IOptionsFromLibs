This idea of this repo is to show how to develop a library that should :
* Allow to use it own IOptions
* Read it from wellknown `SectionName`
* Use the already computed `IConfiguration` that a `Consumer` does on it own (here it use both `appsettings.json` and `appsettings.Development.json`)
* Allow to override it in the `Consumer` startup
* The lib should have the final word with a `PostConfigure` for field validation.
  For example is a value must be positve it could default it again if the supplied value is negative

The result in this scenario is :

```
{
    "Value": {
        "V": "V default value",
        "W": "Value w from appsettings.json",
        "X": "Value x from appsettings.Development.json",
        "Y": "Y value from consumer startup",
        "Z": 0
    }
}
```
