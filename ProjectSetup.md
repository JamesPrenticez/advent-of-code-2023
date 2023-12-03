# Open Visual Studio Code:
cd into your project folder 

create a .gitignore (this will hide the obj folder)

### For each project you want to add:
create a folder and cd into it

```bash
  dotnet new console
```

### Now make a solution
cd to root

```bash
  dotnet new sln
```

### Then add projects to the solution

```bash
  dotnet sln add ./Trebuchet/Trebuchet.csproj
```

### Run your project

```bash
  dotnet run
```

### Build your project 

```bash
  dotnet build
```

