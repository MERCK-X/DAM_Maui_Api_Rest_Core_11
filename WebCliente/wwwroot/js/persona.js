window.onload = function () {
    listar();
}

function listar() {
    pintar({
        url: "Persona/listarPersonas",
        cabeceras: ["Nombre completo", "Fecha nacimiento", "Correo"],
        //Propiedades de PersonaCLS
        propiedades: ["nombrecompleto", "fechanacimientocadena", "correo"],
        propiedadID: "idpersona",
        popup: true,
        titlePopup: "Persona",

        editar: true,
        eliminar: true
    }, {
        url: "Persona/FiltrarPersonas",
        formulario: [
            [
                {
                    class: "col-md-6",
                    label: "Ingrese el nombre completo",
                    type: "text",
                    name: "nombrecompleto"
                }
            ]
        ]
    }, {
        type: "popup",
        urlrecuperar: "Persona/RecuperarPersona",
        parametrorecuperar: "id",
        formulario: [
            [
                {
                    class: "col-md-6 d-none",
                    label: "Id persona",
                    type: "text",
                    name: "iidpersona",

                }, {

                
                    class: "col-md-6",
                    label: "Nombre",
                    type: "text",
                    name: "nombre",

                }, {

                
                    class: "col-md-6",
                    label: "Apellido paterno",
                    type: "text",
                    name: "appaterno",

                }, {

                
                    class: "col-md-6",
                    label: "Fcha Nacimiento",
                    type: "date",
                    name: "fechanacimiento",

                }, {


                    class: "col-md-6",
                    label: "Apellido materno",
                    type: "text",
                    name: "apmaterno",

                }, {


                    class: "col-md-6",
                    label: "Correo",
                    type: "text",
                    name: "correo",

                }, {


                    class: "col-md-6",
                    label: "Sexo",
                    type: "radio",
                    labels: ["Masculino", "Femenino"],
                    values: ["1", "2"],
                    ids: ["rbMasculino", "rbFemenino"],
                    checked: "rbMasculino",
                    name: "iisexo"

                },


            ]
        ]
    })
}