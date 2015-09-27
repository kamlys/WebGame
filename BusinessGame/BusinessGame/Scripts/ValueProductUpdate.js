$(document).ready(function () {
    setInterval(showProducts, 10000);
    showProducts();
});

function showProducts() {
    $.ajax({
        url: '/Home/GetProduct',
        type: 'Post',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        success: function (dataProduct) {
            for (var i = 0; i <= Object.keys(dataProduct).length; i++) {
                var productName = dataProduct[i].ProductName;
                var productValue = (dataProduct[i].Value).toString();
                $("#product_" + dataProduct[i].Product_ID).html(productName + " - " + productValue);
            }
        },
        async: true,
        processData: false
    });
}