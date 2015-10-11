$(document).ready(function () {
    setInterval(addProducts, 300000);
    addProducts();
});

function addProducts() {
    $.ajax({
        url: '/Home/UpdateUserProduct',
        type: 'Post',
        
        async: true,
        processData: false
    });
}