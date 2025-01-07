# Utilise l'image officielle .NET 9 SDK
FROM mcr.microsoft.com/devcontainers/dotnet:dev-9.0

# Configure le répertoire de travail
WORKDIR /workspace

# Installe le client Docker pour utiliser Docker depuis le conteneur
RUN apt-get update && apt-get install -y docker.io

# Installe le débogueur .NET (vsdbg)
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

# Installer les dépendances nécessaires pour Node.js
RUN apt-get update && apt-get install -y curl

# Installer Node.js et Spectral
RUN curl -fsSL https://deb.nodesource.com/setup_18.x | bash - \
  && apt-get install -y nodejs \
  && npm install -g @stoplight/spectral-cli

# Nettoyage
RUN apt-get clean && rm -rf /var/lib/apt/lists/*

# Expose les ports pour .NET Minimal API (HTTP et HTTPS)
EXPOSE 5100 7085

# Définit le point d'entrée par défaut
CMD ["sleep", "infinity"]
