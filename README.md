Moca.NET-WinAppDemo
===================

sample application that uses a moca.net

[Moca.NET Framework](https://github.com/mocanet/MocaCore)


* [Moca.NET Templates](https://visualstudiogallery.msdn.microsoft.com/7735e52f-74f2-4ac7-8172-11cde77e6290) ([v2010](https://visualstudiogallery.msdn.microsoft.com/f97a7486-560b-425a-aa05-528dd397f5ba))
* [Moca.NET Code Snippet](https://visualstudiogallery.msdn.microsoft.com/96efa364-a9d3-4352-85fc-c5d117abca7f) ([v2010](https://visualstudiogallery.msdn.microsoft.com/ef40c12b-d48e-45e5-9e18-12726b9ac1ee))





C# : Properties\WebConfigTransformAssemblyInfo.cs file Please cancel comment.
```
[assembly: log4net.Config.XmlConfigurator(ConfigFile=@"log4net.config", Watch=true)]
```

VB : My Project\WebConfigTransformAssemblyInfo.vb file Please cancel comment.
```
<Assembly: log4net.Config.XmlConfigurator(ConfigFile:="log4net.config", Watch:=True)>
```


C# : add Assembly property.
```
[assembly: Moca.Configuration.SectionProtection(Moca.Configuration.ProtectionProviderType.DPAPI, "Section Name")]
```

VB : add Assembly property.
```
<Assembly: Moca.Configuration.SectionProtection(Moca.Configuration.ProtectionProviderType.DPAPI, "Section Name")>
```
```
Moca.Configuration.SectionProtector.Protect()
```





```
<Moca.Web.Attr.QueryString()>
Public Interface IQueryStrings

    <Moca.Web.Attr.QueryStringName("c")>
    Property Count As String

End Interface
```











