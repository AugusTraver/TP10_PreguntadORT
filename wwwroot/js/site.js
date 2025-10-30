function verificar() {
    const radios = document.getElementsByName("idRespuesta");
    const btnEnviar = document.getElementById("btnEnviar");
    const btnSiguiente = document.getElementById("btnSiguiente");

    let respuestaSeleccionada = false;

    for (let i = 0; i < radios.length; i++) {
        const r = radios[i];
        const label = document.getElementById("label_" + r.value);
        const correcta = document.getElementById("opcion_" + r.value).getAttribute("data-correcta") === "true";

        if (r.checked) {
            respuestaSeleccionada = true;
        } else {
            // Solo deshabilitás los no seleccionados
            r.disabled = true;
        }

        // Colores de corrección
        if (correcta) {
            label.style.color = "green";
        } else {
            label.style.color = "red";
        }
    }

    if (!respuestaSeleccionada) {
        alert("Por favor seleccioná una respuesta antes de enviar.");
        return;
    }

    // Ocultar botón enviar y mostrar siguiente
    btnEnviar.style.display = "none";
    btnSiguiente.style.display = "inline-block";
}
