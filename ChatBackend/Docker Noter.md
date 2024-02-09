
# Husk

Sikr at der peges på det rigtige container image(SDK)  
Sikr at der peges på den rigtige runtime(aspnet)  
Sikr at der peges på den rigtige DLL fil  

## Uddybning

Hvad er det rigtige container image?  
 - Det er typisk det nyeste, hvis du udvikler i en opdateret Visual Studio

 Hvad er den rigtige runtime  
  - Ligeledes, typisk den nyeste  

Der kan findes hints her(Microsoft Repo):  
https://github.com/dotnet/dotnet-docker/blob/main/samples/aspnetapp/Dockerfile  

Hvad er den rigtige DLL fil?  
 - Typisk den, der hedder det samme, som projektets navn  

# Byg docker image

Build kommando:

```docker
docker build -t dragndrop/chatbackend . 
```

I kommandoen, gør ```-t``` at du kan indstille et tag, således at imaget vil kunne fremsøges. Alternativet, hvis du udelader det, får imaget et grimt og ugennemskueligt navn(en SHA Sum).

dragndrop: UserID på Docker Hub
Projektnavn: chatbackend

# Kør docker image

Kør imaget:

```docker
docker run -p 8080:8080 dragndrop/chatbackend
```

Husk ift. 8080:8080, at der altid menes Hostens port først, og bagefter den interne port i containeren  

Før kolon: Host port der lyttes på  
Efter kolon: Intern container port  

# Inspiration

Inspiration:
https://www.youtube.com/watch?v=f0lMGPB10bM
Han har en rigtig cool måde at simplificere virtualisering og containerization på. Worth a watch.
