TODOAPP.BACKEND SAMPLE PROJECT
1. Clean Architecture:
- Application Layer: Contains business logic, use cases, handlers for API request/Mediator request handler.
- Domain Layer: Contains entity, value object, domain model.
- Host Layer: Also named Presentation Layer, contains API endpoints, protocols for client to request.
- Infrastructure Layer: Contains Persistence(for using ORM, raw connection to DBMS.

2. Achieve API Versioning:

| Platform          | Package                           | Version   | TFM                               |
|-------------------|-----------------------------------|-----------|-----------------------------------|
| All               | Asp.Versioning.Abstractions       | 6.0.0+    | net6.0+, netstandard1.0, netstandard2.0 |
| ASP.NET Web API   | Asp.Versioning.WebApi             | 6.0.0+    | net45, net472                     |
| ASP.NET Web API   | Asp.Versioning.WebApi.ApiExplorer | 6.0.0+    | net45, net472                     |
| ASP.NET Web API   | Asp.Versioning.WebApi.OData       | 6.0.0+    | net45, net472                     |
| ASP.NET Web API   | Asp.Versioning.WebApi.OData.ApiExplorer | 6.0.0+ | net45, net472                     |
| ASP.NET Core      | Asp.Versioning.Http1               | 6.0.0+    | net6.0+                           |
| ASP.NET Core      | Asp.Versioning.Mvc2                | 6.0.0+    | net6.0+                           |
| ASP.NET Core      | Asp.Versioning.Mvc.ApiExplorer3     | 6.0.0+    | net6.0+                           |
| ASP.NET Core      | Asp.Versioning.OData               | 6.0.0+    | net6.0+                           |
| ASP.NET Core      | Asp.Versioning.OData.ApiExplorer   | 6.0.0+    | net6.0+                           |
| All               | Asp.Versioning.Http.Client         | 6.0.0+    | net6.0+, netstandard1.1, netstandard2.0 |

[1] Base library that supports Minimal APIs
[2] MVC Core with controller support
[3] Supports exploration of Minimal APIs and controllers