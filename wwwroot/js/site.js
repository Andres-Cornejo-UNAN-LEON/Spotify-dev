// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var btn_stop = document.querySelector("#spotify-stop");
function reproductor(cancion){
    if(this.reproducir == null){
        this.reproducir = new Audio(cancion);
        reproducir.play();
    }
}
btn_stop.addEventListener('click', ()=>{
    reproducir.pause();
    this.reproducir = null;
});
