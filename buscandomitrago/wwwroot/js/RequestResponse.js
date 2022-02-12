function RequestResponse() {
    this.Request = (url, data) => {
        $.ajax({
            type: 'Post',
            url: url,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(data),
            dataType: 'html',
            async: true,
            cache: false,
            success: function (response) {
                $("#bebidas").empty();
                $("#bebidas").html(response);

            },
            error: function (err) {
                console.log(err);
            }
        });
    }
}