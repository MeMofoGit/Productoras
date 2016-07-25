function cerrar_cargando() {
    //$(".opaca-gris").on("click", function () {
    $(".cargando_popup").removeClass("animated zoomIn");
    $(".cargando_popup").addClass("animated zoomOut");
    $(".cargando_popup").fadeOut();
    //$(".opaca-gris").fadeOut(300);
    //});
}
function load_cargando() {
    $(".cargando_popup").removeClass("animated zoomOut");
    $(".cargando_popup").addClass("animated zoomIn");
    $(".cargando_popup").fadeIn(300);
    $(".opaca-gris").fadeIn(300);

    $('html,body').animate({
        scrollTop: 0
    }, 1000, "easeInOutExpo");
    //Se podria hacer que se permitiese cerrar al hacer click en la capa opaca-gris (fuera)
    //cerrar_cargando();
}
$(window).on("beforeunload ", function () {
    wait();
});
function wait() {
    load_cargando();
}
function waitOut() {
    cerrar_cargando();
}
function loadAjax() {
    $(document).ajaxStart(function () {
        wait();
    });
}