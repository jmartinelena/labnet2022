function validar() {
    let nombre = document.getElementById("fname").value;
    let apellido = document.getElementById("lname").value;

    if (nombre == "" && apellido == "") {
        alert("Nombre y apellido deben ser llenados.");
    }
    else {
        alert("Nombre y apellidos llenados.");
    }
}