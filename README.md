```bash
cd src/TodoApi
dotnet run
```

https://localhost:7024/swagger/index.html
https://localhost:7024/api/Users

-----
```bash
docker build -t todoapi:latest .
docker run --rm -p 5004:5004 -p 7024:7024 --name todoapi todoapi:latest
```