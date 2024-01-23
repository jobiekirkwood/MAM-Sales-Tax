var basketCount = 0;
function addToBasket(e)
{
    let productId = $(e).siblings('[data-productid]').data('productid');
    let productName = $(e).siblings('[data-productname]').data('productname');
    let productPrice = $(e).siblings('[data-productprice]').data('productprice');
    //alert(productId);
    //alert(productName);
    //alert(productPrice);

    $('#basket').append('<div class="card my-2">' +
        '<div class="card-title">' + productName + ' - £' + productPrice + ' </div>' +
        '<input type="hidden" name="basketItems[' + basketCount + '].ProductId"' + ' value="' + productId + '"/>' +
        '<input class="text-center border-0" name="basketItems[' + basketCount + '].Quantity" value="' + 1 + '" />' +
        '</div>');
        basketCount++;
}