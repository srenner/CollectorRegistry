# dev notes

## Infrastructure Tech
- C#, .NET 7, Blazor WASM, Entity Framework
- SQL Server 2022
- Docker

---

## Microservice Infrastructure
- Services should have minimal dependencies, and not depend on the main CollectorRegistry.Server project if possible
  - CollectorRegistry.DataBridge is used to send data back to CollectorRegistry.Server via gRPC calls
- All code deployed to Docker containers, targeting Linux
- Small payloads are sent via RabbitMQ messages
- __EXAMPLE__: CollectorRegistry.GeocodeService receives input from the message queue, receives data from an external api, and places the resulting data in an output message queue. This allows the microservice to work with any RabbitMQ project that needs geocoding services performed on an address. If the geocoding service goes down or otherwise fails to perform, the impact to the main project is minimal.

---

## Docker containers
- CollectorRegistry.RabbitMQ
  - Unmodified container based on rabbitmq:3-management-alpine
  - Sends small payloads between containers
- CollectorRegistry.Server
  - Main web project
- CollectorRegistry.GeocodeService
  - Gets latitude/longitude data for a given address
- CollectorRegistry.DataBridge
  - Makes gRPC calls to the main project, primarily to make database updates
- CollectorRegistry.ImageService
  - Input from RabbitMQ: { "photoID": 1, "filePath": "/path/to/file.jpg", "watermarkText": "CollectorRegistry.com", "watermarkLogo": "/path/to/logo.jpg" }
  - Output to RabbitMQ: { "photoID": 1, "isProcessed": True }
  - Multiple resize
    - 1500px max width OR height for desktop
    - 900px max width OR height for mobile
    - thumbnail images...250px?
  - Watermark text and/or logo


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

## Additional Infrastructure Possibilities

### Image Processing
- Resize, watermark

### Item search
- Elasticsearch

### Find nearby items
- ???