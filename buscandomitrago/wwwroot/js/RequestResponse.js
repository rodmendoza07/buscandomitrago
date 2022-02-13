function RequestResponse() {
    this.Request = (url, data, option) => {
        
        $.ajax({
            type: 'Post',
            url: url,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'JSON',
            async: true,
            cache: false,
            success: function (response) {
                $("#bebidas").empty();
                let r = response.bebida;
                let ObjFav = new Favoritos();
                r.map((i) => {
                    switch (option) {
                        case 1:
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
                                '<p><i class="fas fa-cocktail primary-color"></i> Se sirve en: ' + i.strGlass + '</p>' +
                                '</div>' +
                                '<div class="content-middle">' +
                                '<p class="mb-0 d-inline-block">' +
                                '<i class="far fa-lemon pr-1"></i>' +
                                '<strong>Ingredientes:</strong> ' + i.strIngredient1 + ', ' + i.strIngredient2 + ', ' + i.strIngredient3 +
                                '</p>' +
                                '</div>' +
                                '<div class="footer-content">' +
                                '<div class="author d-flex">' +
                                '<p class="mb-0 align-self-center">' +
                                '<i class="fas fa-tag primary-color"></i> Categoria:' +
                                i.strTags +
                                '</p>' +
                                '</div>' +
                                '</div>' +
                                '</div >' +
                                '</div >'
                            )
                            break;
                        case 2:
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
                            break;
                    }
                    
                })
                ObjFav.AddFavoritos();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}