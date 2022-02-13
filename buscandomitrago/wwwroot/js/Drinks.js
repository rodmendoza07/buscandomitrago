$(document).ready(() => {

    let ObjRequest = new RequestResponse();

    const BuscarPorNombre = async () => {

        let data = {
            "strDrink": $("#q").val()
        }

        let url = "/Home/SearchByName";

        ObjRequest.Request(url, data, 1);
    }

    const BuscarPorIngrediente = async () => {
        let data = {
            "strIngredient1": $("#q").val()
        }

        let url = "/Home/SearchByIngredient";
        ObjRequest.Request(url, data, 2);
    }



    $("#formBuscar").submit((e) => {
        e.preventDefault();
        let tipoBusqueda = $("#search-option").val()
        switch (tipoBusqueda) {
            case "1":
                BuscarPorNombre();
                break;
            case "2":
                BuscarPorIngrediente();
                break;
            default:
                break;
        }
    });
});