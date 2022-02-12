$(document).ready(() => {

    console.log("que esta pasando");
    let ObjRequest = new RequestResponse();

    const BuscarPorNombre = async () => {
        let data = {
            "strDrink": $("#q").val()
        }

        let url = "/Home/SearchByName";
        ObjRequest.Request(url, data);
    }

    const BuscarPorIngrediente = async () => {
        let data = {
            "strIngredient1": $("#q").val()
        }

        let url = "/Home/SearchByIngredient";
        ObjRequest.Request(url, data);
    }

    $("#formBuscar").submit((e) => {
        e.preventDefault();
        let tipoBusqueda = $("#search-option").val()
        switch (tipoBusqueda) {
            case "1":
                console.log("buscar por nombre");
                BuscarPorNombre();
                break;
            case "2":
                console.log("buscar por ingrediente");
                BuscarPorIngrediente();
                break;
            default:
                console.log("no hace nada");
                break;
        }
       
    });

});