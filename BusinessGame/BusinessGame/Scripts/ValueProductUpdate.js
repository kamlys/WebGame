//setInterval(function () {
//    $.ajax({
//        url: '/Home/UpdateUserProduct',
//        type: 'Post',
//        dataType: 'html',
//        error: function (data) {
//            alert('cos nie tak');
//        },
//        success: function () {
//            alert('Dodało');
//        },
//        async: true,
//        processData: false
//    });
//}, 10000);
setInterval(function () {
    $.ajax({
        url: '/Home/GetProduct',
        type: 'Post',
        dataType: 'Json',
        contentType: 'application/json; charset=utf-8',
        error: function (data) {
            alert('....');
        },
        success: function (dataProduct) {
            for (var i = 0; i <= Object.keys(dataProduct).length; i++) {
                var productName = (dataProduct[i].ProductName).toString();
                var productValue = (dataProduct[i].Value).toString();
                $("#product_" + dataProduct[i].Product_ID).html(productName + " - " + productValue);
            }
        },
        async: true,
        processData: false
    });
}, 10000);
