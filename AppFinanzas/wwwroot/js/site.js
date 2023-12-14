// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
@{
    ViewBag.Title = "Contador de Sumas con Límite";
}

<h2>@ViewBag.Title</h2>

<p>Suma actual: @Model.SumaActual</p>
<p>Contador final: @Model.ContadorFinal</p>

@if (!string.IsNullOrEmpty(ViewBag.MensajeLimite)) {
    <p>@ViewBag.MensajeLimite</p>
}
