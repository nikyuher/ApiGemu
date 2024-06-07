# ApiGemu 

## Configuración y Ejecución con Docker para entorno local
1. **Construir y ejecutar los contenedores**:

   ```sh
docker-compose up --build --force-recreate -d

2. **Cambia estos valores  en la capa Api en el archivo "appsettings.json"**

"AllowedHosts": "*",
  "ConnectionStrings": {
    "GemuDBLocal": "Server=localhost,8002;Database=Gemu;Uid=sa;Pwd=<YourStrong@Passw0rd>;TrustServerCertificate=True",
    "GemuDBDocker": "Server=db;Database=Gemu;Uid=sa;Pwd=<YourStrong@Passw0rd>;TrustServerCertificate=True"
  },
  "Environment": "Development"
  ,
  "JWT": {
    "ValidAudience": "https://localhost:5173", 
    "ValidIssuer": "https://localhost:8001", 
    "SecretKey": "MyPass@word2MyPass@word2MyPass@word2"
    },