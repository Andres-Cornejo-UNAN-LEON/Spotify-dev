namespace Spotify.Models;
public class Reggaeton{
    public int id{ get; set;}
    public string? cancion{ get; set;}
    public string? artista{ get; set;}
    public string? lanzamiento{ get; set;}
    public string? imgPrincipal{ get; set;}
    public string? Spotify{ get; set;}
    public string? color{ get; set;}
    public List<Comentario> Comments {get; set;}
    public Reggaeton(){
        Comments = new List<Comentario>();
    }
}