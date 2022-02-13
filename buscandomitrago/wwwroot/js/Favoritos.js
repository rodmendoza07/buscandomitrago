function Favoritos() {
    this.VerFavoritos = () => {
        $("#bebidas").empty();
        if (!window.localStorage.getItem("FavsBebidas")) {
            $("#bebidas").append(
                '<div class="col-md-12 mb-30">' +
                '<span class="alert alert-warning">Busqueda sin resultados</span>' +
                '</div>'
            )
            return
        } else {
            let favs = JSON.parse(window.localStorage.getItem("FavsBebidas"))

            favs.map((i) => {
                $("#bebidas").append(
                    '<div class="col-md-4 mb-30">' +
                    '<div class= "feature-item">' +
                    '<div class="img">' +
                    '<img src="' + i.strDrinkThumb + '" class="img-fluid">' +
                    '<div class="hover">' +
                    '<div class="button-group">' +
                    '<a href="#" class="favorite-feature favoritos"><i class="far fa-heart fa-3x" data-dId="' + i.idDrink + '" data-dName="' + i.strDrink + '" data-thumbs="' + i.strDrinkThumb + '"></i></a>' +
                    '</div>' +
                    '</div>' +
                    '</div >' +
                    '<div class="content-title">' +
                    '<h4><a href="#">' + i.strDrink + '</a></h4>' +
                    '</div>' +
                    '</div >' +
                    '</div >'
                )
            })
        }
       
    }

    this.AddFavoritos = () => {
        let FavObj = [];
        if (window.localStorage.getItem("FavsBebidas")) {
            FavObj = JSON.parse(window.localStorage.getItem("FavsBebidas"))
        }
        $(".favoritos").click((e) => {
            let dataFavs = {
                idDrink: $(e.target).attr("data-dId"),
                strDrink: $(e.target).attr("data-dName"),
                strDrinkThumb: $(e.target).attr("data-Thumbs")
            }

            FavObj = [...FavObj, dataFavs]

            window.localStorage.setItem("FavsBebidas", JSON.stringify(FavObj));
        });
    }
}