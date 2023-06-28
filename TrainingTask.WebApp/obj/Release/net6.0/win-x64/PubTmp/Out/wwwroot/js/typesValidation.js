

$(function () {

    function validateName() {
        let name = $('form input[name="Name"]').val();
        let id = $('form input[name="Id"]').val();
        let isValid = true;

        $.ajax({
            url: `/types/isTypeNameValid/${id}?name=${name}`,
            type: "get",
            async: false,
            success: function (isNameValid) {
                if (!isNameValid) {
                    $('form input[name="Name"] ~ span:last-of-type').removeClass("d-none").text("Company Name Has Been Taken");
                    isValid = false;
                }

            }
        })

        if (isValid)
            $('form input[name="Name"] ~ span:last-of-type').addClass("d-none");

        return isValid;
    }

    $('form input[name="Name"]').focusout(function () {
        validateName();
    })

    $('form').submit(function () {
        return validateName();
    })

})

