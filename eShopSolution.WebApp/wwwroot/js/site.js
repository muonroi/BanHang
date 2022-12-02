var SiteController = function () {
    this.initialize = function () {
        regsiterEvents();
        loadCart();
        regsiterEvents2();
    }
    function loadCart() {
        const culture = $('#hidCulture').val();
        $.ajax({
            type: "GET",
            url: "/" + culture + '/Cart/GetListItems',
            success: function (res) {
                $('#lblCartCount').text(res.length);
            }
        });
    }

    function regsiterEvents() {
        // Write your JavaScript code.
        $('body').on('click', '.btn-add-cart', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lblCartCount').text(res.length);
                },
                error: function (err) {
                    console.log(err);
                }
            });
            alert("Thêm sản phẩm vào giỏ thành công");
            window.location.reload();
        });
    }
    function regsiterEvents2() {
        // Write your JavaScript code.
        $('body').on('click', '.add-to-cart-dt2', function (e) {
            e.preventDefault();
            const culture = $('#hidCulture').val();
            const id = $(this).data('id');
            $.ajax({
                type: "POST",
                url: "/" + culture + '/Cart/AddToCart',
                data: {
                    id: id,
                    languageId: culture
                },
                success: function (res) {
                    $('#lblCartCount').text(res.length);
                },
                error: function (err) {
                    console.log(err);
                }
            });
            alert("Thêm sản phẩm vào giỏ thành công");
            window.location.reload();
        });
    }
}


function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
}