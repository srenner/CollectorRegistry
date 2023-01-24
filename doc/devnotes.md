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
- Database access only from the main Server project

---

## Geocode Message Broker Workflow
- Main project sends address info to MassTransit
- Geocode project receives address info from MassTransit
  - Geocode project hits external API and downloads JSON result
- Geocode project sends results to MassTransit
- Main project receives geocode info from MassTransit and writes to database

## Additional Infrastructure Possibilities

### Image Processing
- Resize, watermark

### Item search
- Elasticsearch

### Find nearby items
- ???