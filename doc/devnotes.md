# dev notes

## Infrastructure Tech
- C#, .NET 7, Blazor WASM, Entity Framework
- SQL Server 2022
- Docker (TBD)

---

## Design Patterns in use
- __[Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html)__: Used via Entity Framework. Track changes of multiple database operations and group them in a single database transaction.
- __[DDD Aggregate](https://martinfowler.com/bliki/DDD_Aggregate.html)__: Do not allow child entities to be updated directly; only via updating the parent (aggregate) entity. I am not using a fully idealized aggregate design in order to maintain code readability 

---

## Other Design Decisions
- Class based enums
- Blazor variable naming conventions
  - private variable starts lowercase
  - public parameter starts uppercase
  - no underscores or other conventions you might find in a regular C# class
- Avoid anemic domain model by putting entity behaviors inside entity class methods whenever possible

---

## Additional Infrastructure Possibilities

### Observer Pattern
- For using an event bus between services

### RabbitMQ
- Geocoder
- Image Resizer

### Item search
- Elasticsearch

### Find nearby items
- ???