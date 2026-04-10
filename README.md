# FlightBookingSystem

# 📦 Database Migration Guide (.NET + PostgreSQL)

## 1. Tạo Migration

```bash
dotnet ef migrations add <MigrationName> --project src/FlightBookingSystem.Infrastructure --startup-project src/FlightBookingSystem.API --output-dir Persistence/Migrations

dotnet ef database update --project src/FlightBookingSystem.Infrastructure --startup-project src/FlightBookingSystem.API

dotnet ef migrations remove --project src/FlightBookingSystem.Infrastructure --startup-project src/FlightBookingSystem.API

dotnet ef database drop --project src/FlightBookingSystem.Infrastructure --startup-project src/FlightBookingSystem.API