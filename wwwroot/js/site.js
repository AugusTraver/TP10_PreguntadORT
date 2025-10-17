function verificar() {
    const radios = document.getElementsByName("idRespuesta");
    const btnEnviar = document.getElementById("btnEnviar");
    const btnSiguiente = document.getElementById("btnSiguiente");

    for (let i = 0; i < radios.length; i++) {
        let r = radios[i];
        let label = document.getElementById("label_" + r.value);
        let correcta = document.getElementById("opcion_" + r.value).getAttribute("data-correcta") === "true";

        r.disabled = true;

        if (correcta) {
            label.style.color = "green";
        } else {
            label.style.color = "red";
        }
    }

    // Ocultar botón enviar y mostrar siguiente
    btnEnviar.style.display = "none";
    btnSiguiente.style.display = "inline-block";
}
