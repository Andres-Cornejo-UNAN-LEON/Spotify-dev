namespace Spotify.Models;
public class Comentario{
    public int id{ get; set;}
    public string? texto{ get; set;}
    public string? fecha{get; set;}
    public int ReggaetonId{ get; set;}
    public Reggaeton? Reggaeton {get; set;}
}