FROM mcr.microsoft.com/dotnet/sdk:5.0 as build
WORKDIR /source

COPY *.sln .
COPY Directory.Build.props . 

# Base projects
COPY BLL.Base/*.csproj ./BLL.Base/
COPY Contracts.BLL.Base/*.csproj ./Contracts.BLL.Base/
COPY Contracts.DAL.Base/*.csproj ./Contracts.DAL.Base/
COPY Contracts.Domain.Base/*.csproj ./Contracts.Domain.Base/
COPY Domain.Base/*.csproj ./Domain.Base/
COPY DAL.Base/*.csproj ./DAL.Base/
COPY DAL.Base.EF/*.csproj ./DAL.Base.EF/
COPY Extensions.Base/*.csproj ./Extensions.Base/

# App projects
COPY DTO.App/*.csproj ./DTO.App/
COPY BLL.App/*.csproj ./BLL.App/
COPY BLL.App.DTO/*.csproj ./BLL.App.DTO/
COPY Contracts.BLL.App/*.csproj ./Contracts.BLL.App/
COPY Contracts.DAL.App/*.csproj ./Contracts.DAL.App/
COPY DAL.App.DTO/*.csproj ./DAL.App.DTO/
COPY DAL.App.EF/*.csproj ./DAL.App.EF/
COPY Domain.App/*.csproj ./Domain.App/
COPY DTO.App.V1/*.csproj ./DTO.App.V1/
COPY Resources/*.csproj ./Resources/
COPY WebApp/*.csproj ./WebApp/

# RUN dotnet restore

# Base projects
COPY BLL.Base/. ./BLL.Base/
COPY Contracts.BLL.Base/. ./Contracts.BLL.Base/
COPY Contracts.DAL.Base/. ./Contracts.DAL.Base/
COPY Contracts.Domain.Base/. ./Contracts.Domain.Base/
COPY Domain.Base/. ./Domain.Base/
COPY DAL.Base/. ./DAL.Base/
COPY DAL.Base.EF/. ./DAL.Base.EF/
COPY Extensions.Base/. ./Extensions.Base/

# App projects
COPY DTO.App/. ./DTO.App/
COPY BLL.App/. ./BLL.App/
COPY BLL.App.DTO/. ./BLL.App.DTO/
COPY Contracts.BLL.App/. ./Contracts.BLL.App/
COPY Contracts.DAL.App/. ./Contracts.DAL.App/
COPY DAL.App.DTO/. ./DAL.App.DTO/
COPY DAL.App.EF/. ./DAL.App.EF/
COPY Domain.App/. ./Domain.App/
COPY DTO.App.V1/. ./DTO.App.V1/
COPY Resources/. ./Resources/
COPY WebApp/. ./WebApp/

WORKDIR /source/WebApp

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as runtime

RUN apt-get -y update && apt-get -y upgrade

WORKDIR /app

COPY --from=build /source/WebApp/out ./

ENTRYPOINT ["dotnet", "WebApp.dll"]
