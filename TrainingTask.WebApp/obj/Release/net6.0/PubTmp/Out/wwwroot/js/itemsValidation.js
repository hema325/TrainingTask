

$(function () {

    function validateName() {
        let name = $('form input[name="Name"]').val();
        let id = $('form input[name="Id"]').val();
        let isValid = true;

        if (id == undefined)
            return isValid;

        $.ajax({
            url: `/items/isItemNameValid/${id}?name=${name}`,
            type: "get",
            async: false,
            success: function (isNameValid) {
                if (!isNameValid) {
                    $('form input[name="Name"] ~ span:last-of-type').removeClass("d-none").text("Client Name Has Been Taken");
                    isValid = false;
                }

            }
        })

        if (isValid)
            $('form input[name="Name"] ~ span:last-of-type').addClass("d-none");

        return isValid;
    }

    function validateSellingPrice() {
        let sellingPrice = $('form input[name="SellingPrice"]');
        let buyingPrice = $('form input[name="BuyingPrice"]');
        let validationResult = $(buyingPrice).siblings("span:last-of-type");

        if (Number($(sellingPrice).val()) > Number($(buyingPrice).val()))
            $(validationResult).addClass("d-none");
    }

    function validateBuyingPrice() {
        let BuyingPrice = $('form input[name="BuyingPrice"]');
        let validationResult = $(BuyingPrice).siblings("span:last-of-type");
        let isValid = true;

        if (Number($(BuyingPrice).val()) > Number($('form input[name="SellingPrice"]').val())) {
            $(validationResult).removeClass("d-none").text("Buying Price Must Be Smaller Than Or Equal Selling Price");
            isValid = false;
        }

        if (isValid)
            $(validationResult).addClass("d-none");

        return isValid;
    }


    $('form input[name="Name"]').focusout(function () {
        validateName();
    })

    $('form input[name="SellingPrice"]').keyup(function () {
        validateSellingPrice();
    })

    $('form input[name="BuyingPrice"]').keyup(function () {
        validateBuyingPrice();
    })

    $("form").submit(function () {
        let isFormValid = validateName();
        isFormValid &= validateBuyingPrice();

        return Boolean(isFormValid);
    })
})

